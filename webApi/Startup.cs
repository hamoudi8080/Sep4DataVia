using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Model.Contract;
using WebAPI.EfcData.DaoImp;
using WebAPI.EfcData.DataAccess;
using WebAPI.WebSocketGetway.Services;

namespace WebAPI
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
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" }); });
            //services.AddScoped<IMeasurementService, MeasurementService>();
            //services.AddScoped<IMeasurementRepo, MeasurementRepo>();
            services.AddScoped<ILoRaWANService, LoRaWANServiceImp>();
            // services.AddDbContextPool<MushroomDatabase>(option=>option.UseSqlServer());

            services.AddScoped<IMeasurement, MeasurementDao>();
            services.AddScoped<ICo2Threshhold, CO2Dao>();
            services.AddDbContext<DataAccess1>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));


            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}