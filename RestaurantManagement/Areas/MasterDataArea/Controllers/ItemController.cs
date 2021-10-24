using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Areas.MasterDataArea.Models;
using RestaurantManagement.Data.Entity.MasterDataEntity;
using RestaurantManagement.GenericRepo.GenericRepositoryService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.MasterDataArea.Controllers
{
    [Area("MasterDataArea")]
    public class ItemController : Controller
    {
        private IGenericRepository<Item> _ItemRepo;
        private IGenericRepository<Unit> _UnitRepo;
        private IGenericRepository<Category> _CategoryRepo;

        public ItemController(IGenericRepository<Item> ItemRepo, IGenericRepository<Unit> UnitRepo, IGenericRepository<Category> CategoryRepo)
        {
            _ItemRepo = ItemRepo;
            _UnitRepo = UnitRepo;
            _CategoryRepo = CategoryRepo;
        }

        #region Crud_Section
        //GET:/MasterDataArea/Item/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ItemViewModel model = new ItemViewModel
            {
                items =_ItemRepo.GetAllIncluding(x=>x.Category,x=>x.Unit),
                categories=await _CategoryRepo.GetAllAsync(),
                units=await _UnitRepo.GetAllAsync()
            };
            return View(model);
        }
        //POST:/MasterDataArea/Item/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] ItemViewModel model)
        {

            try
            {

                Item data = new Item
                {
                    Id = model.ItemId,
                    itemName=model.itemName,
                    itemDescription=model.itemDescription,
                    itemCode=Guid.NewGuid().ToString().Substring(0,8),
                    UnitId = model.UnitId,
                    CategoryId = model.CategoryId
                    //vatPercent=model.vatPercent,


                };

             
                if (model.ItemId > 0)
                {

                    return Json(await _ItemRepo.UpdateAsync(data, model.ItemId));
                }
                else
                {

                    return Json(await _ItemRepo.AddAsync(data));
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        //GET:/MasterDataArea/Item/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _ItemRepo.GetAsync(id);
            if (id <= 0 || data == null)
            {
                return Json(false);
            }

            bool response = false;

            try
            {
                response = await _ItemRepo.DeleteAsync(data);

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
