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
    public class FoodCategoryController : Controller
    {
        private IGenericRepository<FoodCategory> _FoodCategoryRepo;

        public FoodCategoryController(IGenericRepository<FoodCategory> FoodCategoryRepo)
        {
            _FoodCategoryRepo = FoodCategoryRepo;
        }




        #region Crud_Section
        //GET:/FoodItemArea/FoodCategory/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            FoodCategoryViewModel model = new FoodCategoryViewModel
            {
                foodCategories = await _FoodCategoryRepo.GetAllAsync(),
            };
            return View(model);
        }
        //POST:/FoodItemArea/FoodCategory/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] FoodCategoryViewModel model)
        {

            try
            {
                FoodCategory data = new FoodCategory
                {
                    Id = model.FoodCategoryId,
                    foodCategoryName = model.foodCategoryName,
                    parentCategoryId = model.parentCategoryId == null ? 0 : model.parentCategoryId

                };

                if (model.FoodCategoryId > 0)
                {

                    return Json(await _FoodCategoryRepo.UpdateAsync(data, model.FoodCategoryId));
                }
                else
                {

                    return Json(await _FoodCategoryRepo.AddAsync(data));
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        //POST:/FoodItemArea/FoodCategory/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _FoodCategoryRepo.GetAsync(id);
            if (id <= 0 || data == null)
            {
                return Json(false);
            }

            bool response = false;

            try
            {
                response = await _FoodCategoryRepo.DeleteAsync(data);

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
