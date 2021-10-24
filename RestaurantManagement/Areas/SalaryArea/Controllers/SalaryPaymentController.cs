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
    public class SalaryPaymentController : Controller
    {
        private IGenericRepository<SalaryStructure> _salaryStructureRepo;
        private IGenericRepository<Employee> _employeeRepo;
        private IGenericRepository<EarningSalary> _earningSalaryRepo;
        private IGenericRepository<SalaryPayment> _salaryPaymentRepo;
        private IGenericRepository<SalaryPayRecord> _salaryPayRecordRepo;
        public SalaryPaymentController(IGenericRepository<SalaryStructure> salaryStructureRepo, IGenericRepository<Employee> employeeRepo, IGenericRepository<EarningSalary> earningSalaryRepo, IGenericRepository<SalaryPayment> salaryPaymentRepo, IGenericRepository<SalaryPayRecord> salaryPayRecordRepo)
        {

            _salaryStructureRepo = salaryStructureRepo;
            _employeeRepo = employeeRepo;
            _earningSalaryRepo = earningSalaryRepo;
            _salaryPaymentRepo = salaryPaymentRepo;
            _salaryPayRecordRepo = salaryPayRecordRepo;
        }

        //GET:/SalaryArea/SalaryPayment/PaySalaryDetails
        public IActionResult PaySalaryDetails()
        {
           
            SalaryPaymentViewModel obj = new SalaryPaymentViewModel
            {
              
                salaryPayments = _salaryPaymentRepo.GetAllIncluding(x => x.Employee, x => x.EarningSalary)
            };
            return View(obj);
        }
        //POST:/SalaryArea/SalaryPayment/PaySalaryDetailsJson
        [HttpPost]
        public IActionResult PaySalaryDetailsJson(int? InputYear,int? InputMonth)
        {
            if (InputYear==null || InputMonth==null)
            {
                return View();
            }

            var data = _salaryPaymentRepo.GetAllIncluding(x => x.Employee, x => x.EarningSalary).Where(x => x.EarningSalary.year == InputYear && x.EarningSalary.month == InputMonth).ToList();
            if (data==null)
            {
                data = new List<SalaryPayment>();
            }

            return Json(data);
        }

        //GET:/SalaryArea/SalaryPayment/Payment
        [HttpGet]
        public IActionResult Payment()
        {
            SalaryPaymentViewModel obj = new SalaryPaymentViewModel();

            var paidSalary = _salaryPaymentRepo.GetAllIncluding(x => x.EarningSalary, x => x.Employee);
            var empList = _employeeRepo.GetAll();
            List<EarningSalary> EarningSalaryList = new List<EarningSalary>();
            EarningSalaryList.AddRange(_earningSalaryRepo.GetAllIncluding(x => x.Employee, x => x.SalaryStructure).OrderByDescending(x => x.createdAt));
            
            foreach (var item in paidSalary)
            {
                EarningSalary earningSalary = new EarningSalary();
                earningSalary = _earningSalaryRepo.Find(x => x.Id == item.EarningSalaryId);

                if (earningSalary.totalPayableSalary == item.paidTotal)
                {
                    EarningSalaryList.Remove(earningSalary);
                }
                else
                {

                }

            }

            obj = new SalaryPaymentViewModel
            {
                salaryPayRecords = _salaryPayRecordRepo.GetAllIncluding(x=>x.EarningSalary,x=>x.Employee),
                earningSalaries = EarningSalaryList,
                salaryPayments = _salaryPaymentRepo.GetAllIncluding(x => x.EarningSalary, x => x.Employee)
            };

            return View(obj);
        }

        //POST:/SalaryArea/SalaryPayment/Payment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Payment(SalaryPaymentViewModel model)
        {
            SalaryPayment data = new SalaryPayment();
            SalaryPayRecord payRecord = new SalaryPayRecord();
            if (model == null)
            {
                return View(model);
            }


            var paySalary = await _salaryPaymentRepo.FindAsync(x=>x.EarningSalaryId== model.EarningSalaryId);
            var earningSalary = await _earningSalaryRepo.FindAsync(x => x.Id == model.EarningSalaryId);
            int? finalPaidSalary = 0;
            if (paySalary != null)
            {
                finalPaidSalary = paySalary.paidTotal + model.paidTotal;
            }
            else
            {
                finalPaidSalary = model.paidTotal;
            }


            if (paySalary!=null)
            {

                data = new SalaryPayment
                {
                    Id = paySalary.Id>0? paySalary.Id:model.SalaryPaymentId,
                    paidTotal = finalPaidSalary,  //total paid Amount
                    processDate = DateTime.Now,
                    totalPaybale = model.totalPaybale,  //total earning salary
                    EmployeeId = model.EmployeeId,
                    EarningSalaryId = model.EarningSalaryId,
                };

                payRecord = new SalaryPayRecord
                {
                    Id=0,
                    EmployeeId = model.EmployeeId,
                    EarningSalaryId = model.EarningSalaryId,
                    paidAmount = model.paidTotal,
                    paidDate = DateTime.Now
                };
                await _salaryPayRecordRepo.AddAsync(payRecord);

                return Json(await _salaryPaymentRepo.UpdateAsync(data, paySalary.Id));
            }
            else
            {
                data = new SalaryPayment
                {
                    Id =0,
                    paidTotal = finalPaidSalary,  //total paid Amount
                    processDate = DateTime.Now,
                    totalPaybale = model.totalPaybale,  //total earning salary
                    EmployeeId = model.EmployeeId,
                    EarningSalaryId = model.EarningSalaryId,
                };
                payRecord = new SalaryPayRecord
                {
                    Id=0,
                    EmployeeId = model.EmployeeId,
                    EarningSalaryId = model.EarningSalaryId,
                    paidAmount = model.paidTotal,
                    paidDate = DateTime.Now
                };
                await _salaryPayRecordRepo.AddAsync(payRecord);
                return Json(await _salaryPaymentRepo.AddAsync(data));
            }





        }


        //POST:/SalaryArea/SalaryPayment/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            SalaryPayment data = new SalaryPayment();

            if (id <= 0)
            {
                return Json(false);
            }
            else
            {
                data = await _salaryPaymentRepo.GetAsync(id);
            }

            if (data.Id > 0)
            {
                return Json(await _salaryPaymentRepo.DeleteAsync(data));
            }
            else
            {
                return Json(false);
            }
        }


        //POST:/SalaryArea/SalaryPayment/GetSalaryPayment/id
        [HttpGet]
        public IActionResult GetSalaryPayment(int id)
        {
            SalaryPayment data = new SalaryPayment();

            if (id <= 0)
            {
                return Json(data);
            }
            else
            {

                return Json(_salaryPaymentRepo.Find(x => x.EarningSalaryId == id));
            }

        }
    }
}
