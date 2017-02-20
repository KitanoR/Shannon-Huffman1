using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosEnc
{
    class Shannon
    {
        List<Caracter> CARACTERES;
        bool bandera = false;
        public Shannon(string entrada)
        {
           CARACTERES =  Caracter.asignarFrecuencias(entrada);
        }
        public List<Caracter> codificar()
        {
            this.dividir(CARACTERES, 0, CARACTERES.Count);
            return CARACTERES;
           
        }
        private void dividir(List<Caracter> CARS, int first, int last)
        {
            int total = CARS.Where(x=> x.indice >= first && x.indice<= last).Sum(x => x.frecuencia);
            if ((first + 1) == last || first == last || first > last)
            {
                if (first == last ||(first+1) == CARS.Count)
                {
                    return;
                }
                CARS[last].codigo += '1';
                CARS[first].codigo += '0';
                return;
            }
            else
            {
              
                float mitad = (float)total / 2;
                int cuenta1 = 0;
                int cuenta2 = 0;
                int cuenta3 = 0;
                int indice = -1;
                int ultimo = CARS.Last().indice;
                int i;
                for (i = first; i <= last; i++)
                {
                    if (cuenta1 >= mitad)
                    {
                        if (Math.Abs(mitad -(float) cuenta3) <= Math.Abs(mitad - (float)cuenta1))
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

                cuenta2 = Math.Abs(cuenta1 - total);

                if (Math.Abs(mitad - cuenta1) > Math.Abs(mitad - cuenta2))
                    indice++;

                //Codificacion
                for (int f = first; f <= indice; f++)
                {
                    CARS[f].codigo = CARS[f].codigo + "0";
                }
                int last1 = last;
                if (last == CARS.Count)
                {
                 last1 = last - 1;
                  
               }
                    
                for (int f = indice + 1; f <=last1; f++)
                {
                    CARS[f].codigo = CARS[f].codigo + "1";
                }

                dividir(CARS, first, indice);
                dividir(CARS, indice + 1, last);
            }
           
            
        }

        //public List<Caracter> dividir1(List<Caracter> CARS)
        //{
        //    int total = CARS.Sum(x => x.frecuencia);
        //    float mitad = total / 2;
        //    int cuenta1=0;
        //    int cuenta2=0;
        //    int cuenta3 = 0;
        //    int indice = -1;
        //    int ultimo = CARS.Last().indice;
        //    int i;
        //    for (i = CARS.First().indice; i < ultimo; i++)
        //    {
        //        if (cuenta1 >= mitad)
        //        {
        //            if (Math.Abs(mitad - cuenta3) <= Math.Abs(mitad - cuenta1))
        //            {
        //                cuenta1 = cuenta3;
        //                indice--;
                       
        //            }
                       
        //          break;
        //        }
        //        cuenta1 += CARS[i].frecuencia;
        //        cuenta3 = cuenta1 - CARS[i].frecuencia;
        //        indice = i;
        //    }
        //    i++;
        //    if(CARS.Count >= i)
        //    cuenta2 = CARS[i].frecuencia + cuenta1;

        //    if (Math.Abs(mitad - cuenta1) <= Math.Abs(mitad - cuenta2))
        //    {
        //        List<Caracter> superior = CARS.Where(x => x.indice <= indice).ToList();

        //        foreach (var item in superior)
        //        {
        //            item.codigo = item.codigo + "0";
        //        }
        //        if (indice > 0)
        //            return dividir(superior);
        //        else
        //        {

        //        }
        //        List<Caracter> inferior = CARS.Where(x => x.indice > indice).ToList();
        //        foreach (var item in inferior)
        //        {
        //            item.codigo = item.codigo + "1";
        //        }
        //        return dividir(inferior);
        //    }
        //    else
        //    {
        //        indice++;
        //        List<Caracter> superior = CARS.Where(x => x.indice >= indice).ToList();
        //        foreach (var item in superior)
        //        {
        //            item.codigo = item.codigo + "0";
        //        }
        //        dividir(superior);
        //        List<Caracter> inferior = CARS.Where(x => x.indice < indice).ToList();
        //        foreach (var item in inferior)
        //        {
        //            item.codigo = item.codigo + "1";
        //        }
        //        dividir(inferior);
        //    }
        //    return null;
        //}

    }
}
