using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiVirtualSystem.Core.Model.Pet_Core.Sub_Pets;

namespace TamagotchiVirtualSystem.Core.Model.Item_Model
{
    public class Food : Item
    {
        public ETypeFood CategoryFood { get; set; }
         
        public Food(string name, string icon, int upgradeValue, ETypeFood categoryFood) : base(name, icon, RecalculateStateFood(categoryFood), upgradeValue)
        {
            CategoryFood = categoryFood;

        }
        public static EState RecalculateStateFood(ETypeFood type)
        {
            if (type.Equals(ETypeFood.Snack)) return EState.Happy;
            else
                return EState.Normal;

        }
    }
}
