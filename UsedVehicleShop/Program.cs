using System;
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
        static void Main(string[] args)
        {
           



            Console.ReadKey();
        }
    }
}
