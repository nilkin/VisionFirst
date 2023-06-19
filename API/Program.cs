using Application;
using FluentValidation.AspNetCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddCors(opt => opt.AddDefaultPolicy(p => { p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));

//builder.Services.AddPersistenceServices(builder.Configuration);
var app = builder.Build();


app.UseAuthorization();

app.MapControllers();
app.UseCors(opt =>
                opt.WithOrigins("https://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials());
app.Run();
