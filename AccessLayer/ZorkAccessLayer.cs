using ProjetZORK.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjetZORK.DataAccessLayer.AccessLayer
{
    public class ZorkAccessLayer : BaseAccessLayer<Player>
    {
        public ZorkAccessLayer(ZorkManagerDbContext context)
            : base(context)
        {
        }
        public override IEnumerable<Player> GetCollection(Expression<Func<Player, bool>> filter = null, bool trackingEnabled = false)
        {
            var dbQuery = this.modelSet.AsQueryable();

            var filterToApply =
                filter == null
                ? x => true
                : filter;

            var collection = trackingEnabled
                            ? dbQuery.Include(p => p.Cell).Where(filterToApply)
                            : dbQuery.Include(p => p.Cell).Where(filterToApply);

            return collection;
        }
        public override Player GetSingle(Expression<Func<Player, bool>> filter, bool trackingEnabled = false)
        {
            var dbQuery = this.modelSet.AsQueryable();

            var item = trackingEnabled
                            ? dbQuery.Include(p => p.Cell).FirstOrDefault(filter)
                            : dbQuery.Include(p => p.Cell).AsNoTracking().FirstOrDefault(filter);
            return item;
        }
    }
}
