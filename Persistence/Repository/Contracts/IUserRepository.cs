using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Contracts
{
   public interface IUserRepository
   {
        void AddUser(User user);
        IEnumerable<User> GetUsers();
        bool DeleteUser(long userId);
        User GetUser(long Id);

    }
}
