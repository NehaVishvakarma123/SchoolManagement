using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SchoolManagement.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string cs = "server=DESKTOP-5H2JP33;database=SchoolManagement;trusted_connection=true;TrustServerCertificate=true; ";
builder.Services.AddDbContext<StudentContext>(abc => abc.UseSqlServer(cs));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.AddSecurityDefinition("auth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
	{
		Description = "Standard Authorization header using the Bearer scheme(\"bearer {token}\")",
		In = ParameterLocation.Header,
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey

	});
	options.OperationFilter<SecurityRequirementsOperationFilter>();
});

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
