﻿using Microsoft.EntityFrameworkCore;
using ProjetZORK.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetZORK.DataAccessLayer
{
    public class ZorkManagerDbContext : DbContext
    {
        public readonly DbContextOptions<ZorkManagerDbContext> _options;

        public ZorkManagerDbContext()
        {
        }

        public ZorkManagerDbContext(DbContextOptions<ZorkManagerDbContext> options)
            : base(options)
        {
            this._options = options;
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Cell> Cells { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Weapon> Weapons { get; set; }

        public DbSet<ObjectPlayer> ObjectPlayers { get; set; }
        public DbSet<ObjectType> ObjectTypes { get; set; }

    }
}
