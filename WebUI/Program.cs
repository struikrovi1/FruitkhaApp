using Business.Abstract;
using Business.Concrete;
using DataAccess;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebUI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FruitkhaDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<MyUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<FruitkhaDbContext>();


builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ISliderManager, SliderManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<ICategoryManager, CategoryManager>();
builder.Services.AddScoped<ICountdownManager, CountdownManager>();
builder.Services.AddScoped<ITeamManager, TeamManager>();
builder.Services.AddScoped<INewsManager, NewsManager>();
builder.Services.AddScoped<IProductManager, ProductManager>();
builder.Services.AddScoped<ICommentManager, CommentManager>();
builder.Services.AddScoped<IContactManager, ContactManager>();
builder.Services.ConfigureApplicationCookie(option =>
{
    option.LoginPath = "/auth/login";
    option.AccessDeniedPath = "/auth/login";
});

//builder.Services.AddScoped<UserManager<MyUser>>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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


app.MapControllerRoute(
     name: "areas",
     pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
