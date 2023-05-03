using CommonService.Core;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().ConfigureApiBehaviorOptions(opt =>
{
    opt.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddCors();

builder.Services.AddEndpointsApiExplorer();

builder.RegisterProjectDependencies();

builder.Services.AddSwaggerGen();

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);

builder.Host.UseSerilog((context, services, config) =>
{
    config.WriteTo.Console();
});

var app = builder.Build();

////Auto Migration
//using (var serviceScope = app.Services.CreateScope())
//{
//    var service = serviceScope.ServiceProvider;
//    var dbContext = service.GetRequiredService<DefaultDBContext>();
//    await dbContext.Database.MigrateAsync();
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(opt =>
{
    opt.AllowAnyHeader();
    opt.AllowAnyOrigin();
    opt.AllowAnyMethod();
});

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.RegisterProjectMiddleWares();

app.MapControllers();

app.UseOcelot();

app.Run();
