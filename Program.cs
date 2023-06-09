var builder = WebApplication.CreateBuilder(args);
//menambahkan MVC
builder.Services.AddControllersWithViews();



var app = builder.Build();

//menggunakan static file
app.UseStaticFiles();

app.UseRouting();
app.MapDefaultControllerRoute();




//app.MapGet("/", () => "Hello World!");

app.Run();
