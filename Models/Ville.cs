using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace siteweb.Models
{
    public class Ville
    {
        public int id { get; set; }
        public string nom { get; set; }
        public ICollection<Medcine> Medcines { get; set; }

    }
}