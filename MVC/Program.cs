using BLL.DAL;
using BLL.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);


// IoC Container:
var connectionString = "server=(localdb)\\mssqllocaldb;database=PatientsAppDB;trusted_connection=true;";
builder.Services.AddDbContext<Db>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IBranchService, BranchService>(); //AddSingleton
builder.Services.AddScoped<IPatientService, PatientService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.Run();
