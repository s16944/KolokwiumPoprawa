using KolokwiumPoprawa.DTO;
using KolokwiumPoprawa.Mappers;
using KolokwiumPoprawa.Middlewares;
using KolokwiumPoprawa.Models;
using KolokwiumPoprawa.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KolokwiumPoprawa
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
            services.AddScoped<IDbService, EfDbService>();
            services.AddScoped<IMapper<AddArtistRequest, Artist>, AddArtistRequestToArtistMapper>();
            services.AddScoped<IMapper<Artist, AddArtistResponse>, ArtistToAddArtistResponseMapper>();
            services.AddDbContext<ArtistsDbContext>(options =>
            {
                options.UseSqlServer("Data Source=db-mssql;Initial Catalog=s16944;Integrated Security=True");
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ErrorMapMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}