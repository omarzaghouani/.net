// See https://aka.ms/new-console-template for more information



using System.Runtime.InteropServices.ObjectiveC;
using System.Security.Claims;
using Am.ApplicationCore.Domain;
using Am.ApplicationCore.Services;
using AM.ApplicationCore.Domain;
using AM.infrastructure;

Console.WriteLine("*****testing*****");

//Plane plane = new Plane();//njmou nest3mlou hadhi wle lokhra khater a9ser washel
//plane.Capacity = 100;
//plane.ManufactDate = DateTime.Now;
//plane.type = PlaneType.Boing;
//Plane plane2 = new Plane(100, DateTime.Now,PlaneType.Airbus);

Plane plane2 = new Plane { Capacity =300,type= PlaneType.Airbus , ManufactDate =new DateTime(2024,09,18)};

Console.WriteLine("I am a passenger");
//Passengers pas = new Passengers {FirstName ="Omar",LastName ="zaghouani", EmailPassort="omarzaghouani@esprit.tn"};
//Console.WriteLine (pas.CheckProfile("Omar","zaghouani"));
//Console.WriteLine(pas.CheckProfile("Omar", "zaghouani", "omarzaghouani@esprit.tn"));

Console.WriteLine("Testing PassengerType method...");


Passengers passenger = new Passengers();
passenger.PassengerType(); 


Staff staff = new Staff();
staff.PassengerType();


Travaler traveler = new Travaler();
traveler.PassengerType();
FlightMethods f=new FlightMethods ();
f.Flights = TestData.listFlights;
FlightMethods fm = new FlightMethods();
fm.Flights = TestData.listFlights;
Console.WriteLine("***********getflightdate (string destniton)");
Console.WriteLine("flight dates to Lisbonne");
foreach (var item in fm.GetFlightdates("Lisbonne"))
    Console.WriteLine(item);

Console.WriteLine("show flight details");
fm.ShowFlightDetails(TestData.Airbusplane);

Console.WriteLine("number of programmed flight in 01/01/2022 week");
Console.WriteLine(fm.ProgrammedFlightNumber(new DateTime(2022, 01, 31)));
Console.WriteLine("***************durationaverge*******");
Console.WriteLine("duration average of flight to Madrid:"+fm.DurationAverge("Madrid"));
Console.WriteLine("***Ordered Flights by Duration***");
fm.OrderFlightsByDuration();
fm.OrderedDurationFlights();
//insertion de bd
AMContext ctx = new AMContext();
// insertion des objet
Plane plane1 = new Plane
{
    type = PlaneType.Airbus,
    Capacity = 150,
    ManufactDate = new DateTime(2015, 02, 03)

};
Flight f1 = new Flight()
{
    departure = "tunsie",
    AirlineLogo = "tunisair",
    FlightDate = new DateTime(  2022,02,01,21,10,10),
    Destination ="paris",

    EffictiveArrival = new DateTime(200,02,01,23,10,10),
    EstimedDuration = 105,
        plane = plane1,

};
//ajouter des objet aux dbset
//ctx.Planes.Add(TestData.Airbusplane);

//ctx.Planes.Add(TestData.BoingPlane);
//methode2
//ctx.Flight.Add(f1);
//persister les donner
ctx.SaveChanges();
Console.WriteLine("ajout avec succes");
//affichier le contenu de la table flight
foreach (Flight flight in ctx.Flights)
    Console.WriteLine("date:"+ flight.FlightDate+"destination:"
        + flight.Destination+""+"plae capacity:"+ flight.plane.Capacity);