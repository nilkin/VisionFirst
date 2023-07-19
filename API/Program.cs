using Application;
using FluentValidation.AspNetCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddCors(opt => opt.AddDefaultPolicy(p => { p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddApplicationServices();



var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();


app.UseCors(opt =>
                opt.WithOrigins("https://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials());
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name v1");
});
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
