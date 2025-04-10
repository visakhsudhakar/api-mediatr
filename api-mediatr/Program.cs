using ApiMediatr.Core.Application.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ApiMediatr.Core.Application.Interfaces;
using ApiMediatr.Infrastructure.Persistence;
using ApiMediatr.Core.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));

// Fix for CS1503: Use the correct overload of AddMediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetUsersQuery).Assembly));

// Register UserRepository
builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();

// Register UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Users.AddRange(new User("John Doe", "john.doe@example.com"), new User("Jane Smith", "jane.smith@example.com"));
    dbContext.SaveChanges();
}
