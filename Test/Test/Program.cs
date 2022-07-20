var builder = WebApplication.CreateBuilder(args).Inject();

builder.Services.AddControllers().AddInject();
// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();
app.UseInject("swagger");
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();
