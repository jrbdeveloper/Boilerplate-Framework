using Framework.Core.Contracts.Data;
using Framework.Core.Contracts.Domain;
using Framework.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Domain
{
    public class PersonDomain : BaseModel, IPersonDomain
    {
        private readonly IPersonData _personData;

        public PersonDomain(IPersonData personData)
        {
            _personData = personData;
        }

        public IEnumerable<PersonViewModel> GetAll()
        {
            return _personData.GetAll();
        }

        public int GetHeadCount()
        {
            return GetAll().Count();
        }

        public IEnumerable<PersonViewModel> GetByFirstName(string first)
        {
            return _personData.GetByFirstName(first);
        }

        public IEnumerable<PersonViewModel> GetByLastName(string last)
        {
            return _personData.GetByLastName(last);
        }

        public PersonViewModel GetById(int id)
        {
            return _personData.GetById(id);
        }

        public void Save(PersonViewModel person)
        {
            _personData.Save(person);
        }

        public void Delete(int id)
        {
            _personData.Delete(id);
        }
    }
}