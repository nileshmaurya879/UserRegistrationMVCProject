using Microsoft.EntityFrameworkCore;
using RegistartionProject001.Interface;
using RegistartionProject001.Models;
using RegistartionProject001.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RegistrationDBContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("TestDB")));
builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Registration}/{action=Index}/{id?}");

app.Run();
