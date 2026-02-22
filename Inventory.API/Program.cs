using Inventory.Application.Commands.UseCases.ProductItems.CreateProductItem;
using Inventory.Application.Commands.UseCases.Products.CreateProduct;
using Inventory.Application.Commands.UseCases.Products.DiscontinueProduct;
using Inventory.Application.Commands.UseCases.Products.UpdateProduct;
using Inventory.Application.Common.UnitOfWork;
using Inventory.Application.Configuration.Mapper;
using Inventory.Application.Factory.Query;
using Inventory.Application.Factory.Query.Brands;
using Inventory.Application.Mapper;
using Inventory.Application.Mapper.Profiles;
using Inventory.Application.Queries.UseCases.Brands.PageBrands;
using Inventory.Application.Queries.UseCases.ProductItems.PageProductItemByProductId;
using Inventory.Application.Queries.UseCases.Products.GetDetailedProductInfoById;
using Inventory.Application.Queries.UseCases.Products.PageProduct;
using Inventory.Domain.Interfaces.Repositories;
using Inventory.Domain.Interfaces.Repositories.Params.Brands;
using Inventory.Domain.Interfaces.Repositories.Params.Products;
using Inventory.Infrastructure.Outbox;
using Inventory.Infrastructure.Persistence;
using Inventory.Infrastructure.Persistence.UnitOfWork;
using Inventory.Infrastructure.Repositories;
using Inventory.Infrastructure.Seeder.Abstraction;
using Inventory.Infrastructure.Seeder.Abstraction.Entity;
using Inventory.Infrastructure.Seeder.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Inventory.API",
            Version = "v1"
        });
        options.EnableAnnotations();
    }
);
// CORS
builder.Services.AddCors();

// Adding Controllers
builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Adding configuration
builder.Services.AddOptions<AutoMapperOptions>()
    .Bind(builder.Configuration.GetSection("AutoMapper"));

// Services
// AutoMapper
builder.Services.AddAutoMapper(cfg =>
{
    var autoMapperOptions = builder.Configuration.GetSection("AutoMapper").Get<AutoMapperOptions>();
    if (autoMapperOptions != null)
        cfg.LicenseKey = autoMapperOptions.LicenseKey;
}, typeof(ProductProfile), typeof(ProductItemProfile));

// Repository
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductItemRepository, ProductItemRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();

// Handlers
// Product
builder.Services.AddScoped<ProductPageableHandler>();
builder.Services.AddScoped<GetProductByIdHandler>();
builder.Services.AddScoped<CreateProductHandler>();
builder.Services.AddScoped<UpdateProductHandler>();
builder.Services.AddScoped<DiscontinueProductHandler>();
// Product Item
builder.Services.AddScoped<PageProductItemByProductIdHandler>();
builder.Services.AddScoped<CreateProductItemHandler>();

// Brands
builder.Services.AddScoped<PageBrandHandler>();

// Workers
builder.Services.AddHostedService<OutboxWorker>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Seeder
builder.Services.AddScoped<IEntitySeeder, BrandSeeder>();
builder.Services.AddScoped<IEntitySeeder, ProductSeeder>();
builder.Services.AddScoped<IEntitySeeder, ProductItemSeeder>();

// Factories
// Products
builder.Services.AddScoped<PageProductParamsFactory>();
// Product Items
builder.Services.AddScoped<PageProductItemParamsFactory>();
builder.Services.AddScoped<ProductItemsParamsFactory>();
// Brands
builder.Services.AddScoped<PageBrandsParamsFactory>();



builder.Services.AddScoped<DatabaseSeeder>();

// Database Connection
var connectionString = builder.Configuration.GetConnectionString("PgsqlDb");

// Read Connection String
builder.Services.AddDbContext<PgsqlDbContext>(optionsBuilder =>
    optionsBuilder.UseNpgsql(connectionString)
);

var app = builder.Build();

// Seeding Database
using (var scope = app.Services.CreateScope())
{
    var dbSeeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();
    await dbSeeder.SeedAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseCors(policyBuilder => policyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.MapControllers();
app.UseHttpsRedirection();
app.Run();