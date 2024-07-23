using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NIC_Demo_Project.Models;
namespace NIC_Demo_Project.Context
{
    public interface IApplicationContext
    {
        DbSet<NIC_EmpMain> NIC_EmpMains { get; set; }
       
        Task<int> SaveChangesAsync();
        int SaveChanges();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
