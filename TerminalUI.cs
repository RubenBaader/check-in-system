using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCL_Programmering_Eksamen
{
    internal class TerminalUI
    {
        // What do? 
        //  Allow the user to interact with program
        //  Actions: Create User; Check In; Check Out; View Logs; Edit User; Delete User;
        
        public TerminalUI() { Console.WriteLine("UI initialized. Welcome!"); }
        public void Run()
        {
            bool IsRunning = true;


            while (IsRunning)
            {
                DisplayMenu();
                string Input = GetInput();

                switch (Input)
                {
                    case "1":
                        Console.WriteLine("You picked 1!");
                        break;
                    case "2":
                        Console.WriteLine("You picked 2!");
                        break;
                    case "q":
                        Console.WriteLine("Goodbye!");
                        IsRunning= false;
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1: Create User");
            Console.WriteLine("2: Edit User");
            Console.WriteLine("3: Check In");
            Console.WriteLine("4: Check Out");
            Console.WriteLine("q: quit");
        }
        private string GetInput()
        {
            Console.WriteLine("Pick an Option:");
            return Console.ReadLine();
        }
    }
}
