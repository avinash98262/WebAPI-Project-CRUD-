using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Data;
using Repository;
using Data;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddDbContext<BookStoreContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreDB")));

//builder.Services.AddScoped<BookRepository>();


builder.Services.AddScoped<IBookRepository, BookRepository>();  //this line must whenever you're creating the interface

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
