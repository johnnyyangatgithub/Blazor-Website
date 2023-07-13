using System;
using System.Security.Claims;

namespace BlazorEcommerceWebsite.Server.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly ICartService _cartService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrderService( DataContext context, ICartService cartService, IHttpContextAccessor httpContextAccessor )
        {
            _context = context;
            _cartService = cartService;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId () => int.Parse( _httpContextAccessor.HttpContext.User.FindFirstValue( ClaimTypes.NameIdentifier ) );

        public async Task<ServiceResponse<bool>> PlaceOrder()
        {
            var products = (await _cartService.GetDbCartProducts()).Data;
            decimal totalPrice = 0;
            products.ForEach( product => totalPrice += product.Price * product.Quantity );

            var orderItems = new List<OrderItem>();
            products.ForEach( Product => orderItems.Add( new OrderItem
            {
                ProductId = Product.ProductId,
                ProductTypeId = Product.ProductTypeId,
                Quantity = Product.Quantity,
                TotalPrice = Product.Price * Product.Quantity
            } ) );

            var order = new Order
            {
                UserId = GetUserId(),
                OrderDate = DateTime.Now,
                TotalPrice = totalPrice,
                OrderItems = orderItems
            };

            _context.Orders.Add( order );
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }
    }
}

