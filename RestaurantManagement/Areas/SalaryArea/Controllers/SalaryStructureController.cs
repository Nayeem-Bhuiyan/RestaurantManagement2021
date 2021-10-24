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
    public class SalaryStructureController : Controller
    {
        private IGenericRepository<SalaryStructure> _salaryStructureRepo;
        private IGenericRepository<Employee> _employeeRepo;
        private IGenericRepository<EarningSalary> _earningSalaryRepo;
        public SalaryStructureController(IGenericRepository<SalaryStructure> salaryStructureRepo, IGenericRepository<Employee> employeeRepo, IGenericRepository<EarningSalary> earningSalaryRepo)
        {

            _salaryStructureRepo = salaryStructureRepo;
            _employeeRepo = employeeRepo;
            _earningSalaryRepo = earningSalaryRepo;
        }


        //GET:/SalaryArea/SalaryStructure/Index
        [HttpGet]
        public IActionResult Index()
        {
            SalaryStructureViewModel model = new SalaryStructureViewModel
            {
                salaryStructures =  _salaryStructureRepo.GetAllIncluding(x=>x.Employee),
            };

            return View(model);
        }


        //GET:/SalaryArea/SalaryStructure/CreateMonthlySalary
        [HttpGet]
        public IActionResult CreateMonthlySalary()
        {
          

            List<SalaryStructure> dataList =new List<SalaryStructure> ();
            IEnumerable<Employee> AllEmployee = _employeeRepo.GetAll().OrderByDescending(x=>x.Id);
            foreach (var emp in AllEmployee)
            {
                SalaryStructure data = new SalaryStructure();
                data= _salaryStructureRepo.GetAllIncluding(x => x.Employee).OrderByDescending(x => x.activeFrom).Where(x => x.EmployeeId == emp.Id).FirstOrDefault();
                dataList.Add(data);
            }

            

            SalaryStructureViewModel model = new SalaryStructureViewModel
            {
                salaryStructures = dataList,
                salaryMonth = DateTime.Now.Month - 1,
                earningSalaries = _earningSalaryRepo.GetAllIncluding(x => x.Employee,x=>x.SalaryStructure)
            };

            return View(model);
        }

        //POST:/SalaryArea/SalaryStructure/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] SalaryStructureViewModel model)
        {


            if (model==null)
            {
                return Json(0);
            }

            SalaryStructure data = new SalaryStructure
            {
                Id = model.SalaryStructureId,
                EmployeeId=model.EmployeeId,
                basic= Convert.ToInt32(model.basic),
                homeRent=Convert.ToInt32((model.basic*20)/100),
                medical= Convert.ToInt32((model.basic*10)/100),
                transport= Convert.ToInt32((model.basic*5)/100),
                totalSalary=Convert.ToInt32((model.basic +((model.basic*20)/100) + ((model.basic*10)/100) + ((model.basic*5)/100))),
                hourlyPayRate= Convert.ToInt32((model.basic + ((model.basic*20)/100) + ((model.basic*10)/100)+((model.basic* 5)/100))/300),
                activeFrom=Convert.ToDateTime(model.activeFrom),
                activeTo= Convert.ToDateTime(model.activeFrom),

            };

            if (model.SalaryStructureId > 0)
            {

                return Json(await _salaryStructureRepo.UpdateAsync(data, model.SalaryStructureId));
            }
            else
            {

                return Json(await _salaryStructureRepo.AddAsync(data));
            }
        }

        //POST:/SalaryArea/SalaryStructure/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            SalaryStructure data = new SalaryStructure();

            if (id <= 0)
            {
                return Json(false);
            }
            else
            {
                data = await _salaryStructureRepo.GetAsync(id);
            }

            if (data.Id > 0)
            {
                return Json(await _salaryStructureRepo.DeleteAsync(data));
            }
            else
            {
                return Json(false);
            }
        }




    }
}
