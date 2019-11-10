using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PR.API.Context;
using PR.Domain.Commands.Handlers;
using PR.Domain.Repositories;
using PR.Infra.Infra;
using PR.Infra.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace PR.API
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
            // DataBase Context
            services.AddSingleton<IDB, MSSQLDB>();
            services.AddTransient<IDBConfiguration, MSSQLDBConfiguration>();
            // Handlers
            services.AddTransient<ConstructionHandler>();
            services.AddTransient<OwnerHandler>();
            services.AddTransient<ReportHandler>();
            services.AddTransient<ResponsibleHandler>();
            services.AddTransient<CommentHandler>();
            // Repositories
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IConstructionRepository, ConstructionRepository>();
            services.AddTransient<IOwnerRepository, OwnerRepository>();
            services.AddTransient<IParticipantRepository, ParticipantRepository>();
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddTransient<IResponsibleRepository, ResponsibleRepository>();
            services.AddResponseCompression();
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "PR", Version = "v1" });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseSwagger(c =>
                      {
                          c.RouteTemplate = "swagger/{documentName}/swagger.json";
                      });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PR API - v1");
                c.RoutePrefix = "swagger";
            });
            app.UseMvc(route =>
            {
                route.MapRoute("default", "{controller=Test}/{action=Index}/{id?}");
            });
            app.UseResponseCompression();

            // Pagina com documentação: '/swagger/index.html'


        }
    }
}
