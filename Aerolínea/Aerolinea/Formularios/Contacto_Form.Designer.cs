
namespace Aerolinea
{
    partial class Contacto_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Contacto_Form));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.contacto_XML_CorreoElectronico = new System.Windows.Forms.Label();
            this.contacto_XML_NumeroTelefonico = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Puede contactarnos por medio del correo electrónico o\r\nbien llamando a nuestro Ca" +
    "ll Center disponible 24/7.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(21, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Correo electónico:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(21, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Número telefónico:";
            // 
            // contacto_XML_CorreoElectronico
            // 
            this.contacto_XML_CorreoElectronico.AutoSize = true;
            this.contacto_XML_CorreoElectronico.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.contacto_XML_CorreoElectronico.Location = new System.Drawing.Point(154, 95);
            this.contacto_XML_CorreoElectronico.Name = "contacto_XML_CorreoElectronico";
            this.contacto_XML_CorreoElectronico.Size = new System.Drawing.Size(87, 17);
            this.contacto_XML_CorreoElectronico.TabIndex = 3;
            this.contacto_XML_CorreoElectronico.Text = "XML_Correo";
            // 
            // contacto_XML_NumeroTelefonico
            // 
            this.contacto_XML_NumeroTelefonico.AutoSize = true;
            this.contacto_XML_NumeroTelefonico.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.contacto_XML_NumeroTelefonico.Location = new System.Drawing.Point(154, 144);
            this.contacto_XML_NumeroTelefonico.Name = "contacto_XML_NumeroTelefonico";
            this.contacto_XML_NumeroTelefonico.Size = new System.Drawing.Size(100, 17);
            this.contacto_XML_NumeroTelefonico.TabIndex = 4;
            this.contacto_XML_NumeroTelefonico.Text = "XML_Teléfono";
            // 
            // Contacto_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(397, 214);
            this.Controls.Add(this.contacto_XML_NumeroTelefonico);
            this.Controls.Add(this.contacto_XML_CorreoElectronico);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Contacto_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Información de Contacto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label contacto_XML_CorreoElectronico;
        public System.Windows.Forms.Label contacto_XML_NumeroTelefonico;
    }
}