using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using NewComputerShop.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.






builder.Services.AddDbContext<ShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ComputerShopDB")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options => //CookieAuthenticationOptions
               {
                   options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/User/Login");
               });



// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IRepository, Repository>();



builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();









var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
