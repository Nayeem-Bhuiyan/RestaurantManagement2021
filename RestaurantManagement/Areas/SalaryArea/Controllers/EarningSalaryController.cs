using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Areas.SalaryArea.Models;
using RestaurantManagement.Data.Entity.EmployeeEntity;
using RestaurantManagement.Data.Entity.SalaryEntity;
using RestaurantManagement.GenericRepo.GenericRepositoryService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.SalaryArea.Controllers
{
    [Area("SalaryArea")]
    public class EarningSalaryController : Controller
    {
        private IGenericRepository<EarningSalary> _earningSalaryRepo;
        private IGenericRepository<Employee> _employeeRepo;
        private IGenericRepository<SalaryStructure> _salaryStructureRepo;
       


        public EarningSalaryController(IGenericRepository<EarningSalary> earningSalaryRepo, IGenericRepository<Employee> employeeRepo, IGenericRepository<SalaryStructure> salaryStructureRepo)
        {

            _earningSalaryRepo = earningSalaryRepo;
            _employeeRepo = employeeRepo;
            _salaryStructureRepo = salaryStructureRepo;
        }


        //GET:/SalaryArea/EarningSalary/Index
        [HttpGet]
        public IActionResult Index()
        {
            EarningSalaryViewModel model = new EarningSalaryViewModel
            {
                earningSalaries = _earningSalaryRepo.GetAllIncluding(x => x.Employee),
                employees = _employeeRepo.GetAll(),
                
            };

            return View(model);
        }

        //POST:/SalaryArea/EarningSalary/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] EarningSalaryViewModel model)
        {


            if (model == null)
            {
                return Json(0);
            }



            EarningSalary data = new EarningSalary
            {
                Id = model.EarningSalaryId,
                EmployeeId = model.EmployeeId,
                absentTotal = model.absentTotal*10,  //daily working 10 hour
                overtimes = model.overtimes,
                overTimePayAmount = model.overtimes*100,  //hourly pay rate=100
                special = model.special,
                SalaryStructureId = model.SalaryStructureId,
                totalPayableSalary = Convert.ToInt32(((300-model.absentTotal*10)* Convert.ToInt32(model.hourlyPayRate))+ Convert.ToInt32(model.overtimes * 100)+ Convert.ToInt32(model.special)),
                month = model.month,
                year = model.year,
                isApproved =0, //0=notApproved,1=approved
            };


            if (model.EarningSalaryId > 0)
            {

                return Json(await _earningSalaryRepo.UpdateAsync(data, model.EarningSalaryId));
            }
            else
            {

                return Json(await _earningSalaryRepo.AddAsync(data));
            }
        }


        //POST:/SalaryArea/EarningSalary/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            EarningSalary data = new EarningSalary();

            if (id <= 0)
            {
                return Json(false);
            }
            else
            {
                data = await _earningSalaryRepo.GetAsync(id);
            }

            if (data.Id > 0)
            {
                return Json(await _earningSalaryRepo.DeleteAsync(data));
            }
            else
            {
                return Json(false);
            }
        }


 

    }
}
