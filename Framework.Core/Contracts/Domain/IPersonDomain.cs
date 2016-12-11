using Framework.Core.ViewModels;
using System.Collections.Generic;

namespace Framework.Core.Contracts.Domain
{
    public interface IPersonDomain
    {
        List<PersonViewModel> GetAll();

        List<PersonViewModel> GetByLastName(string lastName);

        PersonViewModel GetById(int id);

        List<PersonViewModel> GetByHeight(Measurement height);

        int GetHeadCount();

        List<PersonViewModel> GetByHeightAndFirst(Measurement height, string first);
    }
}