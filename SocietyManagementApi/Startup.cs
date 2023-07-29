using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SocietyManagementApi.IServices.IGeneralMaster;
using SocietyManagementApi.IServices.IPayment;
using SocietyManagementApi.IServices.IUser;
using SocietyManagementApi.IServices.Society_Master;
using SocietyManagementApi.Models;
using SocietyManagementApi.Services.General_Master;
using SocietyManagementApi.Services.Payment;
using SocietyManagementApi.Services.Society_Master;
using SocietyManagementApi.Services.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementApi
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
            services.AddDbContext<Society_ManagementContext>(item => item.UseSqlServer(Configuration.GetConnectionString("SocietyManagementContext")));
            services.AddScoped<IGeneralMaster, GeneralMasterService>();
            services.AddScoped<IPayment, PaymentService>();
            services.AddScoped<IUser, UserService>();
            services.AddScoped<ISocietyMaster, SocietyMasterService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SocietyManagementApi", Version = "v1" });
            });

            services.AddControllers().AddNewtonsoftJson(x =>
             x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SocietyManagementApi v1"));
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
