using Framework.Core.ViewModels;
using System.Collections.Generic;

namespace Framework.Core.Contracts.Data
{
    public interface IPersonData
    {
        List<PersonViewModel> GetAll();

        PersonViewModel GetById(int id);

        List<PersonViewModel> GetByFirstName(string first);

        List<PersonViewModel> GetByLastName(string last);

        void Remove(PersonViewModel person);

        void Remove(List<PersonViewModel> people);
    }
}