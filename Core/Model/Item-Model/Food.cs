using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagotchiVirtualSystem.Core.Model.Item_Model
{
    public class Food : Item
    {
        public ETypeFood CategoryFood { get; set; }
         
        public Food(string name, char icon, EState modifierState, int upgradeValue, ETypeFood categoryFood) : base(name, icon, modifierState, upgradeValue)
        {
            CategoryFood = categoryFood;

        }
    }
}
