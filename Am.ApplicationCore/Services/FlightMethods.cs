using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Am.ApplicationCore.Domain;
using Am.ApplicationCore.Interfaces;

namespace Am.ApplicationCore.Services
{

    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; }

        public Action<Plane> FlightDetailsDel;//délégué
        public Func<string, double> DurationAverageDel;
        public FlightMethods()
        {
            DurationAverageDel = DurationAverge;
            FlightDetailsDel = ShowFlightDetails;
            
                // Affectation d'expressions lambda aux délégués

                FlightDetailsDel = plane =>
                {
                    var flightsByPlane = Flights.Where(f => f.plane == plane);
                    foreach (var flight in flightsByPlane)
                    {
                        Console.WriteLine($"Date: {flight.FlightDate}, Destination: {flight.Destination}");
                    }
                };

                DurationAverageDel = dest =>
                {
                    return (from f in Flights
                            where f.Destination.Equals(dest)
                            select f.EstimedDuration).Average();
                };
            
        }

            public void ListAllFlights()
        {
            foreach (var flight in Flights)
            {
                Console.WriteLine(flight.ToString());
            }
        }

        //  nfiltri biha les vols destination
        public List<Flight> GetFlightsByDestination(string destination)
        {
            return Flights.Where(f => f.Destination == destination).ToList();
        }


        public IEnumerable<DateTime> GetFlightDates(string destination)
        {
            IEnumerable<DateTime> d = new List<DateTime>();
            for (int i = 0; i < Flights.Count; i++)
            {
                {
                    if (Flights[i].Destination.Equals(destination))
                    {
                        d.Append(Flights[i].FlightDate);
                    }

                }

            }
            return d;
        }
        public IEnumerable<DateTime> GetFlightdates(string destination)
        {
            List<DateTime> flightDates = new List<DateTime>();

            foreach (var flight in Flights)
            {
                if (flight.Destination.Equals(destination))
                {
                    flightDates.Add(flight.FlightDate);
                }
            }

            return flightDates;
        }





        //ex8
        public void GetFlights(string filterType, string filterValue)
        {
            var filteredFlights = Flights.Where(flight =>
            {
                var property = typeof(Flight).GetProperty(filterType);
                if (property != null)
                {
                    var value = property.GetValue(flight)?.ToString();
                    return value != null && value.Equals(filterValue, StringComparison.OrdinalIgnoreCase);
                }
                return false;
            });

            foreach (var flight in filteredFlights)
            {
                Console.WriteLine(flight.ToString());
            }
        }

        //ex9
        public IEnumerable<DateTime> GetFlightdate(string destination)
        {
            return Flights
                .Where(f => f.Destination.Equals(destination))
                .Select(f => f.FlightDate);
        }



        public int ProgrammedFlightNumber(DateTime startDate)//compare
        {
            DateTime endDate = startDate.AddDays(7);
            return Flights.Count(f => f.FlightDate >= startDate && f.FlightDate <= endDate);
        }






        public void ShowFlightDetails(Plane plane)
        {
            var flightsByPlane = Flights.Where(f => f.plane == plane);

            foreach (var flight in flightsByPlane)
            {
                Console.WriteLine($"Date: {flight.FlightDate}, Destination: {flight.Destination}");
            }



        }
        public double DurationAverge(string destination)
        {
            var req = from flight in Flights
                      where flight.Destination.Equals(destination)
                      select flight.EstimedDuration;
            return req.Average();
        }
        /* public IEnumerable<Flight> OrderedDurationFlights()
         {
             var req = from f in Flights
                       orderby f.EstimedDuration descending
                       select f;
             return req;


         }*/
        public void OrderFlightsByDuration()
        {
            var orderedFlights = Flights.OrderBy(f => f.EstimedDuration).ToList();

            foreach (var flight in orderedFlights)
            {
                Console.WriteLine($"Flight to {flight.Destination}, Duration: {flight.EstimedDuration}, Departure: {flight.FlightDate}");
            }
        }

        public IEnumerable<Travaler> SeniorTravellers(Flight f)

        {
            var req = (from t in f.passengers.OfType<Travaler>()
                       orderby t.BirthDate descending
                       select t).Take(3);

            return req;

        }
        /*group f by f.Destination : Nous regroupons chaque vol f selon sa propriété Destination. Cela crée des groupes de vols ayant la même destination.
Le résultat est une collection de groupes, où chaque groupe est de type IGrouping<string, Flight>.
g.Key représente la clé du groupe, ici la destination (chaîne de caractères).*/
        //ex15
        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var req = from f in Flights
                      group f by f.Destination;
            foreach (var g in req)
            {
                Console.WriteLine("Destination: " + g.Key);
                foreach (var f in g)
                    Console.WriteLine("Décollage: " + f.FlightDate);
            }
            return req;
        }


        public IEnumerable<Flight> OrderedDurationFlights()
        {
            var req = from f in Flights
                      orderby f.EstimedDuration descending
                      select f;
            return req;
        }

        //ex19
       /* public static class PassengerExtension
        {
            public static void UpperFullName(this Passengers p)
            {
                p.FirstName = p.FirstName[0].ToString().ToUpper() + p.FirstName.Substring(1);
                p.LastName = p.LastName[0].ToString().ToUpper() + p.LastName.Substring(1);
            }
        }*/
    }
}