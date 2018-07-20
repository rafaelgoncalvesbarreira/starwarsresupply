using StarWarsTravelStop.console.Api;
using StarWarsTravelStop.console.Model;
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
                int inputDistance;
                if (int.TryParse(args[0], out inputDistance))
                {
                    var calculator = new TravelResupplyCalculator(inputDistance, new RequestClient());
                    var result = calculator.CalculateAllStops();
                    foreach (StopNeeded stopInfo in result)
                    {
                        if (!stopInfo.starship.isUnknow)
                        {
                            Console.WriteLine($"{stopInfo.starship.name}: {stopInfo.numberOfStop}");
                        }
                        else
                        {
                            Console.WriteLine($"{stopInfo.starship.name}: couldn't calculate");
                        }
                    }
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
        }
    }
}
