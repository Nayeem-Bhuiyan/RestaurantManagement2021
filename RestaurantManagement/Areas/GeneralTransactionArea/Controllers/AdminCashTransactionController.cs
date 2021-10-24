using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Areas.GeneralTransactionArea.Models;
using RestaurantManagement.Data.Entity.ApplicationUsersEntity;
using RestaurantManagement.Data.Entity.GeneralTransactionEntity;
using RestaurantManagement.GenericRepo.GenericRepositoryService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.GeneralTransactionArea.Controllers
{
    [Area("GeneralTransactionArea")]
    public class AdminCashTransactionController : Controller
    {
        
        private IGenericRepository<AdminCashTransaction> _AdminCashTransactionRepo;
       

        public AdminCashTransactionController(IGenericRepository<AdminCashTransaction> AdminCashTransactionRepo)
        {
            _AdminCashTransactionRepo = AdminCashTransactionRepo;
            
        }

        #region Crud_Section
        //GET:/GeneralTransactionArea/AdminCashTransaction/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            AdminCashTransactionViewModel model = new AdminCashTransactionViewModel
            {
                adminCashTransactions = await _AdminCashTransactionRepo.GetAllAsync(),
            };
            return View(model);
        }

        //POST:/GeneralTransactionArea/AdminCashTransaction/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] AdminCashTransactionViewModel model)
        {

            try
            {
                AdminCashTransaction data = new AdminCashTransaction
                {
                    Id = model.AdminCashTransactionId,
                    transactionDate=DateTime.Now,
                    transactionType=model.transactionType,
                    cashAmount=model.cashAmount,
                    payTo=model.payTo,
                    payBy= User.Identity.Name,
                    isApproved=1,
                };

                if (model.AdminCashTransactionId > 0)
                {

                    return Json(await _AdminCashTransactionRepo.UpdateAsync(data, model.AdminCashTransactionId));
                }
                else
                {

                    return Json(await _AdminCashTransactionRepo.AddAsync(data));
                }
            }
            catch (Exception)
            {
                throw;
            }

            

        }

        //POST:/GeneralTransactionArea/AdminCashTransaction/Delete/
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _AdminCashTransactionRepo.GetAsync(id);
            if (id <= 0 || data == null)
            {
                return Json(false);
            }

            bool response = false;

            try
            {
                response = await _AdminCashTransactionRepo.DeleteAsync(data);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(response);
        }
        #endregion
    }
}
