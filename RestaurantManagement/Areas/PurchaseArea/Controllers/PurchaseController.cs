using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Areas.MasterDataArea.Models;
using RestaurantManagement.Areas.PurchaseArea.Models;
using RestaurantManagement.Data.Entity.MasterDataEntity;
using RestaurantManagement.Data.Entity.PurchaseEntity;
using RestaurantManagement.GenericRepo.GenericRepositoryService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.PurchaseArea.Controllers
{
    [Area("PurchaseArea")]
    public class PurchaseController : Controller
    {
        private IGenericRepository<Purchase> _PurchaseRepo;
        private IGenericRepository<Item> _ItemRepo;
        private IGenericRepository<Unit> _UnitRepo;
        private IGenericRepository<Category> _CategoryRepo;
        public PurchaseController(IGenericRepository<Purchase> PurchaseRepo, IGenericRepository<Item> ItemRepo, IGenericRepository<Unit> UnitRepo, IGenericRepository<Category> CategoryRepo)
        {
            _PurchaseRepo = PurchaseRepo;
            _ItemRepo = ItemRepo;
            _UnitRepo = UnitRepo;
            _CategoryRepo = CategoryRepo;
        }




        #region Crud_Section

        //GET:/PurchaseArea/Purchase/CreatePurchase
        [HttpGet]
        public async Task<IActionResult> CreatePurchase()
        {
            PurchaseViewModel model = new PurchaseViewModel
            {
                items = _ItemRepo.GetAllIncluding(x => x.Category, x => x.Unit),
                categories = await _CategoryRepo.GetAllAsync(),
                units = await _UnitRepo.GetAllAsync()
            };
            return View(model);
        }
        //POST:/PurchaseArea/Purchase/CreatePurchase
        [HttpPost]
        public async Task<JsonResult> CreatePurchase([FromBody] PurchaseViewModel model)
        {

            try
            {


                var NetQuantity = model.quantity - model.returnQuantity;
                Purchase data = new Purchase
                {
                    Id = model.PurchaseId,
                    boucherNo = BoucherCode(), // must save with boucherNo from controller with auto increament
                    quantity = model.quantity,
                    returnQuantity = model.returnQuantity,  //by default zero will save 
                    netQuantity = NetQuantity,  //netQuantity=quantity-returnQuantity
                    unitPrice = model.unitPrice,
                    vatAmount = model.vatAmount, //form item table
                    discount = model.discount,
                    subTotal = (NetQuantity * model.unitPrice) - (model.discount),   //calculated Column ,subtotal=netQuantiy*unitPrice+(netQuantiy*unitPrice)*vatPercent-discount
                    needDate = model.needDate == null ? DateTime.Now : model.needDate,  //CreatedAt==orderDate
                    supplyDate = model.supplyDate == null ? DateTime.Now : model.supplyDate,// confirm purchase date porbe from DateTime.Now
                                                                                            //fk
                    ItemId = model.ItemId, //
                    SupplierId = model.SupplierId,//
                    CategoryId = model.CategoryId,
                    UnitId = model.UnitId

                };

              return Json(await _PurchaseRepo.AddAsync(data));
            }
            catch (Exception)
            {
                throw;
            }

        }


        public string BoucherCode()
        {
            string Code = "B";
            DateTime todayDate = DateTime.Now;
            Code = (Code + "-" + todayDate.Day + "" + todayDate.Month + "" + todayDate.Year + "" + todayDate.Hour + "" + todayDate.Minute + "" + todayDate.Second).ToString();
            return Code;
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _PurchaseRepo.GetAsync(id);
            if (id <= 0 || data == null)
            {
                return Json(false);
            }

            bool response = false;

            try
            {
                response = await _PurchaseRepo.DeleteAsync(data);

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
