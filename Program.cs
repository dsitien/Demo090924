using Microsoft.EntityFrameworkCore;
using WebAPIDemo.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BooksContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString") ?? throw new InvalidOperationException("Connection string 'SchoolContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    var context = service.GetRequiredService<BooksContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseAuthorization();

app.MapControllers();

app.Run();
