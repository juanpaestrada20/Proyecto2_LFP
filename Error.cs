using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_2
{
    class Error
    {
        private String error;
        private String descripcion;
        private int fila;
        private int columna;

        public Error(String error, String descripcion, int fila, int columna)
        {
            this.error = error;
            this.descripcion = descripcion;
            this.fila = fila;
            this.columna = columna;
        }

        public String getError()
        {
            return error;
        }

        public String getDescripcion()
        {
            return descripcion;
        }

        public int getFila()
        {
            return fila;
        }

        public int getColumna()
        {
            return columna;
        }
    }
}
