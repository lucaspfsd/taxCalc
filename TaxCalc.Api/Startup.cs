using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using TaxCalc.Core;

namespace TaxCalc.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            ConfigureSwagger(services);
            ConfigureDependenceInjection(services);
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Configuration["ApiInfos:CurrentVersion"],
                    new Info
                    {
                        Title = Configuration["ApiInfos:ApiTitle"],
                        Version = Configuration["ApiInfos:CurrentVersion"],
                        Description = Configuration["ApiInfos:ApiDescription"],
                        Contact = new Contact
                        {
                            Name = Configuration["ApiInfos:MaintainerName"],
                            Email = Configuration["ApiInfos:MaintainerEmail"],
                            Url = Configuration["ApiInfos:Url"]
                        }
                    });

                var appPath = PlatformServices.Default.Application.ApplicationBasePath;
                var appName = "TaxCalc.Api";
                var XmlDocPath = Path.Combine(appPath, $"{appName}.xml");

                c.IncludeXmlComments(XmlDocPath);
            });
        }

        private void ConfigureDependenceInjection(IServiceCollection services)
        {
            services.AddSingleton<CalculadoraJuros>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", Configuration["ApiInfos:ApiTitle"]);
                c.RoutePrefix = "";
                c.DocumentTitle = Configuration["ApiInfos:ApiTitle"];
            });

        }
    }
}
