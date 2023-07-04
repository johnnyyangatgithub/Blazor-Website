﻿using System;

namespace BlazorEcommerceWebsite.Server.Services.ProductService
{
	public class ProductService : IProductService
	{
        private readonly DataContext _context;
        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsybc()
        {

            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products.ToListAsync()
            };

            return response;
        }
    }
}

