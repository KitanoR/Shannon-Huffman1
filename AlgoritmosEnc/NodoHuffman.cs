using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosEnc
{
    class NodoHuffman
    {
        public Caracter info;
        public NodoHuffman Izq, Der;
        public NodoHuffman()
        {
            Izq = null;
            Der = null;
            info = null;
        }
    }
}
