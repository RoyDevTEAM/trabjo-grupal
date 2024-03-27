
namespace MarketApp
{
    partial class UnidadMedida
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
            this.buttonUnid = new System.Windows.Forms.Button();
            this.textBoxAbrevia = new System.Windows.Forms.TextBox();
            this.textBoxNombreUni = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonUnid
            // 
            this.buttonUnid.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonUnid.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUnid.Location = new System.Drawing.Point(159, 127);
            this.buttonUnid.Name = "buttonUnid";
            this.buttonUnid.Size = new System.Drawing.Size(248, 32);
            this.buttonUnid.TabIndex = 19;
            this.buttonUnid.Text = "AÑADIR UNIDAD";
            this.buttonUnid.UseVisualStyleBackColor = false;
            this.buttonUnid.Click += new System.EventHandler(this.buttonUnid_Click);
            // 
            // textBoxAbrevia
            // 
            this.textBoxAbrevia.Location = new System.Drawing.Point(315, 77);
            this.textBoxAbrevia.Name = "textBoxAbrevia";
            this.textBoxAbrevia.Size = new System.Drawing.Size(92, 31);
            this.textBoxAbrevia.TabIndex = 16;
            // 
            // textBoxNombreUni
            // 
            this.textBoxNombreUni.Location = new System.Drawing.Point(159, 77);
            this.textBoxNombreUni.Name = "textBoxNombreUni";
            this.textBoxNombreUni.Size = new System.Drawing.Size(126, 31);
            this.textBoxNombreUni.TabIndex = 15;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(55, 98);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(32, 31);
            this.textBox1.TabIndex = 14;
            this.textBox1.Text = "Automatico";
            this.textBox1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(311, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "ABREVIATURA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "NOMBRE DE MEDIDA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "ID";
            this.label1.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(58, 269);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(547, 228);
            this.dataGridView1.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.buttonUnid);
            this.groupBox1.Controls.Add(this.textBoxAbrevia);
            this.groupBox1.Controls.Add(this.textBoxNombreUni);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(58, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 195);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "UNIDAD DE  MEDIDA";
            // 
            // UnidadMedida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 510);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UnidadMedida";
            this.Text = "                                          REGISTRO DE UNIDAD DE MEDIDA";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonUnid;
        private System.Windows.Forms.TextBox textBoxAbrevia;
        private System.Windows.Forms.TextBox textBoxNombreUni;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}