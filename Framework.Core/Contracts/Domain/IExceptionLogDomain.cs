using Framework.Core.ViewModels;
using System.Collections.Generic;

namespace Framework.Core.Contracts.Domain
{
    public interface IExceptionLogDomain
    {
        IEnumerable<ExceptionLogViewModel> GetAll();

        string GetStackTrace(int id);
    }
}