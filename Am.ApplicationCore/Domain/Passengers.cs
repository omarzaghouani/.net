using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Am.ApplicationCore.Domain
{
    public class Passengers

    {

        // public int Id { get; set; }
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]//affichée “Date of Birth”//■ une date valide
        public DateTime BirthDate { get; set; }
        [Key]//primary key
        [StringLength(7)]
        public int PassportNumber { get; set; }
        [DataType(DataType.DateTime)]
        public string EmailPassort { get; set; }

        public FullName FullName {  get; set; }

        [RegularExpression(@"[0-9]{8}$",ErrorMessage = "invalid phone number")]
        public int TelNumber { get; set; }

        public virtual ICollection<Flight>flight{ get; set; }
        // Propriétés de navigation
        public virtual ICollection<Ticket> Tickets { get; set; }

        public override string? ToString()
        {
            return "BirthDate" +BirthDate+ "TelNumber " +TelNumber;
        }

        
        //public bool CheckProfile(String FirstName, String LastName)
      //  {
        //    return FirstName == FirstName && LastName == LastName;
      //  }
      //  public bool CheckProfile(string firstName, string lastName, string email)
       // {
        //    return FirstName == firstName && LastName == lastName && EmailPassort == email;
       // }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }

    }
}
