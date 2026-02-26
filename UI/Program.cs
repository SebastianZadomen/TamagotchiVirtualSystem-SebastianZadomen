using System.Collections;
using System.Xml.Linq;
using TamagotchiVirtualSystem.Core.Model;
using TamagotchiVirtualSystem.Core.Model.Pet_Core.Sub_Pets;

public class Program
{
    public static void Main()
    {
        Cat naranjoso = new Cat("Gatito");

        Console.WriteLine(naranjoso.Stats.EnergyLevel);
        naranjoso.Stats.EnergyLevel -= 10;
        Console.WriteLine(naranjoso.Stats.EnergyLevel);

    }

   
   


}