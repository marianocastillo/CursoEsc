using CursoAPI.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp", policy =>
    {
        policy.WithOrigins("https://localhost:51594")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();

    });


});

builder.Services.AddControllers();


builder.Services.AddDbContext<BdcursoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "CursoController",
        Version = "v1"
    });
});


var app = builder.Build();
app.UseCors("AllowVueApp");


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Registro");
    });
}




// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();


app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
