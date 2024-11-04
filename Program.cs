var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles(); //wwwroot altındaki dosyalar bu komut ile erişime açılmış oldu
app.UseRouting(); // Routing İşlemleri için bu kodu yazdık. Middlewarelerin yönlendirmeden önce çaşlışması için yazıldı.

// {controller=Home}/{action=index}/id?
//app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=index}/{id?}"
);

app.Run();