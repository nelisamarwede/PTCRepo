
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PTC.Domain.EF.Commands;
using PTC.Domain.EF.Commands.Interface;
using PTC.Domain.EF.Context;
using PTC.Domain.EF.Queries;
using PTC.Domain.EF.Services;
using PTC.Domain.Interfaces;
using PTC.Domain.Queries.Providers;

namespace PTC
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
            services.AddCors(i => { i.AddPolicy("allowAll", p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()); });


            #region Queries and Commands Dependancy Injection

            services.AddTransient(typeof(CalculationCommands));
            services.AddTransient(typeof(IQueryProvider<>), typeof(QueryProvider<>));
            //services.AddTransient(typeof(ICalculationCommands), typeof(CalculationCommands));
            //services.AddTransient(typeof(ICalculationCommands), typeof(CalculationCommands));
            //services.AddTransient(typeof())
            #endregion

            #region ApplicationContext

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            #endregion

            #region Repository Injection

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            #endregion
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
            app.UseCors("allowAll");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
