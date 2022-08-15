class CargoTruck : Car
{
	const decimal reserveReduction = .96m;
	private decimal cargoCapacity;

	public CargoTruck(decimal fuelConsumption, decimal fuelTank, decimal speed, decimal capacity) : base(fuelConsumption, fuelTank, speed)
	{
		cargoCapacity = capacity;
	}

	public override decimal GetPowerReserve(decimal fuel, decimal additionalValue = 0)
	{
		decimal cargoWeight = additionalValue;

		if (cargoWeight > cargoCapacity)
		{
			throw new ArgumentOutOfRangeException("Вес груза превышает грузоподъемность автомобиля");
		}

		decimal reserve = CalculateDistanceRemainder(fuel);

		for (int i = 0; i < (cargoWeight / 200); i++)
		{
			reserve *= reserveReduction;
		}

		return reserve;
	}
}