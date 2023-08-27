using Business.Interfaces;
using Data.Config;
using Data.ProductRepository;
using Data.RepositoryGeneric;
using Data.Repositorys;
using Microsoft.EntityFrameworkCore;
using Sentry;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGenerics<>));
builder.Services.AddSingleton<IProduct, ProductRepository>();
builder.Services.AddSingleton<ICategory, CategoryRepository>();

//sting de conexão
//Migration apontando para o projeto WebApi
builder.Services.AddDbContext<AppDBContext>
    (x => x.UseSqlServer(
        builder.Configuration.GetConnectionString("stringConnection"), b => b.MigrationsAssembly("WebApi")
        ));

// Add services to the container.

// Não deixa os jsons entrar em lup
builder.Services.AddControllers()
    .AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add DTo
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Centry
builder.WebHost.UseSentry(o =>
{
    o.Dsn = "https://17cd80fb905040138acbe16209eea216@o4505551929933824.ingest.sentry.io/4505551935897600";
    o.Debug = true;
    o.TracesSampleRate = 1.0;
    // o.Environment = "production";

});

SentrySdk.CaptureMessage("Hello Sentry");

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

app.UseRouting();

// Enable automatic tracing integration.
// If running with .NET 5 or below, make sure to put this middleware
// right after `UseRouting()`.
app.UseSentryTracing();

app.Run();
