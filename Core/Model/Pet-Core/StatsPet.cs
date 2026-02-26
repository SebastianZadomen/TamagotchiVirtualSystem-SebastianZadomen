using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagotchiVirtualSystem.Core.Model
{
    public class StatsPet
    {
        public int HungryLevel { get; set; } = 100;
        public int EnergyLevel { get; set; } = 100;
        public int HealthLevel { get; set; } = 100;

        public StatsPet(int hungryLevel, int energyLevel, int healthLevel) {

            HungryLevel = ClampLevel(hungryLevel + HungryLevel);
            EnergyLevel = ClampLevel(energyLevel + EnergyLevel);
            HealthLevel = ClampLevel(healthLevel + HealthLevel);

        }

        public int ClampLevel(int levelInput)
        {
            return Math.Clamp(levelInput, 0, 100);

        }
    }
}
