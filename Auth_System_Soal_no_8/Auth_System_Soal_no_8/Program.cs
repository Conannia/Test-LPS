using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Auth_System_Soal_no_8.Data;
using Auth_System_Soal_no_8.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Auth_System_Soal_no_8DbContextConnection") ?? throw new InvalidOperationException("Connection string 'Auth_System_Soal_no_8DbContextConnection' not found.");

builder.Services.AddDbContext<Auth_System_Soal_no_8DbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Auth_System_Soal_no_8User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<Auth_System_Soal_no_8DbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
