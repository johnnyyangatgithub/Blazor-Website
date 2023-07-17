﻿using System;
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

