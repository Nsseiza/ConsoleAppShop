using System;
using UsedVehicleShop.HelperClasses;

namespace UsedVehicleShop.UI
{
    class EntryDeleteEditUI
    {
        private static void PrintMenu()
        {
            Console.WriteLine("Possible operations:");
            Console.WriteLine("1 - Enter new entity");
            Console.WriteLine("2 - Delete existing entity");
            Console.WriteLine("3 - Modify Entities");
            Console.WriteLine("4 - Back to previous menu");
        }

        public static void Menu()
        {
            int optionOperation = MainMenus.ExecuteMenu(PrintMenu, 4);

            if (optionOperation == 4)
                return;

            int optionEntity = MainMenus.SelectEntity();

            if (optionEntity == 1 && optionOperation == 1)
            {
                VehicleUI.AddVehicle();
            }
            else if (optionEntity == 1 && optionOperation == 2)
            {
                VehicleUI.DeleteVehicle();
            }
            else if (optionEntity == 1 && optionOperation == 3)
            {
                Console.WriteLine("Change is not possible!");
            }
            else if (optionEntity == 2 && optionOperation == 3)
            {
                Console.WriteLine("Change is not possible!");
            }
        }
    }
}
