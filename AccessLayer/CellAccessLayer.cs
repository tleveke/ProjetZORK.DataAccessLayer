using ProjetZORK.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetZORK.DataAccessLayer.AccessLayer
{

    public class CellAccessLayer : BaseAccessLayer<Cell>
    {
        public CellAccessLayer(ZorkManagerDbContext context)
            : base(context)
        {

        }
    }
}
