using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddDbContext<ColaboratorContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("ColaboratorContext") ?? throw new InvalidOperationException("Connection string 'ColaboratorContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ColaboratorContext>(opt =>
    opt.UseInMemoryDatabase("ColaboratorList"));
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
