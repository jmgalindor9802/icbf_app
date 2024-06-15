using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using icbf_app.Services;
using icbf_app.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IcbfAppContext>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
     options.UseSqlServer(connectionString);
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();


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
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapRazorPages();

//Crear los roles y el primer admin user 
using (var scope = app.Services.CreateScope())
{
    var userManager=scope.ServiceProvider.GetService(typeof(UserManager<IdentityUser>))
        as UserManager<IdentityUser>;
    var roleManager=scope.ServiceProvider.GetService(typeof(RoleManager<IdentityRole>))
        as RoleManager <IdentityRole>;
    await DatabaseInitializer.SeedDataAsync(userManager, roleManager);
}

    app.Run();
