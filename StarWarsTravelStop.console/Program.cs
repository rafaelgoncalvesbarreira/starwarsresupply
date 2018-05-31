using System;

namespace StarWarsTravelStop.console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

            if (args.Length < 1)
                {
                    throw new ArgumentException("You need to inform the input distance");
                }
                double inputDistance;
                if (Double.TryParse(args[0], out inputDistance))
                {
                    //var calculator = new TravelStopCalculator
                    //{
                    //    MegaLightDistance = inputDistance
                    //};
                    //var result = calculator.CalculateStops();
                    //Console.WriteLine($"${result.starship.Name} need ");
                }
                else
                {
                    throw new ArgumentException("The input distance is invalid");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"A erro ocurred: {ex.Message}");
            }


            Console.WriteLine("Hello World!");
            foreach (String arg in args)
            {
                Console.WriteLine(arg);
            }
        }
    }
}
