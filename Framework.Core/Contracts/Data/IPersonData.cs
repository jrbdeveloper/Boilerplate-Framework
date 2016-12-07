using Framework.Core.ViewModels;
using System.Collections.Generic;

namespace Framework.Core.Contracts.Data
{
    public interface IPersonData
    {
        List<PersonViewModel> GetAll();

        PersonViewModel GetById(int id);

        List<PersonViewModel> GetByLastName(string lastName);
    }
}