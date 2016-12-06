using log4net;
using System.Reflection;

namespace Framework.Domain
{
    public abstract class BaseModel
    {
        protected static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    }
}