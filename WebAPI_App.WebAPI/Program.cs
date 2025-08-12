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

//Verilecek CORS izinleri
//CORS, farklı kaynaklardan gelen isteklerin kontrolünü sağlar Ör:React üzerinden istek gönderirsin.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy => policy.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin());
});

var app = builder.Build();

if (app.Environment.IsDevelopment()) //Bir geliştirici olarak
{
    app.UseSwagger(); //Swagger'ı kullan.
    app.UseSwaggerUI();
}


app.UseCors("AllowAll");
app.UseAuthentication(); //Kimlik doğrulama işlemlerini kullan.
app.MapControllers(); //Controller'ları kullan.
app.UseAuthorization(); //Yetkilendirme işlemlerini kullan.
app.Run(); //Uygulamayı çalıştır.