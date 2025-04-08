using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Crm.Sdk.Messages;
using Module_4.DTO;
using Module_4.Models;

namespace Module_4.Controllers;
[ApiController]
[Route("api/auth")]

public class AuthController : Controller
{
    static List<User> UserDetails = new List<User>();

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        if (request == null) return BadRequest("Invalid User Details to register!!!!");

        if (UserDetails.Any(u => u.Email.Equals(request.Email, StringComparison.OrdinalIgnoreCase)))
            return BadRequest("User already exists with this Email Id!");

        UserDetails.Add(new User { Name = request.Name, Email = request.Email, Password = request.Password });
        return Ok("User Registered Successfully...");
    }
    [HttpGet("users")]
    public IActionResult GetAllUserDetails()
    {
        return Ok(UserDetails);
    }
}

