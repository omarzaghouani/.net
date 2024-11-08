using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Am.ApplicationCore.Domain
{
    public class Travaler : Passengers
    {
        public string  healthinformation { get; set; }

        public string  Nationlitay{ get; set; }

        public override string? ToString()
        {
            return "healthinformation" + healthinformation+ "Nationlitay";
        }

        public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("I am a traveller");
        }
    }

}
