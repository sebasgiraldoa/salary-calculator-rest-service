using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using SalaryCalculator.API.Core;
using SalaryCalculator.API.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace SalaryCalculator.API
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
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddAutoMapper(typeof(Startup));
			services.AddMvc()
					.SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
					.AddJsonOptions(options =>
					{
						var contractResolver = options.SerializerSettings.ContractResolver;
						if (contractResolver != null)
							(contractResolver as DefaultContractResolver).NamingStrategy = null;
					});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info
				{
					Version = "v1",
					Title = "Salary calculator rest services",
				});
			});

			services.AddScoped<IEmployeeManager, EmployeeManager>();
			services.AddScoped<IEmployeeRepository, EmployeeRepository>();
			services.AddScoped<IMapper, Mapper>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseMvc();
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Salary calculator Demo");
			});

			app.UseHttpsRedirection();		
		}
	}
}
