using Framework.Core.Contracts.Data;
using Framework.Core.Contracts.Domain;
using Framework.Core.ViewModels;
using System.Collections.Generic;

namespace Framework.Domain
{
    public class ExceptionLogDomain : BaseModel, IExceptionLogDomain
    {
        private readonly IExceptionLogData _exceptionLogData;

        public ExceptionLogDomain(IExceptionLogData exceptionLogData)
        {
            _exceptionLogData = exceptionLogData;
        }

        public IEnumerable<ExceptionLogViewModel> GetAll()
        {
            return _exceptionLogData.GetAll();
        }

        public string GetStackTrace(int id)
        {
            return _exceptionLogData.GetStackTrace(id);
        }
    }
}