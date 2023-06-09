using BelajarASPCore.DAL;

var builder = WebApplication.CreateBuilder(args);
//menambahkan MVC
builder.Services.AddControllersWithViews();
//menambahkan DAL
builder.Services.AddScoped<IMahasiswa,MahasiswaDAL>();



var app = builder.Build();

//menggunakan static file
app.UseStaticFiles();

app.UseRouting();
app.MapDefaultControllerRoute();




//app.MapGet("/", () => "Hello World!");

app.Run();
