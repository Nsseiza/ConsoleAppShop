using System;

namespace UsedVehicleShop.UI
{
    class OverviewUI
    {
        public static void PrintMenu()
        {
            Console.WriteLine("Possible operations:");
            Console.WriteLine("1 - Overview of all entities");
            Console.WriteLine("2 - Overview of existing entities");
            Console.WriteLine("3 - Overview of deleted entities");
            Console.WriteLine("4 - Overview of sold entities (vehicles only)");
            Console.WriteLine("5 - Overview of unsold entities (vehicles only)");
            Console.WriteLine("6 - Back to previous menu");
        }

        public static void Menu()
        {
            //...
        }
    }
}
