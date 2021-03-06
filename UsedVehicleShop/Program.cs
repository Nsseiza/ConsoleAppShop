﻿using System;
using UsedVehicleShop.HelperClasses;
using UsedVehicleShop.UI;

namespace UsedVehicleShop
{
    class Program
    {
        public static void LoadData()
        {
            Files.AdjustPath();
            VehicleUI.LoadVehicles(Files.VehicleFullPath);
            //VehicleUI.PrintVehicles();
        }

        public static void SaveData()
        {
            VehicleUI.SaveVehicle(Files.VehicleFullPath);
        }

        public static void BasicMenuPrint()
        {
            Console.WriteLine("Option:");
            Console.WriteLine("1 - Start sistem");
            Console.WriteLine("2 - Exit and save the changes to a file");
        }

        static void Main(string[] args)
        {

            LoadData();

            while (true)
            {
                int option = MainMenus.ExecuteMenu(BasicMenuPrint, 2);

                if (option == 1)
                {
                    BasicMenu.Menu();
                }
                else if (option == 2)
                {
                    SaveData();
                    break;
                }

            }
        }
    }
}
