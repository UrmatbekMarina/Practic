using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using BackendAPI.Contracts;
using BackendAPI.Contracts;
using Mapster;

//using BusinessLogic.Interfaces;
//using DataAccess.Models;

namespace BackendAPI.Controllers
{
    

        [Route("api/[controller]")]
        [ApiController]

        public class GoodController : ControllerBase
        {
            private IGoodService _goodService;
            public GoodController(IGoodService goodService)
            {
                _goodService = goodService;
            }
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                return Ok(await _goodService.GetAll());
            }
            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var result = await _goodService.GetById(id);
                var response = new GetGoodResponse()
                {
                    Id = result.Id,
                    Name = result.Name,
                    CustomerId = result.CustomerId,
                    ManufacturerId = result.ManufacturerId,
                    Value = result.Value,
                    Price = result.Price,
                    Discount = result.Discount,
                };
                return Ok(response);
            }

            /// <summary>
            /// Создание нового Good
            /// </summary>
            /// <remarks>
            /// Пример запроса:
            ///
            /// POST /Todo
            /// {
            /// "Name" : "aaa",
            /// "CustomerId" : "aaa",
            /// "ManufacturerId" : "aaa",
            /// "Value" : "aaa",
            /// "Price" : "aaa",
            /// "Discount" : "aaa"
            /// }
            ///
            /// </remarks>
            /// <param name="model">Good</param>
            /// <returns></returns>
            // POST api/<GoodsController>
            [HttpPost]
            public async Task<IActionResult> Add(CreateGoodRequest request)
            {
                var GoodDto = request.Adapt<Good>();
                await _goodService.Create(GoodDto);
                return Ok();
            }
        /// <summary>
        /// Обновление Good
        /// </summary>
        /// <remarks>     
        /// </remarks>
        /// <param name="model">Good</param>
        /// <returns></returns>
        // PUT api/<GoodsController>
        [HttpPut]
            public async Task<IActionResult> Update(Good good)
            {
                await _goodService.Update(good);
                return Ok();
            }
        /// <summary>
        /// Удаление Good
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
        /// <param name="model">Good</param>
        /// <returns></returns>
        // DELETE api/<GoodsController>

        [HttpDelete]
            public async Task<IActionResult> Delete(int id)
            {
                await _goodService.Delete(id);
                return Ok();
            }
        }
    
}
