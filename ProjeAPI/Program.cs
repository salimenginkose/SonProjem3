using Microsoft.EntityFrameworkCore;
using ProjeAPI.Core.RepositoryConcrete;
using ProjeAPI.Core.Services;
using ProjeAPI.Repository;
using ProjeAPI.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ProjeDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddTransient(typeof(ICrossCuttingRepository<>), typeof(CrossCuttingRepository<>));

builder.Services.AddTransient<ICompanyService, CompanyServices>();
builder.Services.AddTransient<IProductService, ProductServices>();
builder.Services.AddTransient<IOrderService, OrderServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var currentMinute = DateTime.Now.Minute;
var currentHour = DateTime.Now.Hour;
Console.WriteLine($"Hour {currentHour}");
Console.WriteLine($"Minute {currentMinute}");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
