using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosEnc
{
    class Nodo
    {
        public Caracter info;
        public Nodo Izq, Der;
        public string codigo;
        public int suma;
        public Nodo()
        {
            Izq = null;
            Der = null;
            info = null;
            suma = 0;
            codigo = "";
        }
    }//fin de nodo
}
