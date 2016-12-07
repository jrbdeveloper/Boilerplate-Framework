using Ninject.Modules;
using Framework.Core.Contracts.Data;
using Framework.Data;

namespace Framework.Infrastructure.IoCModules
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPersonData>().To<PersonData>();
            Bind<ICarData>().To<CarData>();
        }
    }
}