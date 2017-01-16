using log4net;
using System.Reflection;

namespace Framework.Data
{
    public abstract class BaseData
    {
        protected static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public BaseData()
        {
            
        }
    }
}