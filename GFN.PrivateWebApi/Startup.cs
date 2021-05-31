using GFN.PrivateWebApi.AppLogic;
using GFN.PrivateWebApi.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Yuniql.AspNetCore;
using Yuniql.Extensibility;

namespace GFN.PrivateWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();
            services.AddControllers();

            services.AddTransient<IDbConnection>(db => new SqlConnection(Configuration.GetConnectionString("DbTest")));
            services.AddTransient<ISampleRepository, SampleSQLRepository>();
            services.AddTransient<SampleAppLogic>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GFN.PrivateWebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GFN.PrivateWebApi v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/hc");
                endpoints.MapControllers();
            });

            if (Environment.GetEnvironmentVariable("RUN_MIGRATIONS") == "true")
            {
                app.UseYuniql(new Yuniql.AspNetCore.Configuration
                {
                    Platform = "SqlServer",
                    Workspace = Path.Combine(Environment.CurrentDirectory, "scripts"),
                    ConnectionString = Configuration.GetConnectionString("DbTest"),
                    IsAutoCreateDatabase = true,
                    IsDebug = true,
                });
            }
        }
    }
}
