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

        [HttpGet("Admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetAdminProducts()
        {
            var result = await _productService.GetAdminProducts();
            return Ok( result );
        }

        [HttpPost, Authorize( Roles = "Admin" )]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> CreateProduct( Product product )
        {
            var result = await _productService.CreateProduct( product );
            return Ok( result );
        }

        [HttpPut, Authorize( Roles = "Admin" )]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> UpdateProduct( Product product )
        {
            var result = await _productService.UpdateProduct( product );
            return Ok( result );
        }

        [HttpDelete( "{productId}" ), Authorize( Roles = "Admin" )]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteProduct( int productId )
        {
            var result = await _productService.DeleteProduct( productId );
            return Ok( result );
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

        [HttpGet( "search/{searchText}/{page}" )]
        public async Task<ActionResult<ServiceResponse<ProductSearchResultDTO>>> SearchProducts ( string searchText, int page)
        {
            var result = await _productService.SearchProducts( searchText, page );
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

