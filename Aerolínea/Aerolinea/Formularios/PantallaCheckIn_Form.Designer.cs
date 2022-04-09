
namespace Aerolinea
{
    partial class PantallaCheckIn_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaCheckIn_Form));
            this.pantallaCheckIn_Label_MaletasARegistrar = new System.Windows.Forms.Label();
            this.pantallaCheckIn_ComboBox_MaletasARegistrar = new System.Windows.Forms.ComboBox();
            this.pantallaCheckIn_Label_PesoMaleta1 = new System.Windows.Forms.Label();
            this.pantallaCheckIn_Label_PesoMaleta2 = new System.Windows.Forms.Label();
            this.pantallaCheckIn_Label_PesoMaleta3 = new System.Windows.Forms.Label();
            this.pantallaCheckIn_TextBox_PesoMaleta1 = new System.Windows.Forms.TextBox();
            this.pantallaCheckIn_TextBox_PesoMaleta2 = new System.Windows.Forms.TextBox();
            this.pantallaCheckIn_TextBox_PesoMaleta3 = new System.Windows.Forms.TextBox();
            this.pantallaCheckIn_Label_Informacion = new System.Windows.Forms.Label();
            this.pantallaCheckIn_Label_PesoTotal = new System.Windows.Forms.Label();
            this.pantallaCheckIn_Label_PesoTotalValor = new System.Windows.Forms.Label();
            this.pantallaCheckIn_Label_PrecioXSobrepesoValor = new System.Windows.Forms.Label();
            this.pantallaCheckIn_Label_PrecioXSobrepeso = new System.Windows.Forms.Label();
            this.pantallaCheckIn_Label_PrecioFinalValor = new System.Windows.Forms.Label();
            this.pantallaCheckIn_Label_PrecioFinal = new System.Windows.Forms.Label();
            this.pantallaCheckIn_Button_Registrar = new System.Windows.Forms.Button();
            this.pantallaCheckIn_Label_Titulo = new System.Windows.Forms.Label();
            this.pantallaCheckIn_Button_Calcular = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pantallaCheckIn_Label_MaletasARegistrar
            // 
            this.pantallaCheckIn_Label_MaletasARegistrar.AutoSize = true;
            this.pantallaCheckIn_Label_MaletasARegistrar.Location = new System.Drawing.Point(26, 61);
            this.pantallaCheckIn_Label_MaletasARegistrar.Name = "pantallaCheckIn_Label_MaletasARegistrar";
            this.pantallaCheckIn_Label_MaletasARegistrar.Size = new System.Drawing.Size(173, 15);
            this.pantallaCheckIn_Label_MaletasARegistrar.TabIndex = 0;
            this.pantallaCheckIn_Label_MaletasARegistrar.Text = "Cantidad de Maletas a Registrar";
            // 
            // pantallaCheckIn_ComboBox_MaletasARegistrar
            // 
            this.pantallaCheckIn_ComboBox_MaletasARegistrar.FormattingEnabled = true;
            this.pantallaCheckIn_ComboBox_MaletasARegistrar.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.pantallaCheckIn_ComboBox_MaletasARegistrar.Location = new System.Drawing.Point(205, 58);
            this.pantallaCheckIn_ComboBox_MaletasARegistrar.Name = "pantallaCheckIn_ComboBox_MaletasARegistrar";
            this.pantallaCheckIn_ComboBox_MaletasARegistrar.Size = new System.Drawing.Size(54, 23);
            this.pantallaCheckIn_ComboBox_MaletasARegistrar.TabIndex = 1;
            this.pantallaCheckIn_ComboBox_MaletasARegistrar.SelectedIndexChanged += new System.EventHandler(this.pantallaCheckIn_ComboBox_MaletasARegistrar_SelectedIndexChanged);
            // 
            // pantallaCheckIn_Label_PesoMaleta1
            // 
            this.pantallaCheckIn_Label_PesoMaleta1.AutoSize = true;
            this.pantallaCheckIn_Label_PesoMaleta1.Location = new System.Drawing.Point(290, 61);
            this.pantallaCheckIn_Label_PesoMaleta1.Name = "pantallaCheckIn_Label_PesoMaleta1";
            this.pantallaCheckIn_Label_PesoMaleta1.Size = new System.Drawing.Size(87, 15);
            this.pantallaCheckIn_Label_PesoMaleta1.TabIndex = 2;
            this.pantallaCheckIn_Label_PesoMaleta1.Text = "Peso Maleta #1";
            // 
            // pantallaCheckIn_Label_PesoMaleta2
            // 
            this.pantallaCheckIn_Label_PesoMaleta2.AutoSize = true;
            this.pantallaCheckIn_Label_PesoMaleta2.Location = new System.Drawing.Point(290, 109);
            this.pantallaCheckIn_Label_PesoMaleta2.Name = "pantallaCheckIn_Label_PesoMaleta2";
            this.pantallaCheckIn_Label_PesoMaleta2.Size = new System.Drawing.Size(87, 15);
            this.pantallaCheckIn_Label_PesoMaleta2.TabIndex = 3;
            this.pantallaCheckIn_Label_PesoMaleta2.Text = "Peso Maleta #2";
            // 
            // pantallaCheckIn_Label_PesoMaleta3
            // 
            this.pantallaCheckIn_Label_PesoMaleta3.AutoSize = true;
            this.pantallaCheckIn_Label_PesoMaleta3.Location = new System.Drawing.Point(290, 159);
            this.pantallaCheckIn_Label_PesoMaleta3.Name = "pantallaCheckIn_Label_PesoMaleta3";
            this.pantallaCheckIn_Label_PesoMaleta3.Size = new System.Drawing.Size(87, 15);
            this.pantallaCheckIn_Label_PesoMaleta3.TabIndex = 4;
            this.pantallaCheckIn_Label_PesoMaleta3.Text = "Peso Maleta #3";
            // 
            // pantallaCheckIn_TextBox_PesoMaleta1
            // 
            this.pantallaCheckIn_TextBox_PesoMaleta1.Location = new System.Drawing.Point(383, 58);
            this.pantallaCheckIn_TextBox_PesoMaleta1.Name = "pantallaCheckIn_TextBox_PesoMaleta1";
            this.pantallaCheckIn_TextBox_PesoMaleta1.Size = new System.Drawing.Size(68, 23);
            this.pantallaCheckIn_TextBox_PesoMaleta1.TabIndex = 5;
            // 
            // pantallaCheckIn_TextBox_PesoMaleta2
            // 
            this.pantallaCheckIn_TextBox_PesoMaleta2.Location = new System.Drawing.Point(383, 106);
            this.pantallaCheckIn_TextBox_PesoMaleta2.Name = "pantallaCheckIn_TextBox_PesoMaleta2";
            this.pantallaCheckIn_TextBox_PesoMaleta2.Size = new System.Drawing.Size(68, 23);
            this.pantallaCheckIn_TextBox_PesoMaleta2.TabIndex = 6;
            // 
            // pantallaCheckIn_TextBox_PesoMaleta3
            // 
            this.pantallaCheckIn_TextBox_PesoMaleta3.Location = new System.Drawing.Point(383, 156);
            this.pantallaCheckIn_TextBox_PesoMaleta3.Name = "pantallaCheckIn_TextBox_PesoMaleta3";
            this.pantallaCheckIn_TextBox_PesoMaleta3.Size = new System.Drawing.Size(68, 23);
            this.pantallaCheckIn_TextBox_PesoMaleta3.TabIndex = 7;
            // 
            // pantallaCheckIn_Label_Informacion
            // 
            this.pantallaCheckIn_Label_Informacion.Location = new System.Drawing.Point(26, 84);
            this.pantallaCheckIn_Label_Informacion.Name = "pantallaCheckIn_Label_Informacion";
            this.pantallaCheckIn_Label_Informacion.Size = new System.Drawing.Size(200, 110);
            this.pantallaCheckIn_Label_Informacion.TabIndex = 8;
            this.pantallaCheckIn_Label_Informacion.Text = "Información: \n\n     Precio primera maleta: $60\n     Precio segunda maleta: $75\n  " +
    "   Precio tercera maleta: $225\n     Peso máximo (en conjunto): 70kg\n     Costo p" +
    "or sobrepeso: $10 por Kilo";
            // 
            // pantallaCheckIn_Label_PesoTotal
            // 
            this.pantallaCheckIn_Label_PesoTotal.AutoSize = true;
            this.pantallaCheckIn_Label_PesoTotal.Location = new System.Drawing.Point(29, 207);
            this.pantallaCheckIn_Label_PesoTotal.Name = "pantallaCheckIn_Label_PesoTotal";
            this.pantallaCheckIn_Label_PesoTotal.Size = new System.Drawing.Size(59, 15);
            this.pantallaCheckIn_Label_PesoTotal.TabIndex = 9;
            this.pantallaCheckIn_Label_PesoTotal.Text = "Peso total";
            // 
            // pantallaCheckIn_Label_PesoTotalValor
            // 
            this.pantallaCheckIn_Label_PesoTotalValor.AutoSize = true;
            this.pantallaCheckIn_Label_PesoTotalValor.Location = new System.Drawing.Point(94, 207);
            this.pantallaCheckIn_Label_PesoTotalValor.Name = "pantallaCheckIn_Label_PesoTotalValor";
            this.pantallaCheckIn_Label_PesoTotalValor.Size = new System.Drawing.Size(29, 15);
            this.pantallaCheckIn_Label_PesoTotalValor.TabIndex = 10;
            this.pantallaCheckIn_Label_PesoTotalValor.Text = "N/A";
            // 
            // pantallaCheckIn_Label_PrecioXSobrepesoValor
            // 
            this.pantallaCheckIn_Label_PrecioXSobrepesoValor.AutoSize = true;
            this.pantallaCheckIn_Label_PrecioXSobrepesoValor.Location = new System.Drawing.Point(292, 207);
            this.pantallaCheckIn_Label_PrecioXSobrepesoValor.Name = "pantallaCheckIn_Label_PrecioXSobrepesoValor";
            this.pantallaCheckIn_Label_PrecioXSobrepesoValor.Size = new System.Drawing.Size(29, 15);
            this.pantallaCheckIn_Label_PrecioXSobrepesoValor.TabIndex = 12;
            this.pantallaCheckIn_Label_PrecioXSobrepesoValor.Text = "N/A";
            // 
            // pantallaCheckIn_Label_PrecioXSobrepeso
            // 
            this.pantallaCheckIn_Label_PrecioXSobrepeso.AutoSize = true;
            this.pantallaCheckIn_Label_PrecioXSobrepeso.Location = new System.Drawing.Point(167, 207);
            this.pantallaCheckIn_Label_PrecioXSobrepeso.Name = "pantallaCheckIn_Label_PrecioXSobrepeso";
            this.pantallaCheckIn_Label_PrecioXSobrepeso.Size = new System.Drawing.Size(119, 15);
            this.pantallaCheckIn_Label_PrecioXSobrepeso.TabIndex = 11;
            this.pantallaCheckIn_Label_PrecioXSobrepeso.Text = "Precio por Sobrepeso";
            // 
            // pantallaCheckIn_Label_PrecioFinalValor
            // 
            this.pantallaCheckIn_Label_PrecioFinalValor.AutoSize = true;
            this.pantallaCheckIn_Label_PrecioFinalValor.Location = new System.Drawing.Point(428, 207);
            this.pantallaCheckIn_Label_PrecioFinalValor.Name = "pantallaCheckIn_Label_PrecioFinalValor";
            this.pantallaCheckIn_Label_PrecioFinalValor.Size = new System.Drawing.Size(29, 15);
            this.pantallaCheckIn_Label_PrecioFinalValor.TabIndex = 14;
            this.pantallaCheckIn_Label_PrecioFinalValor.Text = "N/A";
            // 
            // pantallaCheckIn_Label_PrecioFinal
            // 
            this.pantallaCheckIn_Label_PrecioFinal.AutoSize = true;
            this.pantallaCheckIn_Label_PrecioFinal.Location = new System.Drawing.Point(356, 207);
            this.pantallaCheckIn_Label_PrecioFinal.Name = "pantallaCheckIn_Label_PrecioFinal";
            this.pantallaCheckIn_Label_PrecioFinal.Size = new System.Drawing.Size(66, 15);
            this.pantallaCheckIn_Label_PrecioFinal.TabIndex = 13;
            this.pantallaCheckIn_Label_PrecioFinal.Text = "Precio final";
            // 
            // pantallaCheckIn_Button_Registrar
            // 
            this.pantallaCheckIn_Button_Registrar.Location = new System.Drawing.Point(239, 242);
            this.pantallaCheckIn_Button_Registrar.Name = "pantallaCheckIn_Button_Registrar";
            this.pantallaCheckIn_Button_Registrar.Size = new System.Drawing.Size(215, 23);
            this.pantallaCheckIn_Button_Registrar.TabIndex = 16;
            this.pantallaCheckIn_Button_Registrar.Text = "Registrar";
            this.pantallaCheckIn_Button_Registrar.UseVisualStyleBackColor = true;
            this.pantallaCheckIn_Button_Registrar.Click += new System.EventHandler(this.pantallaCheckIn_Button_Registrar_Click);
            // 
            // pantallaCheckIn_Label_Titulo
            // 
            this.pantallaCheckIn_Label_Titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(138)))), ((int)(((byte)(196)))));
            this.pantallaCheckIn_Label_Titulo.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pantallaCheckIn_Label_Titulo.ForeColor = System.Drawing.Color.White;
            this.pantallaCheckIn_Label_Titulo.Location = new System.Drawing.Point(-1, 0);
            this.pantallaCheckIn_Label_Titulo.Name = "pantallaCheckIn_Label_Titulo";
            this.pantallaCheckIn_Label_Titulo.Size = new System.Drawing.Size(480, 36);
            this.pantallaCheckIn_Label_Titulo.TabIndex = 17;
            this.pantallaCheckIn_Label_Titulo.Text = "Registro";
            this.pantallaCheckIn_Label_Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pantallaCheckIn_Button_Calcular
            // 
            this.pantallaCheckIn_Button_Calcular.Location = new System.Drawing.Point(17, 241);
            this.pantallaCheckIn_Button_Calcular.Name = "pantallaCheckIn_Button_Calcular";
            this.pantallaCheckIn_Button_Calcular.Size = new System.Drawing.Size(215, 23);
            this.pantallaCheckIn_Button_Calcular.TabIndex = 18;
            this.pantallaCheckIn_Button_Calcular.Text = "Calcular";
            this.pantallaCheckIn_Button_Calcular.UseVisualStyleBackColor = true;
            this.pantallaCheckIn_Button_Calcular.Click += new System.EventHandler(this.pantallaCheckIn_Button_Calcular_Click);
            // 
            // PantallaCheckIn_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(480, 285);
            this.Controls.Add(this.pantallaCheckIn_Button_Calcular);
            this.Controls.Add(this.pantallaCheckIn_Label_Titulo);
            this.Controls.Add(this.pantallaCheckIn_Button_Registrar);
            this.Controls.Add(this.pantallaCheckIn_Label_PrecioFinalValor);
            this.Controls.Add(this.pantallaCheckIn_Label_PrecioFinal);
            this.Controls.Add(this.pantallaCheckIn_Label_PrecioXSobrepesoValor);
            this.Controls.Add(this.pantallaCheckIn_Label_PrecioXSobrepeso);
            this.Controls.Add(this.pantallaCheckIn_Label_PesoTotalValor);
            this.Controls.Add(this.pantallaCheckIn_Label_PesoTotal);
            this.Controls.Add(this.pantallaCheckIn_Label_Informacion);
            this.Controls.Add(this.pantallaCheckIn_TextBox_PesoMaleta3);
            this.Controls.Add(this.pantallaCheckIn_TextBox_PesoMaleta2);
            this.Controls.Add(this.pantallaCheckIn_TextBox_PesoMaleta1);
            this.Controls.Add(this.pantallaCheckIn_Label_PesoMaleta3);
            this.Controls.Add(this.pantallaCheckIn_Label_PesoMaleta2);
            this.Controls.Add(this.pantallaCheckIn_Label_PesoMaleta1);
            this.Controls.Add(this.pantallaCheckIn_ComboBox_MaletasARegistrar);
            this.Controls.Add(this.pantallaCheckIn_Label_MaletasARegistrar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PantallaCheckIn_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PantallaCheckIn";
            this.Load += new System.EventHandler(this.PantallaCheckIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pantallaCheckIn_Label_MaletasARegistrar;
        private System.Windows.Forms.ComboBox pantallaCheckIn_ComboBox_MaletasARegistrar;
        private System.Windows.Forms.Label pantallaCheckIn_Label_PesoMaleta1;
        private System.Windows.Forms.Label pantallaCheckIn_Label_PesoMaleta2;
        private System.Windows.Forms.Label pantallaCheckIn_Label_PesoMaleta3;
        private System.Windows.Forms.TextBox pantallaCheckIn_TextBox_PesoMaleta1;
        private System.Windows.Forms.TextBox pantallaCheckIn_TextBox_PesoMaleta2;
        private System.Windows.Forms.TextBox pantallaCheckIn_TextBox_PesoMaleta3;
        private System.Windows.Forms.Label pantallaCheckIn_Label_Informacion;
        private System.Windows.Forms.Label pantallaCheckIn_Label_PesoTotal;
        private System.Windows.Forms.Label pantallaCheckIn_Label_PesoTotalValor;
        private System.Windows.Forms.Label pantallaCheckIn_Label_PrecioXSobrepesoValor;
        private System.Windows.Forms.Label pantallaCheckIn_Label_PrecioXSobrepeso;
        private System.Windows.Forms.Label pantallaCheckIn_Label_PrecioFinalValor;
        private System.Windows.Forms.Label pantallaCheckIn_Label_PrecioFinal;
        private System.Windows.Forms.Button pantallaCheckIn_Button_Registrar;
        private System.Windows.Forms.Label pantallaCheckIn_Label_Titulo;
        private System.Windows.Forms.Button pantallaCheckIn_Button_Calcular;
    }
}