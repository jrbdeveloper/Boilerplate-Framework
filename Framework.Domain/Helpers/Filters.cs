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
    }
}