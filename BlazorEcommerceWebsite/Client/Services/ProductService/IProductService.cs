using System;
namespace BlazorEcommerceWebsite.Client.Services.ProductService
{
	public interface IProductService
	{
		List<Product> Products { get; set; }
		Task GetProducts();
	}
}

