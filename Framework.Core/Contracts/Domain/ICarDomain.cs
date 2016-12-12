using Framework.Core.ViewModels;
using System.Collections.Generic;

namespace Framework.Core.Contracts.Domain
{
    public interface ICarDomain
    {
        IEnumerable<CarViewModel> GetAll();

        IEnumerable<CarViewModel> GetFiltered();

        CarViewModel GetById(int id);
    }
}