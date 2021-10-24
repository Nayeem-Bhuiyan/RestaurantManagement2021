using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Areas.SupplierArea.Models;
using RestaurantManagement.Data.Entity.SupplierEntity;
using RestaurantManagement.GenericRepo.GenericRepositoryService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.SupplierArea.Controllers
{
    [Area("SupplierArea")]
    public class SupplierController : Controller
    {
        private IGenericRepository<Supplier> _SupplierRepo;

        public SupplierController(IGenericRepository<Supplier> SupplierRepo)
        {
            _SupplierRepo = SupplierRepo;
        }


        #region Crud_Section
        //GET:/SupplierArea/Supplier/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            SupplierViewModel model = new SupplierViewModel
            {
                suppliers = await _SupplierRepo.GetAllAsync(),
            };
            return View(model);
        }
        //POST:/SupplierArea/Supplier/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] SupplierViewModel model)
        {

            try
            {
                Supplier data = new Supplier
                {
                    Id = model.SupplierId,
                    supplierName = model.supplierName,
                    contactNo = model.contactNo
                };
                if (model.SupplierId>0)
                {
                    return Json(await _SupplierRepo.UpdateAsync(data, model.SupplierId));
                }
                else
                {
                    return Json(await _SupplierRepo.AddAsync(data));
                }
                
               
            }
            catch (Exception)
            {
                throw;
            }

        }

        //POST:/SupplierArea/Supplier/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _SupplierRepo.GetAsync(id);
            if (id <= 0 || data == null)
            {
                return Json(false);
            }

            bool response = false;

            try
            {
                response = await _SupplierRepo.DeleteAsync(data);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(response);
        }
        #endregion


        //GET:/SupplierArea/Supplier/AllSuppliers
        [HttpGet]
        public async Task<IActionResult> AllSuppliers()
        {
            return Json(await _SupplierRepo.GetAllAsync());
        }
    }
}
