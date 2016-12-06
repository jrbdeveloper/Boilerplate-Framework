using Framework.Core.Enums;
using System.Collections.Generic;

namespace Framework.Core.ViewModels
{
    public class CarViewModel : BaseViewModel
    {
        public string Seat { get; set; }

        public string SteeringWheel { get; set; }

        public CarEngines Engine { get; set; }

        public IEnumerable<CarViewModel> Cars { get; set; }
    }
}