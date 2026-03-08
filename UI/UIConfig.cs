using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiVirtualSystem.Model;

namespace TamagotchiVirtualSystem.UI
{
    public static class UIConfig
    {
        public static class DesingCat
        {
            public static void Draw(Pets pet)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.Clear();

                Console.WriteLine("╔════════════════════════════════╗");
                Console.WriteLine("║          TAMAGOTCHI            ║");
                Console.WriteLine($"║    DateOfBirth: {new DateTime(1987, 01, 15):dd/MM/yyyy}     ║");
                Console.WriteLine($"║       Type: {pet.Pet}           ║");
                Console.WriteLine("╚════════════════════════════════╝");

                Console.WriteLine(GetPetArt(pet.EmotionalState.ToString()));

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
                Console.WriteLine("4 - Exit");
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

            public static string GetPetArt(string state)
            {
                return state switch
                {
                    "Happy" => @"
      /\_/\      
     ( ^‿^ )     
     /       \    
    |         |   
     \__/\___/    
",

                    "Sad" => @"
      /\_/\      
     ( ╥﹏╥ )     
     /       \    
    |         |   
     \__/\___/    
",

                    "Angry" => @"
      /\_/\      
     ( ಠ_ಠ )     
     /       \    
    |         |   
     \__/\___/    
",

                    "Tired" => @"
      /\_/\      
     ( -_- ) zZ  
     /       \    
    |         |   
     \__/\___/    
",

                    "Sick" => @"
      /\_/\      
     ( x_x )     
     /       \    
    |  +--+   |   
     \__/\___/    
",

                    _ => ""
                };
            }
        }
    }
}
