
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PTC.Domain.EF.Commands;
using PTC.Domain.EF.Commands.Interface;
using PTC.Domain.EF.Context;
using PTC.Domain.EF.Inspectors;
using PTC.Domain.EF.Inspectors.Calculators.Concrete;
using PTC.Domain.EF.Inspectors.Calculators.Interface;
using PTC.Domain.EF.Queries;
using PTC.Domain.EF.Services;
using PTC.Domain.Entities;
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


            #region Dependancy Injection on Queries and Commands with respect to sepertion of concern and responsibility

            services.AddTransient(typeof(ICalculationCommands), typeof(CalculationCommands));
            services.AddTransient(typeof(IQueryProvider<>), typeof(QueryProvider<>));
            services.AddTransient(typeof(ITaxInspector), typeof(TaxInspector));
            services.AddTransient(typeof(IFlatRateTaxCalculator), typeof(FlatRateTaxCalculator));
            services.AddTransient(typeof(IFlatValueTaxCalculator), typeof(FlatValueTaxCalculator));
            services.AddTransient(typeof(IProgressiveTaxCalculator), typeof(ProgressiveTaxCalculator));
            services.AddTransient(typeof(ITaxType), typeof(TaxType));

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
