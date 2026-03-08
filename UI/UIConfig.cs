using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiVirtualSystem.Model;
using TamagotchiVirtualSystem.Core.Model;

namespace TamagotchiVirtualSystem.UI
{
    public static class UIConfig
    {
        public static class DesingCat
        {
            public static void Draw(Pets pet)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                


                Console.WriteLine("╔════════════════════════════════╗");
                Console.WriteLine("║          TAMAGOTCHI            ║");
                Console.WriteLine($"║    DateOfBirth: {new DateTime(1987, 01, 15):dd/MM/yyyy}     ║");
                Console.WriteLine($"║       Type: {pet.Pet}           ║");
                Console.WriteLine("╚════════════════════════════════╝");

                Console.WriteLine(GetPetArt(pet));

                Console.WriteLine($"Name: {pet.Name}");
                Console.WriteLine($"Emotional State: {pet.EmotionalState} \n");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Hunger: {DrawBar(pet.Stats.HungryLevel)}");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Energy: {DrawBar(pet.Stats.EnergyLevel)}");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Health: {DrawBar(pet.Stats.HealthLevel)}");

                Console.ResetColor();

                Console.WriteLine("\n---------------------------------");
                Console.WriteLine("1 - Eat");
                Console.WriteLine("2 - Sleep");
                Console.WriteLine("3 - Play");
                Console.WriteLine("4 - Inventory");
                Console.WriteLine("5 - Shop");
                Console.WriteLine("6 - Exit");
                Console.WriteLine("DEBUG: " + pet.Pet);
            }
            public static void MenuSelectionPet()
            {
                Console.Clear();
                Console.WriteLine("=== SELECCIONA TU MASCOTA ===\n1 - Cat\n2 - Chick\n3 - Dog");
               
            }
            private static string DrawBar(int value)
            {
                int totalBlocks = 20;
                int clampedValue = Math.Clamp(value, 0, 100);

                int filledBlocks = clampedValue * totalBlocks / 100;

                return "[" +
                       new string('#', filledBlocks) +
                       new string('-', totalBlocks - filledBlocks) +
                       $"] {clampedValue}%";
            }
            public static string GetPetArt(Pets pet)
            {
                return pet.Pet switch
                {
                    EPetTypes.Cat => GetCatArt(pet.EmotionalState),
                    EPetTypes.Chick => GetChickArt(pet.EmotionalState),
                    EPetTypes.Dog => GetDogArt(pet.EmotionalState),
                    _ => ""
                };
            }
            private static string GetCatArt(EState state)
            {
                return state switch
                {
                    EState.Happy => @"
      /\_/\  
     ( ^‿^ )
     /      \
    |        |
     \__/\___/
",

                    EState.Sad => @"
      /\_/\  
     ( ╥﹏╥ )
     /      \
    |        |
     \__/\___/
",

                    EState.Angry => @"
      /\_/\  
     ( ಠ_ಠ )
     /      \
    |        |
     \__/\___/
",

                    EState.Tired => @"
      /\_/\  
     ( -_- ) zZ
     /      \
    |        |
     \__/\___/
",

                    EState.Sick => @"
      /\_/\  
     ( x_x )
     /  +--+ \
    |        |
     \__/\___/
",

                    _ => @"
      /\_/\  
     (o_o )
     /      \
    |        |
     \__/\___/
"
                };
            }
            private static string GetDogArt(EState state)
            {
                return state switch
                {
                    EState.Happy => @"
        /^-----^\
       V  ^   ^  V
        \   Y   /  
         \____/ 
        /      \
",

                    EState.Sad => @"
        /^-----^\
       V  -   -  V
        \   Y   /  
         \____/ 
        /      \
",

                    EState.Angry => @"
        /^-----^\
       V  ಠ   ಠ  V
        \   Y   /  
         \____/ 
        /      \
",

                    EState.Tired => @"
         /^-----^\
       V  -   -  V ZzZZz
        \   Y   /  
         \____/ 
        /      \
",

                    EState.Sick => @"
        /^-----^\
       V  x   x  V
        \   Y  /  
         \____/ 
        /      \
",

                    _ => @"
        /^-----^\
       V  o   o  V
        \   Y   /  
         \____/ 
        /      \
"
                };
            }
            private static string GetChickArt(EState state)
            {
                return state switch
                {
                    EState.Happy => @"
          ( ^   ^ )
           (  \/  )
            /    \
",

                    EState.Sad => @"
          ( -   - )
           (  \/  )
            /    \
",

                    EState.Angry => @"
         ( ಠ   ಠ )
          (  \/  )
           /    \
",

                    EState.Tired => @"
         ( -   - ) zZz
          (  \/  )
           /    \
",

                    EState.Sick => @"
         ( X   X )
          (  \/  )
           /    \
",

                    _  => @"

          ( o  o )
          (  \/  )
           /    \

",
                };
            }
        }
    }
}
