using System.Collections.Generic;

namespace Framework.Core.ViewModels
{
    public class PersonViewModel : BaseViewModel
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public int Age { get; set; }

        public List<PersonViewModel> People { get; set; }

        public int PeopleCount { get; set; }
    }
}