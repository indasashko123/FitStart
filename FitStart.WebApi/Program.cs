using FitStart.Application;
using FitStart.Application.Common;
using FitStart.Application.Interfaces;
using FitStart.Persistance;
using FitStart.WebApi.AuthOptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;





// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(config => 
    {
        config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
        config.AddProfile(new AssemblyMappingProfile(typeof(IFitStartDbContext).Assembly));
    });
builder.Services.AddApplication();
builder.Services.AddPersistance(configuration);
builder.Services.AddCors(options =>  
    {
        options.AddPolicy("AllowAll", policy =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowAnyOrigin();
        });
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = AuthConfig.GetValidationParameters();
    });




var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
