using Auth.JWT;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DM.API.Filters
{
    public class JwtFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {           
            if (!String.IsNullOrWhiteSpace(context.HttpContext.Request?.Headers["DMAUTH"]))
            {
                string token = System.Uri.UnescapeDataString(context.HttpContext.Request?.Headers["DMAUTH"]);
                string secrect = "F4760D";

                JWTModule module = new JWTModule();
                ValidateModel validateModel = new ValidateModel();
                validateModel.issuer = "admin@abc.com";

                var verifyResult = module.VerifyToken(token, secrect, validateModel);

                if (verifyResult.Status != "OK")
                {
                    context.Result = new BadRequestObjectResult(verifyResult.Content);
                }
            }
            else
            {
                context.Result = new BadRequestObjectResult("Authorization Token is missing from the Request ");
            }

           
        }
    }
}
