# WebAPI_APP

# 1. Ana klasörü oluştur
mkdir WebAPI_App
cd WebAPI_App

# 2. Çözüm (solution) oluştur
dotnet new sln -n WebAPI_App

Birden fazla projeyi ve katmanı içerisinde barındıran bir kapsayıcıdır. Tüm projeyi tek yerden yönetmek için kullanılır

# 3. Katmanları oluştur
dotnet new webapi -n WebAPI_App.WebAPI
Arayüz katmanı

dotnet new classlib -n WebAPI_App.Entities
Veri modelleri burada kullanılır

dotnet new classlib -n WebAPI_App.DataAccess
Veritabanı şablonu, bağlantıları

dotnet new classlib -n WebAPI_App.Business
İşleyiş için

# 4. Projeleri çözüme ekle
dotnet sln add WebAPI_App.WebAPI/WebAPI_App.WebAPI.csproj
dotnet sln add WebAPI_App.Entities/WebAPI_App.Entities.csproj
dotnet sln add WebAPI_App.DataAccess/WebAPI_App.DataAccess.csproj
dotnet sln add WebAPI_App.Business/WebAPI_App.Business.csproj

# 5. Katmanlar arası referans bağlantılarını kur
dotnet add WebAPI_App.DataAccess reference WebAPI_App.Entities
dotnet add WebAPI_App.Business reference WebAPI_App.DataAccess
dotnet add WebAPI_App.WebAPI reference WebAPI_App.Business

# 6. Gerekli NuGet paketlerini yükle
cd WebAPI_App.DataAccess
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
cd ../WebAPI_App.WebAPI
dotnet add package Swashbuckle.AspNetCore
Swagger için yükledim. API dökümünde kullanılıyor yani swagger ui oluşturup API yi web üzerinden test ediyorum.

-----------------------------------------------------------------------------------------------
