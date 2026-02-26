using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiVirtualSystem.Core.Interfaces;
using TamagotchiVirtualSystem.Model;

namespace TamagotchiVirtualSystem.Core.Model.Pet_Core.Sub_Pets
{
    public class Cat : Pets, IPetActionEat, IPetActionPlay, IPetActionSleep
    {
        private const int EnergyMax = 100; 
        public Cat(string name, EState emotionalState = EState.Happy, /*StatsPet stats,*/ EPetTypes pet = EPetTypes.Cat) : base(name,emotionalState, pet/*,stats*/ ) { 
        }

        public void Eat()
        {
            Console.WriteLine($"Haz alimentado a {Name}");
            Stats.HungryLevel += 20;
        }

        public void Play()
        {
            Console.WriteLine($"{Name} esta jugando ");
            Stats.EnergyLevel -= 20;
            Stats.HungryLevel -= 30;
        }

        public void Sleep()
        {
            if (Stats.EnergyLevel == EnergyMax)
                Console.WriteLine($"La energia de {Name} esta al maximo, no puede dormir");
            else
                Console.WriteLine($"{Name} esta descansando");
            Stats.EnergyLevel += 50;
        }
    }
}
