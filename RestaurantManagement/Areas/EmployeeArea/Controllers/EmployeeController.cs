using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Areas.EmployeeArea.Models;
using RestaurantManagement.Data.Entity.EmployeeEntity;
using RestaurantManagement.Data.Entity.MasterDataEntity;
using RestaurantManagement.GenericRepo.GenericRepositoryService.Interface;
using RestaurantManagement.Helpers;
using RestaurantManagement.Services.EmpService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.EmployeeArea.Controllers
{
    [Area("EmployeeArea")]
    public class EmployeeController : Controller
    {
        private IGenericRepository<Employee> _employeeRepo;
        private IGenericRepository<Gender> _genderRepo;
        private IGenericRepository<Designation> _designationRepo;


        public EmployeeController(IGenericRepository<Employee> employeeRepo, IGenericRepository<Gender> genderRepo, IGenericRepository<Designation> designationRepo)
        {
            _employeeRepo = employeeRepo;
            _designationRepo = designationRepo;
            _genderRepo = genderRepo;

        }


        //GET:/EmployeeArea/Employee/Index
        [HttpGet]
        public IActionResult Index()
        {
            EmployeeViewModel model = new EmployeeViewModel()
            {
                //employees = await _employeeService.GetEmployeeList()
                genders=_genderRepo.GetAll(),
                designations=_designationRepo.GetAll(),
                employees = _employeeRepo.GetAllIncluding(x=>x.Gender,x=>x.Department,x=>x.Designation)
            };
            return View(model);
        }

        //POST:/EmployeeArea/Employee/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm]EmployeeViewModel model)
        {

            string empPicUrl = "DefaultImage/NoImage.jpg";
            string empCvUrl = "DefaultImage/NoFile.png";

            string picFileName;
            string cvFileName;
            string PicMessage = FileSave.SaveImage(out picFileName, model.picUrl);
            string CvMessage = FileSave.SaveEmpCV(out cvFileName, model.cvDocUrl);
            if (PicMessage == "success" && CvMessage == "success")
            {
                empPicUrl = "";
                empPicUrl = picFileName;
                empCvUrl = "";
                empCvUrl = cvFileName;
            }
            else
            {
                return View(model);
            }

            Employee data = new Employee
            {
                Id=model.EmployeeId,
                name = model.name,
                empID=model.empID,
                empStatus=model.empStatus,
                joiningDate=model.joiningDate,
                dateOfBirth=model.dateOfBirth,
                contactNo=model.contactNo,
                address=model.address,
                fatherName=model.fatherName,
                cvUrl = empCvUrl,
                pictureUrl= empPicUrl,
                DepartmentId=model.DepartmentId,
                DesignationId=model.DesignationId,
                GenderId=model.GenderId,
                
            };

            if (model.EmployeeId>0)
            {

                return Json(await _employeeRepo.UpdateAsync(data, model.EmployeeId));
            }
            else
            {
                
                return Json(await _employeeRepo.AddAsync(data));
            }
        }

        //POST:/EmployeeArea/Employee/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            Employee data = new Employee();

            if (id<=0)
            {
                return Json(false);
            }
            else
            {
                data = await _employeeRepo.GetAsync(id);
            }

            if (data.Id> 0)
            {
                return Json(await _employeeRepo.DeleteAsync(data));
            }
            else
            {
                return Json(false);
            }
        }



        //GET:/EmployeeArea/Employee/GetEmployees
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            return Json(await _employeeRepo.GetAllAsync());
        }

    }
}
