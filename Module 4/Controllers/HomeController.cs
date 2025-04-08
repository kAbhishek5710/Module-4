using Microsoft.AspNetCore.Mvc;

namespace Module_4.Controllers;
[ApiController]
[Route("api/[Controller]")]

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    
}

