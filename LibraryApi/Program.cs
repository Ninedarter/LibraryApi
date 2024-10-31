using LibraryApi.Data;
using LibraryApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register ApiContext with an in-memory database


builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsApi",
            builder => builder.WithOrigins("http://localhost:3000", "http://mywebsite.com")
                .AllowAnyHeader()
                .AllowAnyMethod());
    });
    builder.Services.AddDbContext<ApiContext>(options =>
        options.UseInMemoryDatabase("LibraryDb"));  // UseInMemoryDatabase is for testing, you can replace it with a real database

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddScoped<CalculationService>();
    builder.Services.AddScoped<ValidationService>();
    builder.Services.AddScoped<ReservationService>();


var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }


    // Create a scope to retrieve services and seed data
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<ApiContext>();

        // Initialize data if needed
        DataGenerator.Initialize(services);
    }
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseCors("CorsApi");

    app.UseAuthorization();

    app.MapControllers();

    app.Run();


