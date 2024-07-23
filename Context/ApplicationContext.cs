using Microsoft.EntityFrameworkCore;

namespace NIC_Demo_Project.Context
{
    //using FinancialAccountsAPI.Models;
    using Microsoft.EntityFrameworkCore.Storage;
    using NIC_Demo_Project.Models;

    public partial class ApplicationContext : DbContext, IApplicationContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {

        }

        public virtual DbSet<NIC_EmpMain> NIC_EmpMains { get; set; }

       

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return base.SaveChanges();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await base.Database.BeginTransactionAsync();
        }

    }
}
