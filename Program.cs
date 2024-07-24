using NIC_Demo_Project.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NIC_Demo_Project", Version = "v1" });
});

builder.Services.AddDbContext<ApplicationContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr"),
b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));


builder.Services.AddScoped<IApplicationContext, ApplicationContext>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMemoryCache();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NIC DEMO API"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=swagger}");
});


app.MapControllers();

app.Run();
