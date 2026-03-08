using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiVirtualSystem.Core.Model.Item_Model;

namespace TamagotchiVirtualSystem.Core.Interfaces
{
    public interface IPetActionEat
    {
        void Eat(Item aliment);
    }
}
