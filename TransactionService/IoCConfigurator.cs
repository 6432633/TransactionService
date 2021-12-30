using Autofac;
using TransactionService.Controllers;
using TransactionService.ImgValidator;

namespace TransactionService
{
    public class IoCConfigurator : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FaceValidator>().As<IFaceValidator>();
            builder.RegisterType<PassportValidator>().As<IPassportValidator>();
            builder.RegisterType<LivenessValidator>().As<ILivenessValidator>();
        }
    }
}
