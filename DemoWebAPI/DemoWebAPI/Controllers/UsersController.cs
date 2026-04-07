using DemoWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static List<User> Users = new List<User>();

        public UsersController() { }

        [HttpGet]
        public IActionResult LayTatCa()
        {
            return Ok(Users);
        }

        [HttpGet("{id}")]
        public IActionResult LayTheoId(Guid id)
        {
            var data = Users.SingleOrDefault(p => p.Id == id);
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }
    }
}
