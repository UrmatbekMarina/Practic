using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Interfaces;
using DataAccess.Models;

namespace BackendAPI.Controllers
{
    public class UserController : Controller
    {
        [Route("api/[controller]")]
        [ApiController]
        public class UserControllerr : ControllerBase
        {
            private IUserService _userService;
            public UserControllerr(IUserService userService)
            {
                _userService = userService;
            }
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                return Ok(await _userService.GetAll());
            }
            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                return Ok(await _userService.GetById(id));
            }
            [HttpPost]
            public async Task<IActionResult> Add(User user)
            {
                await _userService.Create(user);
                return Ok();
            }
            [HttpPut]
            public async Task<IActionResult> Update(User user)
            {
                await _userService.Update(user);
                return Ok();
            }
            [HttpDelete]
            public async Task<IActionResult> Delete(int id)
            {
                await _userService.Delete(id);
                return Ok();
            }
        }
    }
}
