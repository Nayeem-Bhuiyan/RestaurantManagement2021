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
    public class DesignationController : Controller
    {
        private IGenericRepository<Designation> _DesignationRepo;

        public DesignationController(IGenericRepository<Designation> DesignationRepo)
        {
            _DesignationRepo = DesignationRepo;
        }

        #region Crud_Section
        //GET:/MasterDataArea/Designation/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            DesignationViewModel model = new DesignationViewModel
            {
                designations = await _DesignationRepo.GetAllAsync(),
            };
            return View(model);
        }
        //POST:/MasterDataArea/Designation/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] DesignationViewModel model)
        {

            try
            {
                Designation data = new Designation
                {
                    Id = model.DesignationId,
                    name = model.name,

                };
                if (model.DesignationId > 0)
                {

                    return Json(await _DesignationRepo.UpdateAsync(data, model.DesignationId));
                }
                else
                {

                    return Json(await _DesignationRepo.AddAsync(data));
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        //POST:/MasterDataArea/Designation/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _DesignationRepo.GetAsync(id);
            if (id <= 0 || data == null)
            {
                return Json(false);
            }

            bool response = false;

            try
            {
                response = await _DesignationRepo.DeleteAsync(data);

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
