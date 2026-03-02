using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagotchiVirtualSystem.Core.Model.Item_Model
{
    public class ObjectPet : Item
    {
        public ETypeObject TypeObject { get; set; }
        public ObjectPet(string name, string icon, ETypeObject typeObject, int upgradeValue ) : base(name, icon, RecalculateStateObject(typeObject), upgradeValue)
        {
            TypeObject = typeObject;
        }

        public static EState RecalculateStateObject(ETypeObject type)
        {
            if (type.Equals(ETypeObject.Toy)) return EState.Happy;
            else
                return EState.Normal;

        }
    }   
    
}
