using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosEnc
{
    class ArbolBinario
    {
        Nodo raiz;
        int prueba;
        public ArbolBinario()
        {
            raiz = null;
        }    
        //public void Insertar(List<Caracter> info)
        //{
        //    Nodo nuevo;
        //    nuevo = new Nodo();
        //    nuevo.info = info;
        //    nuevo.Izq = null;
        //    nuevo.Der = null;
        //    if (raiz == null)
        //        raiz = nuevo;
        //    else
        //    {
        //        Nodo anterior = null, reco;
        //        reco = raiz;
        //        while (reco != null)
        //        {
        //            anterior = reco;
        //            int indice = Dividir(info);
        //            List<Caracter> superior = info.Where(x => x.indice <= indice).ToList();
        //            List<Caracter> inferior = info.Where(x => x.indice > indice).ToList();
        //            AsignarCodigo(ref superior, "0");
        //            AsignarCodigo(ref inferior, "1");
        //            if (superior != null)
        //                reco =
        //        }
        //    }// fin del else
        //}//fin de insertar
        public void AsignarCodigo(ref List<Caracter> info , string dato)
        {
            foreach (var item in info)
            {
                item.codigo = item.codigo + dato;
            }
        }
        public int Dividir(List<Caracter> CARS)
        {
            int total = CARS.Sum(x => x.frecuencia);
            float mitad = total / 2;
            int cuenta1 = 0;
            int cuenta2 = 0;
            int cuenta3 = 0;
            int indice = -1;
            int ultimo = CARS.Last().indice;
            int i;
            for (i = CARS.First().indice; i < ultimo; i++)
            {
                if (cuenta1 >= mitad)
                {
                    if (Math.Abs(mitad - cuenta3) <= Math.Abs(mitad - cuenta1))
                    {
                        cuenta1 = cuenta3;
                        indice--;

                    }

                    break;
                }
                cuenta1 += CARS[i].frecuencia;
                cuenta3 = cuenta1 - CARS[i].frecuencia;
                indice = i;
            }
            i++;
            if (CARS.Count >= i)
                cuenta2 = CARS[i].frecuencia + cuenta1;

            if (Math.Abs(mitad - cuenta1) <= Math.Abs(mitad - cuenta2))
                return indice;
            else
                return indice++;
        }// fin de dividir
    }// fin de clase

}
