using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetZORK.DataAccessLayer.Models
{
    public class Cell : BaseDataObject
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int MonsterRate { get; set; }
        //public int MonsterGroup { get; set; }
        public bool canMoveTo { get; set; }
        public string Description { get; set; }



    }
}
