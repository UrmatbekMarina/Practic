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

        public class CategoryController : ControllerBase
        {
            private ICategoryService _categoryService;
            public CategoryController(ICategoryService categoryService)
            {
                _categoryService = categoryService;
            }
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                return Ok(await _categoryService.GetAll());
            }
            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {

                var result = await _categoryService.GetById(id);
                var response = new GetCategoryResponse()
                {
                    Id = result.Id,
                    CategoryName = result.CategoryName,
                    GoodsId = result.GoodsId,
                };
                return Ok(response);
            }

            /// <summary>
            /// Создание новой категории
            /// </summary>
            /// <remarks>
            /// Пример запроса:
            ///
            /// POST /Todo
            /// {
            /// "id" : "11",
            /// "CategoryName" : "qq",
            /// "GoodsId" : "1"
            /// }
            ///
            /// </remarks>
            /// <param name="model">Категории</param>
            /// <returns></returns>
            // POST api/<CategoriesController>
            [HttpPost]
            public async Task<IActionResult> Add(Category request)
            {
                var CategoryDto = request.Adapt<Category>();
                await _categoryService.Create(CategoryDto);
                return Ok();
            }
        /// <summary>
        /// Обновление категории
        /// </summary>
        /// <remarks>
        /// 
        ///
        /// </remarks>
        /// <param name="model">Категории</param>
        /// <returns></returns>
        // PUT api/<CategoriesController>
        [HttpPut]
            public async Task<IActionResult> Update(Category category)
            {
                await _categoryService.Update(category);
                return Ok();
            }
        /// <summary>
        /// Удаление  категории
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// DELETE /Todo
        /// {
        /// "id" : "11"
        /// }
        ///
        /// </remarks>
        /// <param name="model">Категории</param>
        /// <returns></returns>
        // DELETE api/<CategoriesController>

        [HttpDelete]
            public async Task<IActionResult> Delete(int id)
            {
                await _categoryService.Delete(id);
                return Ok();
            }
        }
    
}
