using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Am.ApplicationCore.Domain;

namespace AM.ApplicationCore.Domain
{
    public static class TestData
    {
        public static Plane BoingPlane = new Plane { type = PlaneType.Boing, Capacity = 150, ManufactDate = new DateTime(2015, 02, 03) };
        public static Plane Airbusplane = new Plane { type = PlaneType.Airbus, Capacity = 250, ManufactDate = new DateTime(2020, 11, 11) };
        // Staffs
        public static Staff captain = new Staff { FullName = new FullName { FirstName = "captain", LastName = "captain" } , EmailPassort = "captain.captain@gmail.com", BirthDate  = new DateTime(1965, 01, 01), EmploymentDate = new DateTime(1999, 01, 01), Salary = 99999 };
        public static Staff hostess1 = new Staff { FullName = new FullName {FirstName = "hostess1", LastName = "hostess1"}, EmailPassort = "hostess1.hostess1@gmail.com", BirthDate = new DateTime(1995, 01, 01), EmploymentDate = new DateTime(2020, 01, 01), Salary = 999 };
        public static Staff hostess2 = new Staff {FullName = new FullName{ FirstName = "hostess2", LastName = "hostess2"}, EmailPassort = "hostess2.hostess2@gmail.com", BirthDate = new DateTime(1996, 01, 01), EmploymentDate = new DateTime(2020, 01, 01), Salary = 999 };
        // Travellers
         public static Travaler traveller1 = new Travaler { FullName = new FullName { FirstName = "traveller1", LastName = "traveller1" }, EmailPassort = "traveller1.traveller1@gmail.com", BirthDate = new DateTime(1980, 01, 01), healthinformation = "no troubles", Nationlitay = "American" };
          public static Travaler traveller2 = new Travaler { FullName = new FullName { FirstName = "traveller2", LastName = "traveller2" }, EmailPassort = "traveller2.traveller2@gmail.com", BirthDate = new DateTime(1981, 01, 01), healthinformation = "Some troubles", Nationlitay = "French" };
         public static Travaler traveller3 = new Travaler { FullName = new FullName { FirstName = "traveller3", LastName = "traveller3" }, EmailPassort = "traveller3.traveller3@gmail.com", BirthDate = new DateTime(1982, 01, 01), healthinformation = "no troubles", Nationlitay = "Tunisian" };
        // public static Travaler traveller4 = new Travaler { FirstName = "traveller4", LastName = "traveller4", EmailPassort = "traveller4.traveller4@gmail.com", BirthDate = new DateTime(1983, 01, 01), healthinformation = "Some troubles", Nationlitay = "American" };
        // public static Travaler traveller5 = new Travaler { FirstName = "traveller5", LastName = "traveller5", EmailPassort = "traveller5.traveller5@gmail.com", BirthDate = new DateTime(1984, 01, 01), healthinformation = "Some troubles", Nationlitay = "Spanish" };
        // Flights
        // Affect all passengers to flight1
        public static Flight flight1 = new Flight
        {
            FlightDate = new DateTime(2022, 01, 01, 15, 10, 10),
            Destination = "Paris",
            EffictiveArrival = new DateTime(2022, 01, 01, 17, 10, 10),
            EstimedDuration = 110,
        passengers = new List<Passengers> { captain, hostess1, hostess2, traveller1, traveller2, traveller3},


            plane = Airbusplane
        };
        public static Flight flight2 = new Flight { FlightDate = new DateTime(2022, 02, 01, 21, 10, 10), Destination = "Paris", EffictiveArrival = new DateTime(2022, 02, 01, 23, 10, 10), EstimedDuration = 105, plane = BoingPlane };
        public static Flight flight3 = new Flight { FlightDate = new DateTime(2022, 02, 02, 5, 10, 10), Destination = "Paris", EffictiveArrival = new DateTime(2022, 03, 01, 6, 40, 10), EstimedDuration = 100, plane = BoingPlane };
        public static Flight flight4 = new Flight { FlightDate = new DateTime(2022, 04, 01, 6, 10, 10), Destination = "Madrid", EffictiveArrival = new DateTime(2022, 04, 01, 8, 10, 10), EstimedDuration = 130, plane = BoingPlane };
        public static Flight flight5 = new Flight { FlightDate = new DateTime(2022, 05, 01, 17, 10, 10), Destination = "Madrid", EffictiveArrival = new DateTime(2022, 05, 01, 18, 50, 10), EstimedDuration= 105, plane = BoingPlane };
        public static Flight flight6 = new Flight { FlightDate = new DateTime(2022, 06, 01, 20, 10, 10), Destination = "Lisbonne", EffictiveArrival = new DateTime(2022, 06, 01, 22, 30, 10), EstimedDuration = 200, plane = Airbusplane };


        //test list
        public static List<Flight> listFlights = new List<Flight> { flight1, flight2, flight3, flight4, flight5, flight6 };
    }
}
