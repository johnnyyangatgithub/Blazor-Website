using System;
using Stripe.Checkout;

namespace BlazorEcommerceWebsite.Server.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<Session> CreateCheckoutSession();
    }
}

