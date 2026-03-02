using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiVirtualSystem.Core.Interfaces;
using TamagotchiVirtualSystem.Core.Model.Item_Model;
using TamagotchiVirtualSystem.Model;

namespace TamagotchiVirtualSystem.Core.Model.Pet_Core.Sub_Pets
{
    public class Cat : Pets, IPetActionEat, IPetActionPlay, IPetActionSleep
    {
        private const int EnergyMax = 100; 
        public Cat(string name) : base(name, EState.Normal, EPetTypes.Cat, new StatsPet(100, 100, 100))
        { 
        }

        public void Eat(Item aliment)
        {
            Consumed[CountFood] = aliment;
            if (aliment.GetType() == typeof(Food))
            {

                Console.WriteLine($"{Name} esta comiendo {aliment.Name}");
                Stats.HungryLevel += aliment.UpgradeValue;
                if (aliment is Food food && food.CategoryFood == ETypeFood.Snack)
                {
                    SetManualState(EState.Happy);
                }
            }
            else 
            {
                if (aliment is ObjectPet objectAliment)
                {
                    switch(objectAliment.TypeObject)
                    {
                        case ETypeObject.Medicine:
                            Console.WriteLine($"{Name} se ha tomado {objectAliment.Name} ");
                            Stats.HealthLevel += objectAliment.UpgradeValue;
                            SetManualState(EState.Normal);
                            break;
                    }
                }
            }
          

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
