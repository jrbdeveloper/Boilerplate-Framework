using Framework.Core.Enums;
using System.Collections.Generic;

namespace Framework.Core.ViewModels
{
    public class PersonViewModel
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Measurement Height { get; set; }

        public int Weight { get; set; }

        public string EyeColor { get; set; }

        public Hair Hair { get; set; }

        public int Age { get; set; }

        public List<PersonViewModel> People { get; set; }

        public int PeopleCount { get; set; }
    }

    public class Hair
    {
        public string Color { get; set; }

        public Measurement Length { get; set; }

        public HairStyle Style { get; set; }
    }

    public class Measurement
    {
        public int Feet { get; set; }

        public int Inches { get; set; }
    }
}