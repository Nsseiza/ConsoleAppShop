using System;
using UsedVehicleShop.HelperClasses;

namespace UsedVehicleShop.UI
{
    class BasicMenu
    {
        public static void Meni()
        {
            FirstMenu();
        }

        public static void FirstMenu()
        {
            while (true)
            {
                int opcija = MainMenus.ExecuteMenu(MenuPrint, 6);

                if (opcija == 1)
                    EntryDeleteEditUI.Menu();

                else if (opcija == 2)
                    OverviewUI.Menu();

                else if (opcija == 3)
                    Console.WriteLine("In Progress");

                else if (opcija == 4)
                    Console.WriteLine("In Progress");

                else if (opcija == 5)
                    Console.WriteLine("In Progress");

                else if (opcija == 6)
                    break;
            }
        }

        public static void MenuPrint()
        {
            Console.WriteLine("1 - Enter, delete and modify entities");
            Console.WriteLine("2 - Entity Overview");
            Console.WriteLine("3 - Entity Search");
            Console.WriteLine("4 - Invoicing");
            Console.WriteLine("5 - Bills overview");
            Console.WriteLine("5 - Exit");
        }
    }
}
