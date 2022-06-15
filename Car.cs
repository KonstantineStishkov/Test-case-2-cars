using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    abstract class Car
    {
        const decimal noValue = -1;
        protected string type;
        protected decimal fuelConsumption;
        protected decimal fuelTank;
        protected decimal speed;

        public Car(decimal fuelConsumption, decimal fuelTank, decimal speed)
        {
            this.fuelConsumption = fuelConsumption;
            this.fuelTank = fuelTank;
            this.speed = speed;
            this.type = "not implemented";
        }

        public decimal CalculateDistanceRemainder(decimal fuelLeft = noValue)
        //Если в метод не передан остаток топлива, то в рассчет будет принят "Полный бак"
        {
            if (fuelLeft == 0)
            {
                return 0;
            }

            decimal fuel = fuelLeft == noValue ? fuelTank : fuelLeft;
            return fuelConsumption / fuel;
        }

        public decimal CalculateTimeNeeded(decimal fuelLeft, decimal distance, decimal additionalValue = 0)
        {
            if (GetPowerReserve(fuelLeft, additionalValue) < distance)
            {
                return 0;
            }
            else
            {
                return distance / speed;
            }
        }

        public abstract decimal GetPowerReserve(decimal fuel, decimal additionalValue = 0);
    }

    class PassengerCar : Car
    {
        private int maxPassengersCount;

        public PassengerCar(decimal fuelConsumption, decimal fuelTank, decimal speed, int maxPassengers) : base(fuelConsumption, fuelTank, speed)
        {
            type = "Passenger Car";
                maxPassengersCount = maxPassengers;
        }

        public override decimal GetPowerReserve(decimal fuel, decimal additionalValue = 0)
        {
            decimal passengersCount = additionalValue;

            if(passengersCount > maxPassengersCount)
            {
                throw new ArgumentOutOfRangeException("Количество пассажиров превышает вместимость автомобиля");
            }

            return CalculateDistanceRemainder(fuel) * (passengersCount * 0.94m);
        }
    }

    class CargoTruck : Car
    {
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

            int coefficient = (int) cargoWeight / 200;
            return CalculateDistanceRemainder(fuel) * (coefficient * 0.96m);
        }
    }
}
