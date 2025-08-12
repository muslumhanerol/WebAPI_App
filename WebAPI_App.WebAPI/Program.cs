using Microsoft.EntityFrameworkCore;
using WebAPI_App.Business;
using WebAPI_App.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// DefaultConnection = appsettings.Development.json içerisinde ConnectionStrings adı.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//Kapsam belirleme (Dependency Injection) işlemleri
builder.Services.AddScoped<IProductRepository, ProductRepository>();
//IProductRepository çağrıldığında ProductRepository gönderilecek.
builder.Services.AddScoped<IProductService, ProductService>();
//IProductService çağrıldığında ProductService gönderilecek.

builder.Services.AddOpenApi();

var app = builder.Build();

