using AppartmentServiceBE.Data;
using AppartmentServiceBE.Repositories.Implementation;
using AppartmentServiceBE.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApartmentServiceBEconnectionstring"));
});
builder.Services.AddCors(x => x.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("localhost:4200").AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddScoped<INewFlat, NewFlatRepo>();
builder.Services.AddScoped<IComplex, ComplexRepo>();
builder.Services.AddScoped<IuserDetails, UserDetailsRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();


app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});

app.MapControllers();

app.Run();



