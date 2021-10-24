using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Areas.SellArea.Models;
using RestaurantManagement.Data.Entity.SellEntity;
using RestaurantManagement.GenericRepo.GenericRepositoryService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.SellArea.Controllers
{
    [Area("SellArea")]
    public class SellRecordController : Controller
    {
        private IGenericRepository<SellRecord> _SellRecordRepo;

        public SellRecordController(IGenericRepository<SellRecord> SellRecordRepo)
        {
            _SellRecordRepo = SellRecordRepo;
        }

        #region Crud_Section

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            SellRecordViewModel model = new SellRecordViewModel
            {
                sellRecords = await _SellRecordRepo.GetAllAsync(),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] SellRecordViewModel model)
        {

            try
            {
                SellRecord data = new SellRecord
                {
                    Id = model.SellRecordId,

                };

                await _SellRecordRepo.AddAsync(data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw;
            }

        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _SellRecordRepo.GetAsync(id);
            if (id <= 0 || data == null)
            {
                return Json(false);
            }

            bool response = false;

            try
            {
                response = await _SellRecordRepo.DeleteAsync(data);

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
