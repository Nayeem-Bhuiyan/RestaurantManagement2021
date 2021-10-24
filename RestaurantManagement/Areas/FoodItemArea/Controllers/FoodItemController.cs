using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Areas.FoodItemArea.Models;
using RestaurantManagement.Data.Entity.FoodItemEntity;
using RestaurantManagement.Data.Entity.MasterDataEntity;
using RestaurantManagement.GenericRepo.GenericRepositoryService.Interface;
using RestaurantManagement.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.FoodItemArea.Controllers
{
    [Area("FoodItemArea")]
    public class FoodItemController : Controller
    {
        private IGenericRepository<FoodItem> FoodItemRepo;
        private IGenericRepository<Unit> _UnitRepo;
        private IGenericRepository<FoodCategory> _CategoryRepo;
        private IGenericRepository<DailyFoodItem> _DailyFoodItemRepo;

        public FoodItemController(IGenericRepository<FoodItem> ItemRepo, IGenericRepository<Unit> UnitRepo, IGenericRepository<FoodCategory> CategoryRepo,IGenericRepository<DailyFoodItem> DailyFoodItemRepo)
        {
            FoodItemRepo = ItemRepo;
            _UnitRepo = UnitRepo;
            _CategoryRepo = CategoryRepo;
            _DailyFoodItemRepo = DailyFoodItemRepo;
        }


        //GET:/FoodItemArea/FoodItem/CreateDailyFoodItem
        [HttpGet]
        public async Task<IActionResult> CreateDailyFoodItem()
        {
           
            DailyFoodItemViewModel model = new DailyFoodItemViewModel
            {
                foodItems = FoodItemRepo.GetAllIncluding(x => x.FoodCategory, x => x.Unit),
                foodCategories = await _CategoryRepo.GetAllAsync(),
                units = await _UnitRepo.GetAllAsync(),
            };
            return View(model);
        }


        #region Crud_Section
        //GET:/FoodItemArea/FoodItem/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            FoodItemViewModel model = new FoodItemViewModel
            {
                foodItems = FoodItemRepo.GetAllIncluding(x => x.FoodCategory, x => x.Unit),
                foodCategories = await _CategoryRepo.GetAllAsync(),
                units = await _UnitRepo.GetAllAsync(),
            };
            return View(model);
        }
        //POST:/FoodItemArea/FoodItem/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] FoodItemViewModel model)
        {

            try
            {


                string foodItemPicUrl = "DefaultImage/NoImage.jpg";
                string picFileName;
                string PicMessage = FileSave.SaveFoodImage(out picFileName, model.IFormFoodImage);

                if (PicMessage == "success")
                {
                    foodItemPicUrl = "";
                    foodItemPicUrl = picFileName;
                }
                else
                {
                    return View(model);
                }



                FoodItem data = new FoodItem
                {
                    Id = model.FoodItemId,
                    itemName = model.itemName,
                    foodImage = foodItemPicUrl,
                    description = model.description,
                    unitPrice = model.unitPrice,
                    vatPercent = model.vatPercent,
                    //fk
                    FoodCategoryId = model.FoodCategoryId,
                    UnitId = model.UnitId,
                };


                if (model.FoodItemId > 0)
                {

                    return Json(await FoodItemRepo.UpdateAsync(data, model.FoodItemId));
                }
                else
                {

                    return Json(await FoodItemRepo.AddAsync(data));
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        //GET:/FoodItemArea/FoodItem/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await FoodItemRepo.GetAsync(id);
            if (id <= 0 || data == null)
            {
                return Json(false);
            }

            bool response = false;

            try
            {
                response = await FoodItemRepo.DeleteAsync(data);

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
