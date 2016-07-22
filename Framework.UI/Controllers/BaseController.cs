using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Framework.UI.Controllers
{
    public class BaseController : Controller
    {

        protected List<Car> GetAllCars()
        {
            var cars = new List<Car>();
            cars.Add(new Car
            {
                Seat = "Leather",
                SteeringWheel = "Full Controls",
                Engine = "8 Cylindar"
            });

            cars.Add(new Car
            {
                Seat = "Leather",
                SteeringWheel = "No Controls",
                Engine = "8 Cylindar"
            });

            cars.Add(new Car
            {
                Seat = "Fabric",
                SteeringWheel = "Some Controls",
                Engine = "6 Cylindar"
            });

            cars.Add(new Car
            {
                Seat = "Fabric",
                SteeringWheel = "No Controls",
                Engine = "4 Cylindar"
            });

            cars.Add(new Car
            {
                Seat = "Fabric",
                SteeringWheel = "No Controls",
                Engine = "6 Cylindar"
            });

            return cars;
        }

    }

    public static class ListExtensions
    {
        public static IEnumerable<Car> FilterBySeat(this IEnumerable<Car> sequence, string filterValue)
        {
            return sequence.Where(s => s.Seat.Equals(filterValue));
        }

        public static IEnumerable<Car> FilterBySteeringWheel(this IEnumerable<Car> sequence, string filterValue)
        {
            return sequence.Where(s => s.SteeringWheel.Equals(filterValue));
        }
    }

    public class Car
    {
        public string Seat { get; set; }
        public string SteeringWheel { get; set; }
        public string Engine { get; set; }
    }
}