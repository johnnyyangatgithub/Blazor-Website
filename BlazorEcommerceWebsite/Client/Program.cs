global using BlazorEcommerceWebsite.Shared;
global using System.Net.Http.Json;
global using BlazorEcommerceWebsite.Client.Services.ProductService;
global using BlazorEcommerceWebsite.Client.Services.CategoryService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorEcommerceWebsite.Client;
using Blazored.LocalStorage;
using BlazorEcommerceWebsite.Client.Services.CartService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();


await builder.Build().RunAsync();

