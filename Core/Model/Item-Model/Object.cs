using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagotchiVirtualSystem.Core.Model.Item_Model
{
    public class Object : Item
    {
        public ETypeObject TypeObject { get; set; }
        public Object(ETypeObject typeObject,string name, char icon, int upgradeValue ) : base(name, icon, RecalculateState(typeObject), upgradeValue)
        {
            TypeObject = typeObject;
        }

        public static EState RecalculateState(ETypeObject type)
        {
            if (type.Equals(ETypeObject.Toy)) return EState.Happy;
            else
                return EState.Normal;

        }
    }   
    
}
