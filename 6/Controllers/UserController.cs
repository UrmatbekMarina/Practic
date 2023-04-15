using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using BackendAPI.Contracts.User;
//using BackendAPI.Contracts;
using Mapster;
using BusinessLogic.Services;

//using BusinessLogic.Interfaces;
//using DataAccess.Models;

namespace BackendAPI.Controllers
{
   

        [Route("api/[controller]")]
        [ApiController]

        public class UserController : ControllerBase
        {
            private IUserService _userService;
            public UserController(IUserService userService)
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
                var result = await _userService.GetById(id);
                var response = new GetUserResponse()
                {
                    Id = result.Id,
                    UserName = result.UserName,
                    UserRole = result.UserRole,
                    UserPassword = result.UserPassword,
                    UserAddress = result.UserAddress,
                };
                return Ok(response);
            }

            /// <summary>
            /// Создание нового пользователя
            /// </summary>
            /// <remarks>
            /// Пример запроса:
            ///
            /// POST /Todo
            /// {
            /// "UserName" : "aaa",
            /// "UserRole" : "aaa",
            /// "UserPassword" : "aaa",
            /// "UserAddress" : "aaa"
            /// }
            ///
            /// </remarks>
            /// <param name="model">Пользователь</param>
            /// <returns></returns>
            // POST api/<UsersController>
            [HttpPost]
            public async Task<IActionResult> Add(CreateUserRequest request)
            {
                var UserDto = request.Adapt<User>();
                await _userService.Create(UserDto);
                //var UserDto = new User()
                //{
                //    UserName = request.UserName,
                //    UserRole = request.UserRole,
                //    UserPassword = request.UserPassword,
                //    UserAddress = request.UserAddress,
                //};
                //await _userService.Create(UserDto);
                return Ok();
            }
        /// <summary>
        /// Обновление пользователей
        /// </summary>
        /// <remarks>    
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        // PUT api/<UsersController>
        [HttpPut]
            public async Task<IActionResult> Update(User user)
            {
                await _userService.Update(user);
                return Ok();
            }

            /// <summary>
            /// Удаление пользователя
            /// </summary>
            /// <remarks>
            /// Пример запроса:
            ///
            /// DELETE /Todo
            /// {
            /// "ID" : "01",
            /// }
            ///
            /// </remarks>
            /// <param name="model">Пользователь</param>
            /// <returns></returns>
            // DELETE api/<UsersController>
            [HttpDelete]
            public async Task<IActionResult> Delete(int id)
            {
                await _userService.Delete(id);
                return Ok();
            }
        }
    
}
