using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerceWebsite.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProductTypeController : Controller
    {
        private readonly IProductTypeService _productTypeService;
        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ProductType>>>> GetProductTypes()
        {
            var response = await _productTypeService.GetProductTypes();
            return Ok( response );
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<ProductType>>>> AddProductType(ProductType productType)
        {
            var response = await _productTypeService.AddProductType( productType );
            return Ok( response );
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<ProductType>>>> UpdateProductType( ProductType productType )
        {
            var response = await _productTypeService.UpdateProductType( productType );
            return Ok( response );
        }
    }
}

