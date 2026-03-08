using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiVirtualSystem.Core.Model.Item_Model;

namespace TamagotchiVirtualSystem.Core.Model.Player
{
    public class Shop
    {
        public Item[] AvailableItems = new Item[]
        {
        new Food("Meal","🍗",30,ETypeFood.Meal),
        new Food("Snack","🍪",10,ETypeFood.Snack),
        new ObjectPet("Toy Ball","⚽",ETypeObject.Toy,15),
        new ObjectPet("Medicine","💊",ETypeObject.Medicine,40)
        };

        public void ShowItems()
        {
            for (int i = 0; i < AvailableItems.Length; i++)
            {
                Console.WriteLine($"{i} - {AvailableItems[i].Name}");
            }
        }
    }
}
