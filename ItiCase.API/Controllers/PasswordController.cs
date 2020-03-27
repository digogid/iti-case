using Microsoft.AspNetCore.Mvc;
using ItiCaseAPI.Helper;

namespace ItiCaseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordController : ControllerBase
    {
        [HttpGet("isValid/{password?}")]
        public IActionResult isValid(string password = "")
        {
            bool isValid = Password.IsValid(password);
            return Ok(isValid);
        }
    }
}
