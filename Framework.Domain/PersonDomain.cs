using Framework.Core.Contracts.Data;
using Framework.Core.Contracts.Domain;
using Framework.Core.ViewModels;
using System.Collections.Generic;

namespace Framework.Domain
{
    public class PersonDomain : BaseModel, IPersonDomain
    {
        private readonly IPersonData _personData;

        public PersonDomain(IPersonData personData)
        {
            _personData = personData;
        }

        public List<PersonViewModel> GetAll()
        {
            return _personData.GetAll();
        }

        public List<PersonViewModel> GetByLastName(string lastName)
        {
            return _personData.GetByLastName(lastName);
        }

        public PersonViewModel GetById(int id)
        {
            return _personData.GetById(id);
        }
    }
}