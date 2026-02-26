using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiVirtualSystem.Core.Model;

namespace TamagotchiVirtualSystem.Model
{
    public abstract class Pets 
    {
        public string Name { get; set; }
        public EState EmotionalState { get; set; }

        public EPetTypes Pet { get; set; }

        public StatsPet Stats { get; set; } = new StatsPet(100,100,100);
        /*
        public Pets(string name, EState emotionalState, EPetTypes pet, StatsPet stats)
        {
            Name = name;
            EmotionalState = emotionalState;
            Pet = pet;
            Stats = stats;
           
        }*/
        public Pets(string name, EState emotionalState, EPetTypes pet)
        {
            Name = name;
            EmotionalState = ComprobationEmotionalState();
            Pet = pet;
        }

        public EState ComprobationEmotionalState()
        {
            if (Stats.HungryLevel <= 50)
            {
                EmotionalState = EState.Angry;
            }
            else if (Stats.EnergyLevel <= 30)
            {
                EmotionalState = EState.Tired;
            }
            else if (Stats.HealthLevel <= 20)
            {
                EmotionalState = EState.Sick;
            }
            else
            {
                EmotionalState = EState.Normal;
            }
            return EmotionalState;
        }
    }
}
