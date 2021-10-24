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
    public class DepartmentController : Controller
    {
        private IGenericRepository<Department> _DepartmentRepo;

        public DepartmentController(IGenericRepository<Department> DepartmentRepo)
        {
            _DepartmentRepo = DepartmentRepo;
        }

        #region Crud_Section
        //GET:/MasterDataArea/Department/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            DepartmentViewModel model = new DepartmentViewModel
            {
                departments = await _DepartmentRepo.GetAllAsync(),
            };
            return View(model);
        }
        //POST:/MasterDataArea/Department/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] DepartmentViewModel model)
        {

            try
            {
                Department data = new Department
                {
                    Id = model.DepartmentId,
                    name = model.name,

                };


                if (model.DepartmentId > 0)
                {

                    return Json(await _DepartmentRepo.UpdateAsync(data, model.DepartmentId));
                }
                else
                {

                    return Json(await _DepartmentRepo.AddAsync(data));
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        //POST:/MasterDataArea/Department/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _DepartmentRepo.GetAsync(id);
            if (id <= 0 || data == null)
            {
                return Json(false);
            }

            bool response = false;

            try
            {
                response = await _DepartmentRepo.DeleteAsync(data);

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
