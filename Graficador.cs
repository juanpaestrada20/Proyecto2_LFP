using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_2
{
    class Graficador
    {

        String ruta;
        StringBuilder grafo;

        public Graficador()
        {
            ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        }

        private void generarDot(String rdot, String rpng)
        {
            System.IO.File.WriteAllText(rdot, grafo.ToString());
            String comandoDot = "dot.exe -Tpng " + rdot + " -o " + rpng;
            var comando = string.Format(comandoDot);
            var procStart = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comando);
            var proc = new System.Diagnostics.Process();
            proc.StartInfo = procStart;
            proc.Start();
            proc.WaitForExit();
        }

        int graf = 0;
        public void graficar(String valores, String arreglo)
        {
            String[] vector = valores.Split(',');
            grafo = new StringBuilder();
            String rdot = ruta + "\\imagen.dot";
            String rpng = ruta + "\\imagen.png";
            grafo.Append("digraph G {\n "+ arreglo );
            foreach (String item in vector)
            {
                grafo.Append(" -> " + item);
            }
            
            grafo.Append(";}");
            graf++;
            this.generarDot(rdot, rpng);
        }

        public String abrirGrafo()
        {

            if (File.Exists(ruta + "\\imagen.png"))
            {
                try
                {
                    return ruta + "\\imagen.png";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error bro" + ex);
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Grafo no generado");
                return null;
            }
        }
    }
}
