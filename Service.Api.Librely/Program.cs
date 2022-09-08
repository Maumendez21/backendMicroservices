using Service.Api.Librely.Core;
using Service.Api.Librely.Core.ContextMongoDB;
using Service.Api.Librely.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<MongoSettings>(
    options =>
    {
        options.ConnectionString = builder.Configuration.GetSection("MongoDb:ConnectionString").Value;
        options.Database = builder.Configuration.GetSection("MongoDb:Database").Value;
    }
);

builder.Services.AddSingleton<MongoSettings>();

builder.Services.AddTransient<IAutorContext, AutorContext>();
builder.Services.AddTransient<IAutorRepository, AutorRepository>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
