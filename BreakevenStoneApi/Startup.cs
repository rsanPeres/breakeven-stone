using BreakevenStoneApplication.Services;
using BreakevenStoneInfra;
using BreakevenStoneRepository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace BreakevenStoneApi
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
            services.AddControllers();
            services.AddDbContext<ApplicationContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("BreakevenStone")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ClientService, ClientService>();
            services.AddScoped<EmployeeService, EmployeeService>();
            services.AddScoped<ProductService, ProductService>();
            services.AddScoped<EquipmentService, EquipmentService>();
            services.AddScoped<ClientRepository, ClientRepository>();
            services.AddScoped<EmployeeRepository, EmployeeRepository>();
            services.AddScoped<ProductRepository, ProductRepository>();
            services.AddScoped<EquipmentRepository, EquipmentRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BreakevenStoneApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("./v1/swagger.json", "BreakevenStoneApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}