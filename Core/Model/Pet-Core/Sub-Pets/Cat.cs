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
        public Cat(string name, EState emotionalState, StatsPet stats, EPetTypes pet = EPetTypes.Cat) : base(name,emotionalState, pet,stats ) { 
        }

        public void Eat()
        {
            throw new NotImplementedException();
        }

        public void Play()
        {
            throw new NotImplementedException();
        }

        public void Sleep()
        {
            throw new NotImplementedException();
        }
    }
}
