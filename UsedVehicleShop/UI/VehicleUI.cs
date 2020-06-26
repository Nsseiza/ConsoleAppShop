using System;
using System.Collections.Generic;
using System.IO;
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

            if (tokens[0] == "Bicikl")
            {
                return new Motorcycle(strNoFirstWord);
            }
            else if (tokens[0] == "Motocikl")
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
            //int id = IO.UcitajCeoBroj();
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

        public static void PrintVehicles()
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
    }
}
