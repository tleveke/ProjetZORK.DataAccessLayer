using System.Collections.Generic;

namespace ProjetZORK.DataAccessLayer.Models
{
    public class Player : BaseDataObject
    {
        public string Name { get; set; }
        public int XP { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int? CellId { get; set; }
        public virtual Cell Cell { get; set; }
        public int? WeaponId { get; set; }
        public Weapon Weapon { get; set; }
        public ICollection<ObjectPlayer> ObjectInventory { get; set; }

        public bool isFinish { get; set; }

    }
}
