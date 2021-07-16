using System;
using JsonApiDemo.Models;
using JsonApiDemo.Services;
using JsonApiDotNetCore.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JsonApiDemo
{
    public sealed class Startup
    {
        private readonly string _connectionString;

        public Startup(IConfiguration configuration)
        {
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddJsonApi(options => options.Namespace = "api/v1",
                resources: builder => builder.Add<WorkItem>("workItems"));

            services.AddResourceService<WorkItemService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseJsonApi();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            Console.WriteLine("Completed configuration");
        }
    }
}
