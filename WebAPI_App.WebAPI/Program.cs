using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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


builder.Services.AddControllers(); //apı controllerı tanısın.
builder.Services.AddEndpointsApiExplorer(); //apı endpointlerini keşfetsin.Dökümanite etme.
builder.Services.AddSwaggerGen(c =>  //Swagger etkinleştirme.
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI_App", Version = "v1" });
    //Swagger dokümantasyonu için gerekli servisleri ekle.
});