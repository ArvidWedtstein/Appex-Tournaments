﻿using tournament.Models;
using tournament.Services;
using Microsoft.Extensions.Options;


var  MyAllowSpecificOrigins = "AccessControlAllowOrigin";
var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
// Add services to the container.
builder.Services.Configure<TournamentDatabaseSettings>(builder.Configuration.GetSection(nameof(TournamentDatabaseSettings)));
// builder.Services.AddCors(options => {
//     options.AddPolicy(name: MyAllowSpecificOrigins, builder => { 
//         builder.WithOrigins("*", "https://appextournament.netlify.app").AllowAnyHeader();
//     });
// });
// builder.Services.AddCors(options =>
// {
//     options.AddDefaultPolicy(
//     builder =>
//     {
//         builder.WithOrigins("https://appextournament.netlify.app", "*").AllowAnyHeader();
//     });
//     options.AddPolicy("CORSPolicy",
//     builder =>
//     {
//         builder.WithOrigins().AllowAnyHeader().AllowAnyMethod().AllowCredentials();
//     });
// });
builder.Services.AddSingleton<ITournamentDatabaseSettings>(sp => sp.GetRequiredService<IOptions<TournamentDatabaseSettings>>().Value);
builder.Services.AddSingleton<TournamentService>();
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseRouting();
// app.UseCors(MyAllowSpecificOrigins);
app.UseCors(policy =>
    policy.WithOrigins(new string[] { "https://appextournament.netlify.app", "https://appextournament.netlify.app/tournaments" })
);
// app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
