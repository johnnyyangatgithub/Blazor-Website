using System;
namespace BlazorEcommerceWebsite.Server.Services.CartService
{
    public interface ICartService
    {
        Task<ServiceResponse<List<CartProductResponseDTO>>> GetCartProducts (List<CartItem> cartItems);
    }
}

