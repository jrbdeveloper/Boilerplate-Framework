using AutoMapper;
using Framework.Core.Contracts.Data;
using Framework.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Data
{
    public class ExceptionLogData : BaseData, IExceptionLogData
    {
        public IEnumerable<ExceptionLogViewModel> GetAll()
        {
            //using (var context = new TransferSelectionEntities())
            //{
            //    var list = (from item in context.ExceptionLogs
            //                select item).OrderByDescending(x => x.Date.Day).ToList();

            //    return Mapper.Map<List<ExceptionLogViewModel>>(list);
            //}

            return new List<ExceptionLogViewModel>();
        }

        public string GetStackTrace(int id)
        {
            //using (var context = new TransferSelectionEntities())
            //{
            //    return context.ExceptionLogs.Where(x => x.ID == id).Single().Exception;
            //}

            return string.Empty;
        }
    }
}