using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagotchiVirtualSystem.Core.Model.Item_Model
{
    public class Object : Item
    {

        public Object(string name, char icon, EState modifierState, int upgradeValue) : base(name, icon, modifierState, upgradeValue)
        {
        }
    }
}
