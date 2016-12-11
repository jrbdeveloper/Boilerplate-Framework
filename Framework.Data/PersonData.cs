using Framework.Core.Contracts.Data;
using Framework.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Data
{
    public class PersonData : BaseData, IPersonData
    {
        private List<PersonViewModel> _people;

        private List<PersonViewModel> people = new List<PersonViewModel>();
        private List<Measurement> Heights = new List<Measurement>();
        private List<Measurement> Lengths = new List<Measurement>();
        private List<Hair> Hairs = new List<Hair>();

        public PersonData()
        {
            InitializeLengths();
            InitializeHeights();
            InitializeHairs();

            people.Add(new PersonViewModel
            {
                ID = 1,
                FirstName = "John",
                LastName = "Doe",
                Weight = 155,
                EyeColor = "Brown",
                Age = 42,
                Height = Heights[0],
                Hair = Hairs[0]
            });

            people.Add(new PersonViewModel
            {
                ID = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Weight = 125,
                EyeColor = "Blue",
                Age = 47,
                Height = Heights[0],
                Hair = Hairs[3]
            });

            people.Add(new PersonViewModel
            {
                ID = 3,
                FirstName = "Dame",
                LastName = "Doe",
                Weight = 112,
                EyeColor = "Brown",
                Age = 21,
                Height = Heights[2],
                Hair = Hairs[2]
            });

            people.Add(new PersonViewModel
            {
                ID = 4,
                FirstName = "Chap",
                LastName = "Doe",
                Weight = 155,
                EyeColor = "Brown",
                Age = 19,
                Height = Heights[1],
                Hair = Hairs[2]
            });
        }

        private void InitializeLengths()
        {
            Lengths.Add(new Measurement { Feet = 3, Inches = 2 });
            Lengths.Add(new Measurement { Feet = 2, Inches = 1 });
            Lengths.Add(new Measurement { Feet = 4, Inches = 6 });
            Lengths.Add(new Measurement { Feet = 0, Inches = 2 });
            Lengths.Add(new Measurement { Feet = 0, Inches = 4 });
        }

        private void InitializeHeights()
        {
            Heights.Add(new Measurement { Feet = 5, Inches = 6 });
            Heights.Add(new Measurement { Feet = 6, Inches = 0 });
            Heights.Add(new Measurement { Feet = 5, Inches = 2 });
        }

        private void InitializeHairs()
        {
            Hairs.Add(new Hair { Color = "Brown", Style = Core.Enums.HairStyle.Curley, Length = Lengths[1] });
            Hairs.Add(new Hair { Color = "Blond", Style = Core.Enums.HairStyle.Straight, Length = Lengths[2] });
            Hairs.Add(new Hair { Color = "Black", Style = Core.Enums.HairStyle.Thick, Length = Lengths[3] });
            Hairs.Add(new Hair { Color = "Red", Style = Core.Enums.HairStyle.Thin, Length = Lengths[4] });
        }

        public List<PersonViewModel> GetAll()
        {
            if (_people == null)
            {
                _people = people;
            }

            return _people;
        }

        public void Remove(PersonViewModel person)
        {
            _people.Remove(person);
        }

        public void Remove(List<PersonViewModel> people)
        {
            foreach (var person in people)
            {
                _people.Remove(person);
            }
        }

        public PersonViewModel GetById(int id)
        {
            var found = (from person in people
                         where person.ID.Equals(id)
                         select person).Single();

            return found;
        }

        public List<PersonViewModel> GetByFirstName(string first)
        {
            var list = (from person in people
                        where person.LastName.Equals(first)
                        select person).ToList();

            return list;
        }

        public List<PersonViewModel> GetByLastName(string last)
        {
            var list = (from person in people
                        where person.LastName.Equals(last)
                        select person).ToList();

            return list;
        }        
    }
}