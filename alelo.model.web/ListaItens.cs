using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alelo.model.web
{
    [Serializable]
    public class ListaItens
    {
        public int Id { get; set; }
        public String Type { get; set; }
        public String Name { get; set; }
        public int Status { get; set; }
        public IList<string> Items { get; set; }
    }
    
    public class Items
    {
        public IList<ListaItens> Id { get; set; }
        public IList<ListaItens> ListId { get; set; }
        public IList<ListaItens> Name { get; set; }
        public IList<ListaItens> Status { get; set; }
    }
    
}
