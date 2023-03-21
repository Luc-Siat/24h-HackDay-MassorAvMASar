using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using server.Data;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<MassorAvMasarContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("MassorAvMasarContext")));
    app.UseSwagger();
    app.UseSwaggerUI();
if (app.Environment.IsProduction())
{
    builder.Services.AddDbContext<MassorAvMasarContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SQLAZURECONNSTR_MassorAvMasarContext"))); 
}
    app.UseCors(policy =>    {      
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();  //set the allowed origin    });
    });
    using (var scope = app.Services.CreateScope())
    {
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
