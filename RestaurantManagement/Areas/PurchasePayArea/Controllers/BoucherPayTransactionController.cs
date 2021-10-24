using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Areas.PurchasePayArea.Models;
using RestaurantManagement.Data.Entity.PurchasePayEntity;
using RestaurantManagement.GenericRepo.GenericRepositoryService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.BoucherPayTransactionPayArea.Controllers
{
   [Area("BoucherPayTransactionPayArea")]
    public class BoucherPayTransactionController : Controller
    {
        private IGenericRepository<BoucherPayTransaction> _BoucherPayTransactionRepo;

        public BoucherPayTransactionController(IGenericRepository<BoucherPayTransaction> BoucherPayTransactionRepo)
        {
            _BoucherPayTransactionRepo = BoucherPayTransactionRepo;
        }


        #region Crud_Section

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            BoucherPayTransactionViewModel model = new BoucherPayTransactionViewModel
            {
                boucherPayTransactions = await _BoucherPayTransactionRepo.GetAllAsync(),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] BoucherPayTransactionViewModel model)
        {

            try
            {
                BoucherPayTransaction data = new BoucherPayTransaction
                {
                    Id = model.BoucherPayTransactionId,

                };

                await _BoucherPayTransactionRepo.AddAsync(data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw;
            }

        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _BoucherPayTransactionRepo.GetAsync(id);
            if (id <= 0 || data == null)
            {
                return Json(false);
            }

            bool response = false;

            try
            {
                response = await _BoucherPayTransactionRepo.DeleteAsync(data);

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
