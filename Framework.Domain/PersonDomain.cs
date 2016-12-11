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

        public List<PersonViewModel> GetAll()
        {
            return _personData.GetAll();
        }

        public int GetHeadCount()
        {
            return GetAll().Count;
        }

        public List<PersonViewModel> GetByFirstName(string first)
        {
            var people = GetAll().ByFirstName(first).ToList();

            _personData.Remove(people);

            return people;
        }

        public List<PersonViewModel> GetByLastName(string last)
        {
            var people = GetAll().ByLastName(last).ToList();

            _personData.Remove(people);

            return people;
        }

        public PersonViewModel GetById(int id)
        {
            return _personData.GetById(id);
        }

        public List<PersonViewModel> GetByHeightAndFirst(Measurement height, string first)
        {
            var people = GetAll().ByFirstName(first).ByHeight(new Measurement
            {
                Feet = height.Feet,
                Inches = height.Inches
            }).ToList();

            _personData.Remove(people);

            return people;
        }

        public List<PersonViewModel> GetByHeight(Measurement height)
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