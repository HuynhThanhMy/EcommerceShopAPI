using EcommerceWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using EcommerceWebAPI.Services;//.net 5
//using EcommerceWebAPI.Repositories; //.net 6

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddDbContext<MyDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDB"));
});

//builder.Services.AddAutoMapper(typeof(Program));//.net 6

// Life cycle DI: AddSingleton(), AddTransient(), AddScoped()
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();//.net 5
//builder.Services.AddScoped<ICategoryRepository, CategoryRepositoryMemory>();//.net 5
//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); //.net 6
builder.Services.AddScoped<IProductRepository, ProductRepository>();

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
