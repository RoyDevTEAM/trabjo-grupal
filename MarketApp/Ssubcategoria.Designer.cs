
namespace MarketApp
{
    partial class Ssubcategoria
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxNombreSub = new System.Windows.Forms.TextBox();
            this.textBoxDescriSub = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AñadirCategoria = new System.Windows.Forms.Button();
            this.buttonSubCAT = new System.Windows.Forms.Button();
            this.comboBoxCat = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBusque = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "NOMBRE SUBCATEGORIA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(350, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "DESCRIPCION";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(57, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(33, 31);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Automatico";
            this.textBox1.Visible = false;
            // 
            // textBoxNombreSub
            // 
            this.textBoxNombreSub.Location = new System.Drawing.Point(139, 64);
            this.textBoxNombreSub.Multiline = true;
            this.textBoxNombreSub.Name = "textBoxNombreSub";
            this.textBoxNombreSub.Size = new System.Drawing.Size(197, 30);
            this.textBoxNombreSub.TabIndex = 4;
            // 
            // textBoxDescriSub
            // 
            this.textBoxDescriSub.Location = new System.Drawing.Point(354, 64);
            this.textBoxDescriSub.Name = "textBoxDescriSub";
            this.textBoxDescriSub.Size = new System.Drawing.Size(195, 31);
            this.textBoxDescriSub.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "CATEGORIA";
            // 
            // AñadirCategoria
            // 
            this.AñadirCategoria.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.AñadirCategoria.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AñadirCategoria.Location = new System.Drawing.Point(311, 140);
            this.AñadirCategoria.Name = "AñadirCategoria";
            this.AñadirCategoria.Size = new System.Drawing.Size(25, 32);
            this.AñadirCategoria.TabIndex = 8;
            this.AñadirCategoria.Text = "+";
            this.AñadirCategoria.UseVisualStyleBackColor = false;
            this.AñadirCategoria.Click += new System.EventHandler(this.AñadirCategoria_Click);
            // 
            // buttonSubCAT
            // 
            this.buttonSubCAT.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonSubCAT.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubCAT.Location = new System.Drawing.Point(354, 141);
            this.buttonSubCAT.Name = "buttonSubCAT";
            this.buttonSubCAT.Size = new System.Drawing.Size(195, 31);
            this.buttonSubCAT.TabIndex = 9;
            this.buttonSubCAT.Text = "AÑADIR SUBCATEGORIA";
            this.buttonSubCAT.UseVisualStyleBackColor = false;
            this.buttonSubCAT.Click += new System.EventHandler(this.buttonSubCAT_Click);
            // 
            // comboBoxCat
            // 
            this.comboBoxCat.FormattingEnabled = true;
            this.comboBoxCat.Location = new System.Drawing.Point(139, 141);
            this.comboBoxCat.Name = "comboBoxCat";
            this.comboBoxCat.Size = new System.Drawing.Size(166, 31);
            this.comboBoxCat.TabIndex = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(44, 305);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(643, 169);
            this.dataGridView1.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.comboBoxCat);
            this.groupBox1.Controls.Add(this.buttonSubCAT);
            this.groupBox1.Controls.Add(this.AñadirCategoria);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxDescriSub);
            this.groupBox1.Controls.Add(this.textBoxNombreSub);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(44, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(643, 222);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SUBCATEGORIAS";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBusque);
            this.groupBox2.Location = new System.Drawing.Point(44, 267);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(643, 207);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BUSQUEDA";
            // 
            // textBusque
            // 
            this.textBusque.Location = new System.Drawing.Point(103, -2);
            this.textBusque.Name = "textBusque";
            this.textBusque.Size = new System.Drawing.Size(176, 31);
            this.textBusque.TabIndex = 0;
            this.textBusque.TextChanged += new System.EventHandler(this.textBusque_TextChanged);
            // 
            // Ssubcategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 501);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Ssubcategoria";
            this.Text = "                                                     REGISTRO DE SUBCATEGORIA";
            this.Load += new System.EventHandler(this.Ssubcategoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBoxNombreSub;
        private System.Windows.Forms.TextBox textBoxDescriSub;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AñadirCategoria;
        private System.Windows.Forms.Button buttonSubCAT;
        private System.Windows.Forms.ComboBox comboBoxCat;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBusque;
    }
}