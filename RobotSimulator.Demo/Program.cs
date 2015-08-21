using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotSimulator;

namespace RobotSimulator.Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            var robotdriver = new RobotDriver(new RobotInstructions());

            ShowWelcomeMessage();
            ShowHelp();

            while (true)
            {
                string instruction = PromptInstruction();

                if (instruction.ToUpper() == "Q")
                {
                    Environment.Exit(0);
                }

                Console.WriteLine(robotdriver.Command(instruction));
            }
        }

        private static void ShowWelcomeMessage()
        {
            Console.WriteLine("Welcome to Navone Robot Simulator");
            Console.WriteLine("**************************");
        }

        private static string PromptInstruction()
        {
            Console.Write("Navone #: ");
            return Console.ReadLine();
        }

        private static void ShowHelp()
        {
            Console.WriteLine("Valid Commands with syntax:");
            Console.WriteLine("---------------------------");
            Console.WriteLine("PLACE X,Y,F  -put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST");
            Console.WriteLine("MOVE  -move the toy robot one unit forward in the direction it is currently facing");
            Console.WriteLine("LEFT  -rotate the robot 90 degrees to the left without changing the position of the robot");
            Console.WriteLine("RIGHT  -rotate the robot 90 degrees to the right without changing the position of the robot.");
            Console.WriteLine("REPORT  -announce the X,Y and F of the robot");
            Console.WriteLine("---------------------------");
            Console.WriteLine("To quit type q and hit enter");
            Console.WriteLine("---------------------------");
            Console.WriteLine("---------------------------");
            //return Console.ReadLine();
        }
    }
}
