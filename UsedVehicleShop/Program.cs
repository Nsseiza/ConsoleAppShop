using System;
using UsedVehicleShop.HelperClasses;
using UsedVehicleShop.UI;

namespace UsedVehicleShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Files.AdjustPath();
            VehicleUI.LoadVehicles(Files.VehicleFullPath);
            VehicleUI.PrintVehicles();



            Console.ReadKey();
        }
    }
}
