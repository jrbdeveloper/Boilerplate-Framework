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
        private IEnumerable<PersonViewModel> _people;

        public PersonDomain(IPersonData personData)
        {
            _personData = personData;
        }

        public IEnumerable<PersonViewModel> GetAll()
        {
            if (_people == null)
            {
                _people = _personData.GetAll();
            }

            return _people;
        }

        public int GetHeadCount()
        {
            return GetAll().Count();
        }

        public IEnumerable<PersonViewModel> GetByFirstName(string first)
        {
            var people = GetAll().ByFirstName(first).ToList();

            _personData.Remove(people);

            return people;
        }

        public IEnumerable<PersonViewModel> GetByLastName(string last)
        {
            var people = GetAll().ByLastName(last).ToList();

            _personData.Remove(people);

            return people;
        }

        public PersonViewModel GetById(int id)
        {
            return _personData.GetById(id);
        }

        public IEnumerable<PersonViewModel> GetByHeightAndFirst(Measurement height, string first)
        {
            var people = GetAll().ByFirstName(first).ByHeight(new Measurement
            {
                Feet = height.Feet,
                Inches = height.Inches
            }).ToList();

            _personData.Remove(people);

            return people;
        }

        public IEnumerable<PersonViewModel> GetByHeight(Measurement height)
        {
            var people = GetAll().ByHeight(new Measurement
            {
                Feet = height.Feet,
                Inches = height.Inches
            }).ToList();

            _personData.Remove(people);

            return people;
        }        
    }
}