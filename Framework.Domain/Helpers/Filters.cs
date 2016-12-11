using Framework.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Domain
{
    public static class Filters
    {
        public static IEnumerable<CarViewModel> FilterBySeat(this IEnumerable<CarViewModel> sequence, string filterValue)
        {
            return sequence.Where(s => s.Seat.Equals(filterValue)).ToList();
        }

        public static IEnumerable<CarViewModel> FilterBySteeringWheel(this IEnumerable<CarViewModel> sequence, string filterValue)
        {
            return sequence.Where(s => s.SteeringWheel.Equals(filterValue)).ToList();
        }

        public static IEnumerable<PersonViewModel> ByFirstName(this IEnumerable<PersonViewModel> list, string first)
        {
            return list.Where(s => s.FirstName.Equals(first));
        }

        public static IEnumerable<PersonViewModel> ByLastName(this IEnumerable<PersonViewModel> list, string last)
        {
            return list.Where(s => s.LastName.Equals(last));
        }

        public static IEnumerable<PersonViewModel> ByHeight(this IEnumerable<PersonViewModel> list, Measurement height)
        {
            return list.Where(s => s.Height.Feet.Equals(height.Feet) && s.Height.Inches.Equals(height.Inches));
        }
    }
}