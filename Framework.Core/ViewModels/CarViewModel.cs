using Framework.Core.Enums;
using System.Collections.Generic;

namespace Framework.Core.ViewModels
{
    public class CarViewModel : BaseViewModel
    {
        public int ID { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string Color { get; set; }

        public CarEngines Engine { get; set; }

        public IEnumerable<CarViewModel> Cars { get; set; }
    }
}