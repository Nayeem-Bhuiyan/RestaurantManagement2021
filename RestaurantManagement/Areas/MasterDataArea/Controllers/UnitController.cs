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
    public class UnitController : Controller
    {
        private IGenericRepository<Unit> _UnitRepo;

        public UnitController(IGenericRepository<Unit> UnitRepo)
        {
            _UnitRepo = UnitRepo;
        }

        #region Crud_Section
        //GET:/MasterDataArea/Unit/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            UnitViewModel model = new UnitViewModel
            {
                units = await _UnitRepo.GetAllAsync(),
            };
            return View(model);
        }
        //POST:/MasterDataArea/Unit/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] UnitViewModel model)
        {

            try
            {
                Unit data = new Unit
                {
                    Id = model.UnitId,
                    unitName=model.unitName,
                    description=model.description
                };

           
                if (model.UnitId > 0)
                {

                    return Json(await _UnitRepo.UpdateAsync(data, model.UnitId));
                }
                else
                {

                    return Json(await _UnitRepo.AddAsync(data));
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        //POST:/MasterDataArea/Unit/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _UnitRepo.GetAsync(id);
            if (id <= 0 || data == null)
            {
                return Json(false);
            }

            bool response = false;

            try
            {
                response= await _UnitRepo.DeleteAsync(data);

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
