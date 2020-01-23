using DomainModel.Models;
using Persistence.UnitOfWork;
using ServiceLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
   public class UserSL : IUserSL
    {

        private readonly IUnitOfWork uow;

        public UserSL(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void AddUser(User user)
        {
            uow.User.AddUser(user);
        }

        public bool DeleteUser(long userId)
        {
            uow.User.DeleteUser(userId);
            uow.Save();
            return true;
        }

        public User GetUser(long Id)
        {
            if (Id <= default(long))
                throw new ArgumentException("Invalid id");

            return uow.User.GetUser(Id);
        }

        public IEnumerable<User> GetUsers()
        {
            return uow.User.GetUsers();
        }

        public User UpsertUser(User user)
        {
            if (user == null)
                throw new ArgumentException("Invalid user");

            if (string.IsNullOrWhiteSpace(user.Name))
                throw new ArgumentException("Invalid user name");

            var _user = uow.User.GetUser(user.Id);
            if (_user == null)
            {
                _user = new User
                {
                    Name = user.Name
                };
                uow.User.AddUser(_user);
            }
            else
            {
                _user.Name = user.Name;
            }

            uow.Save();

            return _user;
        }
    }
}
