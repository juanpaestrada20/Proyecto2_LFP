using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_2
{
    class Analizador_Sintactico
    {
        public static string rutaTabla = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\TablaSimbolos.html";
        public static LinkedList<Simbolo> listaSimbolos = new LinkedList<Simbolo>();

        int controlToken;
        Token tokenActual;
        LinkedList<Token> listaTokens;

        LinkedList<Error> error = new LinkedList<Error>();

        Dictionary<string, Simbolo> variables = new Dictionary<string, Simbolo>();

        Simbolo nuevaVariable;

        bool errorEncontrado = false;

        string tipo_dato = "";
        string variableID = "";
        object valor = "";


        string tabulacion = "";
        String varAuxiliar = "";

        String traduccion = "";
        String impresion = "";

        public void parsear(LinkedList<Token> tokens)
        {
            this.listaTokens = tokens;
            controlToken = 0;
            tokenActual = listaTokens.ElementAt(controlToken);

            Inicio();
        }

        public void Inicio()
        {
            match(Token.Tipo.CLASS);
            match(Token.Tipo.ID);
            match(Token.Tipo.LLAVE_ABRE);
            match(Token.Tipo.STATIC);
            match(Token.Tipo.VOID);
            match(Token.Tipo.MAIN);
            match(Token.Tipo.PARENTESIS_ABRE);
            match(Token.Tipo.STRING);
            match(Token.Tipo.CORCHETE_ABRE);
            match(Token.Tipo.CORCHETE_CIERRA);
            match(Token.Tipo.ARGS);
            match(Token.Tipo.PARENTESIS_CIERRA);
            match(Token.Tipo.LLAVE_ABRE);
            Cuerpo();
            match(Token.Tipo.LLAVE_CIERRA);
            match(Token.Tipo.LLAVE_CIERRA);
        }

        public String generarTraduccion()
        {
            return this.traduccion;
        }

        public String generarImpresion()
        {
            return this.impresion;
        }
        public void Cuerpo()
        {
            //if (!tabulacion.Equals(""))
            //{
            //    traduccion += tabulacion;
            //}
            if ((tokenActual.getTipo() == Token.Tipo.INT) || (tokenActual.getTipo() == Token.Tipo.DOUBLE) ||
                (tokenActual.getTipo() == Token.Tipo.STRING) || (tokenActual.getTipo() == Token.Tipo.CHAR) ||
                (tokenActual.getTipo() == Token.Tipo.BOOL))
            {
                tipo_dato = tokenActual.getTipoToken();
                match(tokenActual.getT  ipo());
                if (variables.ContainsKey(tokenActual.getValor()))
                {
                    Console.WriteLine("Variable ya declarada!", "Error de Declaracion");
                    error.AddLast(new Error(tokenActual.getValor(), "Variable ya declarada", tokenActual.getFila(), tokenActual.getColumna()));
                }
                else
                {
                    Declaracion();
                    match(Token.Tipo.PUNTO_COMA);
                    variableID = "";
                    valor = "";
                    tipo_dato = "";
                    varAuxiliar = "";
                    Cuerpo();
                }
            }
            else if (tokenActual.getTipo() == Token.Tipo.ID)
            {
                match(Token.Tipo.ID);
                if (tokenActual.getTipo() == Token.Tipo.IGUAL)
                {
                    match(Token.Tipo.IGUAL);
                    switch (tokenActual.getTipo())
                    {
                        case Token.Tipo.NUMERO:
                            valor = tokenActual.getValor();
                            match(Token.Tipo.NUMERO);
                            break;
                        case Token.Tipo.DECIMAL:
                            valor = tokenActual.getValor();
                            match(Token.Tipo.DECIMAL);
                            break;
                        case Token.Tipo.COMILLA_DOBLE:
                            match(Token.Tipo.COMILLA_DOBLE);
                            valor = tokenActual.getValor();
                            match(Token.Tipo.CADENA);
                            match(Token.Tipo.COMILLA_DOBLE);
                            break;
                        case Token.Tipo.COMILLA_SIMPLE:
                            match(Token.Tipo.COMILLA_SIMPLE);
                            valor = tokenActual.getValor();
                            match(Token.Tipo.CARACTER);
                            match(Token.Tipo.COMILLA_SIMPLE);
                            break;
                        case Token.Tipo.TRUE:
                            valor = tokenActual.getValor();
                            match(Token.Tipo.TRUE);
                            break;
                        case Token.Tipo.FALSE:
                            valor = tokenActual.getValor();
                            match(Token.Tipo.FALSE);
                            break;
                        default:
                            Console.WriteLine("Error! Se esperaba algun valor");
                            error.AddLast(new Error("null", "No se asigno ningun valor", tokenActual.getFila(), tokenActual.getColumna()));
                            break;
                    }
                }
                else
                {
                    match(Token.Tipo.PARENTESIS_ABRE);
                    Simbolo grafica = null;
                    foreach (Simbolo item in variables.Values)
                    {
                        if (item.getID() == tokenActual.getValor())
                        {
                            grafica = item;
                        }
                    }
                    match(Token.Tipo.ID);
                    match(Token.Tipo.COMA);
                    match(Token.Tipo.COMILLA_DOBLE);
                    String nombre = tokenActual.getValor();
                    match(Token.Tipo.CADENA);
                    match(Token.Tipo.COMILLA_DOBLE);
                    match(Token.Tipo.PARENTESIS_CIERRA);
                    try
                    {
                        Graficador graf = new Graficador();
                        graf.graficar(grafica.getValor().ToString(), nombre);
                        String ruta = graf.abrirGrafo();
                    }
                    catch (NullReferenceException e)
                    {
                        Console.WriteLine(e);
                    }
                }
                match(Token.Tipo.PUNTO_COMA);
                Cuerpo();
            }
            else if ((tokenActual.getTipo() == Token.Tipo.COMENTARIO) || (tokenActual.getTipo() == Token.Tipo.COMENTARIO_MULTILINEA))
            {
                Comentario();
                Cuerpo();
            }
            else if (tokenActual.getTipo() == Token.Tipo.CONSOLE)
            {
                match(Token.Tipo.CONSOLE);
                match(Token.Tipo.PUNTO);
                match(Token.Tipo.WRITELINE);
                match(Token.Tipo.PARENTESIS_ABRE);
                traduccion += "print(";
                Impresion();//pendiente
                impresion += "\n";
                match(Token.Tipo.PARENTESIS_CIERRA);
                match(Token.Tipo.PUNTO_COMA);
                traduccion += ")\n";
                Cuerpo();
            }
            else if (tokenActual.getTipo() == Token.Tipo.IF)
            {
                match(Token.Tipo.IF);
                CicloIf();
                Cuerpo();
            }
            else if (tokenActual.getTipo() == Token.Tipo.FOR)
            {
                match(Token.Tipo.FOR);
                CicloFor();
                Cuerpo();
            }
            else if (tokenActual.getTipo() == Token.Tipo.WHILE)
            {
                match(Token.Tipo.WHILE);
                CicloWhile();
                Cuerpo();
            }
            else if (tokenActual.getTipo() == Token.Tipo.SWITCH)
            {
                match(Token.Tipo.SWITCH);
                CuerpoSwitch();
                Cuerpo();
            }
            else
            {
                //epsilon
            }
        }

        public void CuerpoSwitch()
        {
            traduccion += "if ";
            match(Token.Tipo.PARENTESIS_ABRE);
            traduccion += " " + tokenActual.getValor();
            match(Token.Tipo.ID);
            match(Token.Tipo.PARENTESIS_CIERRA);
            match(Token.Tipo.LLAVE_ABRE);
            Case();
            match(Token.Tipo.LLAVE_CIERRA);
        }

        public void Case()
        {
            String id;
            match(Token.Tipo.CASE);
            traduccion += " = " + tokenActual.getValor();
            id = tokenActual.getValor();
            match(Token.Tipo.NUMERO);
            match(Token.Tipo.DOS_PUNTOS);
            traduccion += " :\n";
            Cuerpo();
            match(Token.Tipo.BREAK);
            match(Token.Tipo.PUNTO_COMA);
            CasePrima(id);
            match(Token.Tipo.DEFAULT);
            match(Token.Tipo.DOS_PUNTOS);
            Cuerpo();
            match(Token.Tipo.BREAK);
            match(Token.Tipo.PUNTO_COMA);
        }

        public void CasePrima(String id)
        {
            if (Token.Tipo.CASE == tokenActual.getTipo())
            {
                traduccion += " elif "+id+" = ";
                match(Token.Tipo.CASE);
                traduccion+= tokenActual.getValor();
                match(Token.Tipo.NUMERO);
                match(Token.Tipo.DOS_PUNTOS);
                traduccion += " :\n";
                Cuerpo();
                match(Token.Tipo.BREAK);
                match(Token.Tipo.PUNTO_COMA);
                CasePrima(id);
            }
            else 
            {

            }
        }
        public void Declaracion()
        {
            if (tokenActual.getTipo() == Token.Tipo.ID)
            {

                if (variables.ContainsKey(tokenActual.getValor()))
                {
                    Console.WriteLine("Variable ya declarada!", "Error de Declaracion"); error.AddLast(new Error(tokenActual.getValor(), "Variable ya declarada", tokenActual.getFila(), tokenActual.getColumna()));
                }
                else
                {
                    variableID = tokenActual.getValor();
                    varAuxiliar += variableID + " ";
                    match(Token.Tipo.ID);
                    DeclaracionPrima();
                }
            }
            else if (tokenActual.getTipo() == Token.Tipo.CORCHETE_ABRE)
            {
                match(Token.Tipo.CORCHETE_ABRE);
                match(Token.Tipo.CORCHETE_CIERRA);
                if (variables.ContainsKey(tokenActual.getValor()))
                {
                    Console.WriteLine("Variable ya declarada!", "Error de Declaracion");
                }
                else
                {
                    variableID = tokenActual.getValor();
                    varAuxiliar += variableID + " = array ([";
                    match(Token.Tipo.ID);
                    match(Token.Tipo.IGUAL);
                    Arreglo();
                }
            }
        }

        public void DeclaracionPrima()
        {
            if (tokenActual.getTipo() == Token.Tipo.COMA)
            {
                if (valor.Equals("") && !variables.ContainsKey(variableID))
                {
                    variables.Add(variableID, new Simbolo(tipo_dato, 0, variableID));
                    variableID = "";
                    varAuxiliar = "";
                }
                match(Token.Tipo.COMA);
                variableID = tokenActual.getValor();
                varAuxiliar += variableID;
                match(Token.Tipo.ID);
                DeclaracionPrima();
            }
            else if (tokenActual.getTipo() == Token.Tipo.IGUAL)
            {
                varAuxiliar += " = ";
                match(Token.Tipo.IGUAL);
                Asignacion();
            }
            else
            {
                //epsilon
            }
        }



        public void Asignacion()
        {
            switch (tokenActual.getTipo())
            {
                case Token.Tipo.NUMERO:
                    valor = tokenActual.getValor();
                    match(Token.Tipo.NUMERO);
                    break;
                case Token.Tipo.DECIMAL:
                    valor = tokenActual.getValor();
                    match(Token.Tipo.DECIMAL);
                    break;
                case Token.Tipo.COMILLA_DOBLE:
                    match(Token.Tipo.COMILLA_DOBLE);
                    valor = tokenActual.getValor();
                    match(Token.Tipo.CADENA);
                    match(Token.Tipo.COMILLA_DOBLE);
                    break;
                case Token.Tipo.COMILLA_SIMPLE:
                    match(Token.Tipo.COMILLA_SIMPLE);
                    valor = tokenActual.getValor();
                    match(Token.Tipo.CARACTER);
                    match(Token.Tipo.COMILLA_SIMPLE);
                    break;
                case Token.Tipo.TRUE:
                    valor = tokenActual.getValor();
                    match(Token.Tipo.TRUE);
                    break;
                case Token.Tipo.FALSE:
                    valor = tokenActual.getValor();
                    match(Token.Tipo.FALSE);
                    break;
                default:
                    Console.WriteLine("Error! Se esperaba algun valor");
                    break;
            }
            varAuxiliar += valor;
            variables.Add(variableID, new Simbolo(tipo_dato, valor, variableID));
            traduccion += varAuxiliar + "\n";
            tabulacion += "\t";
            varAuxiliar = "";
            valor = "";
            variableID = "";
            OtraDeclaracion();
        }

        public void OtraDeclaracion()
        {
            if (tokenActual.getTipo() == Token.Tipo.COMA)
            {
                if (valor.Equals("") && !variables.ContainsKey(variableID))
                {
                    variables.Add(variableID, new Simbolo(tipo_dato, 0, variableID));
                    variableID = "";
                    varAuxiliar = "";
                }
                match(Token.Tipo.COMA);
                variableID = tokenActual.getValor();
                varAuxiliar += variableID + " ";
                match(Token.Tipo.ID);
                DeclaracionPrima();
            }
            else
            {
                //epsilon
            }
        }

        public void Arreglo()
        {
            if (tokenActual.getTipo() == Token.Tipo.LLAVE_ABRE)
            {
                match(Token.Tipo.LLAVE_ABRE);
                switch (tokenActual.getTipo())
                {
                    case Token.Tipo.NUMERO:
                        valor = tokenActual.getValor();
                        match(Token.Tipo.NUMERO);
                        break;
                    case Token.Tipo.DECIMAL:
                        valor = tokenActual.getValor();
                        match(Token.Tipo.DECIMAL);
                        break;
                    case Token.Tipo.COMILLA_DOBLE:
                        match(Token.Tipo.COMILLA_DOBLE);
                        valor = tokenActual.getValor();
                        match(Token.Tipo.CADENA);
                        match(Token.Tipo.COMILLA_DOBLE);
                        break;
                    case Token.Tipo.COMILLA_SIMPLE:
                        match(Token.Tipo.COMILLA_SIMPLE);
                        valor = tokenActual.getValor();
                        match(Token.Tipo.CARACTER);
                        match(Token.Tipo.COMILLA_SIMPLE);
                        break;
                    case Token.Tipo.TRUE:
                        valor = tokenActual.getValor();
                        match(Token.Tipo.TRUE);
                        break;
                    case Token.Tipo.FALSE:
                        valor = tokenActual.getValor();
                        match(Token.Tipo.FALSE);
                        break;
                    default:
                        Console.WriteLine("Error! Se esperaba algun valor");
                        break;
                }
                OtroValor();
                traduccion += varAuxiliar + ")] \n";
                variables.Add(variableID, new Simbolo(tipo_dato, valor, variableID));
                valor = "";
                variableID = "";
                varAuxiliar = "";
                match(Token.Tipo.LLAVE_CIERRA);
            }
            else
            {
                match(Token.Tipo.NEW);
                if (tokenActual.getTipoToken() == tipo_dato)
                {
                    match(tokenActual.getTipo());
                    match(Token.Tipo.CORCHETE_ABRE);
                    match(Token.Tipo.CORCHETE_CIERRA);
                }
                else
                {
                    Console.WriteLine("Se esperaba " + tipo_dato + ", no " + tokenActual.getTipoToken());
                }
            }
        }

        public void OtroValor()
        {
            if (tokenActual.getTipo() == Token.Tipo.COMA)
            {
                match(Token.Tipo.COMA);
                switch (tokenActual.getTipo())
                {
                    case Token.Tipo.NUMERO:
                        valor += "," + tokenActual.getValor();
                        match(Token.Tipo.NUMERO);
                        break;
                    case Token.Tipo.DECIMAL:
                        valor += "," + tokenActual.getValor();
                        match(Token.Tipo.DECIMAL);
                        break;
                    case Token.Tipo.COMILLA_DOBLE:
                        match(Token.Tipo.COMILLA_DOBLE);
                        valor += ", \"" + tokenActual.getValor() + "\"";
                        match(Token.Tipo.CADENA);
                        match(Token.Tipo.COMILLA_DOBLE);
                        break;
                    case Token.Tipo.COMILLA_SIMPLE:
                        match(Token.Tipo.COMILLA_SIMPLE);
                        valor += ", \'" + tokenActual.getValor() + "\'";
                        match(Token.Tipo.CARACTER);
                        match(Token.Tipo.COMILLA_SIMPLE);
                        break;
                    case Token.Tipo.TRUE:
                        valor += "," + tokenActual.getValor();
                        match(Token.Tipo.TRUE);
                        break;
                    case Token.Tipo.FALSE:
                        valor += "," + tokenActual.getValor();
                        match(Token.Tipo.FALSE);
                        break;
                    default:
                        Console.WriteLine("Error! Se esperaba algun valor");
                        break;
                }
                OtroValor();
            }
            else
            {
                varAuxiliar += valor;
                //epsilon
            }
        }

        public void Comentario()
        {
            if (tokenActual.getTipo() == Token.Tipo.COMENTARIO)
            {
                traduccion += "#" + tokenActual.getValor();
                match(Token.Tipo.COMENTARIO);
            }
            else if (tokenActual.getTipo() == Token.Tipo.COMENTARIO_MULTILINEA)
            {
                traduccion += "\"\"\"";
                traduccion += tokenActual.getValor();
                match(Token.Tipo.COMENTARIO_MULTILINEA);
                traduccion += "\"\"\"\n";
            }
            else
            {
                //epsilon
            }
        }

        public void Impresion()
        {
            if (tokenActual.getTipo() == Token.Tipo.COMILLA_DOBLE)
            {
                match(Token.Tipo.COMILLA_DOBLE);
                traduccion += "\"" + tokenActual.getValor() + "\" ";
                impresion += tokenActual.getValor();
                match(Token.Tipo.CADENA);
                match(Token.Tipo.COMILLA_DOBLE);
                ImpresionPrima();
            }
            else if (tokenActual.getTipo() == Token.Tipo.COMILLA_SIMPLE)
            {
                match(Token.Tipo.COMILLA_SIMPLE);
                traduccion += "\"" + tokenActual.getValor() + "\" ";
                impresion += tokenActual.getValor();
                match(Token.Tipo.CARACTER);
                match(Token.Tipo.COMILLA_SIMPLE);
                ImpresionPrima();
            }
            else if (tokenActual.getTipo() == Token.Tipo.NUMERO)
            {
                traduccion += tokenActual.getValor();
                impresion += tokenActual.getValor();
                match(Token.Tipo.NUMERO);
                ImpresionPrima();
            }
            else if (tokenActual.getTipo() == Token.Tipo.DECIMAL)
            {
                traduccion += tokenActual.getValor();
                impresion += tokenActual.getValor();
                match(Token.Tipo.DECIMAL);
                ImpresionPrima();

            }
            else if (tokenActual.getTipo() == Token.Tipo.ID)
            {
                traduccion += tokenActual.getValor();
                impresion += tokenActual.getValor();
                match(Token.Tipo.ID);
                ImpresionPrima();
            }
            else
            {

            }
        }

        public void ImpresionPrima()
        {
            if (tokenActual.getTipo() == Token.Tipo.SUMA)
            {
                match(Token.Tipo.SUMA);
                impresion += " ";
                traduccion += " + ";
                Impresion();
            }
            else
            {

            }
        }

        public void CicloIf()
        {
            match(Token.Tipo.PARENTESIS_ABRE);
            traduccion += "if ";
            Condicion();
            match(Token.Tipo.PARENTESIS_CIERRA);
            match(Token.Tipo.LLAVE_ABRE);
            traduccion += ":\n";
            tabulacion += "\t";
            Cuerpo();
            match(Token.Tipo.LLAVE_CIERRA);
            traduccion += "\n";

            tabulacion = tabulacion.Substring(0, tabulacion.Length - 1);
            CuerpoElse();
        }

        public void Condicion()
        {
            Dato();
            Operador();
            Dato();
            CondicionPrima();
        }

        public void CuerpoElse()
        {
            if (tokenActual.getTipo() == Token.Tipo.ELSE)
            {
                traduccion += "else ";
                tabulacion += "\t";
                match(Token.Tipo.ELSE);
                match(Token.Tipo.LLAVE_ABRE);
                Cuerpo();
                match(Token.Tipo.LLAVE_CIERRA);
                tabulacion = tabulacion.Substring(0, tabulacion.Length - 1);
            }
            else
            {
                //epsilon
            }
        }

        public void Dato()
        {
            if (forciclo == false)
            {
                traduccion += tokenActual.getValor();
            }
            if (tokenActual.getTipo() == Token.Tipo.ID)
            {
                match(Token.Tipo.ID);
            }
            else if (tokenActual.getTipo() == Token.Tipo.NUMERO)
            {
                match(Token.Tipo.NUMERO);
            }
            else if (tokenActual.getTipo() == Token.Tipo.DECIMAL)
            {
                match(Token.Tipo.DECIMAL);
            }
            else if (tokenActual.getTipo() == Token.Tipo.TRUE)
            {
                match(Token.Tipo.TRUE);
            }
            else if (tokenActual.getTipo() == Token.Tipo.FALSE)
            {
                match(Token.Tipo.FALSE);
            }
            traduccion += " ";
        }

        public void Operador()
        {
            if (forciclo == false)
            {
                traduccion += tokenActual.getValor();
            }
            else
            {
                fin = tokenActual.getValor();
            }
            if (tokenActual.getTipo() == Token.Tipo.MAYOR_QUE)
            {
                match(Token.Tipo.MAYOR_QUE);
            }
            else if (tokenActual.getTipo() == Token.Tipo.MAYOR_IGUAL)
            {
                match(Token.Tipo.MAYOR_IGUAL);
            }
            else if (tokenActual.getTipo() == Token.Tipo.MENOR_QUE)
            {
                match(Token.Tipo.MENOR_QUE);
            }
            else if (tokenActual.getTipo() == Token.Tipo.MENOR_IGUAL)
            {
                match(Token.Tipo.MENOR_IGUAL);
            }
            else if (tokenActual.getTipo() == Token.Tipo.IGUAL_IGUAL)
            {
                match(Token.Tipo.IGUAL_IGUAL);
            }
            else if (tokenActual.getTipo() == Token.Tipo.SIGNO_ADMIRACION)
            {
                match(Token.Tipo.SIGNO_ADMIRACION);
                traduccion += tokenActual.getValor();
                match(Token.Tipo.IGUAL);
            }

        }

        public void CondicionPrima()
        {

            if (tokenActual.getTipo() == Token.Tipo.OPERADOR_Y)
            {
                traduccion += tokenActual.getValor();
                match(Token.Tipo.OPERADOR_Y);
            }
            else if (tokenActual.getTipo() == Token.Tipo.OPERADOR_O)
            {
                traduccion += tokenActual.getValor();
                match(Token.Tipo.OPERADOR_O);
            }
            else
            {
                //epsilon
            }
        }
        string fin = "";
        bool forciclo = false;
        public void CicloFor()
        {
            traduccion += "for ";
            match(Token.Tipo.PARENTESIS_ABRE);
            match(Token.Tipo.INT);
            traduccion += tokenActual.getValor() + " in range (";
            match(Token.Tipo.ID);
            match(Token.Tipo.IGUAL);
            string inicio = tokenActual.getValor();
            traduccion += inicio + ", ";
            match(Token.Tipo.NUMERO);
            match(Token.Tipo.PUNTO_COMA);
            Condicion();
            traduccion += fin + ")";
            match(Token.Tipo.PUNTO_COMA);
            match(Token.Tipo.ID);

            Incremento();
            match(Token.Tipo.PARENTESIS_CIERRA);
            match(Token.Tipo.LLAVE_ABRE);
            traduccion += "\n";
            tabulacion += "\t";
            Cuerpo();
            match(Token.Tipo.LLAVE_CIERRA);
        }

        public void Incremento()
        {
            if (tokenActual.getTipo() == Token.Tipo.SUMA)
            {
                match(Token.Tipo.SUMA);
                match(Token.Tipo.SUMA);
            }
            else
            {
                match(Token.Tipo.RESTA);
                match(Token.Tipo.RESTA);
            }
        }

        public void CicloWhile()
        {
            traduccion += "while ";
            match(Token.Tipo.PARENTESIS_ABRE);
            Condicion();
            match(Token.Tipo.PARENTESIS_CIERRA);
            match(Token.Tipo.LLAVE_ABRE);
            traduccion += ":\n";
            tabulacion += "\t";
            Cuerpo();
            match(Token.Tipo.LLAVE_CIERRA);
        }

        public void match(Token.Tipo tipoToken)
        {
            if (tokenActual.getTipo() != tipoToken)
            {
                Console.WriteLine("Error! se esperaba " + getTipoError(tipoToken));
                Console.WriteLine(tokenActual.getValor() + " " + tokenActual.getFila());
                error.AddLast(new Error(tokenActual.getValor(), "se esperaba " + getTipoError(tipoToken), tokenActual.getFila(), tokenActual.getColumna()));
                while (tokenActual.getTipo() != Token.Tipo.PUNTO_COMA && tokenActual.getTipo() != Token.Tipo.ULTIMO)
                {
                    controlToken += 1;
                    tokenActual = listaTokens.ElementAt(controlToken);
                    if (tokenActual.getTipo() != Token.Tipo.ULTIMO)
                    {
                        break;
                    }
                }
                errorEncontrado = true;
            }
            if (tokenActual.getTipo() != Token.Tipo.ULTIMO)
            {
                controlToken += 1;
                tokenActual = listaTokens.ElementAt(controlToken);
            }
        }

        public String getTipoError(Token.Tipo tipo)
        {
            switch (tipo)
            {
                case Token.Tipo.ARGS:
                    return "Args";
                case Token.Tipo.ASTERISCO:
                    return "Asterisco";
                case Token.Tipo.BOOL:
                    return "Boolean";
                case Token.Tipo.BREAK:
                    return "Break";
                case Token.Tipo.CADENA:
                    return "Cadena";
                case Token.Tipo.CASE:
                    return "Case";
                case Token.Tipo.CHAR:
                    return "Char";
                case Token.Tipo.CLASS:
                    return "Class";
                case Token.Tipo.COMA:
                    return "Coma";
                case Token.Tipo.COMILLA_DOBLE:
                    return "Comilla Doble";
                case Token.Tipo.COMILLA_SIMPLE:
                    return "Comilla Simple";
                case Token.Tipo.CONSOLE:
                    return "Console";
                case Token.Tipo.CORCHETE_ABRE:
                    return "Corchete Abre";
                case Token.Tipo.CORCHETE_CIERRA:
                    return "Corchete Cierra";
                case Token.Tipo.DEFAULT:
                    return "Default";
                case Token.Tipo.DIAGONAL:
                    return "Diagonal";
                case Token.Tipo.ELSE:
                    return "Else";
                case Token.Tipo.FLOAT:
                    return "Float";
                case Token.Tipo.FOR:
                    return "For";
                case Token.Tipo.ID:
                    return "Id";
                case Token.Tipo.IF:
                    return "If";
                case Token.Tipo.IGUAL:
                    return "Signo Igual";
                case Token.Tipo.INT:
                    return "Int";
                case Token.Tipo.MAIN:
                    return "Main";
                case Token.Tipo.MAYOR_QUE:
                    return "Signo Mayor Que";
                case Token.Tipo.MENOR_QUE:
                    return "Signo Menor Que";
                case Token.Tipo.LLAVE_ABRE:
                    return "Llave Abre";
                case Token.Tipo.LLAVE_CIERRA:
                    return "Llave Cierra";
                case Token.Tipo.NUMERO:
                    return "Numero";
                case Token.Tipo.PARENTESIS_ABRE:
                    return "Parentesis Abre";
                case Token.Tipo.PARENTESIS_CIERRA:
                    return "Parentesis Cierra";
                case Token.Tipo.PUNTO:
                    return "Punto Decimal";
                case Token.Tipo.PUNTO_COMA:
                    return "Punto y Coma";
                case Token.Tipo.RESTA:
                    return "Signo de Resta";
                case Token.Tipo.STRING:
                    return "String";
                case Token.Tipo.SUMA:
                    return "Signo Suma";
                case Token.Tipo.SWITCH:
                    return "Switch";
                case Token.Tipo.VOID:
                    return "Void";
                case Token.Tipo.WHILE:
                    return "While";
                case Token.Tipo.WRITELINE:
                    return "Writeline";
                case Token.Tipo.CARACTER:
                    return "Caracter";
                case Token.Tipo.SIGNO_ADMIRACION:
                    return "Signo de Admiracion";
                case Token.Tipo.COMENTARIO:
                    return "Comentario";
                case Token.Tipo.COMENTARIO_MULTILINEA:
                    return "Comentario Multilinea";
                case Token.Tipo.MENOR_IGUAL:
                    return "Signo Menor o Igual Que";
                case Token.Tipo.MAYOR_IGUAL:
                    return "Signo Mayor o Igual Que";
                case Token.Tipo.IGUAL_IGUAL:
                    return "Signo Igual Igual";
                case Token.Tipo.NEW:
                    return "new";
                case Token.Tipo.DECIMAL:
                    return "Número Decimal";
                case Token.Tipo.DOUBLE:
                    return "Double";
                case Token.Tipo.STATIC:
                    return "Static";
                case Token.Tipo.TRUE:
                    return "True";
                case Token.Tipo.FALSE:
                    return "false";
                default:
                    return "Desconocido";
            }
        }

        public bool VerificarAnalisis()
        {
            generarTablaSimbolos();

            return errorEncontrado;
        }

        public void generarTablaSimbolos()
        {
            DateTime dia = DateTime.Now;
            try
            {
                MessageBox.Show("HTML errores ha sido creado", "HTML creado");

                using (Stream s = File.Open(rutaTabla, FileMode.Append))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.WriteLine("<!DOCTYPE html>");
                    sw.WriteLine("<html>");
                    sw.WriteLine("<head>");
                    sw.WriteLine("<title>Tabla de Simbolos</title>");
                    sw.WriteLine("<meta charset=" + '"' + "utf-8" + '"' + "/>");
                    sw.WriteLine("</head>");
                    sw.WriteLine("<body>");
                    sw.WriteLine("<h1><center>Listado de Errores</center></h1>");
                    sw.WriteLine("<p>\n" + "<br>\n" + "</p>");
                    sw.WriteLine("<br>\n<br>\n");
                    sw.WriteLine("<p><center>" + dia + "</center></p>");
                    sw.WriteLine("<br>\n<br>\n");
                    sw.WriteLine("<center>\n" + "<table border= 4>");
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<td><center><b>#</b></center></td>");
                    sw.WriteLine("<td><center><b>Tipo</b></center></td>");
                    sw.WriteLine("<td><center><b>ID</b></center></td>");
                    sw.WriteLine("<td><center><b>VAlor</b></center></td>");
                    sw.WriteLine("</tr>");
                    int i = 1;
                    foreach (Simbolo item in variables.Values)
                    {
                        sw.WriteLine("<tr>");
                        sw.WriteLine("<td><center>" + i + "</center></td>");
                        sw.WriteLine("<td><center>" + item.getTipo() + "</center></td>");
                        sw.WriteLine("<td><center>" + item.getID() + "</center></td>");
                        sw.WriteLine("<td><center>" + item.getValor() + "</center></td>");
                        sw.WriteLine("</tr>");
                        i++;
                    }
                    sw.WriteLine("</center>\n" + "</table>");
                    sw.WriteLine("</body>");
                    sw.Write("</html>");
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
            DateTime dia = DateTime.Now;
            try
            {
                MessageBox.Show("HTML errores ha sido creado", "HTML creado");

                using (Stream s = File.Open(AnalizadorLexico.rutaError, FileMode.Append))
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
                    sw.WriteLine("<br>\n<br>\n");
                    sw.WriteLine("<p><center>" + dia + "</center></p>");
                    sw.WriteLine("<br>\n<br>\n");
                    sw.WriteLine("<center>\n" + "<table border= 4>");
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<td><center><b>#</b></center></td>");
                    sw.WriteLine("<td><center><b>Fila</b></center></td>");
                    sw.WriteLine("<td><center><b>Columna</b></center></td>");
                    sw.WriteLine("<td><center><b>Caracter</b></center></td>");
                    sw.WriteLine("<td><center><b>Descripcion</b></center></td>");
                    sw.WriteLine("</tr>");
                    int i = 1;
                    foreach (Error item in error)
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