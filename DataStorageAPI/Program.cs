using DataStorageAPI.Context;
using DataStorageAPI.Handlers;
using DataStorageAPI.IServices;
using DataStorageAPI.Models.ViewModels;
using DataStorageAPI.Services;
using Microsoft.EntityFrameworkCore;
using static DataStorageAPI.Models.Input.JacketInputModel;
using static DataStorageAPI.Models.Input.JeansInputModel;
using static DataStorageAPI.Models.Input.ShoesInputModel;
using static DataStorageAPI.Models.Input.WatchInputModel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(
    x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(
    x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql_Connection")));

builder.Services.AddTransient<JacketHandler>();
builder.Services.AddTransient<JeansHandler>();
builder.Services.AddTransient<ShoesHandler>();
builder.Services.AddTransient<WatchHandler>();
builder.Services.AddTransient<IGenericService<JacketViewModel, CreateJacketInputModel, UpdateJacketInputModel>, JacketService>();
builder.Services.AddTransient<IGenericService<JeansViewModel, CreateJeansInputModel, UpdateJeansInputModel>, JeansService>();
builder.Services.AddTransient<IGenericService<ShoesViewModel, CreateShoesInputModel, UpdateShoesInputModel>, ShoesService>();
builder.Services.AddTransient<IGenericService<WatchViewModel, CreateWatchInputModel, UpdateWatchInputModel>, WatchService>();


var app = builder.Build();

app.UseSwaggerUI(c =>
{
    c.DefaultModelsExpandDepth(-0);
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Data Storage API");
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(
    x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.UseHttpsRedirection();

app.MapControllers();

app.UseAuthorization();

app.Run();
