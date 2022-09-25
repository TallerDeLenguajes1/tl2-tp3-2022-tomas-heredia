using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp
{
    public class Pedido
    {
        public int Nro{get; set;}
        public string Obs{get; set;}
        public Cliente cliente{get; set;}
        public bool estado{get; set;} 
        public Pedido(int n, string ob, Cliente c, bool e){
            Nro = n;
            Obs = ob;
            cliente = c;
            estado = e;
        }
    }
}