using Microsoft.EntityFrameworkCore; 
using SIMAppBackendAPI.Models; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<lab3Context>(options => options.UseSqlServer("Server=database-lab3." + "cmil5mckzzne.ca-central-1.rds.amazonaws.com; " + "User ID=admin; Password=Wahida.hossain2021; Database=lab3;"));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "SimAppBackendApi", Version = "v1" });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SimAppBackendApi v1"));
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
