using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Am.ApplicationCore.Domain
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public double Prix { get; set; }
        public string Siege { get; set; }
        public bool VIP { get; set; }

        // Clé étrangère et propriété de navigation pour Passenger
        [ForeignKey("Passenger")]
        public int PassengerFK { get; set; }
        public Passengers Passenger { get; set; }

        // Clé étrangère et propriété de navigation pour Flight
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
    }
}