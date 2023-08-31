using WebApplication10.Interface;
using WebApplication10.Models;
using WebApplication10.Services;

var builder = WebApplication.CreateBuilder(args);
var constr = "Endpoint=https://azureappconfig786.azconfig.io;Id=nCIH;Secret=2LpV88kyO1WkjNlM2nf/nISroo3ZEc4qr9RL3dtPUBA=";

builder.Host.ConfigureAppConfiguration(config =>
{
    config.AddAzureAppConfiguration(constr);
});
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IEmployee, EmployeeService>();
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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
