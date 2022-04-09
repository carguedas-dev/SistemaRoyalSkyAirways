
namespace Aerolinea
{
    partial class pantallaLogin_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pantallaLogin_Form));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_usuario_login = new System.Windows.Forms.TextBox();
            this.tbx_contrasena_login = new System.Windows.Forms.TextBox();
            this.btn_verificar_login = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(256, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(256, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña";
            // 
            // tbx_usuario_login
            // 
            this.tbx_usuario_login.Location = new System.Drawing.Point(357, 42);
            this.tbx_usuario_login.Name = "tbx_usuario_login";
            this.tbx_usuario_login.Size = new System.Drawing.Size(100, 23);
            this.tbx_usuario_login.TabIndex = 2;
            this.tbx_usuario_login.TextChanged += new System.EventHandler(this.tbx_usuario_login_TextChanged);
            // 
            // tbx_contrasena_login
            // 
            this.tbx_contrasena_login.Location = new System.Drawing.Point(357, 81);
            this.tbx_contrasena_login.Name = "tbx_contrasena_login";
            this.tbx_contrasena_login.PasswordChar = '•';
            this.tbx_contrasena_login.Size = new System.Drawing.Size(100, 23);
            this.tbx_contrasena_login.TabIndex = 3;
            this.tbx_contrasena_login.TextChanged += new System.EventHandler(this.tbx_contrasena_login_TextChanged);
            // 
            // btn_verificar_login
            // 
            this.btn_verificar_login.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_verificar_login.Location = new System.Drawing.Point(256, 133);
            this.btn_verificar_login.Name = "btn_verificar_login";
            this.btn_verificar_login.Size = new System.Drawing.Size(201, 23);
            this.btn_verificar_login.TabIndex = 4;
            this.btn_verificar_login.Text = "Verificar";
            this.btn_verificar_login.UseVisualStyleBackColor = false;
            this.btn_verificar_login.Click += new System.EventHandler(this.btn_verificar_login_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(16, -60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 270);
            this.label3.TabIndex = 5;
            this.label3.Text = "                                                     \r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n      " +
    "                                                              \r\n\r\n\r\n\r\n\r\n\r\n\r\n";
            // 
            // pantallaLogin_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(490, 198);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_verificar_login);
            this.Controls.Add(this.tbx_contrasena_login);
            this.Controls.Add(this.tbx_usuario_login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "pantallaLogin_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Royal Sky Airways - Login";
            this.Load += new System.EventHandler(this.pantallaLogin_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_usuario_login;
        private System.Windows.Forms.TextBox tbx_contrasena_login;
        private System.Windows.Forms.Button btn_verificar_login;
        private System.Windows.Forms.Label label3;
    }
}