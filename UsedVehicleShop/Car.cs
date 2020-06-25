using System.Collections.Generic;

namespace UsedVehicleShop
{
    class Car : Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int NumOfDoors { get; set; }
        public List<string> Equipment { get; set; }

        public Car(string brand, string model, int numOfDoors, List<string> equipment,
            string advTitle, double price, string descrption, bool condition = true) : base(advTitle, price, descrption, condition)
        {
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
            Brand = tokens[3];
            Model = tokens[4];
            NumOfDoors = int.Parse(tokens[5]);
            Condition = bool.Parse(tokens[6]);
            Deleted = bool.Parse(tokens[7]);
            Equipment = new List<string>();

            for (int i = 8; i < tokens.Length; i++)
            {
                Equipment.Add(tokens[i]);
            }
        }

        public override string ToString()
        {
            string str = base.ToString() + string.Format($"; brand: {Brand}; model: {Model}; doors: {NumOfDoors}; Equipment: ",
                Brand, Model, NumOfDoors);

            if (Equipment.Count == 0)
            {
                return str + "no equipment";
            }

            string strEquipment = "";
            for (int i = 0; i < Equipment.Count; i++)
            {
                if (i == 0)
                {
                    strEquipment += string.Format($"{Equipment[i]}");
                }
                else
                {
                    strEquipment += string.Format($"{Equipment[i]}");
                }
            }

            return str + strEquipment;
        }

        public override string ToFileString()
        {
            string firstPart = string.Format($"Car,{AdvTitle},{Price},{Descrption},{Brand},{Model},{NumOfDoors},{Condition},{Deleted}");

            string secondPart = "";
            for (int i = 0; i < Equipment.Count; i++)
            {
                secondPart += string.Format($",{Equipment[i]}");
            }
            return firstPart + secondPart;
        }

    }
}
