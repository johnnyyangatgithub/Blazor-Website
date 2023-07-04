using System;
namespace BlazorEcommerceWebsite.Server.Services.ProductService
{
	public interface IProductService
	{

		Task<ServiceResponse<List<Product>>> GetProductsAsybc();
	}
}

