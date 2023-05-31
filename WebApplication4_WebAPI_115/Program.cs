using Microsoft.EntityFrameworkCore;
using WebApplication4_WebAPI_115.Data;
using WebApplication4_WebAPI_115.DTOMapping;
using WebApplication4_WebAPI_115.Repository;
using WebApplication4_WebAPI_115.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string cs = builder.Configuration.GetConnectionString("conStr");
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(cs));
builder.Services.AddScoped<INationalParkRepository, NationalParkRepository>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
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
