using System;
namespace BlazorEcommerceWebsite.Server.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<Category>>> GetCategories ();
    }
}

