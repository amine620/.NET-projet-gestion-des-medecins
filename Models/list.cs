using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace siteweb.Models
{
    public class list
    {
        public Medcine Medcines { get; set; }
        public ICollection<Sexe> Sexes { get; set; }
        public ICollection<Specialite> Specialites { get; set; }
        public ICollection<Ville> Villes { get; set; }


    }
}