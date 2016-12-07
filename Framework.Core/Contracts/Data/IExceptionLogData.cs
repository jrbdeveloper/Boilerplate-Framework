using Framework.Core.ViewModels;
using System.Collections.Generic;

namespace Framework.Core.Contracts.Data
{
    public interface IExceptionLogData
    {
        IEnumerable<ExceptionLogViewModel> GetAll();

        string GetStackTrace(int id);
    }
}