using DMS.API;
using DMS.BL.Services;
using DMS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

const string _policy = "CorsPolicy";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ServiceRegistration.RegisterServices(builder.Services, builder.Configuration);
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddDbContextPool<ApplicationDBContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("cs")));
//builder.Services.AddScoped<IStudentRepo, StudentRepo>();

//builder.Services.AddSwaggerGen();
//builder.Services.AddCors(opt =>
//{
//    opt.AddPolicy(name: _policy, builder =>
//    {
//        builder.AllowAnyOrigin()
//            .AllowAnyHeader()
//            .AllowAnyMethod()
//            .AllowAnyOrigin();
//    });
//});

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(_policy);
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();
