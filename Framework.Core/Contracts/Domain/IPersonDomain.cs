using Framework.Core.ViewModels;
using System.Collections.Generic;

namespace Framework.Core.Contracts.Domain
{
    public interface IPersonDomain
    {
        IEnumerable<PersonViewModel> GetAll();

        IEnumerable<PersonViewModel> GetByLastName(string lastName);

        PersonViewModel GetById(int id);

        int GetHeadCount();

        void Save(PersonViewModel person);

        void Delete(int id);
    }
}