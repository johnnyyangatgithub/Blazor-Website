using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerceWebsite.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController ( ICategoryService categoryService )
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> GetCategories ()
        {
            var result = await _categoryService.GetCategories();
            return Ok( result );
        }

        /// <summary>
        /// Create a category object.
        /// </summary>
        /// <param name="category">The category object.</param>
        /// <returns>The ObjectResult with status code.</returns>
        [HttpPost( "admin" ), Authorize( Roles = "Admin" )]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> AddCategory( Category category )
        {
            var result = await _categoryService.AddCategory( category );
            return Ok( result );
        }

        /// <summary>
        /// Read a category object.
        /// </summary>
        /// <returns>The ObjectResult with status code.</returns>
        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> GetAdminCategories()
        {
            var result = await _categoryService.GetAdminCategories();
            return Ok( result );
        }

        /// <summary>
        /// Delete a category from database.
        /// </summary>
        /// <param name="id">The id of category that needs to be deleted.</param>
        /// <returns>The ObjectResult with status code.</returns>
        [HttpDelete( "admin/{id}" ), Authorize( Roles = "Admin" )]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategory( id );
            return Ok( result );
        }

        /// <summary>
        /// Update a category with a category object.
        /// </summary>
        /// <param name="category">The category object.</param>
        /// <returns>The ObjectResult with status code.</returns>
        [HttpPut( "admin" ), Authorize( Roles = "Admin" )]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> UpdateCategory( Category category )
        {
            var result = await _categoryService.UpdateCategory( category );
            return Ok( result );
        }
    }
}

