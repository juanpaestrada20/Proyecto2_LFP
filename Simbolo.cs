using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_2
{
    class Simbolo
    {
        private string tipo;
        private object valor;
        private string id;

        public Simbolo(string tipo, object valor, string id)
        {
            this.tipo = tipo;
            this.valor = valor;
            this.id = id;
        }

        public string getTipo()
        {
            return tipo;
        }

        public object getValor()
        {
            return valor;
        }

        public string getID()
        {
            return id;
        }

        public void setValor(object valor)
        {
            this.valor = valor;
        }

        public void setTipo(string tipo)
        {
            this.tipo = tipo;
        }

        public void setID(string id)
        {
            this.id = id;
        }
    }
}
