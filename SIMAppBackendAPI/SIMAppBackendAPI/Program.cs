using Microsoft.EntityFrameworkCore; //-//--------------
using SIMAppBackendAPI.Models; //-//--------------

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//builder.AddNewtonsoftJson();
AddNewtonsoftJson();

void AddNewtonsoftJson()
{
    //throw new NotImplementedException();
}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddDbContext<lab3Context>(options => options.UseSqlServer("connectionTolab3"));  /// added line ***isa***
builder.Services.AddDbContext<lab3Context>(options => options.UseSqlServer("Server=database-lab3.cmil5mckzzne.ca-central-1.rds.amazonaws.com; User ID=admin; Password=Wahida.hossain2021; Database=lab3;"));
//Server=database-lab3.cmil5mckzzne.ca-central-1.rds.amazonaws.com; User ID=admin; Password=Wahida.hossain2021; Database=lab3;
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "SimAppBackendApi", Version = "v1" });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Commented line ***isa*** Starts
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SimAppBackendApi v1"));
}
// Commented line ***isa***  Ends

///// added line ***isa*** Starts
//if (builder.Environment.IsDevelopment()) 
//{
//    app.UseDeveloperExceptionPage();
//}
///// added line ***isa*** Ends

//automapper ----------------------------
/*private void ConfigureServices(IServiceCollection services)
{
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
}*/




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
