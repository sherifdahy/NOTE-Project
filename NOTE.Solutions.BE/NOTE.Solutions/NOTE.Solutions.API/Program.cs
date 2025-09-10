using NOTE.Solutions.API.ApplicationConfiguration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Services.DI(builder.Configuration);
builder.Services.AddHttpContextAccessor();

builder.Services.AddDistributedMemoryCache();

builder.Host.UseSerilog((context,configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler();

app.Run();
