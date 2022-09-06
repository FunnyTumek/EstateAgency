using Microsoft.EntityFrameworkCore;
using Persistance;
using Services;
using Services.Abstractions;
using Domain.RepositoryInterfaces;
using Persistance.Repositories;
using Persistance.Configurations.MappingToDto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
.AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<MappingProfile>();
});

builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(policy =>
	{
		policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
	});
});

builder.Services.AddMvc();

builder.Services.AddScoped<IEstatesService, EstatesService>();
builder.Services.AddScoped<IPdfService, PdfService>();
builder.Services.AddScoped<IEstatesRepository, EstatesRepository>();


builder.Services.AddDbContext<EstatesDbContext>(options => options.UseInMemoryDatabase(databaseName: "EstateAgency"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
