using System;
namespace BlazorEcommerceWebsite.Server.Services.ProductTypeService
{
    public interface IProductTypeService
    {
        Task<ServiceResponse<List<ProductType>>> GetProductTypes();
    }
}

