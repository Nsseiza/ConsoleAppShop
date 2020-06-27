using System;
using UsedVehicleShop.Model;

namespace UsedVehicleShop.UI
{
    class EngineUI
    {
        public static Engine.FuelType GetFuelType()
        {
            while (true)
            {
                Console.Write("Enter fuel type (diesel / petrol): ");
                string input = Console.ReadLine();

                if (input == "diesel")
                    return Engine.FuelType.Diesel;

                if (input == "petrol")
                    return Engine.FuelType.Petrol;

                Console.WriteLine("Faulty input!");
            }
        }

        public static Engine LoadEngine()
        {
            Console.Write("Enter capacity: ");
            double capacity = double.Parse(Console.ReadLine());
            Console.Write("Enter power: ");
            double power = double.Parse(Console.ReadLine());
            Engine.FuelType fuelType = GetFuelType();
            return new Engine(capacity, power, fuelType);
        }
    }
}
