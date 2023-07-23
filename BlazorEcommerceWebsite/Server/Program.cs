global using BlazorEcommerceWebsite.Shared;
global using Microsoft.EntityFrameworkCore;
global using BlazorEcommerceWebsite.Server.Data;
global using BlazorEcommerceWebsite.Server.Services.ProductService;
global using BlazorEcommerceWebsite.Server.Services.CategoryService;
global using BlazorEcommerceWebsite.Server.Services.CartService;
global using BlazorEcommerceWebsite.Server.Services.AuthService;
global using BlazorEcommerceWebsite.Server.Services.OrderService;
global using BlazorEcommerceWebsite.Server.Services.PaymentService;
global using BlazorEcommerceWebsite.Server.Services.AddressService;
global using BlazorEcommerceWebsite.Server.Services.ProductTypeService;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using BlazorEcommerceWebsite.Server.Services.ProductTypeService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IProductTypeService, ProductTypeService>();
builder.Services.AddAuthentication( JwtBearerDefaults.AuthenticationScheme )
    .AddJwtBearer( options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey
            (
                System.Text.Encoding.UTF8
                    .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value
            ) ),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    } );
// To inject the service
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseSwagger();
app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

// Adds the Authorization and Authorization middleware
app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

