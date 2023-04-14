using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using BackendAPI.Contracts;
using Mapster;

//using BusinessLogic.Interfaces;
//using DataAccess.Models;

namespace BackendAPI.Controllers
{
  
        [Route("api/[controller]")]
        [ApiController]

        public class ManufacturerController : ControllerBase
        {
            private IManufacturerService _manufacturerService;
            public ManufacturerController(IManufacturerService manufacturerService)
            {
                _manufacturerService = manufacturerService;
            }
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                return Ok(await _manufacturerService.GetAll());
            }
            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var result = await _manufacturerService.GetById(id);
                var response = new GetManufacturerResponse()
                {
                    Id = result.Id,
                    Name = result.Name,
                    Inn = result.Inn,
                    Location = result.Location,
                };
                return Ok(response);
            }

            /// <summary>
            /// Создание нового Manufacturer
            /// </summary>
            /// <remarks>
            /// Пример запроса:
            ///
            /// POST /Todo
            /// {
            /// "Id" : "1",
            /// "Name" : "aaa",
            /// "Inn" : "1",
            /// "Location" : "aaa"
            /// }
            ///
            /// </remarks>
            /// <param name="model">Manufacturer</param>
            /// <returns></returns>
            // POST api/<ManufacturersController>
            [HttpPost]
            public async Task<IActionResult> Add(CreateManufacturerRequest request)
            {
                var ManufacturerDto = request.Adapt<Manufacturer>();
                await _manufacturerService.Create(ManufacturerDto);
                return Ok();
            }
        /// <summary>
        /// Обновление Manufacturer
        /// </summary>
        /// <remarks>      
        /// </remarks>
        /// <param name="model">Manufacturer</param>
        /// <returns></returns>
        // PUT api/<ManufacturersController>
        [HttpPut]
            public async Task<IActionResult> Update(Manufacturer manufacturer)
            {
                await _manufacturerService.Update(manufacturer);
                return Ok();
            }
        /// <summary>
        /// Удаление Manufacturer
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
        /// <param name="model">Manufacturer</param>
        /// <returns></returns>
        // DELETE api/<ManufacturersController>
        [HttpDelete]
            public async Task<IActionResult> Delete(int id)
            {
                await _manufacturerService.Delete(id);
                return Ok();
            }
        }
    
}
