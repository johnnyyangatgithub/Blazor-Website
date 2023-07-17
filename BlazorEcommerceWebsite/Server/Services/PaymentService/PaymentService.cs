using System;
using Stripe;
using Stripe.Checkout;

namespace BlazorEcommerceWebsite.Server.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly ICartService _cartService;
        private readonly IAuthService _authService;
        private readonly IOrderService _orderService;
        public PaymentService( ICartService cartService , IAuthService authService , IOrderService orderService )
        {
            StripeConfiguration.ApiKey = "sk_test_51NUl8BL1jOYXaygsFCUfZUMKGFQFV6WRzEJEdoEcg3ddOD824lfR2ELTVCBl9LwKy9apLsQDuX5wK4znVJFTgwSp00aCZT3flu";

            _cartService = cartService;
            _authService = authService;
            _orderService = orderService;
        }

        public async Task<Session> CreateCheckoutSession()
        {
            var products = (await _cartService.GetDbCartProducts()).Data;
            var lineItems = new List<SessionLineItemOptions>();
            products.ForEach( product => lineItems.Add( new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = product.Price * 100,
                    Currency = "aud",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = product.Title,
                        Images = new List<string> { product.ImageUrl }
                    }
                },
                Quantity = product.Quantity
            } ) );

            var options = new SessionCreateOptions
            {
                CustomerEmail = _authService.GetUserEmail(),
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "https://localhost:7164/order-success",
                CancelUrl = "https://localhost:7164/cart"
            };

            var service = new SessionService();
            Session session = service.Create( options );
            return session;
        }
    }
}

