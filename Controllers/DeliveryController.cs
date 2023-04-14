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
    public class DeliveryController : Controller
    {

        [Route("api/[controller]")]
        [ApiController]

        public class DeliveryControllerr : ControllerBase
        {
            private IDeliveryService _deliveryService;
            public DeliveryControllerr(IDeliveryService deliveryService)
            {
                _deliveryService = deliveryService;
            }
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                return Ok(await _deliveryService.GetAll());
            }
            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var result = await _deliveryService.GetById(id);
                var response = new GetDeliveryResponse()
                {
                    Id = result.Id,
                    DeliveryStatus = result.DeliveryStatus,
                    DeliveryPrice = result.DeliveryPrice,
                    UserId = result.UserId,
                    GoodsId = result.GoodsId,
                };
                return Ok(response);
            }

            /// <summary>
            /// Создание нового delivery
            /// </summary>
            /// <remarks>
            /// Пример запроса:
            ///
            /// POST /Todo
            /// {
            /// "DeliveryStatus" : "aaa",
            /// "DeliveryPrice" : "1",
            /// "UserId" : "1",
            /// "GoodsId" : "1"
            /// }
            ///
            /// </remarks>
            /// <param name="model">Delivery</param>
            /// <returns></returns>
            // POST api/<DeliveriesController>
            [HttpPost]
            public async Task<IActionResult> Add(CreatDeliveryRequest request)
            {
                var DeliveryDto = request.Adapt<Delivery>();
                await _deliveryService.Create(DeliveryDto);
                return Ok();
            }
            /// <summary>
            /// Обновление delivery
            /// </summary>
            /// <remarks>
            
            ///
            /// </remarks>
            /// <param name="model">Delivery</param>
            /// <returns></returns>
            // PUT api/<DeliveriesController>
            [HttpPut]
            public async Task<IActionResult> Update(Delivery delivery)
            {
                await _deliveryService.Update(delivery);
                return Ok();
            }
            /// <summary>
            /// Удаление delivery
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
            /// <param name="model">Delivery</param>
            /// <returns></returns>
            // DELETE api/<DeliveriesController>
            [HttpDelete]
            public async Task<IActionResult> Delete(int id)
            {
                await _deliveryService.Delete(id);
                return Ok();
            }
        }
    }
}
