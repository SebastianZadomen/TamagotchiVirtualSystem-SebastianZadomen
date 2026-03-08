using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiVirtualSystem.Core.Model;
using TamagotchiVirtualSystem.Core.Model.Item_Model;

namespace TamagotchiVirtualSystem.Model
{
    public abstract class Pets 
    {
        public int CountFood = 0;
        private EState? _emotionalState;
        public string Name { get; set; }
        public bool IsDead { get; private set; } = false;

        public DateTime LastUpdate { get; set; }


        public EState EmotionalState
        {
            get
            {
                if (_emotionalState is not null)
                {
                    EState temp = _emotionalState.Value;
                    _emotionalState = null;
                    return temp;
                }
                return ComprobationEmotionalState();
            }
            
        }
        public Item[] Consumed { get; set; } = new Item[5];

        public EPetTypes Pet { get; set; }

        public StatsPet Stats { get; set; } = new StatsPet(100,100,100);
   
        public Pets(string name, EState emotionalState, EPetTypes pet, StatsPet stats)
        {
            Name = name;
            Pet = pet;
            Stats = stats;
            LastUpdate = DateTime.Now;

        }

        public EState ComprobationEmotionalState()
        {
            if (Stats.HealthLevel <= 20)
                return EState.Sick;
            else if (Stats.HungryLevel <= 30)
                return EState.Sad;
            else if (Stats.HungryLevel <= 50)
                return EState.Angry;
            else if (Stats.EnergyLevel <= 30)
                return EState.Tired;
            else
                return EState.Happy;

        }
        public void SetManualState(EState state)
        {
            _emotionalState = state;
        }
        public void UpdateStatsOverTime()
        {
            if (IsDead) return;

            TimeSpan elapsed = DateTime.Now - LastUpdate;

            if (elapsed.TotalSeconds < 10) return; 

            int decay = (int)(elapsed.TotalSeconds / 10);

            Stats.EnergyLevel -= decay * 2;
            Stats.HungryLevel -= decay * 2;

            LastUpdate = DateTime.Now;
            CheckIfDead();
        }
        public void CheckIfDead()
        {
            if (Stats.EnergyLevel <= 0 || Stats.HealthLevel <= 0)
            {
                IsDead = true;
                Stats.EnergyLevel = 0;
                Stats.HungryLevel = 0;
                Stats.HealthLevel = 0;
                Console.WriteLine($"\n{Name} ha muerto... el juego se reiniciará.");
            }
        }
    }
}
