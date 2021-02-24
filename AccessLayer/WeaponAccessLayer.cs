﻿using ProjetZORK.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetZORK.DataAccessLayer.AccessLayer
{
    public class WeaponAccessLayer : BaseAccessLayer<Weapon>
    {
        public WeaponAccessLayer(ZorkManagerDbContext context)
            : base(context)
        {

        }
    }
}
