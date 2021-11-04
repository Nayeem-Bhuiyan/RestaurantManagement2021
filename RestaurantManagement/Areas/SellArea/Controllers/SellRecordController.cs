using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Areas.SellArea.Models;
using RestaurantManagement.Data.Entity.FoodItemEntity;
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
        private IGenericRepository<DailyFoodItem> _DailyFoodItemRepo;

        public SellRecordController(IGenericRepository<SellRecord> SellRecordRepo, IGenericRepository<DailyFoodItem> DailyFoodItemRepo)
        {
            _SellRecordRepo = SellRecordRepo;
            _DailyFoodItemRepo = DailyFoodItemRepo;
        }

        #region Crud_Section
        //GET:/SellArea/SellRecord/CreateSell
        [HttpGet]
        public IActionResult CreateSell()
        {
            SellRecordViewModel model = new SellRecordViewModel
            {
                dailyFoodItems= _DailyFoodItemRepo.GetAllIncluding(x=>x.FoodItem,x=>x.FoodCategory,x=>x.Unit)
            };
            return View(model);
        }
        //POST:/SellArea/SellRecord/CreateSell
        [HttpPost]
        public async Task<IActionResult> CreateSell([FromBody] SellRecordViewModel model)
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

        //POST:/SellArea/SellRecord/Delete
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
