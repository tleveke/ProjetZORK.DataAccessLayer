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
    public class ObjectTypeAccessLayer : BaseAccessLayer<ObjectType>
    {
        public ObjectTypeAccessLayer(ZorkManagerDbContext context)
            : base(context)
        { 
        
        }
    }
}
