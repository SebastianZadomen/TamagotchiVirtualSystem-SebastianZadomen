using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagotchiVirtualSystem.Core.Model.Item_Model
{
    public abstract class Item
    {
        public  string Name { get; set; }
        public string Icon { get; set; }
        public EState ModifierState { get; set; }
        public int UpgradeValue { get; set; }

        public Item(string name, string icon, EState modifierState, int upgradeValue) {

            Name = name;
            Icon = icon;
            ModifierState = modifierState;
            UpgradeValue = upgradeValue;

        }

    }
}
