global using AutoMapper;
using ContactsAPI.Data;
using ContactsAPI.Services.ContactService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
//builder.Services.AddDbContext<ContactAPIDbContext>(options => options.UseInMemoryDatabase("ContactDb"));
builder.Services.AddDbContext<ContactAPIDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("ContactsApiConnectionString")));
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
