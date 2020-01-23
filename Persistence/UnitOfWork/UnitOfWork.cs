using DomainModel;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence.Contracts;
using Persistence.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepository _User;

        private IProductRepository _Product;


        private readonly AppDbContext _dbContext;

        private IDbContextTransaction _dbTransaction;

        public UnitOfWork(AppDbContext dbContext)
        {
         
            this._dbContext = dbContext;
        }


        public IUserRepository User
        {
            get
            {
                if (this._User == null)
                {
                    this._User = new UserRepository(_dbContext);
                }
                return this._User;
            }
        }
        public IProductRepository Product
        {
            get
            {
                if (this._Product == null)
                {
                    this._Product = new ProductRepository(_dbContext);
                }
                return this._Product;
            }
        }

        public void Commit()
        {
            _dbTransaction.Commit();
        }

        public void CreateTransaction()
        {
            _dbTransaction = _dbContext.Database.BeginTransaction();
        }

        public void Rollback()
        {
            _dbTransaction.Rollback();
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void DisposeAsync()
        {
            _dbContext.DisposeAsync();
        }

        public async Task CommitAsync()
        {
            await _dbTransaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await _dbTransaction.RollbackAsync();
        }
    }

}

