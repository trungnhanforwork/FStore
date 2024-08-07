using Contracts;
using FStore.Extensions;
using Helper;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.Extensions.Logging;


var builder = WebApplication.CreateBuilder(args);
LogManager.Setup().LoadConfigurationFromSection(builder.Configuration);
// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddControllers()
    .AddApplicationPart(typeof(FStore.Presentation.AssemblyReference).Assembly);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureFileService();
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();

var app = builder.Build();
var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);
if (app.Environment.IsProduction())
    app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
