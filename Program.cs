using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//you need to connect to database before builder 
builder.Services.AddDbContext<FullStackDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Dbconnection")));
//here Dbconnection is the nmae of the connection string given in the appsettings.json file 
//builder.Services.AddDbContext<FullStackDbContext> - this part registers the FullStackDbContext within the DI container, allowing it to be injected  into other parts of the application
//options => options.UseSqlServer(builder.Configuration.GetConnectionString("Dbconnection")), this is a lambda function configures the DbContextOptions for FullStackDbContext
//options.UseSqlServer(...) specifies that .NET should use SQL Server as the database provider.
//builder.Configuration provides access to the application's configuration settings.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
//this means you are allowing any method from any origin to access this server 

app.UseAuthorization();

app.MapControllers();

app.Run();
