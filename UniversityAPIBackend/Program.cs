using Microsoft.EntityFrameworkCore;
using UniversityAPIBackend.DataAcess;
using UniversityAPIBackend.Services;

var builder = WebApplication.CreateBuilder(args);


// TODO: Connection with sql server
// 
// 2. Connection with SQL Server Express
const string connectionName = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(connectionName);

// 3. add Context

builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));



// Add services to the container.

builder.Services.AddControllers();

// 4. Add custom services(folder services)

builder.Services.AddScoped<IStudentsService, StudentService>();

//TODO; Add the rest of services



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
