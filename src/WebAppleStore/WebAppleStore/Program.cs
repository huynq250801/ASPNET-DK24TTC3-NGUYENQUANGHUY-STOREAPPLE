using Microsoft.EntityFrameworkCore;
using WebAppleStore.Data;

var builder = WebApplication.CreateBuilder(args);

// ??ng ký DbContext
builder.Services.AddDbContext<AppleStoreShopContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AppleStoreShopContext")
    ));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
