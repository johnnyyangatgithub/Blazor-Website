using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerceWebsite.Server.Controllers
{
    [ApiController]
    [Route( "api/[controller]" )]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public CartController ( ICartService cartService )
        {
            _cartService = cartService;
        }

        [HttpPost( "products" )]
        public async Task<ActionResult<ServiceResponse<List<CartProductResponseDTO>>>> GetCartProducts ( List<CartItem> cartItems )
        {
            var result = await _cartService.GetCartProducts( cartItems );
            return Ok( result );
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<CartProductResponseDTO>>>> StoreCartItems ( List<CartItem> cartItems )
        {
            var result = await _cartService.StoreCartItems( cartItems );
            return Ok( result );
        }

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<bool>>> AddToCart ( CartItem cartItem )
        {
            var result = await _cartService.AddToCart( cartItem );
            return Ok( result );
        }

        [HttpPut( "update-quantity" )]
        public async Task<ActionResult<ServiceResponse<bool>>> UpdateQuantity ( CartItem cartItem )
        {
            var result = await _cartService.UpdateQuantity( cartItem );
            return Ok( result );
        }

        [HttpGet( "count" )]
        public async Task<ActionResult<ServiceResponse<int>>> GetCartItemsCount()
        {
            return await _cartService.GetCartItemsCount();
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CartProductResponseDTO>>>> GetDbCartProducts()
        {
            var result = await _cartService.GetDbCartProducts();
            return Ok( result );
        }
    }
}

