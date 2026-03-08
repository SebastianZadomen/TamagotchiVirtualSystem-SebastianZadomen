using System.Collections;
using System.Numerics;
using System.Xml.Linq;
using TamagotchiVirtualSystem.Core.Interfaces;
using TamagotchiVirtualSystem.Core.Model;
using TamagotchiVirtualSystem.Core.Model.Item_Model;
using TamagotchiVirtualSystem.Core.Model.Pet_Core.Sub_Pets;
using TamagotchiVirtualSystem.Model;
using TamagotchiVirtualSystem.UI;


public class Program
{
//menu const
    private const string OptionEat = "1";
    private const string OptionSleep = "2";
    private const string OptionPlay = "3";
    private const string OptionInventory = "4";
    private const string OptionExit = "5";
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
                        break;

                    case OptionExit:
                        running = false;
                        break;
                }
            }
        }
    }

   
    static void EatMenu(Player player)
    {
        Console.Clear();

        player.UseItem();
    }

    static void PlayMenu(Player player)
    {
        Console.Clear();

        ObjectPet toy = new ObjectPet("Pelota", "⚽", ETypeObject.Toy, 15);

        if (player.Pet is IPetActionPlay playPet)
            playPet.Play(toy);
    }

    static void RestartGame()
    {
        Console.WriteLine("\nEl juego se reiniciará...");
        System.Threading.Thread.Sleep(2000);
        Console.Clear();
        StartGame();
    }
}