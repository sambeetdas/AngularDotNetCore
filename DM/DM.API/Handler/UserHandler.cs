using DM.API.IHandler;
using DM.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DM.API.Handler
{
    public class UserHandler : IUser
    {
        public User AuthUser(User user)
        {
            if (user.Email == "admin@abc.com" && user.Password == "admin")
            {
                return user;
            }

            return null;
        }
    }
}
