using AppartmentServiceBE.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AppartmentServiceBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            var user = _context.UserTable.FirstOrDefault(u => u.userName == loginRequest.UserName && u.password == loginRequest.Password);
            if (user == null)
            {
                ModelState.AddModelError("UserName", "Invalid Username");
                return BadRequest(ModelState);
            }
            if (!IsPasswordValid(user.password, loginRequest.Password))
            {
                ModelState.AddModelError("Password", "Invalid Password");
            }
            return Ok(user);
        }
        private bool IsPasswordValid(string storedPassword, string enteredPassword)
        {
            return storedPassword == enteredPassword;
        }





    }
    public class LoginRequest
    {







        [Required(ErrorMessage = "username is required")]
        public string UserName { get; set; }





        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
