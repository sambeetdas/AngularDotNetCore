using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.JWT;
using DM.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace DM.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        private readonly IConfiguration _iconfig;
        public JwtController(IConfiguration iConfig)
        {
            _iconfig = iConfig;
        }

        [HttpPost]
        public TokenResponseModel CreateToken([FromBody] DmJwt jwt)
        {
            string secrect = _iconfig.GetSection("Jwt").GetSection("JwtSecrect").Value;
            int algorithmKey = Convert.ToInt32(_iconfig.GetSection("Jwt").GetSection("JwtAlgKey").Value);
            string expSeconds = _iconfig.GetSection("Jwt").GetSection("JwtExpiry").Value;

            JWTModule module = new JWTModule();
            TokenRequestModel reqModel = new TokenRequestModel();
            reqModel.issuer = jwt.Issuer;
            reqModel.expiryInSeconds = expSeconds;
            var result = module.CreateToken(reqModel, secrect, algorithmKey);

            return result;

        }

    }
}
