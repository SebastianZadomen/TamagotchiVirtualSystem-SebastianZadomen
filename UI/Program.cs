using System.Collections;
using System.Numerics;
using System.Xml.Linq;
using TamagotchiVirtualSystem.Core.Interfaces;
using TamagotchiVirtualSystem.Core.Model;
using TamagotchiVirtualSystem.Core.Model.Item_Model;
using TamagotchiVirtualSystem.Core.Model.Pet_Core.Sub_Pets;
using TamagotchiVirtualSystem.Core.Model.Player;
using TamagotchiVirtualSystem.Model;
using TamagotchiVirtualSystem.UI;


public class Program
{
//menu const
    private const string OptionEat = "1";
    private const string OptionSleep = "2";
    private const string OptionPlay = "3";
    private const string OptionInventory = "4";
    private const string OptionShop = "5";
    private const string OptionExit = "6";
    private const string OptionCat = "1";
    private const string OptionChick = "2";
    private const string OptionDog = "3";


    public static void Main()
    {
        StartGame();
    }

    static void StartGame()
    {
        Player player = new Player();

        player.Pet = SelectPet();
        GameLoop(player);
    }

    static Pets SelectPet()
    {
        UIConfig.DesingCat.MenuSelectionPet();


        string option = Console.ReadLine();

        Console.Write("Introduce el nombre de tu mascota: ");
        string name = Console.ReadLine();

        switch (option)
        {
            case OptionCat:
                 return new Cat(name);
                break;

            case OptionChick:
                return new Chick(name);
                break;
            case OptionDog:
                return new Dog(name);
                break;
                
            default:
                Console.WriteLine("Opción no válida. Se creará un Cat por defecto.");
                return new Cat(name);
                break;
        }
    }

  
    static void GameLoop(Player player)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            player.Pet.UpdateStatsOverTime();

            if (player.Pet.IsDead)
            {
                RestartGame();

            }
            else
            {

                UIConfig.DesingCat.Draw(player.Pet);

                string option = Console.ReadLine();

                switch (option)
                {
                    case OptionEat:
                        EatMenu(player);
                        break;

                    case OptionSleep:
                        if (player.Pet is IPetActionSleep sleepPet)
                            sleepPet.Sleep();
                        break;

                    case OptionPlay:
                        PlayMenu(player);
                        break;

                    case OptionInventory:
                        player.ShowInventory();
                        Console.ReadKey();
                        break;

                    case OptionShop:
                        ShopMenu(player);
                        break;

                    case OptionExit:
                        running = false;
                        break;
                }
            }
        }
        StartGame();
        Console.ReadKey();
    }


    public static void EatMenu(Player player)
    {
        Console.Clear();
        Item item = player.SelectItem();

        if (item == null) return;

        // Comprobamos que sea comida o medicina
        if (item is Food || (item is ObjectPet obj && obj.TypeObject == ETypeObject.Medicine))
        {
            if (player.Pet is IPetActionEat eatPet)
            {
                eatPet.Eat(item);
            }

            Console.WriteLine($"{item.Name} dado a {player.Pet.Name}");
        }
        else
        {
            Console.WriteLine($"{item.Name} no se le puede dar de comer a {player.Pet.Name}");
        }

        Console.ReadKey();
    }

    public static void PlayMenu(Player player)
    {
        Console.Clear();
        Item item = player.SelectItem();

        if (item == null) return;

       
        if (item is ObjectPet obj && obj.TypeObject == ETypeObject.Toy)
        {
            if (player.Pet is IPetActionPlay playPet)
            {
                playPet.Play(item);
            }

            Console.WriteLine($"{item.Name} usado para jugar con {player.Pet.Name}");
        }
        else
        {
            Console.WriteLine($"{item.Name} no se puede usar para jugar con {player.Pet.Name}");
        }

        Console.ReadKey();
    }

    public static void RestartGame()
    {
        Console.WriteLine("\nLa mascota ha muerto.");
        Console.WriteLine("Presiona una tecla para reiniciar...");
        Console.ReadKey();

        Console.Clear();
        StartGame();
    }
    public static void ShopMenu(Player player)
    {
        Shop shop = new Shop();

        Console.Clear();
        shop.ShowItems();

        Console.WriteLine("Selecciona item para comprar:");
        int index = int.Parse(Console.ReadLine());

        Item item = shop.BuyItem(index);

        if (item != null)
        {
            player.AddItem(item);
        }

        Console.WriteLine("Pulsa una tecla para volver...");
        Console.ReadKey();
    }
}