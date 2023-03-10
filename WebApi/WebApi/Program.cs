using Business.Interfaces;
using Data.Config;
using Data.ProductRepository;
using Data.RepositoryGeneric;
using Data.Repositorys;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGenerics<>));
builder.Services.AddSingleton<IProduct, ProductRepository>();
builder.Services.AddSingleton<ICategory, CategoryRepository>();

//sting de conex?o
//Migration apontando para o projeto WebApi
builder.Services.AddDbContext<AppDBContext>
    (x => x.UseSqlServer(
        builder.Configuration.GetConnectionString("stringConnection"), b => b.MigrationsAssembly("WebApi")
        ));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add DTo
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
