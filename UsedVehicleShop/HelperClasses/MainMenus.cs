using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsedVehicleShop.HelperClasses
{
    public delegate void PrintMenu();

    class MainMenus
    {
        // Prints and takes the correct option from the given menu
        public static int ExecuteMenu(PrintMenu delegateForPrint, int inOption)
        {
            while (true)
            {
                // Prints obtained menu
                delegateForPrint();

                // Get some number from the user
                Console.Write($"Select an option [1-{inOption}]");
                int option = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (option >= 1 && option <= inOption)
                {
                    return option;
                }
                else
                {
                    Console.WriteLine("Invalid option!");
                }
            }
           
        }
    }
}
