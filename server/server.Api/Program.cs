using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using server.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MassorAvMasarContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("MassorAvMasarContext")));


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

    using (var scope = app.Services.CreateScope())
    {
    var services = scope.ServiceProvider;
    // SeedData.Initialize(services);
    }
}
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(policy =>    {      
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();  //set the allowed origin    });
    });
// if (app.Environment.IsProduction())
// {
//     builder.Services.AddDbContext<MassorAvMasarContext>(options =>
//         options.UseSqlServer(builder.Configuration.GetConnectionString("SQLAZURECONNSTR_MassorAvMasarContext")));
// }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
