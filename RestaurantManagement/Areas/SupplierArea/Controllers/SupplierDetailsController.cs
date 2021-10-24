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
    public class SupplierDetailsController : Controller
    {
        private IGenericRepository<SupplierDetails> _SupplierDetailsRepo;
        private IGenericRepository<Supplier> _SupplierRepo;

        public SupplierDetailsController(IGenericRepository<SupplierDetails> SupplierDetailsRepo, IGenericRepository<Supplier> SupplierRepo)
        {
            _SupplierDetailsRepo = SupplierDetailsRepo;
            _SupplierRepo = SupplierRepo;
        }

        #region Crud_Section
        //GET:/SupplierArea/SupplierDetails/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            SupplierDetailsViewModel model = new SupplierDetailsViewModel
            {
                supplierListDetails = _SupplierDetailsRepo.GetAllIncluding(x => x.Supplier),
                suppliers = await _SupplierRepo.GetAllAsync()
            };
            return View(model);
        }
        //POST:/SupplierArea/SupplierDetails/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] SupplierDetailsViewModel model)
        {

            try
            {
                SupplierDetails data = new SupplierDetails
                {
                    Id = model.SupplierDetailsId,
                    shopNo = model.shopNo,
                    shopLocation = model.shopLocation,
                    licenceNo = model.licenceNo,
                    presentAddress = model.presentAddress,
                    permanentAddress = model.permanentAddress,
                    SupplierId = model.SupplierId
                };
                if (model.SupplierDetailsId > 0)
                {
                    return Json(await _SupplierDetailsRepo.UpdateAsync(data, model.SupplierDetailsId));
                }
                else
                {
                    return Json(await _SupplierDetailsRepo.AddAsync(data));
                }
                
            }
            catch (Exception)
            {
                throw;
            }

        }

        //POST:/SupplierArea/SupplierDetails/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _SupplierDetailsRepo.GetAsync(id);
            if (id <= 0 || data == null)
            {
                return Json(false);
            }

            bool response = false;

            try
            {
                response = await _SupplierDetailsRepo.DeleteAsync(data);

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
