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
    public class ObjectPlayerAccessLayer : BaseAccessLayer<ObjectPlayer>
    {
        public ObjectPlayerAccessLayer(ZorkManagerDbContext context)
            : base(context)
        { }
        public override IEnumerable<ObjectPlayer> GetCollection(Expression<Func<ObjectPlayer, bool>> filter = null, bool trackingEnabled = false)
        {
            var dbQuery = this.modelSet.AsQueryable();

            var filterToApply =
                filter == null
                ? x => true
                : filter;

            var collection = trackingEnabled
                            ? dbQuery.Include(o => o.Player).Where(filterToApply)
                            : dbQuery.Include(o => o.Player).Where(filterToApply);

            return collection;
        }
    }
}
