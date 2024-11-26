using Auth.API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionStringKey = builder.Environment.IsDevelopment()
    ? Environment.GetEnvironmentVariable("ASPNETCORE_DOCKER") == "true"
        ? "ConnectionDocker"
        : "DefaultConnection"
        : "DefaultConnection";

Console.WriteLine($"Usando Connection String: {connectionStringKey}");
Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(connectionStringKey)));

builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<DataContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
