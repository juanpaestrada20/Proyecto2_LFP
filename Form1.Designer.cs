namespace Proyecto_2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.btnMin = new System.Windows.Forms.PictureBox();
            this.btnNormal = new System.Windows.Forms.PictureBox();
            this.btnMax = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTokens = new System.Windows.Forms.Button();
            this.btnError = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSimbolos = new System.Windows.Forms.Button();
            this.btnAcerca = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnTraducir = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSalida = new FastColoredTextBoxNS.FastColoredTextBox();
            this.txtEntrada = new FastColoredTextBoxNS.FastColoredTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConsola = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNormal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntrada)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(1133, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(22, 21);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMin.Image = ((System.Drawing.Image)(resources.GetObject("btnMin.Image")));
            this.btnMin.Location = new System.Drawing.Point(1077, 12);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(22, 21);
            this.btnMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMin.TabIndex = 2;
            this.btnMin.TabStop = false;
            this.btnMin.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // btnNormal
            // 
            this.btnNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNormal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNormal.Image = ((System.Drawing.Image)(resources.GetObject("btnNormal.Image")));
            this.btnNormal.Location = new System.Drawing.Point(1105, 12);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(22, 21);
            this.btnNormal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnNormal.TabIndex = 3;
            this.btnNormal.TabStop = false;
            this.btnNormal.Visible = false;
            this.btnNormal.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // btnMax
            // 
            this.btnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMax.Image = ((System.Drawing.Image)(resources.GetObject("btnMax.Image")));
            this.btnMax.Location = new System.Drawing.Point(1105, 12);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(22, 21);
            this.btnMax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMax.TabIndex = 4;
            this.btnMax.TabStop = false;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.btnTokens);
            this.panel1.Controls.Add(this.btnError);
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Controls.Add(this.btnSimbolos);
            this.panel1.Controls.Add(this.btnAcerca);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.btnTraducir);
            this.panel1.Controls.Add(this.btnMax);
            this.panel1.Controls.Add(this.btnNormal);
            this.panel1.Controls.Add(this.btnMin);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1167, 66);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // btnTokens
            // 
            this.btnTokens.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTokens.FlatAppearance.BorderSize = 0;
            this.btnTokens.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btnTokens.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.btnTokens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTokens.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTokens.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTokens.Image = ((System.Drawing.Image)(resources.GetObject("btnTokens.Image")));
            this.btnTokens.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTokens.Location = new System.Drawing.Point(578, 12);
            this.btnTokens.Name = "btnTokens";
            this.btnTokens.Size = new System.Drawing.Size(112, 48);
            this.btnTokens.TabIndex = 7;
            this.btnTokens.Text = "Tokens";
            this.btnTokens.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTokens.UseVisualStyleBackColor = true;
            this.btnTokens.Visible = false;
            this.btnTokens.Click += new System.EventHandler(this.btnTokens_Click);
            // 
            // btnError
            // 
            this.btnError.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnError.FlatAppearance.BorderSize = 0;
            this.btnError.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btnError.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.btnError.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnError.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnError.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnError.Image = ((System.Drawing.Image)(resources.GetObject("btnError.Image")));
            this.btnError.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnError.Location = new System.Drawing.Point(932, 12);
            this.btnError.Name = "btnError";
            this.btnError.Size = new System.Drawing.Size(121, 48);
            this.btnError.TabIndex = 9;
            this.btnError.Text = "Errores";
            this.btnError.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnError.UseVisualStyleBackColor = true;
            this.btnError.Visible = false;
            this.btnError.Click += new System.EventHandler(this.btnError_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(455, 12);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(129, 48);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar ";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSimbolos
            // 
            this.btnSimbolos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSimbolos.FlatAppearance.BorderSize = 0;
            this.btnSimbolos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btnSimbolos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.btnSimbolos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimbolos.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimbolos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSimbolos.Image = ((System.Drawing.Image)(resources.GetObject("btnSimbolos.Image")));
            this.btnSimbolos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSimbolos.Location = new System.Drawing.Point(705, 12);
            this.btnSimbolos.Name = "btnSimbolos";
            this.btnSimbolos.Size = new System.Drawing.Size(221, 48);
            this.btnSimbolos.TabIndex = 8;
            this.btnSimbolos.Text = "Tabla de Simbolos";
            this.btnSimbolos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSimbolos.UseVisualStyleBackColor = true;
            this.btnSimbolos.Visible = false;
            this.btnSimbolos.Click += new System.EventHandler(this.btnSimbolos_Click);
            // 
            // btnAcerca
            // 
            this.btnAcerca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAcerca.FlatAppearance.BorderSize = 0;
            this.btnAcerca.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btnAcerca.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.btnAcerca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcerca.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcerca.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAcerca.Image = ((System.Drawing.Image)(resources.GetObject("btnAcerca.Image")));
            this.btnAcerca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcerca.Location = new System.Drawing.Point(70, 12);
            this.btnAcerca.Name = "btnAcerca";
            this.btnAcerca.Size = new System.Drawing.Size(103, 48);
            this.btnAcerca.TabIndex = 11;
            this.btnAcerca.Text = "Abrir";
            this.btnAcerca.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAcerca.UseVisualStyleBackColor = true;
            this.btnAcerca.Click += new System.EventHandler(this.btnAcerca_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(179, 12);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(132, 48);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnTraducir
            // 
            this.btnTraducir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTraducir.FlatAppearance.BorderSize = 0;
            this.btnTraducir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btnTraducir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.btnTraducir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraducir.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraducir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTraducir.Image = ((System.Drawing.Image)(resources.GetObject("btnTraducir.Image")));
            this.btnTraducir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTraducir.Location = new System.Drawing.Point(317, 12);
            this.btnTraducir.Name = "btnTraducir";
            this.btnTraducir.Size = new System.Drawing.Size(132, 48);
            this.btnTraducir.TabIndex = 6;
            this.btnTraducir.Text = "Traducir";
            this.btnTraducir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTraducir.UseVisualStyleBackColor = true;
            this.btnTraducir.Click += new System.EventHandler(this.btnTraducir_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtSalida);
            this.panel2.Controls.Add(this.txtEntrada);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtConsola);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1167, 718);
            this.panel2.TabIndex = 1;
            // 
            // txtSalida
            // 
            this.txtSalida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSalida.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.txtSalida.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:" +
    "]*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.txtSalida.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.txtSalida.BackBrush = null;
            this.txtSalida.BackColor = System.Drawing.Color.CornflowerBlue;
            this.txtSalida.BookmarkColor = System.Drawing.Color.OldLace;
            this.txtSalida.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.txtSalida.CaretColor = System.Drawing.Color.White;
            this.txtSalida.CharHeight = 14;
            this.txtSalida.CharWidth = 8;
            this.txtSalida.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSalida.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtSalida.FoldingIndicatorColor = System.Drawing.Color.White;
            this.txtSalida.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.txtSalida.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtSalida.IndentBackColor = System.Drawing.Color.CornflowerBlue;
            this.txtSalida.IsReplaceMode = false;
            this.txtSalida.Language = FastColoredTextBoxNS.Language.CSharp;
            this.txtSalida.LeftBracket = '(';
            this.txtSalida.LeftBracket2 = '{';
            this.txtSalida.LineNumberColor = System.Drawing.Color.Tomato;
            this.txtSalida.Location = new System.Drawing.Point(602, 95);
            this.txtSalida.Name = "txtSalida";
            this.txtSalida.Paddings = new System.Windows.Forms.Padding(0);
            this.txtSalida.RightBracket = ')';
            this.txtSalida.RightBracket2 = '}';
            this.txtSalida.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtSalida.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtSalida.ServiceColors")));
            this.txtSalida.ServiceLinesColor = System.Drawing.Color.CornflowerBlue;
            this.txtSalida.Size = new System.Drawing.Size(525, 363);
            this.txtSalida.TabIndex = 7;
            this.txtSalida.Zoom = 100;
            // 
            // txtEntrada
            // 
            this.txtEntrada.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.txtEntrada.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:" +
    "]*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.txtEntrada.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.txtEntrada.BackBrush = null;
            this.txtEntrada.BackColor = System.Drawing.Color.DarkTurquoise;
            this.txtEntrada.BookmarkColor = System.Drawing.Color.PaleGreen;
            this.txtEntrada.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.txtEntrada.CharHeight = 14;
            this.txtEntrada.CharWidth = 8;
            this.txtEntrada.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEntrada.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtEntrada.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.txtEntrada.IndentBackColor = System.Drawing.Color.DarkCyan;
            this.txtEntrada.IsReplaceMode = false;
            this.txtEntrada.Language = FastColoredTextBoxNS.Language.CSharp;
            this.txtEntrada.LeftBracket = '(';
            this.txtEntrada.LeftBracket2 = '{';
            this.txtEntrada.LineNumberColor = System.Drawing.Color.Yellow;
            this.txtEntrada.Location = new System.Drawing.Point(39, 95);
            this.txtEntrada.Name = "txtEntrada";
            this.txtEntrada.Paddings = new System.Windows.Forms.Padding(0);
            this.txtEntrada.RightBracket = ')';
            this.txtEntrada.RightBracket2 = '}';
            this.txtEntrada.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtEntrada.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtEntrada.ServiceColors")));
            this.txtEntrada.Size = new System.Drawing.Size(525, 363);
            this.txtEntrada.TabIndex = 6;
            this.txtEntrada.Zoom = 100;
            this.txtEntrada.Load += new System.EventHandler(this.fastColoredTextBox1_Load);
            this.txtEntrada.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEntrada_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(598, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "TRADUCCIÓN:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(35, 461);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "CONSOLA:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(35, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "ENTRADA DE TEXO:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtConsola
            // 
            this.txtConsola.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsola.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtConsola.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConsola.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsola.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtConsola.Location = new System.Drawing.Point(39, 486);
            this.txtConsola.Name = "txtConsola";
            this.txtConsola.Size = new System.Drawing.Size(1088, 204);
            this.txtConsola.TabIndex = 2;
            this.txtConsola.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(1167, 718);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNormal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntrada)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.PictureBox btnMin;
        private System.Windows.Forms.PictureBox btnNormal;
        private System.Windows.Forms.PictureBox btnMax;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnError;
        private System.Windows.Forms.Button btnSimbolos;
        private System.Windows.Forms.Button btnTokens;
        private System.Windows.Forms.Button btnTraducir;
        private System.Windows.Forms.Button btnAcerca;
        private System.Windows.Forms.RichTextBox txtConsola;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private FastColoredTextBoxNS.FastColoredTextBox txtEntrada;
        private FastColoredTextBoxNS.FastColoredTextBox txtSalida;
    }
}

