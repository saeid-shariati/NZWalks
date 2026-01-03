using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using NZWalks.API.Data;
using NZWalks.API.Mappings;
using NZWalks.API.Models;
using NZWalks.API.Repositories.Interfaces;
using NZWalks.API.Repositories.RepositoryClasses;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IRegionRepository, RegionRepository>();
builder.Services.AddAutoMapper(config =>
{
    config.AddMaps(typeof(Program).Assembly);
});
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    /*options.SwaggerDoc("V1",new OpenApiInfo()
    {
        Title =  "NZWalks API",
        Version = "V1"
    });*/
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        //options.SwaggerEndpoint("/swagger/v1/swagger.json", "NZWalks API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();



app.Run();

