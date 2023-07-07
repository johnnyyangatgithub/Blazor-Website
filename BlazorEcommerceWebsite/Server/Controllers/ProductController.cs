using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerceWebsite.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        /// <summary>
        /// Get data from database by using DI
        /// </summary>
        /// <param name="context">The context returned from database.</param>
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            var result = await _productService.GetProductsAsync();
            return Ok(result);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int productId)
        {
            var result = await _productService.GetProductAsync(productId);
            return Ok(result);
        }

        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategory ( string categoryUrl )
        {
            var result = await _productService.GetProductsByCategory( categoryUrl );
            return Ok( result );
        }

        [HttpGet( "search/{searchText}" )]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> SearchProducts ( string searchText)
        {
            var result = await _productService.SearchProducts( searchText );
            return Ok( result );
        }

        [HttpGet( "searchsuggestions/{searchText}" )]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductSearchSuggestions ( string searchText )
        {
            var result = await _productService.GetProductSearchSuggestions( searchText );
            return Ok( result );
        }

        [HttpGet( "featured" )]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetFeaturedProducts ()
        {
            var result = await _productService.GetFeaturedProducts();
            return Ok( result );
        }
    }
}

