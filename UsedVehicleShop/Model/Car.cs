using System.Collections.Generic;

namespace UsedVehicleShop.Model
{
    class Car : Vehicle
    {
        public Engine Engine { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int NumOfDoors { get; set; }
        public List<string> Equipment { get; set; }

        public Car(string advTitle, double price, string descrption,
            Engine engine, string brand, string model, int numOfDoors, List<string> equipment, bool condition = true) : base(advTitle, price, descrption, condition)
        {
            Engine = engine;
            Brand = brand;
            Model = model;
            NumOfDoors = numOfDoors;
            Equipment = equipment;
        }

        public Car(string str) : base()
        {
            string[] tokens = str.Split(',');

            AdvTitle = tokens[0];
            Price = double.Parse(tokens[1]);
            Descrption = tokens[2];
            double capacity = double.Parse(tokens[3]);
            double power = double.Parse(tokens[4]);
            Engine.FuelType type = (tokens[5] == "Petrol") ? Engine.FuelType.Petrol : Engine.FuelType.Diesel;
            Engine = new Engine(capacity, power, type);
            Brand = tokens[6];
            Model = tokens[7];
            NumOfDoors = int.Parse(tokens[8]);
            Condition = bool.Parse(tokens[9]);
            Deleted = bool.Parse(tokens[10]);
            Equipment = new List<string>();

            for (int i = 11; i < tokens.Length; i++)
            {
                Equipment.Add(tokens[i]);
            }
        }

        public override string ToString()
        {
            string str = base.ToString() + string.Format($"\n\t engine: {Engine}\n\t brand: {Brand}\n\t model: {Model}\n\t doors: {NumOfDoors}\n\t Equipment: ");

            if (Equipment.Count == 0)
            {
                return str + "no equipment";
            }

            string strEquipment = "";
            for (int i = 0; i < Equipment.Count; i++)
            {
                if (i == 0)
                {
                    strEquipment += string.Format($"{Equipment[i]}, ");
                }
                else
                {
                    strEquipment += string.Format($"{Equipment[i]}, ");
                }
            }

            return str + strEquipment;
        }

        public override string ToFileString()
        {
            string firstPart = string.Format($"Car,{AdvTitle},{Price},{Descrption},{Engine.EngineCapacity},{Engine.Power},{Engine.fuelType},{Brand},{Model},{NumOfDoors},{Condition},{Deleted}");

            string secondPart = "";
            for (int i = 0; i < Equipment.Count; i++)
            {
                secondPart += string.Format($",{Equipment[i]}");
            }
            return firstPart + secondPart;
        }

    }
}
