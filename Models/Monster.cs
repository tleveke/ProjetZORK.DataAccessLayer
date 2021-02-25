using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetZORK.DataAccessLayer.Models
{
    public class Monster : BaseDataObject
    {
        public string Name { get; set; }
        public int AttackRate { get; set; }
        public int MissRate { get; set; }
        public int HP { get; set; }
        public int Group { get; set; }
        public int Attack { get; set; }
    }
}
