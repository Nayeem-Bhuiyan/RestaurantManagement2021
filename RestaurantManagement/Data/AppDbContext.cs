using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantManagement.Data.Entity.ApplicationUsersEntity;
using RestaurantManagement.Data.Entity.FoodItemEntity;
using RestaurantManagement.Data.Entity.GeneralTransactionEntity;
using RestaurantManagement.Data.Entity.MasterDataEntity;
using RestaurantManagement.Data.Entity.PurchasePayEntity;
using RestaurantManagement.Data.Entity.PurchaseEntity;
using RestaurantManagement.Data.Entity.SellEntity;
using System.Threading;
using System.Security.Principal;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using RestaurantManagement.Data.Entity.KitchenEntity;
using RestaurantManagement.Data.Entity.SupplierEntity;
using RestaurantManagement.Data.Entity.EmployeeEntity;
using RestaurantManagement.Data.Entity.SalaryEntity;

namespace RestaurantManagement.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        internal object tblName;

        public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor _httpContextAccessor) : base(options)
        {
            this._httpContextAccessor = _httpContextAccessor;
        }


        #region Settings Configs
        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        private void AddTimestamps()
        {

            var entities = ChangeTracker.Entries().Where(x => x.Entity is Base && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var currentUsername = !string.IsNullOrEmpty(_httpContextAccessor?.HttpContext?.User?.Identity?.Name)
                ? _httpContextAccessor.HttpContext.User.Identity.Name
                : "Anonymous";

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((Base)entity.Entity).createdAt = DateTime.Now;
                    ((Base)entity.Entity).createdBy = currentUsername;
                }
                else
                {
                    entity.Property("createdAt").IsModified = false;
                    entity.Property("createdBy").IsModified = false;
                    ((Base)entity.Entity).updatedAt = DateTime.Now;
                    ((Base)entity.Entity).updatedBy = currentUsername;
                }
                #region changelog
                int sessionId = 0;
                DateTime myDate1 = new DateTime(1970, 1, 9, 0, 0, 00);
                DateTime myDate2 = DateTime.Now;
                TimeSpan myDateResult;
                myDateResult = myDate2 - myDate1;
                double seconds = myDateResult.TotalSeconds;
                sessionId = Convert.ToInt32(seconds);

                string entityName = entity.Entity.GetType().Name;
                string entityState = entity.State.ToString();
                if (entityName != "UserLogHistory")
                {

                    var builder = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json");

                    var configuration = builder.Build();

                    using (var db = new SqlConnection(configuration.GetConnectionString("AppDbConnection")))
                    {
                        db.Open();

                        var entityMember = entity.Members;
                        var value = entity.Members.Count();
                        var entityinfo = entity.Entity.GetType();
                        var entityVal = entity.Entity;
                        string customAttributeName = string.Empty;
                        var fieldName = entityinfo.GetProperties();
                        for (int i = 0; i < fieldName.Count(); i++)
                        {
                            var columnName = fieldName[i].Name;
                            string colType = fieldName[i].PropertyType.ToString();
                            var custmAttribute = fieldName[i].GetCustomAttributesData();
                            if (custmAttribute.Count() >= 1)
                                customAttributeName = custmAttribute.FirstOrDefault().AttributeType.Name;

                            if (colType.Contains("RestaurantManagement") || customAttributeName == "NotMappedAttribute")
                            {

                            }
                            else
                            {

                                var valueName = entity?.Property(columnName)?.CurrentValue?.ToString();
                                valueName = valueName?.Replace("'", "''");
                                string Tmp1 = $"INSERT INTO DbChangeHistories (entityName,fieldName,fieldValue,entityState,sessionId,createdBy,createdAt) VALUES('{entityName}','{columnName}','{valueName}','{entityState}','{sessionId}','{currentUsername}','{DateTime.Now}');";
                                SqlCommand cmd1 = new SqlCommand(Tmp1, db);
                                cmd1.ExecuteScalar();
                            }

                        }
                        db.Close();
                    }

                }

                #endregion
            }
        }
        #endregion
        //#region Settings 
        //public virtual void Save()
        //{
        //    base.SaveChanges();
        //}
        //public string UserProvider
        //{
        //    get
        //    {
        //            return  !string.IsNullOrEmpty(_httpContextAccessor?.HttpContext?.User?.Identity?.Name)
        //                    ? _httpContextAccessor.HttpContext.User.Identity.Name
        //                    : "Anonymous";
        //    }
        //}

        //public Func<DateTime> TimestampProvider { get; set; } = ()
        //    => DateTime.UtcNow;
        //public override int SaveChanges()
        //{
        //    TrackChanges();
        //    return base.SaveChanges();
        //}

        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        //{
        //    TrackChanges();
        //    return await base.SaveChangesAsync(cancellationToken);
        //}

        //private void TrackChanges()
        //{


        //    foreach (var entry in this.ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
        //    {
        //        if (entry.Entity is Base)
        //        {

        //            var baseEntity = entry.Entity as Base;
        //            if (entry.State == EntityState.Added)
        //            {
        //                baseEntity.createdBy = UserProvider;//  
        //                baseEntity.createdAt = TimestampProvider();

        //            }
        //            else
        //            {

        //                baseEntity.updatedBy = UserProvider;
        //                baseEntity.updatedAt = TimestampProvider();
        //            }

        //            #region changelog
        //            int sessionId = 0;
        //            DateTime myDate1 = new DateTime(1970, 1, 9, 0, 0, 00);
        //            DateTime myDate2 = DateTime.Now;
        //            TimeSpan myDateResult;
        //            myDateResult = myDate2 - myDate1;
        //            double seconds = myDateResult.TotalSeconds;
        //            sessionId = Convert.ToInt32(seconds);

        //            string entityName = entry.Entity.GetType().Name;
        //            string entityState = entry.State.ToString();
        //            if (entityName != "UserLogHistory")
        //            {

        //                var builder = new ConfigurationBuilder()
        //                                .SetBasePath(Directory.GetCurrentDirectory())
        //                                .AddJsonFile("appsettings.json");

        //                var configuration = builder.Build();

        //                using (var db = new SqlConnection(configuration.GetConnectionString("AppDbConnection")))
        //                {
        //                    db.Open();

        //                    var entityMember = entry.Members;
        //                    var value = entry.Members.Count();
        //                    var entityinfo = entry.Entity.GetType();
        //                    var entityVal = entry.Entity;
        //                    string customAttributeName = string.Empty;
        //                    var fieldName = entityinfo.GetProperties();
        //                    for (int i = 0; i < fieldName.Count(); i++)
        //                    {
        //                        var columnName = fieldName[i].Name;
        //                        string colType = fieldName[i].PropertyType.ToString();
        //                        var custmAttribute = fieldName[i].GetCustomAttributesData();
        //                        if (custmAttribute.Count() >= 1)
        //                            customAttributeName = custmAttribute.FirstOrDefault().AttributeType.Name;

        //                        if (colType.Contains("RestaurantManagement") || customAttributeName == "NotMappedAttribute")
        //                        {

        //                        }
        //                        else
        //                        {

        //                            var valueName = entry?.Property(columnName)?.CurrentValue?.ToString();
        //                            valueName = valueName?.Replace("'", "''");
        //                            string Tmp1 = $"INSERT INTO DbChangeHistories (entityName,fieldName,fieldValue,entityState,sessionId,createdBy,createdAt) VALUES('{entityName}','{columnName}','{valueName}','{entityState}','{sessionId}','{UserProvider}','{DateTime.Now}');";
        //                            SqlCommand cmd1 = new SqlCommand(Tmp1, db);
        //                            cmd1.ExecuteScalar();
        //                        }

        //                    }
        //                    db.Close();
        //                }

        //            }

        //            #endregion

        //        }
        //    }
        //}
        //#endregion



        #region Change History
        public DbSet<DbChangeHistory> DbChangeHistories { get; set; }
        public DbSet<UserLogHistory> UserLogHistories { get; set; }
        #endregion

        #region EmployeeEntity
        public DbSet<Employee> Employees { get; set; }
        #endregion

        #region DailyFoodItemEntity
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<DailyFoodItem> DailyFoodItems { get; set; }
        #endregion

        #region GeneralTransactionEntity
        public DbSet<AdminCashTransaction> AdminCashTransactions { get; set; }
        #endregion

        #region KitchenEntity
        public DbSet<KitchenSupply> KitchenSupplies { get; set; }
        #endregion

        #region MasterDataEntity
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Gender> Genders { get; set; }
        #endregion

        #region PurchaseEntity
        public DbSet<Purchase> Purchases { get; set; }
        #endregion

        #region PuchasePayEntity
        public DbSet<BoucherPayTransaction> BoucherPayTransactions { get; set; }
        public DbSet<PurchaseBillPayment> PurchaseBillPayments { get; set; }
        #endregion 

        #region SalaryEntity
        public DbSet<SalaryStructure> SalaryStructures { get; set; }
        public DbSet<EarningSalary> EarningSalaries { get; set; }
        public DbSet<SalaryPayment> SalaryPayments { get; set; }
        public DbSet<SalaryPayRecord> SalaryPayRecords { get; set; }
        public DbSet<MonthlyDeduction> MonthlyDeductions { get; set; }
        #endregion

        #region SellEntity
        public DbSet<SellRecord> SellRecords { get; set; }
        #endregion

        #region SupplierEntity
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierDetails> SupplierDetails { get; set; }
        #endregion
    }
}
