using tournament.Controllers;
using tournament.Models;
using MongoDB.Driver;
using tournament.Services;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using System.Linq;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc.Cors;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace tournament {
    public class Startup {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseRouting();
            //app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();

            //app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var target = Environment.GetEnvironmentVariable("TARGET") ?? "World";
                    await context.Response.WriteAsync($"Hello {target}!\n");
                });
            });
        }
    }
}
