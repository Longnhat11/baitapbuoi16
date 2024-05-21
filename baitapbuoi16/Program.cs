using baitapbuoi16.DataAccess.DBContext;
using baitapbuoi16.DataAccess.IServices;
using baitapbuoi16.DataAccess.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Đăng ký DbContext
var connectionString = builder.Configuration.GetConnectionString("MyConnect");
builder.Services.AddControllersWithViews();
// Đăng ký StudentServices
builder.Services.AddScoped<IStudentServices, StudentServices>();

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
    pattern: "{controller=Students}/{action=Edit}/{Id=3}");

app.Run();
