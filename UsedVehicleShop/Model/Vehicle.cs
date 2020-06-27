namespace UsedVehicleShop.Model
{
    class Vehicle
    {
        private static int counterID = 0;

        public int ID { get; set; }
        public string AdvTitle { get; set; }
        public double Price { get; set; }
        public string Descrption { get; set; }
        public bool Condition { get; set; }
        public bool Deleted { get; set; }

        public Vehicle()
        {
            ID = counterID;
            counterID++;

            AdvTitle = "";
            Price = 0;
            Descrption = "";
            Condition = false;
            Deleted = false;
        }

        public Vehicle(string advTitle, double price, string descrption, bool condition = true)
        {
            ID = counterID;
            counterID++;

            AdvTitle = advTitle;
            Price = price;
            Descrption = descrption;
            Condition = condition;
            Deleted = false;
        }

        public virtual string ToFileString()
        {
            return "";
        }

        public override string ToString()
        {
            return string.Format($"ID: {ID}| title: {AdvTitle}| price: {Price}| condition: {(Condition ? "Available" : "Sold")}| description: {Descrption}");
        }

        public bool IsDeleted()
        {
            return Deleted;
        }


    }
}
