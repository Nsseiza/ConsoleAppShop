namespace UsedVehicleShop.Model
{
    class Engine
    {
        public enum FuelType { Petrol, Diesel }

        public double EngineCapacity { get; set; }
        public double Power { get; set; }
        public FuelType fuelType { get; set; }

        public Engine(double engineCapacity, double power, FuelType fuelType)
        {
            EngineCapacity = engineCapacity;
            Power = power;
            this.fuelType = fuelType;
        }

        public override string ToString()
        {
            return string.Format($"capacity: {EngineCapacity}; power: {Power}; fuel type: {fuelType}");
        }

    }
}
