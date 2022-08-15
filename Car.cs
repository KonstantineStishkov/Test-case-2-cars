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

        /// <summary>
        /// Calculates how far car can drive with current fuel
        /// </summary>
        /// <param name="fuelLeft">pass -1 if it is a full tank</param>
        /// <returns></returns>
        public decimal CalculateDistanceRemainder(decimal fuelLeft = noValue)
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
}
