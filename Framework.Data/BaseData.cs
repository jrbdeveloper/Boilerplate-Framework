using AutoMapper;
using Framework.Core.ViewModels;
using log4net;
using System.Reflection;

namespace Framework.Data
{
    public abstract class BaseData
    {
        protected static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public BaseData()
        {
            Mapper.Initialize(cfg =>
            {
                //cfg.CreateMap<Car, CarViewModel>();
            });
        }
    }
}