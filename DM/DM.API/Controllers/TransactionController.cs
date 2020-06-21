using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DM.API.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DM.API.Controllers
{
    [ServiceFilter(typeof(JwtFilter))]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
    }
}