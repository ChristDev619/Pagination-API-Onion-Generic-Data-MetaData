using Microsoft.EntityFrameworkCore;
using Pagination_API_Onion_Generic_Data_MetaData.API.Application.Services;
using Pagination_API_Onion_Generic_Data_MetaData.API.Infrastructure.Database;
using Pagination_API_Onion_Generic_Data_MetaData.API.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to DI container
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>(); // Database Access
builder.Services.AddScoped<IEmployeeService, EmployeeService>(); // Business Logic
// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
