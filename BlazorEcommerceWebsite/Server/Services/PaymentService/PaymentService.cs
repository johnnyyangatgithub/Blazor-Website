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

        const string secret = "whsec_cdc67a67ae8377362e66efcbc067b7082788bab65513ea4fe59502f5538a39d8";

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
                ShippingAddressCollection =
                    new SessionShippingAddressCollectionOptions
                    {
                        AllowedCountries = new List<string> { "AU" }
                    },

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

        public async Task<ServiceResponse<bool>> FulfillOrder(HttpRequest request)
        {
            var json = await new StreamReader( request.Body ).ReadToEndAsync();
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                    json,
                    request.Headers["Stripe-Signature"],
                    secret
                    );

                if(stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    var session = stripeEvent.Data.Object as Session;
                    var user = await _authService.GetUserByEmail( session.CustomerEmail );
                    await _orderService.PlaceOrder( user.Id );
                }

                return new ServiceResponse<bool> { Data = true };
            }
            catch( Exception ex )
            {
                return new ServiceResponse<bool> { Data = false, Success = false, Message = ex.Message };
            }
        }
    }
}

