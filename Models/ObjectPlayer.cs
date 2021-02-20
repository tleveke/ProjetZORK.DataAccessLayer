using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetZORK.DataAccessLayer.Models
{
    public class ObjectPlayer : BaseDataObject
    {
        public int? PlayerId { get; set; }
        public Player Player { get; set; }
        public int? ObjectTypeId { get; set; }
        public ObjectType ObjectType { get; set; }
    }
}
