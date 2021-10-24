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
    public class GenderController : Controller
    {
        private IGenericRepository<Gender> _GenderRepo;

        public GenderController(IGenericRepository<Gender> GenderRepo)
        {
            _GenderRepo = GenderRepo;
        }

        #region Crud_Section
        //GET:/MasterDataArea/Gender/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            GenderViewModel model = new GenderViewModel
            {
                genders = await _GenderRepo.GetAllAsync(),
            };
            return View(model);
        }
        //POST:/MasterDataArea/Gender/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] GenderViewModel model)
        {

            try
            {
                Gender data = new Gender
                {
                    Id = model.GenderId,
                    name = model.name,

                };
                if (model.GenderId > 0)
                {

                    return Json(await _GenderRepo.UpdateAsync(data, model.GenderId));
                }
                else
                {

                    return Json(await _GenderRepo.AddAsync(data));
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        //POST:/MasterDataArea/Gender/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _GenderRepo.GetAsync(id);
            if (id <= 0 || data == null)
            {
                return Json(false);
            }

            bool response = false;

            try
            {
                response = await _GenderRepo.DeleteAsync(data);

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
