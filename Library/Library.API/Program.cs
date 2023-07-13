using Library.API.Infrastructure.Repositories;
using Library.Domain.Repositories;
using Library.Domain.Services;

var builder1 = WebApplication.CreateBuilder(args);

// Configure the services for the first instance running on port 7019
builder1.Services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder1.Services.AddControllers();
builder1.Services.AddEndpointsApiExplorer();
builder1.Services.AddSwaggerGen();
builder1.Services.AddTransient<IBookService, BookService>();
builder1.Services.AddSingleton<IBookRepository, MockBookRepository>();

// Customize the service configurations for the first instance
builder1.Services.AddCors(options =>
{
	options.AddDefaultPolicy(builder =>
	{
		builder.WithOrigins("http://localhost:7019")
			   .AllowAnyHeader()
			   .AllowAnyMethod()
			   .AllowCredentials();
		builder.WithOrigins("http://localhost:4200")
			   .AllowAnyHeader()
			   .AllowAnyMethod()
			   .AllowCredentials();
	});
});

var app1 = builder1.Build();

// Configure the HTTP request pipeline for the first instance
if (app1.Environment.IsDevelopment())
{
	app1.UseSwagger();
	app1.UseSwaggerUI();
}

app1.UseHttpsRedirection();
app1.UseAuthorization();

// Move the following line before MapControllers()
app1.UseCors();

app1.MapControllers();
app1.Run();
