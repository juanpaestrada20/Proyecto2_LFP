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
            btnLimpiar.Visible = false;
            Console.WriteLine(txtEntrada.Text);
            txtEntrada.Text = "";

        }

        private void btnTraducir_Click(object sender, EventArgs e)
        {
            String entrada = txtEntrada.Text;
            AnalizadorLexico analizador = new AnalizadorLexico();
            LinkedList<Token> tokens = analizador.Escanner(entrada);
            if (AnalizadorLexico.listaErrores.Count == 0)
            {
                MessageBox.Show("No se han encontrado errores", "Análisis Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnTokens.Visible = true;
                btnSimbolos.Visible = true;
                analizador.generarHTML_Tokens(tokens);
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
    }
}
