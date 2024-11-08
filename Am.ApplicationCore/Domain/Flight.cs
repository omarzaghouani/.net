using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Am.ApplicationCore.Domain
{
    public class Flight
    {
        public string Destination { get; set; }

        public string AirlineLogo { get; set; }
        public string departure { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }
        public DateTime EffictiveArrival{ get; set; }
        public int EstimedDuration { get; set; }

        public Plane plane { get; set; }
        public virtual ICollection<Passengers> passengers { get; set; }
        public  virtual ICollection<Ticket> Tickets { get; set; }
        //cle etranger
        //[foreign key]
        //public plane plane{get; set;]
        [ForeignKey("PlaneFK")]
        public int PLaneFK { get; set; }

        public override string? ToString()
        {
            return "destintion" +Destination+ "departure" +departure+ "flightdate" +FlightDate +"Flight";
        }

        //  public static implicit operator Flight(Flight v)
        // {
        //     throw new NotImplementedException();
        //  }//Add-Migration NewPropertyAirline -Project AM.Infrastructure -StartupProject AM.Infrastructure ajouter fel base( Ajouter la migration NewPropertyAirline)
        //Update-Database -Project AM.Infrastructure -StartupProject AM.Infrastructure Mettre à jour la base de données 

    }
}
