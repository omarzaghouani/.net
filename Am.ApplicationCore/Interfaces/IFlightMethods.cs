using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Am.ApplicationCore.Domain;

namespace Am.ApplicationCore.Interfaces
{
    internal interface IFlightMethods
    {
        IEnumerable<DateTime> GetFlightdates(string destination);
        void GetFlights(string filterType, string filterValue);
        void ShowFlightDetails(Plane plane);
        int ProgrammedFlightNumber(DateTime startDate);
        double DurationAverge(string destination);
        IEnumerable<Flight> OrderedDurationFlights();
        void OrderFlightsByDuration();
        IEnumerable<Travaler> SeniorTravellers(Flight f);
        IEnumerable<IGrouping<string,Flight>> DestinationGroupedFlights();
    }
    //static void UpperFullName(this Passengers p);
}
