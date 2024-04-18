using OtelEleon.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OtelEleon.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("OtelEleonDbContextConnection") ?? throw new InvalidOperationException("Connection string 'OtelEleonDbContextConnection' not found.");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<OtelEleonDbContext>();

builder.Services
    .AddDefaultIdentity<User>(options => 
    {
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 5;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.SignIn.RequireConfirmedEmail = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<OtelEleonDbContext>();
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
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();