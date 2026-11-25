using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindchillCalc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool playing = true;
            string weatherScale;


            while (playing == true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to our application!");
                Console.WriteLine("To continue press [1] or [2] for the corresponding options ");
                Console.WriteLine("Calculate wind chill [1]");
                Console.WriteLine("Exit application [2]");

                int confirmedInteger;
                while (!int.TryParse(Console.ReadLine(), out confirmedInteger))
                {
                    Console.Clear();
                    Console.WriteLine("[ERROR] input was not [1] or [2]");
                    //Thread.Sleep(2000);
                    
                    Console.WriteLine("To continue press [1] or [2] for the corresponding options ");
                    Console.WriteLine("Calculate wind chill [1]");
                    Console.WriteLine("Exit application [2]");

                    
                }

                if (confirmedInteger == 2)
                {
                    playing = false;
                }

                switch (playing)
                {
                    case true:
                        double temperature;  // Kommer att innehålla värde för temperatur, just nu tom
                        double speedOfwind; // Samma sak fast för vind i meter per sekund

                        Console.Clear();
                        Console.WriteLine("How cold is it in celcius degrees?"); // Skriver ut en förfrågan i terminalen


                        while (!double.TryParse(Console.ReadLine(), out temperature))
                        {
                            Console.Clear();
                            Console.WriteLine("[ERROR] input is not a double");
                            Console.WriteLine("How cold is it in celcius degrees?");
                        }

                        Console.Clear();
                        Console.WriteLine("What is the speed of the wind? (In m/s)");

                        while (!double.TryParse(Console.ReadLine(), out speedOfwind))
                        {
                            Console.Clear();
                            Console.WriteLine("[ERROR] input is not a double");
                            Console.WriteLine("What is the speed of the wind? (In m/s)");
                        }

                        if (speedOfwind < 0)
                        {
                            speedOfwind = speedOfwind - speedOfwind - speedOfwind;
                        }

                        double speedOfWind_kph = speedOfwind * 3.6;
                        double WCT = (13.12 + 0.6215 * temperature - 11.37 * Math.Pow(speedOfWind_kph, 0.16) + 0.3965 * temperature * Math.Pow(speedOfWind_kph, 0.16)); // This calculation is wrong!

                        if (WCT > 0)
                        {
                            weatherScale = "WCT classification says it's warm...";
                        }

                        else if (WCT > -25 && WCT < 0) // Is this correct or should it be flipped?
                        {
                           weatherScale = "WCT classification says it's cold!";
                        }

                        else if (WCT < -25 && WCT > -35)
                        {
                            weatherScale = "WCT classification says it's VERY cold!";
                        }

                        else if (WCT < -35 && WCT > -60)
                        {
                            weatherScale = "WCT classification says there's risk for frostbite!";
                        }

                        else
                        {
                            weatherScale = "WCT classification says there's a BIG risk for frostbite!";
                        }


                        Console.Clear();
                        Console.WriteLine($"Temperature: {temperature}");
                        Console.WriteLine($"Speed of wind: {speedOfwind}");
                        Console.WriteLine($"WCT: {WCT:F1}");
                        Console.WriteLine(weatherScale);

                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();

                        break;

                    case false:
                        Console.Clear();
                        Console.WriteLine("Goodbye");
                        Environment.Exit(0);
                        break;
                }


                // Use a scale for weather!!!
                // Add measures for logical bugs! (e.g 0)



            }




        }
    }
}
