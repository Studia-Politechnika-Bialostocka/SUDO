using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SUDO.Areas.Identity.Data;
using SUDO.Areas.Identity;
using SUDO;
using SUDO.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SudoDB");

builder.Services.AddDbContext<SUDOIdentityDbContext>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddSignInManager<MySignInManager>()
    .AddEntityFrameworkStores<SUDOIdentityDbContext>();;


builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Lockout settings.
    options.User.RequireUniqueEmail = true;
});

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddProjectServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
