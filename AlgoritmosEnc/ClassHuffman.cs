using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosEnc
{
     public class ClassHuffman
    {
        List<Nodo> datos = new List<Nodo>();
        List<Caracter> CARACTERES;
        bool bandera = false;
        List<string> codigos = new List<string>();
        List<Caracter> decodificados = new List<Caracter>();
        string cadena = "";
        public ClassHuffman(string entrada)
        {
            CARACTERES = Caracter.asignarFrecuencias(entrada);
            InsertarNodos();
            RetornarArbol(datos);
            Imprimir();
            List<Caracter> list2 = decodificados.OrderByDescending(x => x.frecuencia).ThenBy(x => x.car).ToList();
            decodificados = list2;
        }
      

        void RetornarArbol(List<Nodo> data)
        {

            datos = data;
            if (data.Count == 1)
                return;
            
            Nodo nuevonodo = CrearNodoConNodos(data[data.Count - 1], data[data.Count - 2]);
            data.Remove(data[data.Count - 1]);
            data.Remove(data[data.Count - 1]);
            data.Add(nuevonodo);
            List<Nodo> ordenado = data.OrderByDescending(x => x.suma).ToList();
            RetornarArbol(ordenado);
            
        }
        void InsertarNodos()
        {
            foreach (var item in CARACTERES)
            {
                Nodo nodo = new Nodo();
                nodo.info = item;
                nodo.suma = item.frecuencia;
                datos.Add(nodo);
            }
        }
        Nodo CrearNodoConNodos(Nodo iz, Nodo der)
        {
            Nodo nuevoNodo = new Nodo();
            nuevoNodo.suma = iz.suma + der.suma;
            iz.codigo =  "0";
            der.codigo = "1";
            nuevoNodo.Izq = iz;
            nuevoNodo.Der = der;
            return nuevoNodo;
        }
        private void Imprimir(Nodo reco,string anterior)
        {
            if (reco != null)
            {
                
                if (reco.info != null)
                {
                    Caracter nuevo = new Caracter();
                    nuevo.car = reco.info.car;
                    nuevo.codigo = reco.codigo+ anterior;
                    nuevo.frecuencia = reco.info.frecuencia;
                    decodificados.Add(nuevo);
                }
                Imprimir(reco.Izq,reco.codigo+anterior);
                Imprimir(reco.Der,reco.codigo+anterior);
                
            }

        }
        public void Imprimir()
        {
            Imprimir(datos[0],"");
        }
       public List<Caracter>Codificado()
        {
            return decodificados;
        }

    }
}
