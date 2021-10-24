using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Areas.FoodItemArea.Models;
using RestaurantManagement.Data.Entity.FoodItemEntity;
using RestaurantManagement.GenericRepo.GenericRepositoryService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.FoodItemArea.Controllers
{
   [Area("FoodItemArea")]
    public class DailyFoodItemController : Controller
    {
        private IGenericRepository<DailyFoodItem> _DailyFoodItemRepo;

        public DailyFoodItemController(IGenericRepository<DailyFoodItem> DailyFoodItemRepo)
        {
            _DailyFoodItemRepo = DailyFoodItemRepo;
        }


        #region Crud_Section
        //GET:/FoodItemArea/DailyFoodItem/Index
        [HttpGet]
        public IActionResult Index()
        {
            DailyFoodItemViewModel model = new DailyFoodItemViewModel
            {
                dailyFoodItems =  _DailyFoodItemRepo.GetAllIncluding(x=>x.FoodCategory,x=>x.FoodItem,x=>x.Unit),
            };
            return View(model);
        }

        //POST:/FoodItemArea/DailyFoodItem/CreateDailyFoodItem
        [HttpPost]
        public async Task<JsonResult> CreateDailyFoodItem([FromBody] DailyFoodItemViewModel model)
        {

            try
            {

                
                await _DailyFoodItemRepo.DeleteRangeAsync(await _DailyFoodItemRepo.FindAllAsync(X => X.FoodItemId == model.FoodItemId));

                    DailyFoodItem data = new DailyFoodItem
                    {
                        Id = model.DailyFoodItemId,
                        FoodCategoryId = model.FoodCategoryId,
                        UnitId = model.UnitId,
                        FoodItemId = model.FoodItemId,
                    };

                   return Json(await _DailyFoodItemRepo.AddAsync(data));
                
                
            }
            catch (Exception)
            {
                throw;
            }

        }

        //POST:/FoodItemArea/DailyFoodItem/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _DailyFoodItemRepo.GetAsync(id);
            if (id <= 0 || data == null)
            {
                return Json(false);
            }

            bool response = false;

            try
            {
                response = await _DailyFoodItemRepo.DeleteAsync(data);

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
