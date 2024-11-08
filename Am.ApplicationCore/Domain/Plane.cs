using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Am.ApplicationCore.Domain
{
    public enum PlaneType
    {
        Boing,
        Airbus
    }
    public class Plane //toujour en met public
    {
      public int PlaneId { get; set; }

        [Range(5, int.MaxValue, ErrorMessage = "La capacité doit être un entier positif.")]//un entier positif
        public int Capacity { get; set; }

    
    public virtual DateTime ManufactDate { get; set; }
        public virtual PlaneType type { get; set; } //enumerations
      public virtual  ICollection<Flight> flight { get; set; }

        public override string? ToString()
        {
            return "capacity" + Capacity + "manufacturyDate" + ManufactDate + "pLanetype" + type;//je veut  affchier capacity les atributs
        }

        public Plane()
        {
        }

        
    }
}
