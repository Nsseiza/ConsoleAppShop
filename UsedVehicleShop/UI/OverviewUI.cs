using System;
using UsedVehicleShop.HelperClasses;

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
            int optionOperation = MainMenus.ExecuteMenu(PrintMenu, 6);

            if (optionOperation == 6)
                return;

            int optionEntity = MainMenus.SelectEntity();

            if (optionOperation == 1 && optionEntity == 1)
            {
                VehicleUI.PrintAllVehicles();
            }
            else if (optionOperation == 2 && optionEntity == 1)
            {
                VehicleUI.PrintExistingVehicles();
            }
            else if (optionOperation == 3 && optionEntity == 1)
            {
                VehicleUI.PrintDeletedVehicles();
            }
            else if (optionOperation == 4 && optionEntity == 1)
            {
                VehicleUI.PrintSoldVehicles();
            }
            else if (optionOperation == 4 && optionEntity == 2)
            {
                Console.WriteLine("Options 4 and 5 are only possible for vehicles!");
            }
            else if (optionOperation == 5 && optionEntity == 1)
            {
                VehicleUI.PrintUnsoldVehicles();
            }
            else if (optionOperation == 5 && optionEntity == 2)
            {
                Console.WriteLine("Options 4 and 5 are only possible for vehicles!");
            }
        }
    }
}
