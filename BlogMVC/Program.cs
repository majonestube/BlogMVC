using BlogMVC.Authorization;
using BlogMVC.Data;
using BlogMVC.Models.Entities;
using BlogMVC.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not found");

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add the repositories
builder.Services.AddTransient<IBlogRepository, BlogRepository>();
builder.Services.AddTransient<IPostRepository, PostRepository>();
builder.Services.AddTransient<ICommentRepository, CommentRepository>();

// Authorization
builder.Services.AddScoped<IAuthorizationHandler, BlogOwnerHandler>();

// Temp Data
builder.Services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();

// Db services
builder.Services.AddDbContext<BlogDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<BlogDbContext>();

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

// For login
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Blog}/{action=Index}/{id?}");

// For login
app.MapRazorPages();

app.Run();