using Managemail.DAL.Entities;
using Managemail.Model.Common.Infrastructure;
using Managemail.Model.Common.Interfaces;
using Managemail.Model.Implementations;
using Managemail.Model.Infrastructure;
using Managemail.Repository;
using Managemail.Repository.Common.Interfaces;
using Managemail.Repository.Implementations;
using Managemail.Service.Common.Infrastructure;
using Managemail.Service.Common.Interfaces;
using Managemail.Service.Implementations.Lookups;
using Managemail.Service.Implementations.Services;
using Managemail.Service.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Managemail.Alpha
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            /*
            The AddControllers() extension method adds the services required to use Web API Controllers, and nothing more. 
            So you get Authorization, Validation, formatters, and CORS for example, but nothing related to Razor Pages or view rendering. 
            This is important as we are using only Web API not MVC in this project
             */
            var mvcBuilderService = services.AddControllers();
            mvcBuilderService.PartManager.ApplicationParts.Add(new AssemblyPart(Assembly.Load("Managemail.Web")));


            /*
            AddDbContextPool: at the time a DbContext instance is requested by a controller we will first check if there is an instance available in the pool. 
            Once the request processing finalizes, any state on the instance is reset and the instance is itself returned to the pool.
            This is conceptually similar to how connection pooling operates in ADO.NET providers and has the advantage of saving some of the 
            cost of initialization of DbContext instance.
             */
            services.AddDbContextPool<ManagemailDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("ManagemailConnectionString")));


            /*
             This registers AutoMapper:
                As a singleton for the MapperConfiguration
                As a transient instance for IMapper
                ITypeConverter instances as transient
                IValueConverter instances as transient
                IValueResolver instances as transient
                IMemberValueResolver instances as transient
                IMappingAction instances as transient
             */
            services.AddAutoMapper(Assembly.GetAssembly(typeof(AutomapperRepositoryConfigurationProfile)), Assembly.GetAssembly(typeof(AutomapperWebConfigurationProfile)));


            /* there are thre methods that define dependency injection lifetime: 
                Singleton: this lifetime creates one instance of the service. The service instance may be created at the registration time by 
                            using the Add() method, as you saw in the example above. Alternatively, the service instance can be created the 
                            first time it is requested by using the AddSingleton() method.

                Transient: by using this lifetime, your service will be created each time it will be requested. This means, for example, that 
                            a service injected in the constructor of a class will last as long as that class instance exists. To create a service 
                            with the transient lifetime, you have to use the AddTransient() method.

                Scoped: the scoped lifetime allows you to create an instance of a service for each client request. This is particularly useful 
                            in the ASP.NET context since it allows you to share the same service instance for the duration of an HTTP request 
                            processing. To enable the scoped lifetime, you need to use the AddScoped() method.
            */
            services.AddScoped<IImportanceTypeLookup, ImportanceTypeLookup>();
            services.AddScoped<IEmailHistoryService, EmailHistoryService>();
            services.AddScoped<IImportanceTypeRepository, ImportanceTypeRepository>();
            services.AddScoped<IEmailHistoryRepository, EmailHistoryRepository>();
            
            services.AddScoped<IImportanceTypeModel, ImportanceTypeModel>();
            services.AddScoped<IEmailHistoryModel, EmailHistoryModel>();
            
            services.AddScoped<IResultModel, ResultModel>();
            services.AddScoped<IOptionsParameters, OptionsParameters>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
                .AllowAnyOrigin() //change this only for localhost:3000
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //This only maps controllers that are decorated with routing attributes - it doesn't configure any conventional routes
                endpoints.MapControllers();
            });
        }
    }
}
