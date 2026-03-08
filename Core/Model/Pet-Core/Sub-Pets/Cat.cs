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

            
            CountFood++;
            if (CountFood >= Consumed.Length)
            {
                CountFood = 0;
            }

            if (aliment is Food food)
            {
                Console.WriteLine($"{Name} esta comiendo {food.Name}");

                Stats.HungryLevel += food.UpgradeValue;

                if (food.CategoryFood == ETypeFood.Snack)
                {
                    int snackCount = 0;

                    foreach (var item in Consumed)
                    {
                        if (item is Food f && f.CategoryFood == ETypeFood.Snack)
                        {
                            snackCount++;
                        }
                    }

                    if (snackCount >= 3)
                    {
                        Console.WriteLine($"{Name} ha comido demasiados snacks y se ha enfermado 🤒");
                        SetManualState(EState.Sick);
                    }
                    else
                    {
                        SetManualState(EState.Happy);
                    }
                }
            }
            else if (aliment is ObjectPet objectItem && objectItem.TypeObject == ETypeObject.Medicine)
            {
                Console.WriteLine($"{Name} ha tomado {objectItem.Name}");

                Stats.HealthLevel += objectItem.UpgradeValue;

                SetManualState(EState.Normal);
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
