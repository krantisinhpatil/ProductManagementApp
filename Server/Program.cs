using Microsoft.EntityFrameworkCore;
using ProductManagement.ApiService.Extension;
using ProductManagement.Data.DataContext;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

ServiceCollectionExtenstion.AddService(builder.Services);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        options.AddPolicy("AllowOrigin",
         builder => builder.WithOrigins("http://localhost:5013")
             .AllowAnyHeader()
             .AllowAnyMethod()
             .AllowCredentials());
    });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Cors Implemention
app.UseHttpsRedirection();
app.UseCors("AllowOrigin");
app.UseAuthorization();

app.MapControllers();

app.Run();