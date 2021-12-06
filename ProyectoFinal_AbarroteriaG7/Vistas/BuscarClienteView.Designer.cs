
namespace ProyectoFinal_AbarroteriaG7.Vistas
{
    partial class BuscarClienteView
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
            this.ClientesdataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.NombreClientetextBox = new System.Windows.Forms.TextBox();
            this.Aceptarbutton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Cancelarbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ClientesdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ClientesdataGridView
            // 
            this.ClientesdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientesdataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientesdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClientesdataGridView.Location = new System.Drawing.Point(-3, 230);
            this.ClientesdataGridView.Name = "ClientesdataGridView";
            this.ClientesdataGridView.Size = new System.Drawing.Size(616, 103);
            this.ClientesdataGridView.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(100, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Nombre Cliente";
            // 
            // NombreClientetextBox
            // 
            this.NombreClientetextBox.Location = new System.Drawing.Point(208, 116);
            this.NombreClientetextBox.Name = "NombreClientetextBox";
            this.NombreClientetextBox.Size = new System.Drawing.Size(191, 20);
            this.NombreClientetextBox.TabIndex = 34;
            this.NombreClientetextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.NombreClientetextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NombreClientetextBox_KeyUp);
            // 
            // Aceptarbutton
            // 
            this.Aceptarbutton.Location = new System.Drawing.Point(208, 158);
            this.Aceptarbutton.Name = "Aceptarbutton";
            this.Aceptarbutton.Size = new System.Drawing.Size(75, 23);
            this.Aceptarbutton.TabIndex = 35;
            this.Aceptarbutton.Text = "Aceptar";
            this.Aceptarbutton.UseVisualStyleBackColor = true;
            this.Aceptarbutton.Click += new System.EventHandler(this.Aceptarbutton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Lavender;
            this.pictureBox1.Image = global::ProyectoFinal_AbarroteriaG7.Properties.Resources._26240019_1535731569829556_6472502337529994649_o1;
            this.pictureBox1.Location = new System.Drawing.Point(174, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(259, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // Cancelarbutton
            // 
            this.Cancelarbutton.Location = new System.Drawing.Point(324, 158);
            this.Cancelarbutton.Name = "Cancelarbutton";
            this.Cancelarbutton.Size = new System.Drawing.Size(75, 23);
            this.Cancelarbutton.TabIndex = 37;
            this.Cancelarbutton.Text = "Cancelar";
            this.Cancelarbutton.UseVisualStyleBackColor = true;
            this.Cancelarbutton.Click += new System.EventHandler(this.Cancelarbutton_Click);
            // 
            // BuscarClienteView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(614, 337);
            this.Controls.Add(this.Cancelarbutton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Aceptarbutton);
            this.Controls.Add(this.NombreClientetextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClientesdataGridView);
            this.Name = "BuscarClienteView";
            this.Text = "BuscarCliente";
            this.Load += new System.EventHandler(this.BuscarClienteView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ClientesdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView ClientesdataGridView;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox NombreClientetextBox;
        public System.Windows.Forms.Button Aceptarbutton;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Button Cancelarbutton;
    }
}