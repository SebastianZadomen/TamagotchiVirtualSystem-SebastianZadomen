using System.Collections;
using System.Xml.Linq;
using TamagotchiVirtualSystem.Core.Model;
using TamagotchiVirtualSystem.Core.Model.Pet_Core.Sub_Pets;
using TamagotchiVirtualSystem.Core.Model.Item_Model;


public class Program
{
    public static void Main()
    {
        Cat naranjoso = new Cat("Gatito");
        
        Console.WriteLine(naranjoso.Stats.EnergyLevel);
        naranjoso.Stats.EnergyLevel -= 10;
        Console.WriteLine(naranjoso.Stats.EnergyLevel);
        Console.WriteLine(naranjoso.EmotionalState);
        //naranjoso.Stats.EnergyLevel -= 80;
        Console.WriteLine(naranjoso.Stats.EnergyLevel);
        Console.WriteLine(naranjoso.EmotionalState);

        Food carne = new Food("carne", "f",50 ,ETypeFood.Snack);
        ObjectPet medicina = new ObjectPet("pastilla", "💊", ETypeObject.Toy, 40);

        Console.WriteLine(medicina.ModifierState);
        Console.WriteLine(carne.ModifierState);

        naranjoso.Eat(carne);
        Console.WriteLine(naranjoso.EmotionalState);
    }

}