using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.JWT;
using Auth.JWT.Model;
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
            string algorithmKey = _iconfig.GetSection("Jwt").GetSection("JwtAlgKey").Value.ToString();
            string expSeconds = _iconfig.GetSection("Jwt").GetSection("JwtExpiry").Value;

            JWTModule module = new JWTModule();
            TokenRequestModel reqModel = new TokenRequestModel();
            reqModel.Issuer = jwt.Issuer;
            reqModel.ExpiryInSeconds = expSeconds;
            var result = module.CreateToken(reqModel, secrect, algorithmKey);

            return result;

        }

    }
}
