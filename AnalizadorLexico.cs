using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_2
{
    class AnalizadorLexico
    {
        private LinkedList<Token> Salida;
        private int estado;
        private int fila;
        private int columna;
        private String auxlex;
        public static LinkedList<Error> listaErrores = new LinkedList<Error>();

        public LinkedList<Token> Escanner(String entrada)
        {
            Salida = new LinkedList<Token>();
            estado = 0;
            fila = 1;
            columna = 1;
            auxlex = "";
            Char c;
            Char d;
            entrada += "#";

            for (int i = 0; i < entrada.Length; i++)
            {

                c = entrada.ElementAt(i);
                Console.WriteLine(c);
                switch (estado)
                {
                    //decidir estado
                    case 0:
                        if (Char.IsLetter(c))
                        {
                            estado = 1;
                            i--;
                        }
                        else if (Char.IsDigit(c))
                        {
                            estado = 2;
                            i--;
                        }
                        else if (c.CompareTo('"') == 0)
                        {
                            auxlex += c;
                            agregarToken(Token.Tipo.COMILLA_DOBLE);
                            estado = 3;
                            columna++;
                        }
                        else if (c.CompareTo('\'') == 0)
                        {
                            auxlex += c;
                            agregarToken(Token.Tipo.COMILLA_SIMPLE);
                            estado = 3;
                            columna++;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == entrada.Length - 1)
                            {
                                Console.WriteLine("Hemos concluido el analiss con exito");
                                break;
                            }
                            estado = 4;
                            i--;
                        }
                        break;
                    //letras
                    case 1:
                        auxlex += c;
                        columna++;
                        if (auxlex.CompareTo("args") == 0)
                        {
                            d = entrada.ElementAt(i + 1);
                            if (Char.IsLetter(d))
                            {
                                estado = 1;
                                break;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.ARGS);
                                break;
                            }
                        }
                        else if (auxlex.CompareTo("bool") == 0)
                        {
                            d = entrada.ElementAt(i + 1);
                            if (Char.IsLetter(d))
                            {
                                estado = 1;
                                break;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.BOOL);
                                break;
                            }
                        }
                        else if (auxlex.CompareTo("break") == 0)
                        {
                            d = entrada.ElementAt(i + 1);
                            if (Char.IsLetter(d))
                            {
                                estado = 1;
                                break;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.BREAK);
                                break;
                            }
                        }
                        else if (auxlex.CompareTo("case") == 0)
                        {
                            d = entrada.ElementAt(i + 1);
                            if (Char.IsLetter(d))
                            {
                                estado = 1;
                                break;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.CASE);
                                break;
                            }
                        }
                        else if (auxlex.CompareTo("char") == 0)
                        {
                            d = entrada.ElementAt(i + 1);
                            if (Char.IsLetter(d))
                            {
                                estado = 1;
                                break;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.CHAR);
                                break;
                            }
                        }
                        else if (auxlex.CompareTo("Class") == 0)
                        {
                            d = entrada.ElementAt(i + 1);
                            if (Char.IsLetter(d))
                            {
                                estado = 1;
                                break;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.CLASS);
                                break;
                            }
                        }
                        else if (auxlex.CompareTo("Console") == 0)
                        {
                            d = entrada.ElementAt(i + 1);
                            if (Char.IsLetter(d))
                            {
                                estado = 1;
                                break;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.CONSOLE);
                                break;
                            }
                        }
                        else if (auxlex.CompareTo("default") == 0)
                        {
                            d = entrada.ElementAt(i + 1);
                            if (Char.IsLetter(d))
                            {
                                estado = 1;
                                break;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.DEFAULT);
                                break;
                            }
                        }
                        else if (auxlex.CompareTo("else") == 0)
                        {
                            d = entrada.ElementAt(i + 1);
                            if (Char.IsLetter(d))
                            {
                                estado = 1;
                                break;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.ELSE);
                                break;
                            }
                        }
                        else if (auxlex.CompareTo("float") == 0)
                        {
                            d = entrada.ElementAt(i + 1);
                            if (Char.IsLetter(d))
                            {
                                estado = 5;
                                break;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.FLOAT);
                                break;
                            }
                        }
                        else if (auxlex.CompareTo("for") == 0)
                        {
                            d = entrada.ElementAt(i + 1);
                            if (Char.IsLetter(d))
                            {
                                estado = 1;
                                break;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.FOR);
                                break;
                            }
                        }
                        else if (auxlex.CompareTo("if") == 0)
                        {
                            d = entrada.ElementAt(i + 1);
                            if (Char.IsLetter(d))
                            {
                                estado = 1;
                                break;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.IF);
                                break;
                            }
                        }
                        else if (auxlex.CompareTo("int") == 0)
                        {
                            d = entrada.ElementAt(i + 1);
                            if (Char.IsLetter(d))
                            {
                                estado = 1;
                                break;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.INT);
                                break;
                            }
                        }
                        else if (auxlex.CompareTo("Main") == 0)
                        {
                            d = entrada.ElementAt(i + 1);
                            if (Char.IsLetter(d))
                            {
                                estado = 1;
                                break;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.MAIN);
                                break;
                            }
                        }
                        else if ((auxlex.CompareTo("string") == 0) || (auxlex.CompareTo("String") == 0))
                        {
                            d = entrada.ElementAt(i + 1);
                            if (Char.IsLetter(d))
                            {
                                estado = 1;
                                break;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.STRING);
                                break;
                            }
                        }
                        else if (auxlex.CompareTo("switch") == 0)
                        {
                            d = entrada.ElementAt(i + 1);
                            if (Char.IsLetter(d))
                            {
                                estado = 1;
                                break;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.SWITCH);
                                break;
                            }
                        }
                        else if (auxlex.CompareTo("void") == 0)
                        {
                            d = entrada.ElementAt(i + 1);
                            if (Char.IsLetter(d))
                            {
                                estado = 1;
                                break;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.VOID);
                                break;
                            }
                        }
                        else if (auxlex.CompareTo("while") == 0)
                        {
                            d = entrada.ElementAt(i + 1);
                            if (Char.IsLetter(d))
                            {
                                estado = 1;
                                break;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.WHILE);
                                break;
                            }
                        }
                        else if ((auxlex.CompareTo("Write") == 0) || (auxlex.CompareTo("WriteLine") == 0))
                        {
                            d = entrada.ElementAt(i + 1);
                            if (Char.IsLetter(d))
                            {
                                estado = 1;
                                break;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.WRITELINE);
                                break;
                            }
                        }
                        else if (auxlex.CompareTo("new") == 0)
                        {
                            d = entrada.ElementAt(i + 1);
                            if (Char.IsLetter(d))
                            {
                                estado = 1;
                                break;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.NEW);
                                break;
                            }
                        }
                        else if ((auxlex.CompareTo("double") == 0) || (auxlex.CompareTo("Double") == 0))
                        {
                            d = entrada.ElementAt(i + 1);
                            if (Char.IsLetter(d))
                            {
                                estado = 1;
                                break;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.DOUBLE);
                                break;
                            }
                        }
                        else if (auxlex.CompareTo("static") == 0)
                        {
                            d = entrada.ElementAt(i + 1);
                            if (Char.IsLetter(d))
                            {
                                estado = 1;
                                break;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.STATIC);
                                break;
                            }
                        }
                        else if (auxlex.CompareTo("true") == 0)
                        {
                            d = entrada.ElementAt(i + 1);
                            if (Char.IsLetter(d))
                            {
                                estado = 1;
                                break;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.TRUE);
                                break;
                            }
                        }
                        else if (auxlex.CompareTo("false") == 0)
                        {
                            d = entrada.ElementAt(i + 1);
                            if (Char.IsLetter(d))
                            {
                                estado = 1;
                                break;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.FALSE);
                                break;
                            }
                        }
                        else if (c.Equals(' ') || c.Equals('\t') || c.Equals('\n'))
                        {
                            i--;
                            columna--;
                            auxlex = auxlex.TrimEnd(c);
                            agregarToken(Token.Tipo.ID);
                            break;
                        }
                        estado = 1;
                        break;
                    //numero
                    case 2:
                        if (Char.IsDigit(c) == true)
                        {
                            auxlex += c;
                            columna++;
                            estado = 2;
                        }
                        else
                        {
                            if (c.CompareTo('.') == 0)
                            {
                                auxlex += c;
                                columna++;
                                estado = 7;
                                break;
                            }
                            else if (c.Equals(' ') || c.Equals('\t') || c.Equals('\n'))
                            {
                                i--;
                                agregarToken(Token.Tipo.NUMERO);
                            }
                            else
                            {
                                if (Char.IsLetter(c))
                                {
                                    auxlex += c;
                                    estado = 8;
                                    columna++;
                                }
                                else
                                {
                                    i--;
                                    agregarToken(Token.Tipo.NUMERO)
                                }
                                break;
                            }
                        }
                        break;
                    //cadenas/caracter
                    case 3:
                        if (c == '"')
                        {

                            auxlex = auxlex.TrimEnd(c);
                            agregarToken(Token.Tipo.CADENA);
                            auxlex += c;
                            columna++;
                            agregarToken(Token.Tipo.COMILLA_DOBLE);
                        }
                        else if (c == '\'')
                        {

                            auxlex = auxlex.TrimEnd(c);
                            agregarToken(Token.Tipo.CARACTER);
                            auxlex += c;
                            columna++;
                            agregarToken(Token.Tipo.COMILLA_SIMPLE);
                        }
                        else
                        {
                            estado = 3;
                            columna++;
                            auxlex += c;
                        }
                        break;
                    //Simbolos
                    case 4:
                        if (c.Equals(' ') || c.Equals('\t'))
                        {
                            columna++;
                            estado = 0;
                        }
                        else if (c.Equals('\n'))
                        {
                            columna = 0;
                            fila++;
                            estado = 0;
                        }
                        else if (c.Equals('{'))
                        {
                            auxlex += c;
                            columna++;
                            agregarToken(Token.Tipo.LLAVE_ABRE);
                        }
                        else if (c.Equals('\r'))
                        {
                            columna--;
                            estado = 0;
                        }
                        else if (c.Equals('}'))
                        {
                            auxlex += c;
                            columna++;
                            agregarToken(Token.Tipo.LLAVE_CIERRA);
                        }
                        else if (c.Equals('['))
                        {
                            auxlex += c;
                            columna++;
                            agregarToken(Token.Tipo.CORCHETE_ABRE);
                        }
                        else if (c.Equals(']'))
                        {
                            auxlex += c;
                            columna++;
                            agregarToken(Token.Tipo.CORCHETE_CIERRA);
                        }
                        else if (c.Equals(':'))
                        {
                            auxlex += c;
                            columna++;
                            agregarToken(Token.Tipo.DOS_PUNTOS);
                        }
                        else if (c.Equals(';'))
                        {
                            auxlex += c;
                            columna++;
                            agregarToken(Token.Tipo.PUNTO_COMA);
                        }
                        else if (c.Equals('('))
                        {
                            auxlex += c;
                            columna++;
                            agregarToken(Token.Tipo.PARENTESIS_ABRE);
                        }
                        else if (c.Equals(')'))
                        {
                            auxlex += c;
                            columna++;
                            agregarToken(Token.Tipo.PARENTESIS_CIERRA);
                        }
                        else if (c.Equals('*'))
                        {
                            auxlex += c;
                            columna++;
                            agregarToken(Token.Tipo.ASTERISCO);
                        }
                        else if (c.Equals('='))
                        {
                            columna++;
                            auxlex += c;
                            d = entrada.ElementAt(i + 1);
                            if (d.Equals('='))
                            {
                                auxlex += d;
                                columna++;
                                i++;
                                agregarToken(Token.Tipo.IGUAL);
                            }
                            else
                            {
                                agregarToken(Token.Tipo.IGUAL_IGUAL);
                            }
                        }
                        else if (c.Equals('/'))
                        {
                            columna++;
                            d = entrada.ElementAt(i + 1);
                            if (d.Equals('/'))
                            {
                                i++;
                                estado = 5;
                                break;
                            }
                            else if (d.Equals('*'))
                            {
                                i++;
                                estado = 6;
                                break;
                            }
                            else
                            {
                                auxlex += c;
                                agregarToken(Token.Tipo.DIAGONAL);
                            }
                        }
                        else if (c.Equals('>'))
                        {
                            columna++;
                            auxlex += c;
                            d = entrada.ElementAt(i + 1);
                            if (d.Equals('='))
                            {
                                auxlex += d;
                                columna++;
                                i++;
                                agregarToken(Token.Tipo.MAYOR_IGUAL);
                            }
                            else
                            {
                                agregarToken(Token.Tipo.MAYOR_QUE);
                            }
                        }
                        else if (c.Equals('<'))
                        {
                            columna++;
                            auxlex += c;
                            d = entrada.ElementAt(i + 1);
                            if (d.Equals('='))
                            {
                                auxlex += d;
                                columna++;
                                i++;
                                agregarToken(Token.Tipo.MENOR_IGUAL);
                            }
                            else
                            {
                                agregarToken(Token.Tipo.MENOR_QUE);
                            }
                        }
                        else if (c.Equals('!'))
                        {
                            auxlex += c;
                            columna++;
                            agregarToken(Token.Tipo.SIGNO_ADMIRACION);
                        }
                        else if (c.Equals('+'))
                        {
                            auxlex += c;
                            columna++;
                            agregarToken(Token.Tipo.SUMA);
                        }
                        else if (c.Equals('-'))
                        {
                            auxlex += c;
                            columna++;
                            agregarToken(Token.Tipo.RESTA);
                        }
                        else if (c.Equals('.'))
                        {
                            auxlex += c;
                            columna++;
                            agregarToken(Token.Tipo.PUNTO);
                        }
                        else if (c.Equals(','))
                        {
                            auxlex += c;
                            columna++;
                            agregarToken(Token.Tipo.COMA);
                        }
                        else
                        {
                            auxlex += c;
                            columna++;
                            agregarError(auxlex, columna, fila);
                        }
                        break;
                    //Comentarios
                    case 5:
                        if (c.Equals('\n'))
                        {
                            fila++;
                            agregarToken(Token.Tipo.COMENTARIO);
                        }
                        else
                        {
                            auxlex += c;
                            columna++;
                        }
                        break;
                    //comentario multilinea
                    case 6:
                        if (c.Equals('*'))
                        {
                            columna++;
                            d = entrada.ElementAt(i + 1);
                            if (d.Equals('/'))
                            {
                                columna++;
                                i++;
                                agregarToken(Token.Tipo.COMENTARIO_MULTILINEA);
                            }
                            else
                            {
                                Console.WriteLine("Se esperaba un '*/'");
                                auxlex = "";
                                estado = 0;
                            }
                        }
                        else
                        {
                            auxlex += c;
                            columna++;
                        }
                        break;
                    //numeros decimales
                    case 7:
                        if (Char.IsDigit(c) == true)
                        {
                            auxlex += c;
                            columna++;
                            estado = 7;
                        }
                        else
                        {
                            if (c.Equals(' ') || c.Equals('\t') || c.Equals('\n'))
                            {
                                i--;
                                agregarToken(Token.Tipo.DECIMAL);
                            }
                            else
                            {
                                if (Char.IsLetter(c))
                                {
                                    estado = 8;
                                    columna++;
                                    auxlex += c;
                                }
                                else
                                {

                                }
                            }
                        }
                        break;
                    //id
                    case 8:
                        if (c.Equals(' ') || c.Equals('\t') || c.Equals('\n'))
                        {
                            i--;
                            agregarToken(Token.Tipo.ID);
                        }
                        break;
                }
            }

            return Salida;
        }

        public void agregarToken(Token.Tipo tipo)
        {
            Salida.AddLast(new Token(tipo, auxlex, fila, columna));
            auxlex = "";
            estado = 0;
        }

        public void agregarError(String errorLexico, int columna, int fila)
        {
            listaErrores.AddLast(new Error(errorLexico, "Desconocido", fila, columna));
            auxlex = "";
            estado = 0;
        }

        public void generarHTML_Tokens(LinkedList<Token> lista_tokens)
        {
            try
            {
                MessageBox.Show("HTML con tokens Reconocidos ha sido creado", "HTML creado");
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.Filter = "(*.html)|*.html";
                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    using (Stream s = File.Open(guardar.FileName, FileMode.Create))
                    using (StreamWriter sw = new StreamWriter(s))
                    {
                        sw.WriteLine("<!DOCTYPE html>");
                        sw.WriteLine("<html>");
                        sw.WriteLine("<head>");
                        sw.WriteLine("<title>Tokens Guardados</title>");
                        sw.WriteLine("<meta charset=" + '"' + "utf-8" + '"' + "/>");
                        sw.WriteLine("</head>");
                        sw.WriteLine("<body>");
                        sw.WriteLine("<h1><center>Listado de Tokens</center></h1>");
                        sw.WriteLine("<p>\n" + "<br>\n" + "</p>");
                        sw.WriteLine("<center>\n" + "<table border= 4>");
                        sw.WriteLine("<tr>");
                        sw.WriteLine("<td><center><b>#</b></center></td>");
                        sw.WriteLine("<td><center><b>Lexema</b></center></td>");
                        sw.WriteLine("<td><center><b>id Token</b></center></td>");
                        sw.WriteLine("<td><center><b>Token</b></center></td>");
                        sw.WriteLine("<td><center><b>Fila</b></center></td>");
                        sw.WriteLine("<td><center><b>Columna</b></center></td>");
                        sw.WriteLine("</tr>");
                        int i = 1;
                        foreach (Token item in lista_tokens)
                        {
                            sw.WriteLine("<tr>");
                            sw.WriteLine("<td><center>" + i + "</center></td>");
                            sw.WriteLine("<td><center>" + item.getValor() + "</center></td>");
                            sw.WriteLine("<td><center>" + item.getId() + "</center></td>");
                            sw.WriteLine("<td><center>" + item.getTipoToken() + "</center></td>");
                            sw.WriteLine("<td><center>" + item.getFila() + "</center></td>");
                            sw.WriteLine("<td><center>" + item.getColumna() + "</center></td>");
                            sw.WriteLine("</tr>");
                            i++;
                        }
                        sw.WriteLine("</center>\n" + "</table>");
                        sw.WriteLine("</body>");
                        sw.Write("</html>");
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                if (ex.Source != null)
                    Console.WriteLine("IOException source: {0}", ex.Source);
                throw;
            }
            catch (IOException ex)
            {
                if (ex.Source != null)
                    Console.WriteLine("IOException source: {0}", ex.Source);
                throw;
            }
        }

        public void generar_HTML_Errores()
        {
            try
            {
                MessageBox.Show("HTML errores ha sido creado", "HTML creado");
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.Filter = "(*.html)|*.html";
                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    using (Stream s = File.Open(guardar.FileName, FileMode.Create))
                    using (StreamWriter sw = new StreamWriter(s))
                    {
                        sw.WriteLine("<!DOCTYPE html>");
                        sw.WriteLine("<html>");
                        sw.WriteLine("<head>");
                        sw.WriteLine("<title>Errores Reconocidos</title>");
                        sw.WriteLine("<meta charset=" + '"' + "utf-8" + '"' + "/>");
                        sw.WriteLine("</head>");
                        sw.WriteLine("<body>");
                        sw.WriteLine("<h1><center>Listado de Errores</center></h1>");
                        sw.WriteLine("<p>\n" + "<br>\n" + "</p>");
                        sw.WriteLine("<center>\n" + "<table border= 4>");
                        sw.WriteLine("<tr>");
                        sw.WriteLine("<td><center><b>#</b></center></td>");
                        sw.WriteLine("<td><center><b>Fila</b></center></td>");
                        sw.WriteLine("<td><center><b>Columna</b></center></td>");
                        sw.WriteLine("<td><center><b>Caracter</b></center></td>");
                        sw.WriteLine("<td><center><b>Descripcion</b></center></td>");
                        sw.WriteLine("</tr>");
                        int i = 1;
                        foreach (Error item in listaErrores)
                        {
                            sw.WriteLine("<tr>");
                            sw.WriteLine("<td><center>" + i + "</center></td>");
                            sw.WriteLine("<td><center>" + item.getFila() + "</center></td>");
                            sw.WriteLine("<td><center>" + item.getColumna() + "</center></td>");
                            sw.WriteLine("<td><center>" + item.getError() + "</center></td>");
                            sw.WriteLine("<td><center>" + item.getDescripcion() + "</center></td>");
                            sw.WriteLine("</tr>");
                            i++;
                        }
                        sw.WriteLine("</center>\n" + "</table>");
                        sw.WriteLine("</body>");
                        sw.Write("</html>");
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                if (ex.Source != null)
                    Console.WriteLine("IOException source: {0}", ex.Source);
                throw;
            }
            catch (IOException ex)
            {
                if (ex.Source != null)
                    Console.WriteLine("IOException source: {0}", ex.Source);
                throw;
            }
        }

    }
}