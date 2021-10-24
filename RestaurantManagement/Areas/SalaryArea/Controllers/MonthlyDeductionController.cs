using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.SalaryArea.Controllers
{
    public class MonthlyDeductionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
