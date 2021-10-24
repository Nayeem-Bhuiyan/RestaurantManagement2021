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
    public class CategoryController : Controller
    {
        private IGenericRepository<Category> _CategoryRepo;

        public CategoryController(IGenericRepository<Category> CategoryRepo)
        {
            _CategoryRepo = CategoryRepo;
        }




        #region Crud_Section
        //GET:/MasterDataArea/Category/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            CategoryViewModel model = new CategoryViewModel
            {
                categories = await _CategoryRepo.GetAllAsync(),
            };
            return View(model);
        }
        //POST:/MasterDataArea/Category/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] CategoryViewModel model)
        {

            try
            {
                Category data = new Category
                {
                    Id = model.CategoryId,
                    categoryName=model.categoryName,
                    parentCategoryId=model.parentCategoryId==null?0:model.parentCategoryId

                };

                if (model.CategoryId > 0)
                {

                    return Json(await _CategoryRepo.UpdateAsync(data, model.CategoryId));
                }
                else
                {

                    return Json(await _CategoryRepo.AddAsync(data));
                }
            
            }
            catch (Exception)
            {
                throw;
            }

        }

        //POST:/MasterDataArea/Category/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data=  await _CategoryRepo.GetAsync(id);
            if (id <= 0 || data==null)
            {
                return Json(false);
            }

            bool response = false;

            try
            {
                response = await _CategoryRepo.DeleteAsync(data);

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
