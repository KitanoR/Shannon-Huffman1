using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosEnc
{
    class Huffman
    {
        List<Caracter> CARACTERES;
        List<NodoHuffman> LISTANODOS;
        bool bandera = false;
        public Huffman(string entrada)
        {
            CARACTERES = Caracter.asignarFrecuencias(entrada);
        }
       private void Ordenar()
        {
            
        }
        private void CrearNodoAgregarLista()
        {
            foreach (var item in CARACTERES)
            {
                NodoHuffman nuevonodo = new NodoHuffman();
                nuevonodo.info = item;
                LISTANODOS.Add(nuevonodo);
            }
            
        }
    }
}
