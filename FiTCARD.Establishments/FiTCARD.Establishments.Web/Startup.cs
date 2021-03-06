using FiTCARD.Establishments.Repository.Categorias;
using FiTCARD.Establishments.Repository.Estabelecimentos;
using FiTCARD.Establishments.Repository.Master;
using FiTCARD.Establishments.Service.Categorias;
using FiTCARD.Establishments.Service.Estabelecimentos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FiTCARD.Establishments.Web
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
            services.AddControllersWithViews();

            ConfigureSwagger(services);

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<IMasterRepository, MasterRepository>();
            services.AddScoped<ICategoriasService, CategoriasService>();
            services.AddScoped<ICategoriasRepository, CategoriasRepository>();
            services.AddScoped<IEstabelecimentosRepository, EstabelecimentosRepository>();
            services.AddScoped<IEstabelecimentosService, EstabelecimentosService>();
        }

        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FiTCARD",
                    Version = "v1",
                    Description = "FiTCARD Establishments"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FiTCARD");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
