global using BlazorEcommerceWebsite.Shared;
global using System.Net.Http.Json;
global using BlazorEcommerceWebsite.Client.Services.ProductService;
global using BlazorEcommerceWebsite.Client.Services.CategoryService;
global using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorEcommerceWebsite.Client;
using Blazored.LocalStorage;
using BlazorEcommerceWebsite.Client.Services.CartService;
using BlazorEcommerceWebsite.Client.Services.AuthService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAuthService, AuthService>();
//Related to the Microsoft.AspNetCore.Components.Authorization package
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();


await builder.Build().RunAsync();

