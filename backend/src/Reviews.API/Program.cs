using Reviews.API;
using Reviews.Application;
using Reviews.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers();
    
    builder.Services
        .AddApi()
        .AddApplication()
        .AddInfrastructure();

    builder.Services.AddCors();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.MapControllers();
    app.UseHttpsRedirection();
    app.UseCors();
    app.Run();
}