using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagotchiVirtualSystem.Core.Model
{
    public class StatsPet
    {
        public int HungryLevel { get; set; }
        public int EnergyLevel { get; set; }
        public int HealthLevel { get; set; }

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
