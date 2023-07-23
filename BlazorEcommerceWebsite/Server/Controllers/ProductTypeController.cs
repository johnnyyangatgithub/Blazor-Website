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

        public async Task<ActionResult<ServiceResponse<List<ProductType>>>> GetProductTypes()
        {
            var response = await _productTypeService.GetProductTypes();
            return Ok( response );
        }
    }
}

