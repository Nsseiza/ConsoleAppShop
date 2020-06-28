using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UsedVehicleShop.HelperClasses;
using UsedVehicleShop.Model;

namespace UsedVehicleShop.UI
{
    class VehicleUI
    {
        static List<Vehicle> allVehicles = new List<Vehicle>();

        public static Vehicle CreateVehicleFromString(string str)
        {
            string[] tokens = str.Split(',');
            int i = str.IndexOf(',') + 1;
            string strNoFirstWord = str.Substring(i);

            if (tokens[0] == "Motorcycle")
            {
                return new Motorcycle(strNoFirstWord);
            }
            else if (tokens[0] == "Car")
            {
                return new Car(strNoFirstWord);
            }

            return null;
        }

        // Loads some original vehicles
        public static void LoadVehicles(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (StreamReader reader1 = File.OpenText(fileName))
                {
                    string line;
                    while ((line = reader1.ReadLine()) != null)
                    {
                        Vehicle vehicle = CreateVehicleFromString(line);
                        if (vehicle != null)
                            allVehicles.Add(vehicle);
                    }
                }
            }
            else
            {
                Console.WriteLine($"File {fileName} does not exist or the path is incorrect.");
            }
        }

        // Logical deletion of the vehicle
        public static void DeleteVehicle()
        {
            Console.Write("Enter the vehicle code you want to delete: ");
            int id = int.Parse(Console.ReadLine());

            foreach (Vehicle v in allVehicles)
            {
                if (v.ID == id && v.Condition == true && v.Deleted == false)
                {
                    v.Deleted = true;
                    return;
                }
            }

            Console.WriteLine("Operation failed. There is no vehicle with code {0}.", id);
        }

        private static List<string> LoadEquipment()
        {
            List<string> equipments = new List<string>();
            Console.WriteLine("Input of accessories; enters names one by one, or ‘end’ when there is no more equipment");
            while (true)
            {
                Console.Write("Enter the following name or 'end': ");
                string input = Console.ReadLine();

                if (input == "end")
                    return equipments;

                equipments.Add(input);
            }
        }

        private static string LoadTypeVehicle()
        {
            while (true)
            {
                Console.Write("What type of vehicle do you want (passenger / motorcycle): ");
                string input = Console.ReadLine();
                if (input.Equals("passenger") || input.Equals("motorcycle"))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Faulty input!");
                }
            }

        }

        public static void AddVehicle()
        {
            Console.Write("Enter title: ");
            string title = Console.ReadLine();
            Console.Write("Enter price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter description: ");
            string description = Console.ReadLine();

            string typeVehicle = LoadTypeVehicle();
            Vehicle newVehicle = null;

            if (typeVehicle == "motorcycle")
            {
                Engine e = EngineUI.LoadEngine();
                newVehicle = new Motorcycle(title, price, description, e);
            }

            else if (typeVehicle == "passenger")
            {
                /*Motor motor, string marka, string model, int brojVrata, List<string> oprema*/
                Engine engine = EngineUI.LoadEngine();
                Console.Write("Enter brand: ");
                string brand = Console.ReadLine();
                Console.Write("Enter model: ");
                string model = Console.ReadLine();
                Console.Write("Enter doors number: ");
                int doors = int.Parse(Console.ReadLine());
                List<string> equipment = LoadEquipment();
                newVehicle = new Car(title, price, description, engine, brand, model, doors, equipment);
            }

            allVehicles.Add(newVehicle);
        }

        public static void PrintExistingVehicles()
        {
            foreach (Vehicle v in allVehicles)
            {
                if (v.Deleted == false)
                    Console.WriteLine(v);
            }
        }

        public static void PrintDeletedVehicles()
        {
            foreach (Vehicle v in allVehicles)
            {
                if (v.Deleted == true)
                    Console.WriteLine(v);
            }
        }

        public static void PrintSoldVehicles()
        {
            foreach (Vehicle v in allVehicles)
            {
                if (v.Condition == false)
                    Console.WriteLine(v);
            }
        }

        public static void PrintUnsoldVehicles()
        {
            foreach (Vehicle v in allVehicles)
            {
                if (v.Condition == true)
                    Console.WriteLine(v);
            }
        }


        // Vehicle sorting
        public static void PrintSortingOptions()
        {
            Console.WriteLine("How do you want to sort vehicles:");
            Console.WriteLine("1 - By name Ascending");
            Console.WriteLine("2 - By name Descending");
            Console.WriteLine("3 - By price Ascending");
            Console.WriteLine("4 - By price Descending");
        }

        private static int ByNameAscending(Vehicle v1, Vehicle v2)
        {
            return v1.AdvTitle.CompareTo(v2.AdvTitle);
        }

        private static int ByNameDescending(Vehicle v1, Vehicle v2)
        {
            return -v1.AdvTitle.CompareTo(v2.AdvTitle);
        }

        private static int ByPriceAscending(Vehicle v1, Vehicle v2)
        {
            return v1.Price.CompareTo(v2.Price);
        }

        private static int ByPriceDescending(Vehicle v1, Vehicle v2)
        {
            return -v1.Price.CompareTo(v2.Price);
        }

        public static void PrintAllVehicles()
        {
            int option = MainMenus.ExecuteMenu(PrintSortingOptions, 4);

            List<Vehicle> copyList = new List<Vehicle>(allVehicles);

            if (option == 1)
            {
                copyList.Sort(ByNameAscending);
            }
            else if (option == 2)
            {
                copyList.Sort(ByNameDescending);
            }
            else if (option == 3)
            {
                copyList.Sort(ByPriceAscending);
            }
            else if (option == 4)
            {
                copyList.Sort(ByPriceDescending);
            }

            Console.WriteLine("List of vehicles in the system:");
            foreach (Vehicle v in copyList)
            {
                Console.WriteLine(v);
            }
        }

        // Saving data entity to file
        public static void SaveVehicle(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                foreach (Vehicle v in allVehicles)
                {
                    writer.WriteLine(v.ToFileString());
                }
            }
        }

    }
}
