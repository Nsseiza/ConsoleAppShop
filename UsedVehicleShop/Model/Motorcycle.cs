namespace UsedVehicleShop.Model
{
    class Motorcycle : Vehicle
    {
        public Engine Engine { get; set; }

        public Motorcycle(string advTitle, double price, string descrption, Engine engine, bool condition = true) : base(advTitle, price, descrption, condition)
        {
            Engine = engine;
        }

        public Motorcycle(string str) : base()
        {
            string[] tokens = str.Split(',');

            AdvTitle = tokens[0];
            Price = double.Parse(tokens[1]);
            Descrption = tokens[2];
            double capacity = double.Parse(tokens[3]);
            double power = double.Parse(tokens[4]);
            Engine.FuelType type = (tokens[5] == "Petrol") ? Engine.FuelType.Petrol : Engine.FuelType.Diesel;
            Engine = new Engine(capacity, power, type);
            Condition = bool.Parse(tokens[6]);
            Deleted = bool.Parse(tokens[7]);
        }

        public override string ToString()
        {
            return base.ToString() + "| engine: " + Engine;
        }

        public override string ToFileString()
        {
            return string.Format($"Motorcycle,{AdvTitle},{Price},{Descrption},{Engine.EngineCapacity},{Engine.Power},{Engine.fuelType.ToString()},{Condition},{Deleted}");
        }
    }
}
