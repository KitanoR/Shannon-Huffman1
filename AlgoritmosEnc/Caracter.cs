using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosEnc
{
   public class Caracter
    {

        public char car;
        public int frecuencia;
        public string codigo;
        public int indice; 
        public Caracter()
        {

        }
        public Caracter (char c, int f)
        {
            car = c;
            frecuencia = f;
            codigo = "";
        }

        public static List<Caracter> asignarFrecuencias(string entrada)
        {
            List<Caracter> listaCar = new List<Caracter>();
            int j = 0; 
            for (int i = 33; i < 127; i++)
            {
                Caracter c = new Caracter(Convert.ToChar(i), entrada.Count(a => a == Convert.ToChar(i)));
                if(c.frecuencia >0)
                {
                    

                    listaCar.Add(c);
                   
                }
                
            }
            List<Caracter> list2 = listaCar.OrderByDescending(x => x.frecuencia).ThenBy(x => x.car).ToList();
            foreach (var item in list2)
            {
                item.indice = j;
                j++;
            }
            return list2;
        }
        //Propiedades
        public char Simbolo 
            {
                get { return car; }
            }
        public int Frecuencia
        {
            get { return frecuencia; }
        }
        public string Codigo
        {
            get { return codigo; }
        }
    }
}
