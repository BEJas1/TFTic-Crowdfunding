using API.Crowdfunding.Models;
using BLL.Crowdfunding.Entities;
using COMMON.Crowdfunding.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Crowdfunding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserRepository<User, Guid> _userRepository;

        public AuthController(IUserRepository<User, Guid> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("Login")]
        public IActionResult Login(UserLogin login)
        {
            if (login.Email is null || login.Password is null) return BadRequest();
            try
            {
                User? loggedIn = _userRepository.Login(login.Email, login.Password);
                return loggedIn is null ? Unauthorized() : Ok(loggedIn);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        [HttpPost("Register")]
        public IActionResult Register(UserRegister register)
        {
            if (register.Email is null || register.Password is null || register.LastName is null || register.FirstName is null) return BadRequest();

            try
            {
                Guid id = _userRepository.Register(new User()
                {
                    Email = register.Email,
                    Password = register.Password,
                    FirstName = register.FirstName,
                    LastName = register.LastName
                });

                return id == Guid.Empty ? BadRequest() : Ok(id);
            } 
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
