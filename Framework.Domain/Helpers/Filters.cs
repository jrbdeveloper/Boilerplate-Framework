using Framework.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Domain
{
    public static class Filters
    {
        public static IEnumerable<CarViewModel> FilterByColor(this IEnumerable<CarViewModel> sequence, string filterValue)
        {
            return sequence.Where(s => s.Color.Equals(filterValue)).ToList();
        }

        public static IEnumerable<CarViewModel> FilterByMake(this IEnumerable<CarViewModel> sequence, string filterValue)
        {
            return sequence.Where(s => s.Make.Equals(filterValue)).ToList();
        }

        public static IEnumerable<PersonViewModel> ByFirstName(this IEnumerable<PersonViewModel> list, string first)
        {
            return list.Where(s => s.FirstName.Equals(first));
        }

        public static IEnumerable<PersonViewModel> ByLastName(this IEnumerable<PersonViewModel> list, string last)
        {
            return list.Where(s => s.LastName.Equals(last));
        }
    }
}