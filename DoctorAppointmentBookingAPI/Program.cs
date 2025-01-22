using System.Reflection;
using DoctorAppointmentBookingAPI;
using Presentation.EndPoint;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.InstallAvailabilityModules()
                .InstallAppointmentModule()
                .InstallAppointmentManagement();

builder.Services.AddControllers()
    .AddApplicationPart(Assembly.GetAssembly(typeof(PresentationLayer.EndPointMarker.DoctorAvailabilityEndPoint))!)
    .AddApplicationPart(Assembly.GetAssembly(typeof(Shell.EndPointMarker.AppointmentStatusEndPoint))!)
    .AddApplicationPart(Assembly.GetAssembly(typeof(AppointmentBookingEndPoint))!);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c
    =>
{
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};
app.UseOpenApi();
app.UseSwaggerUI(settings => { });

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Test}/{action=Index}");
});


app.Run();