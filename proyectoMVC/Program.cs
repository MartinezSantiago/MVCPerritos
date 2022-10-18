using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using proyectoMVC.Context;
using proyectoMVC.Helper;
using proyectoMVC.Mapper;
using proyectoMVC.Service;
using proyectoMVC.Services;
using AppContext = proyectoMVC.Context.AppContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("defaultConection")));
builder.Services.AddScoped<AutoMapper>();
builder.Services.AddScoped<Encriptacion>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ImageToDirectory>();
builder.Services.AddScoped<DadorService>();
builder.Services.AddScoped<DonarService>();
builder.Services.AddScoped<MascotaService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x => {
    x.LoginPath = "/Users/Login"; x.AccessDeniedPath = new PathString("/Unauthorized");
    x.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    x.SlidingExpiration = false;
    
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var cookiePolicyOptions = new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
};
app.UseCookiePolicy(cookiePolicyOptions);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Home}");


app.Run();
