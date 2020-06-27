using System;

namespace UsedVehicleShop.HelperClasses
{
    public delegate void PrintMenu();

    class MainMenus
    {
        private static void PrintSelectEntityMenu()
        {
            Console.WriteLine("Which entity do you want to work with: ");
            Console.WriteLine("1 - Vehicle");
            Console.WriteLine("2 - In progress ... [don't work]");
        }

        public static int SelectEntity()
        {
            int option = ExecuteMenu(PrintSelectEntityMenu, 2);
            return option;
        }

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
