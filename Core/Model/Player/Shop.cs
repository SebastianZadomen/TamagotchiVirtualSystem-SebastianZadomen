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
        Item[] items;    // Array fijo de items
        private int[] stock;     // Stock para comida y medicina

        public Shop()
        {
            // Inicializamos los items
            items = new Item[]
            {
                new Food("Meal","🍗",30,ETypeFood.Meal),
                new Food("Snack","🍪",10,ETypeFood.Snack),
                new ObjectPet("Toy Ball","⚽",ETypeObject.Toy,15),
                new ObjectPet("Medicine","💊",ETypeObject.Medicine,40)
            };

           
            stock = new int[] { 3, 5, -1, 2 }; 
        }

        public void ShowItems()
        {
            Console.WriteLine("=== TIENDA ===");

            for (int i = 0; i < items.Length; i++)
            {
                string stockText = stock[i] < 0 ? "∞" : stock[i].ToString();
                Console.WriteLine($"{i} - {items[i].Name} | Stock: {stockText}");
            }
        }

        public Item BuyItem(int index)
        {
            if (index < 0 || index >= items.Length)
            {
                Console.WriteLine("Índice inválido.");
                return null;
            }

            Item item = items[index];

            if (stock[index] == 0)
            {
                Console.WriteLine($"{item.Name} está agotado.");
                return null;
            }

            if (stock[index] > 0)
            {
                stock[index]--;
            }

            Console.WriteLine($"{item.Name} añadido al inventario.");
            return item;
        }
    }
}
