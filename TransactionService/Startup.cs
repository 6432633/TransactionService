using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using TransactionService;
using TransactionService.Controllers;
using TransactionService.Data;
using TransactionService.ImgValidator;

namespace UserService
{
    public class Startup
    {
        private IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TransactionContext>(options => options.UseNpgsql
            (_configuration.GetConnectionString("TransactionConnection")));
            services.AddControllers().AddNewtonsoftJson(s =>
                     s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddOptions();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
        public void ConfigureIoC(IServiceCollection services, ContainerBuilder builder)
        {

            builder.RegisterModule(new IoCConfigurator());
        }
    }
}