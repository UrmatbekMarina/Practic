using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using BackendAPI.Contracts.User;
using BackendAPI.Contracts;
using Mapster;

//using BusinessLogic.Interfaces;
//using DataAccess.Models;

namespace BackendAPI.Controllers
{
    

        [Route("api/[controller]")]
        [ApiController]

        public class CustomerController : ControllerBase
        {
            private ICustomerService _customerService;
            public CustomerController(ICustomerService customerService)
            {
                _customerService = customerService;
            }
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                return Ok(await _customerService.GetAll());
            }
            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var result = await _customerService.GetById(id);
                var response = new GetCustomerResponse()
                {
                    Id = result.Id,
                    Name = result.Name,
                };
                return Ok(response);
            }

            /// <summary>
            /// Создание нового Customer
            /// </summary>
            /// <remarks>
            /// Пример запроса:
            ///
            /// POST /Todo
            /// {
            /// "Id" : "1",
            /// "Name" : "aaa"
            /// }
            ///
            /// </remarks>
            /// <param name="model">Customer</param>
            /// <returns></returns>
            // POST api/<CustomersController>
            [HttpPost]
            public async Task<IActionResult> Add(CreateUserRequest request)
            {
                var CustomerDto = request.Adapt<Customer>();
                await _customerService.Create(CustomerDto);

                return Ok();
            }

        /// <summary>
        /// Обновление Customer
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="model">Customer</param>
        /// <returns></returns>
        // PUT api/<CustomersController>
        [HttpPut]
            public async Task<IActionResult> Update(Customer customer)
            {
                await _customerService.Update(customer);
                return Ok();
            }

        /// <summary>
        /// Удаление Customer
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// DELETE /Todo
        /// {
        /// "Id" : "1"
        /// }
        ///
        /// </remarks>
        /// <param name="model">Customer</param>
        /// <returns></returns>
        // DELETE api/<CustomersController>
        [HttpDelete]
            public async Task<IActionResult> Delete(int id)
            {
                await _customerService.Delete(id);
                return Ok();
            }
        }
    
}
