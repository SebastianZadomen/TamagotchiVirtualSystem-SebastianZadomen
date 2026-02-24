using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiVirtualSystem.Core.Model;

namespace TamagotchiVirtualSystem.Model
{
    public abstract class Pets
    {
        public string Name { get; set; }
        public EState EmotionalState { get; set; }

        public EPetTypes Pet { get; set; }
        

    }
}
