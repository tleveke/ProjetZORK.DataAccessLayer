using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetZORK.DataAccessLayer.Models
{
    public class Weapon : BaseDataObject
    {
        public string Name { get; set; }
        public int AttackRate { get; set; }
        public int MissRate { get; set; }

        public Player player { get; set; }


    }
}
