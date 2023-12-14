using CoreApplication.ports;
using CoreApplication.Service;
using Email;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connetctionString = builder.Configuration.GetConnectionString("ConnectionStrings");
builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(connetctionString));

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddControllers();
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

app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Content-Security-Policy", "default-src 'self';");
    await next();
});

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().SetPreflightMaxAge(new TimeSpan(24, 12, 1)));


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
