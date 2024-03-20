using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Steam.Data;
using Steam.Middleware;
using Steam.Models;
using Steam.Services;
using Steam.Services.Base;
using System.Data.SqlClient;
using System.Reflection;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IGameServiceBase, GameService>();
builder.Services.AddScoped<IWorkShopServiceBase, WorkShopService>();
builder.Services.AddScoped<IGroupServices, GroupService>();
builder.Services.AddScoped<IUserServiceBase, UserService>();
builder.Services.AddScoped<IAdminPanel, AdminPanelService>();
builder.Services.AddScoped<IFriendService, FriendService>();
builder.Services.AddScoped<INotificationServiceBase, NotificationService>();

builder.Services.AddDbContext<SteamDBContext>(dbContextOptionsBuilder => {
    var connectionString = builder.Configuration.GetConnectionString("SteamBase");
    dbContextOptionsBuilder.UseSqlServer(connectionString);
});

builder.Services.AddIdentity<User, IdentityRole>(options => {
    options.Password.RequiredLength = 8;
    
}).AddEntityFrameworkStores<SteamDBContext>();



builder.Services.ConfigureApplicationCookie(options =>
{   
    options.LoginPath = "/User/Login";
    options.AccessDeniedPath = "/ErrorPage/Error"; 
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();



app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<CheckIsBannedMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
