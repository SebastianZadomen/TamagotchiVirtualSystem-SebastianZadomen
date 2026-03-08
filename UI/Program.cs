using System.Collections;
using System.Xml.Linq;
using TamagotchiVirtualSystem.Core.Interfaces;
using TamagotchiVirtualSystem.Core.Model;
using TamagotchiVirtualSystem.Core.Model.Item_Model;
using TamagotchiVirtualSystem.Core.Model.Pet_Core.Sub_Pets;
using TamagotchiVirtualSystem.Model;
using TamagotchiVirtualSystem.UI;


public class Program
{
        public static void Main()
        {
            Player player = new Player();

            player.Pet = new Cat("Gatito");

            bool running = true;

            while (running)
            {
                UIConfig.DesingCat.Draw(player.Pet);

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":

                        Food comida = new Food("Snack", "🍪", 20, ETypeFood.Snack);

                        if (player.Pet is IPetActionEat eatPet)
                            eatPet.Eat(comida);

                        break;

                    case "2":

                        if (player.Pet is IPetActionSleep sleepPet)
                            sleepPet.Sleep();

                        break;

                    case "3":

                        ObjectPet toy = new ObjectPet("Pelota", "⚽", ETypeObject.Toy, 10);

                        if (player.Pet is IPetActionPlay playPet)
                            playPet.Play(toy);

                        break;

                    case "4":

                        running = false;

                        break;
                }
            }
        }

    }