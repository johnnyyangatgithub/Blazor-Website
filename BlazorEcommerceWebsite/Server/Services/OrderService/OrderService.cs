using System;
using System.Security.Claims;

namespace BlazorEcommerceWebsite.Server.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly ICartService _cartService;
        private readonly IAuthService _authService;
        public OrderService( DataContext context, ICartService cartService, IAuthService authService )
        {
            _context = context;
            _cartService = cartService;
            _authService = authService;
        }

        public async Task<ServiceResponse<List<OrderOverviewResponseDTO>>> GetOrders()
        {
            var response = new ServiceResponse<List<OrderOverviewResponseDTO>>();
            var orders = await _context.Orders
                .Include( o => o.OrderItems )
                .ThenInclude( OrderItem => OrderItem.Product )
                .Where( o => o.UserId == _authService.GetUserId() )
                .OrderByDescending( o => o.OrderDate )
                .ToListAsync();

            var orderResponse = new List<OrderOverviewResponseDTO>();
            orders.ForEach( o => orderResponse.Add( new OrderOverviewResponseDTO
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                TotalPrice = o.TotalPrice,
                Product = o.OrderItems.Count > 1 ?
                    $"{o.OrderItems.First().Product.Title} and" +
                    $"{o.OrderItems.Count - 1} more..." :
                    o.OrderItems.First().Product.Title,
                ProductImageUrl = o.OrderItems.First().Product.ImageUrl
            } ) );

            response.Data = orderResponse;
            return response;
        }

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
                UserId = _authService.GetUserId(),
                OrderDate = DateTime.Now,
                TotalPrice = totalPrice,
                OrderItems = orderItems
            };

            _context.Orders.Add( order );

            _context.CartItems.RemoveRange( _context.CartItems
                .Where( ci => ci.UserId == _authService.GetUserId() ) );
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }
    }
}

