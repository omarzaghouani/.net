using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Am.ApplicationCore.Domain;

namespace Am.ApplicationCore.Services
{
    public static class PassengerExtension
    {
        // Méthode d'extension pour obtenir le nom complet en majuscule
        public static string UpperFullName(this Passengers passenger)
        {
            // Vérifiez si les noms ne sont pas vides ou null
            if (passenger?.FullName != null && !string.IsNullOrEmpty(passenger.FullName.FirstName) && !string.IsNullOrEmpty(passenger.FullName.LastName))
            {
                var cultureInfo = CultureInfo.CurrentCulture;
                var textInfo = cultureInfo.TextInfo;

                // Formater le prénom et le nom de famille
                string formattedFirstName = textInfo.ToTitleCase(passenger.FullName.FirstName.ToLower());
                string formattedLastName = textInfo.ToTitleCase(passenger.FullName.LastName.ToLower());

                return $"{formattedFirstName} {formattedLastName}";
            }
            return string.Empty; //nrj3ou chaine fergha kiybda nom prenom vide et null
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
