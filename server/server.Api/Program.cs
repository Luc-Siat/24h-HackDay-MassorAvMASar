using Microsoft.Data.SqlClient;
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
    // builder.Services.AddDbContext<MassorAvMasarContext>(options =>
    //     options.UseSqlServer(builder.Configuration.GetConnectionString("MassorAvMasarContext")));

      var conStrBuilder = new SqlConnectionStringBuilder(
        builder.Configuration.GetConnectionString("MassorAvMasarContext"));

    var connection = conStrBuilder.ConnectionString;
}
if (app.Environment.IsProduction())
{
    // builder.Services.AddDbContext<MassorAvMasarContext>(options =>
    //     options.UseSqlServer(builder.Configuration.GetConnectionString("SQLAZURECONNSTR_MassorAvMasarContext"))); 

    var conStrBuilder = new SqlConnectionStringBuilder(
    builder.Configuration.GetConnectionString("SQLAZURECONNSTR_MassorAvMasarContext"));
    var connection = conStrBuilder.ConnectionString;
}
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(policy =>    {      
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
    // using (var scope = app.Services.CreateScope())
    // {
    // var services = scope.ServiceProvider;
    // SeedData.Initialize(services);
    // }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
