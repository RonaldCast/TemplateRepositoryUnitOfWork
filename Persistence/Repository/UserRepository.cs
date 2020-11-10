using DomainModel;
using DomainModel.Models;
using DTO;
using Microsoft.AspNetCore.Identity;
using Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public UserRepository(AppDbContext dbContext, UserManager<AppUser> userManager)
        {
           _context = dbContext;
          _userManager = userManager;
        }
        public void AddUser(User user)
        {
            _context.User.Add(user);
        }

        public bool DeleteUser(long userId)
        {
            var removed = false;
            User user = GetUser(userId);

            if (user != null)
            {
                removed = true;
                _context.User.Remove(user);
            }

            return removed;
        }

        public User GetUser(long Id)
        {
            return _context.User.Where(u => u.Id == Id).FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.User;
        }

       public async  Task<ResponseMessage<bool>> Create(CreateAccount model)
       {
            var appUser = new AppUser { Email = model.email, UserName = model.userName };
            var identity = await _userManager.CreateAsync(appUser, model.password);
            ResponseMessage<bool> resp = new ResponseMessage<bool>();

            if (!identity.Succeeded)
            {
                resp.Response = false;
                resp.Message = "Error a la hora de crear usuario";
                return resp;
            }

            var user = new User() { 
             Name = model.firstName,
             LastName = model.lastName,
             IdentityId = appUser.Id,
             UserName = model.userName

            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();


            resp.Response = true;
            resp.Message = "Se ha agregador correctamente";
            return resp;
        }



    }
}
