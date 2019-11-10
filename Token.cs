using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_2
{
    class Token
    {

        public enum Tipo
        {
            CLASS,
            ID,
            VOID,
            MAIN,
            PARENTESIS_ABRE,
            PARENTESIS_CIERRA,
            STRING,
            ARGS,
            CORCHETE_ABRE,
            CORCHETE_CIERRA,
            LLAVE_ABRE,
            LLAVE_CIERRA,
            INT,
            FLOAT,
            BOOL,
            CHAR,
            COMA,
            PUNTO_COMA,
            DOS_PUNTOS,
            IGUAL,
            COMILLA_DOBLE,
            COMILLA_SIMPLE,
            DIAGONAL,
            ASTERISCO,
            NUMERO,
            MAYOR_QUE,
            MENOR_QUE,
            SIGNO_ADMIRACION,
            SUMA,
            RESTA,
            PUNTO,
            CONSOLE,
            WRITELINE,
            IF,
            ELSE,
            SWITCH,
            CASE,
            DEFAULT,
            BREAK,
            FOR,
            WHILE,
            CADENA,
            CARACTER,
            COMENTARIO,
            COMENTARIO_MULTILINEA,
            MAYOR_IGUAL,
            MENOR_IGUAL,
            IGUAL_IGUAL,
            NEW,
            DECIMAL,
            DOUBLE,
            STATIC,
            TRUE,
            FALSE
        }

        private Tipo tipoToken;
        private String valor;
        private int fila;
        private int columna;

        public Token(Tipo tipo_Token, String val, int fila, int columna)
        {
            this.tipoToken = tipo_Token;
            this.valor = val;
            this.fila = fila;
            this.columna = columna;
        }

        public String getValor()
        {
            return valor;
        }

        public Tipo getTipo()
        {
            return tipoToken;
        }

        public String getTipoToken()
        {
            switch (tipoToken)
            {
                case Tipo.ARGS:
                    return "Args";
                case Tipo.ASTERISCO:
                    return "Asterisco";
                case Tipo.BOOL:
                    return "Boolean";
                case Tipo.BREAK:
                    return "Break";
                case Tipo.CADENA:
                    return "Cadena";
                case Tipo.CASE:
                    return "Case";
                case Tipo.CHAR:
                    return "Char";
                case Tipo.CLASS:
                    return "Class";
                case Tipo.COMA:
                    return "Coma";
                case Tipo.COMILLA_DOBLE:
                    return "Comilla Doble";
                case Tipo.COMILLA_SIMPLE:
                    return "Comilla Simple";
                case Tipo.CONSOLE:
                    return "Console";
                case Tipo.CORCHETE_ABRE:
                    return "Corchete Abre";
                case Tipo.CORCHETE_CIERRA:
                    return "Corchete Cierra";
                case Tipo.DEFAULT:
                    return "Default";
                case Tipo.DIAGONAL:
                    return "Diagonal";
                case Tipo.ELSE:
                    return "Else";
                case Tipo.FLOAT:
                    return "Float";
                case Tipo.FOR:
                    return "For";
                case Tipo.ID:
                    return "Id";
                case Tipo.IF:
                    return "If";
                case Tipo.IGUAL:
                    return "Signo Igual";
                case Tipo.INT:
                    return "Int";
                case Tipo.MAIN:
                    return "Main";
                case Tipo.MAYOR_QUE:
                    return "Signo Mayor Que";
                case Tipo.MENOR_QUE:
                    return "Signo Menor Que";
                case Tipo.LLAVE_ABRE:
                    return "Llave Abre";
                case Tipo.LLAVE_CIERRA:
                    return "Llave Cierra";
                case Tipo.NUMERO:
                    return "Numero";
                case Tipo.PARENTESIS_ABRE:
                    return "Parentesis Abre";
                case Tipo.PARENTESIS_CIERRA:
                    return "Parentesis Cierra";
                case Tipo.PUNTO:
                    return "Punto Decimal";
                case Tipo.PUNTO_COMA:
                    return "Punto y Coma";
                case Tipo.RESTA:
                    return "Signo de Resta";
                case Tipo.STRING:
                    return "String";
                case Tipo.SUMA:
                    return "Signo Suma";
                case Tipo.SWITCH:
                    return "Switch";
                case Tipo.VOID:
                    return "Void";
                case Tipo.WHILE:
                    return "While";
                case Tipo.WRITELINE:
                    return "Writeline";
                case Tipo.CARACTER:
                    return "Caracter";
                case Tipo.SIGNO_ADMIRACION:
                    return "Signo de Admiracion";
                case Tipo.COMENTARIO:
                    return "Comentario";
                case Tipo.COMENTARIO_MULTILINEA:
                    return "Comentario Multilinea";
                case Tipo.MENOR_IGUAL:
                    return "Signo Menor o Igual Que";
                case Tipo.MAYOR_IGUAL:
                    return "Signo Mayor o Igual Que";
                case Tipo.IGUAL_IGUAL:
                    return "Signo Igual Igual";
                case Tipo.NEW:
                    return "new";
                case Tipo.DECIMAL:
                    return "Número Decimal";
                case Tipo.DOUBLE:
                    return "Double";
                case Tipo.STATIC:
                    return "Static";
                case Tipo.TRUE:
                    return "True";
                case Tipo.FALSE:
                    return "false";
                default:
                    return "Desconocido";
            }
        }
        public int getFila()
        {
            return fila;
        }

        public int getColumna()
        {
            return columna;
        }

        public int getId()
        {
            switch (tipoToken)
            {
                case Tipo.ARGS:
                    return 1;
                case Tipo.ASTERISCO:
                    return 2;
                case Tipo.BOOL:
                    return 3;
                case Tipo.BREAK:
                    return 4;
                case Tipo.CADENA:
                    return 5;
                case Tipo.CARACTER:
                    return 6;
                case Tipo.CASE:
                    return 7;
                case Tipo.CHAR:
                    return 8;
                case Tipo.CLASS:
                    return 9;
                case Tipo.COMA:
                    return 10;
                case Tipo.COMILLA_DOBLE:
                    return 11;
                case Tipo.COMILLA_SIMPLE:
                    return 12;
                case Tipo.CONSOLE:
                    return 13;
                case Tipo.CORCHETE_ABRE:
                    return 14;
                case Tipo.CORCHETE_CIERRA:
                    return 15;
                case Tipo.DEFAULT:
                    return 16;
                case Tipo.DIAGONAL:
                    return 17;
                case Tipo.DOS_PUNTOS :
                    return 18;
                case Tipo.ELSE:
                    return 19;
                case Tipo.FLOAT:
                    return 20;
                case Tipo.FOR:
                    return 21;
                case Tipo.ID:
                    return 22;
                case Tipo.IF:
                    return 23;
                case Tipo.IGUAL:
                    return 24;
                case Tipo.INT:
                    return 25;
                case Tipo.LLAVE_ABRE:
                    return 26;
                case Tipo.LLAVE_CIERRA:
                    return 27;
                case Tipo.MAIN:
                    return 28;
                case Tipo.MAYOR_QUE:
                    return 29;
                case Tipo.MENOR_QUE:
                    return 30;
                case Tipo.NUMERO:
                    return 31;
                case Tipo.PARENTESIS_ABRE:
                    return 32; 
                case Tipo.PARENTESIS_CIERRA:
                    return 33;
                case Tipo.PUNTO:
                    return 34;
                case Tipo.PUNTO_COMA:
                    return 35;
                case Tipo.RESTA:
                    return 36;
                case Tipo.SIGNO_ADMIRACION:
                    return 37;
                case Tipo.STRING:
                    return 38;
                case Tipo.SUMA:
                    return 39;
                case Tipo.SWITCH:
                    return 40;
                case Tipo.VOID:
                    return 41;
                case Tipo.WHILE:
                    return 42;
                case Tipo.WRITELINE:
                    return 43;
                case Tipo.COMENTARIO:
                    return 44;
                case Tipo.COMENTARIO_MULTILINEA:
                    return 45;
                case Tipo.MENOR_IGUAL:
                    return 46;
                case Tipo.MAYOR_IGUAL:
                    return 47;
                case Tipo.IGUAL_IGUAL:
                    return 48;
                case Tipo.NEW:
                    return 49;
                case Tipo.DECIMAL:
                    return 50;
                case Tipo.DOUBLE:
                    return 51;
                case Tipo.STATIC:
                    return 52;
                case Tipo.TRUE:
                    return 53;
                case Tipo.FALSE:
                    return 54;
                default:
                    return 0;
            }
        }

    }
}
