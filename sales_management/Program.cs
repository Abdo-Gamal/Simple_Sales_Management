using FastReport.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using sales_management.Models;
using sales_management.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

  FastReport.Utils.RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

//Transient lifetime beer request 
builder.Services.AddTransient<IServices<Customer>,CustomerServices>();
builder.Services.AddTransient<IServices<CustomerType>, CustomerTypeServices>();
builder.Services.AddTransient<IServices<Company_info>, Company_infoServies>();
builder.Services.AddTransient<IServices<invoice>, InvoiceServices>();
builder.Services.AddTransient < IServices <products>, productServices>();
builder.Services.AddTransient<IServices<Car>, CarServices>();

builder.Services.AddAutoMapper(typeof(Program));
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
app.UseFastReport();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
