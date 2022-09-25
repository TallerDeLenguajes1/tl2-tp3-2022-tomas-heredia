using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp
{
    public class Cadeteria
    {
        public string Nombre{get; set;}
        public float Telefono{get; set;}

        public Cadeteria(string n, float t){
            Nombre = n;
            Telefono = t;
        }

        public List<Cadete> Cadetes = new List<Cadete>();
    }
}