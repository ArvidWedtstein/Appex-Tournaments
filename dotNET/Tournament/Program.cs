using tournament.Models;
using tournament.Services;
using Microsoft.Extensions.Options;
using Serilog;
using Autofac.Extensions.DependencyInjection;
using Autofac;
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");



try
{
    var MyAllowSpecificOrigins = "AccessControlAllowOrigin";
    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console()
        .WriteTo.Seq("http://localhost:5341")
        .ReadFrom.Configuration(ctx.Configuration));

    // Add services to the container.
    builder.Services.Configure<TournamentDatabaseSettings>(builder.Configuration.GetSection(nameof(TournamentDatabaseSettings)));
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: MyAllowSpecificOrigins, builder =>
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
    });
    builder.Services.AddSingleton<ITournamentDatabaseSettings>(sp => sp.GetRequiredService<IOptions<TournamentDatabaseSettings>>().Value);
    builder.Services.AddSingleton<TournamentService>();
    builder.Services.AddControllers();


    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    //builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder=>containerBuilder.RegisterModule<TournamentModule>());
    var app = builder.Build();


    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();

    app.UseRouting();
    app.UseCors(MyAllowSpecificOrigins);
    app.UseAuthorization();

    app.UseSerilogRequestLogging();

    app.MapControllers();
    app.UseStaticFiles();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}

