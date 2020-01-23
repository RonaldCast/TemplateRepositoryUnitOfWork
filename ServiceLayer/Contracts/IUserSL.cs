using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Contracts
{
    public interface IUserSL
    {
        User UpsertUser(User user);
        void AddUser(User user);
        IEnumerable<User> GetUsers();
        bool DeleteUser(long userId);
        User GetUser(long Id);
    }
}
