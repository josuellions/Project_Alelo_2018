using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alelo.model.web
{
    [Serializable]
    public class CategoriaLista
    {
        public Int32 Id { get; set; }
        public Int32 TypeId { get; set; }
        public String Name { get; set; }
        public int Status { get; set; }
    }
}
