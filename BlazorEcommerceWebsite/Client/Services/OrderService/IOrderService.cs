using System;
namespace BlazorEcommerceWebsite.Client.Services.OrderService
{
    public interface IOrderService
    {
        Task<string> PlaceOrder ();
        Task<List<OrderOverviewResponseDTO>> GetOrders();
        Task<OrderDetailsResponse> GetOrderDetails(int orderId);
    }
}

