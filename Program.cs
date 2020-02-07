using System;
using System.Collections.Generic;



namespace PrototypeStructuralExample
{
    class Program
    {
        static void Main(string[] args)
        {

            ConcreteAirplane skyCruiser = new ConcreteAirplane(10,100,2,100,50,5);
            ConcreteAirplane skyLounger = (ConcreteAirplane)skyCruiser.Clone();
            skyLounger.AirplaneLength = 400;
            skyLounger.AirplanePassengers = 400;

            ConcreteAirplane skyBurner = (ConcreteAirplane)skyLounger.Clone();
            skyBurner.AirplaneEnginePower = 200;

            ConcreteAirplane amazonAir = (ConcreteAirplane)skyLounger.Clone();
            amazonAir.AirplanePassengers = 0;

            List<ConcreteAirplane> airportHanger = new List<ConcreteAirplane>();
            airportHanger.Add(skyCruiser);
            airportHanger.Add(skyLounger);
            airportHanger.Add(skyBurner);
            airportHanger.Add(amazonAir);

            foreach(ConcreteAirplane airplane in airportHanger)
            {
                Console.WriteLine("=======================");
                Console.WriteLine("Wing Span: {0}",airplane.AirplaneWingSpan);
                Console.WriteLine("Plane Length: {0}", airplane.AirplaneLength);
                Console.WriteLine("Number of Engines: {0}", airplane.AirplaneEngines);
                Console.WriteLine("Number of Passengers: {0}", airplane.AirplanePassengers);
                Console.WriteLine("Engine Power: {0}", airplane.AirplaneEnginePower);
                Console.WriteLine("Plane Length: {0}", airplane.AirplaneWeight);
            }
            
        }
    }

    abstract class AirplanePrototype
    {


        public AirplanePrototype(int wingSpan, int length, int numEngines, int numPassengers, int enginePower, int weight)
        {
            this.AirplaneWingSpan = wingSpan;
            this.AirplaneLength = length;
            this.AirplaneEngines = numEngines;
            this.AirplanePassengers = numPassengers;
            this.AirplaneEnginePower = enginePower;
            this.AirplaneWeight = weight;

        }


        public int AirplaneWingSpan { get; set; }
        public int AirplaneLength { get; set; }
        public int AirplaneEngines { get; set; }
        public int AirplanePassengers { get; set; }
        public int AirplaneEnginePower { get; set; }
        public int AirplaneWeight { get; set; }


        //Un-Initialized Clone function
        public abstract AirplanePrototype Clone();
    }

    //ConcreteAirplane Example  
    class ConcreteAirplane : AirplanePrototype
    {
        //Takes in an ID Name and passes value to base class data member
        public ConcreteAirplane(int wingSpan, int length, int numEngines, int numPassengers, int enginePower, int weight) : base(wingSpan, length, numEngines,numPassengers,enginePower,weight) { }

        

        //Override of base class abstract Clone() function
        public override AirplanePrototype Clone()
        {
            //returns type Prototype shallow copy of caller
            return (ConcreteAirplane)this.MemberwiseClone();
        }

    }


}
