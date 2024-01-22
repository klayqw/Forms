using StackOverflow.Middleware;
using StackOverflow.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string myDb1ConnectionString = builder.Configuration.GetConnectionString("ForumBase");

builder.Services.AddScoped<IForumRepository>(e =>
{
    return new ForumSqlRepository(myDb1ConnectionString);
});

builder.Services.AddScoped<ILogRepository>(e => new LogSqlServices(myDb1ConnectionString));

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

app.UseAuthorization();
app.UseMiddleware<LogMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
