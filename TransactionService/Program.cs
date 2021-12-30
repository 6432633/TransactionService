
using Autofac;
using Autofac.Extensions.DependencyInjection;
using TransactionService;

namespace UserService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new IoCConfigurator() ))
            .ConfigureWebHostDefaults(webbuilder => {
                webbuilder.UseStartup<Startup>();
            });
    }
}