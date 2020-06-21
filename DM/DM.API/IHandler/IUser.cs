using DM.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DM.API.IHandler
{
    public interface IUser
    {
        User AuthUser(User user);
    }
}
