using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        //Panel dock top
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wsmg, int wparam, int lmaparam);

        private int fila = 1;
        private int columna = 1;

        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnNormal.Visible = false;
            btnMax.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMax.Visible = false;
            btnNormal.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            btnError.Visible = false;
            btnTokens.Visible = false;
            btnSimbolos.Visible = false;
            txtEntrada.Text = "";
            txtSalida.Text = "";
            txtConsola.Text = "";
            if (File.Exists(AnalizadorLexico.rutaTokens))
            {
                File.Delete(AnalizadorLexico.rutaTokens);
            }
            if (File.Exists(Analizador_Sintactico.rutaTabla))
            {
                File.Delete(Analizador_Sintactico.rutaTabla);
            }
            if (File.Exists(AnalizadorLexico.rutaError))
            {
                File.Delete(AnalizadorLexico.rutaError);
            }

        }

        private void btnTraducir_Click(object sender, EventArgs e)
        {
             String entrada = txtEntrada.Text;
            AnalizadorLexico analizador = new AnalizadorLexico();
            LinkedList<Token> tokens = analizador.Escanner(entrada);
            if (AnalizadorLexico.listaErrores.Count == 0)
            {
                MessageBox.Show("No se han encontrado errores léxicos", "Análisis Léxico Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnTokens.Visible = true;

                tokens.AddLast(new Token(Token.Tipo.ULTIMO, "Ultimo", 0, 0));
                analizador.generarHTML_Tokens(tokens);
                Analizador_Sintactico analizadorSintactico = new Analizador_Sintactico();
                analizadorSintactico.parsear(tokens);
                if (!analizadorSintactico.VerificarAnalisis())
                {
                    MessageBox.Show("No se han encontrado errores sintácticos", "Análisis Sintáctico Finalizado");
                    btnSimbolos.Visible = true;
                    txtSalida.Text = analizadorSintactico.generarTraduccion();
                    txtConsola.Text = analizadorSintactico.generarImpresion();

                }
                else
                {
                    MessageBox.Show("Se han encontrado errores sintácticos", "Análisis Sintáctico Finalizado");
                    analizadorSintactico.generar_HTML_Errores();
                    btnError.Visible = true;
                }
            }
            else
            {
                btnError.Visible = true;
                analizador.generar_HTML_Errores();
            }
        }

        private void txtEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtEntrada.Text.Length >= 1)
            {
                btnLimpiar.Visible = true;
            }
            else
            {
                btnLimpiar.Visible = false;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                fila++;
                columna = 1;
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Back) && columna > 0)
            {
                columna--;
            }
            else
            {
                columna++;
            }
            //  lblFila.Text = "Fila: " + fila;
            // lblColumna.Text = "Columna: " + columna;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            if (this.WindowState == FormWindowState.Normal)
            {
                btnMax.Visible = true;
                btnNormal.Visible = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fastColoredTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void txtEntrada_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void btnAcerca_Click(object sender, EventArgs e)
        {
            try
            {
                Stream stream;
                OpenFileDialog dialogo = new OpenFileDialog();
                dialogo.Title = "Seleccione archivo";
                dialogo.Filter = "(*.cs)|*.cs";
                if (dialogo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if ((stream = dialogo.OpenFile()) != null)
                    {
                        string texto = File.ReadAllText(dialogo.FileName);
                        txtEntrada.Text = texto;
                        stream.Close();
                    }
                    else
                    {
                        MessageBox.Show("El archivo no es compatible", "Error de archivo");
                    }

                }
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            catch (IOException ex)
            {
                if (ex.Source != null)
                    Console.WriteLine("IOException source: {0}", ex.Source);
                throw;
            }
        }

        private void btnTokens_Click(object sender, EventArgs e)
        {
            if (File.Exists(AnalizadorLexico.rutaTokens))
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = AnalizadorLexico.rutaTokens;
                p.Start();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSalida.Text == "")
                {
                    MessageBox.Show("No hay ningun archivo para guardar", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SaveFileDialog guardar = new SaveFileDialog();
                    guardar.Title = "Guardar archivo como";
                    guardar.Filter = "(*.py)|*.py";
                    guardar.FileName = "resultado";
                    guardar.DefaultExt = ".py";
                    if (guardar.ShowDialog() == DialogResult.OK)
                    {
                        using (Stream s = File.Open(guardar.FileName, FileMode.CreateNew))
                        using (StreamWriter sw = new StreamWriter(s))
                        {
                            sw.Write(txtSalida.Text);
                            sw.Flush();
                            sw.Close();
                        }
                    }
                }
            }
            catch (IOException)
            {
                throw;
            }
        }

        private void btnSimbolos_Click(object sender, EventArgs e)
        {
            if (File.Exists(Analizador_Sintactico.rutaTabla))
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = Analizador_Sintactico.rutaTabla;
                p.Start();
            }
        }

        private void btnError_Click(object sender, EventArgs e)
        {
            if (File.Exists(AnalizadorLexico.rutaError))
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = Analizador_Sintactico.rutaTabla;
                p.Start();
            }
        }
    }
}
