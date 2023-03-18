using eshop.Domain.Customers.Contracts;
using eshop.Domain.Orders.Contracts;
using eshop.Domain.Products.Contracts;
using eshop.Persistence.Database;
using eshop.Persistence.Repositories.Customers;
using eshop.Persistence.Repositories.Orders;
using eshop.Persistence.Repositories.Products;
using Shared.Paging;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services
builder.Services.AddSingleton<IDbConnectionFactory>(new SqlConnectionFactory(builder.Configuration));

// Repos
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICustomerRepostiory, CustomerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<PaginationMiddleware>();

app.Run();
