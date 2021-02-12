﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetZORK.DataAccessLayer.Models
{
    public class Player : BaseDataObject
    {
        public string Name { get; set; }
        public int XP { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public List<Weapon> WeaponsInventory { get; set; }
        public Cell currentCell { get; set; }

    }
}
