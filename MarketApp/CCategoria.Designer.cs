
namespace MarketApp
{
    partial class CCategoria
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
            this.textDESCRICAT = new System.Windows.Forms.TextBox();
            this.textNOMBRECAT = new System.Windows.Forms.TextBox();
            this.textID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCat = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textDESCRICAT
            // 
            this.textDESCRICAT.Location = new System.Drawing.Point(284, 55);
            this.textDESCRICAT.Multiline = true;
            this.textDESCRICAT.Name = "textDESCRICAT";
            this.textDESCRICAT.Size = new System.Drawing.Size(164, 29);
            this.textDESCRICAT.TabIndex = 11;
            // 
            // textNOMBRECAT
            // 
            this.textNOMBRECAT.Location = new System.Drawing.Point(113, 56);
            this.textNOMBRECAT.Multiline = true;
            this.textNOMBRECAT.Name = "textNOMBRECAT";
            this.textNOMBRECAT.Size = new System.Drawing.Size(143, 28);
            this.textNOMBRECAT.TabIndex = 10;
            // 
            // textID
            // 
            this.textID.Location = new System.Drawing.Point(53, 54);
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(24, 31);
            this.textID.TabIndex = 9;
            this.textID.Text = "Automatico";
            this.textID.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(280, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "DESCRIPCION";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(109, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "NOMBRE CATEGORIA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "ID";
            this.label1.Visible = false;
            // 
            // buttonCat
            // 
            this.buttonCat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonCat.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCat.Location = new System.Drawing.Point(193, 100);
            this.buttonCat.Name = "buttonCat";
            this.buttonCat.Size = new System.Drawing.Size(150, 41);
            this.buttonCat.TabIndex = 12;
            this.buttonCat.Text = "AÑADIR CATEGORIA";
            this.buttonCat.UseVisualStyleBackColor = false;
            this.buttonCat.Click += new System.EventHandler(this.buttonCat_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(45, 215);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(536, 156);
            this.dataGridView1.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.buttonCat);
            this.groupBox1.Controls.Add(this.textDESCRICAT);
            this.groupBox1.Controls.Add(this.textNOMBRECAT);
            this.groupBox1.Controls.Add(this.textID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(45, 26);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(536, 158);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CATEGORIAS";
            // 
            // CCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 386);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CCategoria";
            this.Text = "                                                                   REGISTRO DE CA" +
    "TEGORIA";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textDESCRICAT;
        private System.Windows.Forms.TextBox textNOMBRECAT;
        private System.Windows.Forms.TextBox textID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCat;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}