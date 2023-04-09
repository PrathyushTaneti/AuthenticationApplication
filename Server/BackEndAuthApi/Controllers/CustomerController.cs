using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IEnumerable<string> GetCustomers() => new string[] { "Abdul Rahman" };
    }    
}
