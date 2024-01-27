using Microsoft.EntityFrameworkCore;
using UdemySwagger.Models;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SwaggerDBContext>(opts=>
{
    opts.UseSqlServer(builder.Configuration["ConnectionString"]);
});

builder.Services.AddSwaggerGen(gen =>
{
    gen.SwaggerDoc("productV1", new OpenApiInfo
    {
        Version = "V1",
        Title = "Product API",
        Description = "Ürün Ekleme/Silme/Güncelleme Ýþlemlerini Gerçekleþtiren API",
        Contact=new OpenApiContact
        {
            Name="Þule Celep",
            Email="sulecelep@gmail.com",
            Url= new Uri("http://www.sulecelep.com/")
        }

    });
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
    gen.IncludeXmlComments(xmlPath);
});





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/productV1/swagger.json", "Product API");
    });
}





app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
