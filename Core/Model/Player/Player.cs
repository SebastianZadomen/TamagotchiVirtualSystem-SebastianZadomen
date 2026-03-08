using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiVirtualSystem.Core.Interfaces;
using TamagotchiVirtualSystem.Core.Model.Item_Model;

namespace TamagotchiVirtualSystem.Model
{
    public class Player
    {
        public Pets Pet { get; set; }

        private Item[] inventory = new Item[10];

        private int count = 0;

        public void AddItem(Item item)
        {
            if (count >= inventory.Length)
            {
                Console.WriteLine("Inventario lleno");

            }
            else
            {
                inventory[count] = item;
                count++;

                Console.WriteLine($"{item.Name} añadido al inventario");
            }
        }

        public void ShowInventory()
        {
            Console.WriteLine("\n=== INVENTARIO ===");

            if (count == 0)
            {
                Console.WriteLine("Inventario vacío");
            }

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i} - {inventory[i].Name}");
            }
        }

        public void RemoveItem()
        {
            ShowInventory();

            Console.WriteLine("\nSelecciona el item a eliminar:");

            int index = int.Parse(Console.ReadLine());

            if (index < 0 || index >= count)
            {
                Console.WriteLine("Item invalido");
            }
            else
            { 
                Console.WriteLine($"{inventory[index].Name} eliminado");

            for (int i = index; i < count - 1; i++)
            {
                inventory[i] = inventory[i + 1];
            }

            inventory[count - 1] = null;
            count--;
             }
        }

        public void UseItem()
        {
            ShowInventory();

            Console.WriteLine("\nSelecciona el item a usar:");

            int index = int.Parse(Console.ReadLine());

            if (index < 0 || index >= count)
            {
                Console.WriteLine("Item invalido");
            }
            else
            {
                Item item = inventory[index];

                if (item is Food || (item is ObjectPet obj && obj.TypeObject == ETypeObject.Medicine))
                {
                    if (Pet is IPetActionEat eatPet)
                    {
                        eatPet.Eat(item);
                    }
                }

                RemoveItemUnpainted(index);
            }
        }
        private void RemoveItemUnpainted(int index)
        {
            for (int i = index; i < count - 1; i++)
            {
                inventory[i] = inventory[i + 1];
            }

            inventory[count - 1] = null;
            count--;
        }
    }
}
