using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetZORK.DataAccessLayer.Models
{
    public class ObjectType : BaseDataObject
    {
        public int HPRestoreValue { get; set; }
        public string Name { get; set; }
        public int AttackStrenghBoost { get; set; }
        public int DefenseBoost { get; set; }

        
    }
}
