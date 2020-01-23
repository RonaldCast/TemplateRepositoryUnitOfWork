using Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.UnitOfWork
{
    public interface IUnitOfWork
    {
        // Repository Contract
        IUserRepository User { get; }
        IProductRepository Product { get; }

        // Method for created 
        void CreateTransaction();
        void Commit();
        void Rollback();
        int Save();
        Task<int> SaveAsync();
        Task CommitAsync();

        Task RollbackAsync();
    }
}
