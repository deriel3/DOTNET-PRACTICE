using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoStartUp.Entities
{
    public class Start
    {

        public Guid id { get; set; }
        public string nombre { get; set; }
        public string producto { get; set; }
        public double precio { get; set; }
    }
}
