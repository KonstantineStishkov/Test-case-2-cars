class PassengerCar : Car
{
    const decimal reserveReduction = .94m;
    private int maxPassengersCount;

    public PassengerCar(decimal fuelConsumption, decimal fuelTank, decimal speed, int maxPassengers) : base(fuelConsumption, fuelTank, speed)
    {
        type = "Passenger Car";
        maxPassengersCount = maxPassengers;
    }

    public override decimal GetPowerReserve(decimal fuel, decimal additionalValue = 0)
    {
        decimal passengersCount = additionalValue;

        if (passengersCount > maxPassengersCount)
        {
            throw new ArgumentOutOfRangeException("Количество пассажиров превышает вместимость автомобиля");
        }

        decimal distance = CalculateDistanceRemainder(fuel);
        for (int i = 0; i < passengersCount; i++)
        {
            distance = distance * reserveReduction;
        }
        return  distance;
    }
}