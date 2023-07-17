using System;
namespace BlazorEcommerceWebsite.Client.Services.OrderService
{
    public interface IOrderService
    {
        Task PlaceOrder ();
        Task<List<OrderOverviewResponseDTO>> GetOrders();
    }
}

