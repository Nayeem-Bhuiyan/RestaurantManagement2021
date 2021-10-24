using RestaurantManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data.Entity.SalaryEntity;
using RestaurantManagement.Services.SalaryService.Interface;

namespace RestaurantManagement.Services.SalaryService
{
    public class SalaryStructureService: ISalaryStructureService
    {
        protected AppDbContext _context;
        public SalaryStructureService(AppDbContext context)
        {
            _context = context;
        }


    }
}
