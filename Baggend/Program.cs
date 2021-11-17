using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using baggend.Models;
using baggend.Services;
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,builder => {
        builder.WithOrigins("http://localhost:3000");
    });
});
builder.Services.Configure<TournamentDatabaseSettings>(builder.Configuration.GetSection(nameof(TournamentDatabaseSettings)));

builder.Services.AddSingleton<ITournamentDatabaseSettings>(sp => sp.GetRequiredService<IOptions<TournamentDatabaseSettings>>().Value);
builder.Services.AddSingleton<TournamentService>();
builder.Services.AddControllers();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
} 

app.UseDefaultFiles();
app.UseCors(MyAllowSpecificOrigins);
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();