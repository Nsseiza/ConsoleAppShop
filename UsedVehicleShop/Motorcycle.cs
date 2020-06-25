namespace UsedVehicleShop
{
    class Motorcycle : Vehicle
    {
        public Motorcycle(string advTitle, double price, string descrption, bool condition = true) : base(advTitle, price, descrption, condition)
        {

        }

        public Motorcycle(string str) : base()
        {
            string[] tokens = str.Split(',');

            AdvTitle = tokens[0];
            Price = double.Parse(tokens[1]);
            Descrption = tokens[2];
            Condition = bool.Parse(tokens[3]);
            Deleted = bool.Parse(tokens[4]);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override string ToFileString()
        {
            return string.Format($"Motorcycle,{AdvTitle},{Price},{Descrption},{Condition},{Deleted}");
        }
    }
}
