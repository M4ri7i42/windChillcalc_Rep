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
            bool playing = true;  // variable storing status of the app. The the application starts the "playing" status is true


            while (playing == true) // While the game is active...
            {
                Console.Clear();
                Console.WriteLine("Welcome to our application!");
                Console.WriteLine("To continue press [1] or [2] for the corresponding options ");
                Console.WriteLine("Calculate wind chill [1]");
                Console.WriteLine("Exit application [2]");

                int confirmedInteger;
                while (!int.TryParse(Console.ReadLine(), out confirmedInteger) || (confirmedInteger != 1 && confirmedInteger != 2))
                // while the input can not be transformed into a integer... otherwise put the value into variable named confirmedInteger
                // While the input is not 1 or 2...

                {
                    Console.Clear();
                    Console.WriteLine("[ERROR] input was not [1] or [2]"); // Error message that gets looped until the requested input is correct
                    Console.WriteLine("To continue press [1] or [2] for the corresponding options ");
                    Console.WriteLine("Calculate wind chill [1]");
                    Console.WriteLine("Exit application [2]");



                }

                if (confirmedInteger == 2) // if confirmedInteger == 2 || if user wants to exit application --> switch the playing state to false and move down the false section of the switch
                {
                    playing = false;
                }





                switch (playing) // The mentioned switch that has different paths. Works similarly to an if, else staircase. if this statement is true go down this path... if this is correct instead go down... 
                {
                    case true:
                        double temperature;  // stores value for temperature --> will be given from input
                        double speedOfwind; // Same thing but for wind

                        Console.Clear();
                        Console.WriteLine("How cold is it in celcius degrees?"); // The start of the WCT calculation. Here they'll ask for temperature


                        while (!double.TryParse(Console.ReadLine(), out temperature))
                        // A statement that checks if the input can be parsed into a double. Also puts the correct input into variable temperature
                        // As long as the statement if false, the text request will continue to loop

                        {
                            Console.Clear();
                            Console.WriteLine("[ERROR] input is not a double");
                            Console.WriteLine("How cold is it in celcius degrees?");
                        }

                        Console.Clear();
                        Console.WriteLine("What is the speed of the wind? (In m/s)"); // Asks for speed of wind

                        while (!double.TryParse(Console.ReadLine(), out speedOfwind))
                        // Same type of loop as above
                        // The input will be put into variable speedOfwind if accepted
                        {


                            Console.Clear();
                            Console.WriteLine("[ERROR] input is not a double");
                            Console.WriteLine("What is the speed of the wind? (In m/s)");
                        }


                        // weatherScale 
                        string weatherScale;

                        if (speedOfwind < 0)
                        {
                            speedOfwind = speedOfwind - speedOfwind - speedOfwind;
                        }

                        double speedOfWind_kph = speedOfwind * 3.6; // Recalculates the speed of wind from m/s to km/h
                        double WCT = (13.12 + 0.6215 * temperature - 11.37 * Math.Pow(speedOfWind_kph, 0.16) + 0.3965 * temperature * Math.Pow(speedOfWind_kph, 0.16)); // Calculates WCT using temperature, speedOfwind and the formula

                        if (WCT > 100)
                        {
                            weatherScale = "WCT classification says it's EXTREMELY warm!...";
                        }


                        else if (WCT > 0) // A starcaise of if, else statements that determine how cold it according to a weather scale

                        {
                            weatherScale = "WCT classification says it's warm...";
                        }

                        else if (WCT > -25 && WCT <= 0)
                        {
                            weatherScale = "WCT classification says it's cold!";
                        }

                        else if (WCT > -35 && WCT <= -25)
                        {
                            weatherScale = "WCT classification says it's VERY cold!";
                        }

                        else if (WCT > -60 && WCT <= -35)
                        {
                            weatherScale = "WCT classification says there's risk for frostbite!";
                        }

                        else
                        {
                            weatherScale = "WCT classification says there's a BIG risk for frostbite!";
                        }


                        Console.Clear(); // Resets the terminal to make it look cleaner. Below this are the results of the inputs and calculations printed out
                        Console.WriteLine($"Temperature: {temperature} degrees celcius");
                        Console.WriteLine($"Speed of wind: {speedOfwind} m/s");
                        Console.WriteLine($"WCT: {WCT.ToString("F1")} degrees celcius");
                        Console.WriteLine(weatherScale);

                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine(); // Restarts the code from the top if used input i 1 and exists if the input is 2

                        break;

                    case false:
                        Console.Clear();
                        Console.WriteLine("Goodbye");
                        Environment.Exit(0); // Terminates the application if the user picks option 2 in the startup-selection menu
                        break;
                }





            }




        }
    }
}
