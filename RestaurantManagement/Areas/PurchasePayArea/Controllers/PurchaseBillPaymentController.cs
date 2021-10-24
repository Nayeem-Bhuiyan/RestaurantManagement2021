using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Areas.PurchasePayArea.Models;
using RestaurantManagement.Data.Entity.PurchasePayEntity;
using RestaurantManagement.GenericRepo.GenericRepositoryService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.PurchasePayArea.Controllers
{
    [Area("PurchasePayArea")]
    public class PurchaseBillPaymentController : Controller
    {
        private IGenericRepository<PurchaseBillPayment> _PurchaseBillPaymentRepo;

        public PurchaseBillPaymentController(IGenericRepository<PurchaseBillPayment> PurchaseBillPaymentRepo)
        {
            _PurchaseBillPaymentRepo = PurchaseBillPaymentRepo;
        }

        #region Crud_Section

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            PurchaseBillPaymentViewModel model = new PurchaseBillPaymentViewModel
            {
                purchaseBillPayments = await _PurchaseBillPaymentRepo.GetAllAsync(),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] PurchaseBillPaymentViewModel model)
        {

            try
            {
                PurchaseBillPayment data = new PurchaseBillPayment
                {
                    Id = model.PurchaseBillPaymentId,

                };

                await _PurchaseBillPaymentRepo.AddAsync(data);
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
            var data = await _PurchaseBillPaymentRepo.GetAsync(id);
            if (id <= 0 || data == null)
            {
                return Json(false);
            }

            bool response = false;

            try
            {
                response = await _PurchaseBillPaymentRepo.DeleteAsync(data);

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
