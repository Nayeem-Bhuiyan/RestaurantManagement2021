using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Areas.KitchenArea.Models;
using RestaurantManagement.Data.Entity.KitchenEntity;
using RestaurantManagement.Data.Entity.MasterDataEntity;
using RestaurantManagement.Data.Entity.PurchaseEntity;
using RestaurantManagement.GenericRepo.GenericRepositoryService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.KitchenArea.Controllers
{
    [Area("KitchenArea")]
    public class KitchenSupplyController : Controller
    {
        private IGenericRepository<KitchenSupply> _KitchenSupplyRepo;
        private IGenericRepository<Item> _ItemRepo;
        private IGenericRepository<Purchase> _PurchaseRepo;

        public KitchenSupplyController(IGenericRepository<KitchenSupply> KitchenSupplyRepo, IGenericRepository<Item> ItemRepo, IGenericRepository<Purchase> PurchaseRepo)
        {
            _KitchenSupplyRepo = KitchenSupplyRepo;
            _ItemRepo = ItemRepo;
            _PurchaseRepo = PurchaseRepo;
        }

        #region Crud_Section
        //GET:/KitchenArea/KitchenSupply/Index
        [HttpGet]
        public IActionResult Index()
        {

            List<KitchenDetailsViewModel> KitchenDetailList = new List<KitchenDetailsViewModel>();

            foreach (var data in _PurchaseRepo.GetAllIncluding(x=>x.Item,x=>x.Category,x=>x.Unit))
            {
                KitchenDetailsViewModel KitchenDetail = new KitchenDetailsViewModel
                {
                    ItemId = data.ItemId,
                    itemName = data.Item?.itemName,
                    itemCode=data.Item?.itemCode,
                    itemDescription = data.Item?.itemDescription,
                    purchaseTotalAmount = _PurchaseRepo.FindAll(x => x.ItemId == data.ItemId).Sum(x => x.netQuantity),
                    kitchenTotalSupplyAmount = _KitchenSupplyRepo.FindAll(x => x.ItemId == data.ItemId).Sum(x => x.netQuantity),
                    stockAmount = (_PurchaseRepo.FindAll(x => x.ItemId == data.ItemId).Sum(x => x.netQuantity))-(_KitchenSupplyRepo.FindAll(x => x.ItemId == data.ItemId).Sum(x => x.netQuantity)),
                    categoryName =data.Category?.categoryName,
                    unitName = data.Unit?.unitName,
                    unitDescription = data.Unit?.description,
                };
                KitchenDetailList.Add(KitchenDetail);
            }

            KitchenSupplyViewModel model = new KitchenSupplyViewModel
            {
                kitchenSupplys = _KitchenSupplyRepo.GetAllIncluding(x => x.Item,x=>x.Item.Category, x => x.Item.Unit),
                items = _ItemRepo.GetAll(),
                kitchenDetailsViewModels= KitchenDetailList
            };
            return View(model);
        }
        //POST:/KitchenArea/KitchenSupply/Index
        [HttpPost]
        public async Task<IActionResult> Index([FromBody] KitchenSupplyViewModel model)
        {

            try
            {
           
                KitchenSupply data = new KitchenSupply
                {
                    Id = model.KitchenSupplyId,
                    ItemId = model.ItemId,
                    OrderCode = model.OrderCode,
                    quantity = model.quantity,
                    returnQuantity = model.returnQuantity,
                    netQuantity = (model.quantity - model.returnQuantity),
                };

                if (model.KitchenSupplyId > 0)
                {
                    if (model.returnQuantity > 0)
                    {
                       var returnSupply= _KitchenSupplyRepo.FindFirst(x => x.Id == model.KitchenSupplyId);
                        returnSupply.returnQuantity = model.returnQuantity;
                        return Json(await _KitchenSupplyRepo.UpdateAsync(returnSupply, model.KitchenSupplyId));
                    }
                    else
                    {
                        return Json(await _KitchenSupplyRepo.UpdateAsync(data, model.KitchenSupplyId));
                    }
                    
                }
                else
                {

                    return Json(await _KitchenSupplyRepo.AddAsync(data));
                }

            }
            catch (Exception)
            {
                throw;
            }

        }



        //POST:/KitchenArea/KitchenSupply/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _KitchenSupplyRepo.GetAsync(id);
            if (id <= 0 || data == null)
            {
                return Json(false);
            }

            bool response = false;

            try
            {
                response = await _KitchenSupplyRepo.DeleteAsync(data);

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
