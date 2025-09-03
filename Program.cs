
using Microsoft.EntityFrameworkCore;

using temu_back.Data;
using temu_back.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// entity framework
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped<temu_back.Repositories.IPersonRepository, temu_back.Repositories.PersonRepository>();
builder.Services.AddScoped<temu_back.Repositories.IItemRepository, temu_back.Repositories.ItemRepository>();
builder.Services.AddScoped<temu_back.Repositories.IOrderRepository, temu_back.Repositories.OrderRepository>();
builder.Services.AddScoped<temu_back.Repositories.IOrderDetailRepository, temu_back.Repositories.OrderDetailRepository>();

// Services
builder.Services.AddScoped<temu_back.Services.IPersonService, temu_back.Services.PersonService>();
builder.Services.AddScoped<temu_back.Services.IItemService, temu_back.Services.ItemService>();
builder.Services.AddScoped<temu_back.Services.IOrderService, temu_back.Services.OrderService>();
builder.Services.AddScoped<temu_back.Services.IOrderDetailService, temu_back.Services.OrderDetailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();



