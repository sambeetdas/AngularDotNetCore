using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DM.API.IHandler;
using DM.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DM.API.Filters;

namespace DM.API.Controllers
{    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }


        [HttpPost]
        public User Authenticate([FromBody] User user)
        {
            var result = _user.AuthUser(user);
            return result;
        }
    }
}