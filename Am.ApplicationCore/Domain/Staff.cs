using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Am.ApplicationCore.Domain
{
   public class Staff :Passengers //heritage hadhi a:b
    {
        public string Function { get; set; }
        public DateTime EmploymentDate { get; set; }
        //  [Range(0.01, double.MaxValue, ErrorMessage = "Le salaire doit être une valeur monétaire positive.")]
        [DataType(DataType.Currency)]
       
        public  float Salary { get; set; }

      

        public override string? ToString()
        {
            return "Function" +Function+ "EmploymentDate "+ EmploymentDate+ "Salary"+ Salary;
        }
        //polymorphisme par heretage
        public override void PassengerType()//virtual abstract fel java fi blaset override
        {
            base.PassengerType();
            Console.WriteLine("I am a Staff Member");
            

        }
       
    }
}
