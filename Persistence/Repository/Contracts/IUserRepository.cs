using DomainModel.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contracts
{
   public interface IUserRepository
   {
        void AddUser(User user);
        IEnumerable<User> GetUsers();
        bool DeleteUser(long userId);
        User GetUser(long Id);
        Task<ResponseMessage<bool>> Create(CreateAccount model);

    }
}
