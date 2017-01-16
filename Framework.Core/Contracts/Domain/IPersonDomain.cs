using Framework.Core.ViewModels;
using System.Collections.Generic;

namespace Framework.Core.Contracts.Domain
{
    public interface IPersonDomain
    {
        IEnumerable<PersonViewModel> GetAll();

        IEnumerable<PersonViewModel> GetByLastName(string lastName);

        PersonViewModel GetById(int id);

        IEnumerable<PersonViewModel> GetByHeight(Measurement height);

        int GetHeadCount();

        IEnumerable<PersonViewModel> GetByHeightAndFirst(Measurement height, string first);
    }
}