namespace stokDeneme
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewSepet = new System.Windows.Forms.DataGridView();
            this.txturunadi = new System.Windows.Forms.TextBox();
            this.btnSepeteEkle = new System.Windows.Forms.Button();
            this.numUpDownAdet = new System.Windows.Forms.NumericUpDown();
            this.btnSatisTamamla = new System.Windows.Forms.Button();
            this.lblToplamFiyat = new System.Windows.Forms.Label();
            this.btnSepettenCikar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSepet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownAdet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.SlateGray;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(42, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(438, 387);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // dataGridViewSepet
            // 
            this.dataGridViewSepet.AllowUserToAddRows = false;
            this.dataGridViewSepet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSepet.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridViewSepet.BackgroundColor = System.Drawing.Color.SlateGray;
            this.dataGridViewSepet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSepet.Location = new System.Drawing.Point(681, 12);
            this.dataGridViewSepet.Name = "dataGridViewSepet";
            this.dataGridViewSepet.RowHeadersVisible = false;
            this.dataGridViewSepet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSepet.Size = new System.Drawing.Size(438, 387);
            this.dataGridViewSepet.TabIndex = 1;
            this.dataGridViewSepet.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSepet_CellContentClick);
            this.dataGridViewSepet.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewSepet_CellFormatting);
            // 
            // txturunadi
            // 
            this.txturunadi.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txturunadi.Location = new System.Drawing.Point(42, 432);
            this.txturunadi.Name = "txturunadi";
            this.txturunadi.Size = new System.Drawing.Size(257, 40);
            this.txturunadi.TabIndex = 2;
            this.txturunadi.ReadOnlyChanged += new System.EventHandler(this.txturunadi_ReadOnlyChanged);
            this.txturunadi.TextChanged += new System.EventHandler(this.txturunadi_TextChanged);
            // 
            // btnSepeteEkle
            // 
            this.btnSepeteEkle.BackColor = System.Drawing.Color.Lavender;
            this.btnSepeteEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSepeteEkle.Location = new System.Drawing.Point(42, 499);
            this.btnSepeteEkle.Name = "btnSepeteEkle";
            this.btnSepeteEkle.Size = new System.Drawing.Size(201, 67);
            this.btnSepeteEkle.TabIndex = 3;
            this.btnSepeteEkle.Text = "Sepete Ekle ";
            this.btnSepeteEkle.UseVisualStyleBackColor = false;
            this.btnSepeteEkle.Click += new System.EventHandler(this.btnSepeteEkle_Click_1);
            // 
            // numUpDownAdet
            // 
            this.numUpDownAdet.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.numUpDownAdet.Location = new System.Drawing.Point(360, 432);
            this.numUpDownAdet.Name = "numUpDownAdet";
            this.numUpDownAdet.Size = new System.Drawing.Size(120, 40);
            this.numUpDownAdet.TabIndex = 4;
            // 
            // btnSatisTamamla
            // 
            this.btnSatisTamamla.BackColor = System.Drawing.Color.GreenYellow;
            this.btnSatisTamamla.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSatisTamamla.Location = new System.Drawing.Point(455, 499);
            this.btnSatisTamamla.Name = "btnSatisTamamla";
            this.btnSatisTamamla.Size = new System.Drawing.Size(261, 67);
            this.btnSatisTamamla.TabIndex = 5;
            this.btnSatisTamamla.Text = "Satışı Tamamla";
            this.btnSatisTamamla.UseVisualStyleBackColor = false;
            this.btnSatisTamamla.Click += new System.EventHandler(this.btnSatisTamamla_Click_1);
            // 
            // lblToplamFiyat
            // 
            this.lblToplamFiyat.AutoSize = true;
            this.lblToplamFiyat.BackColor = System.Drawing.Color.Transparent;
            this.lblToplamFiyat.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamFiyat.ForeColor = System.Drawing.Color.White;
            this.lblToplamFiyat.Location = new System.Drawing.Point(674, 429);
            this.lblToplamFiyat.Name = "lblToplamFiyat";
            this.lblToplamFiyat.Size = new System.Drawing.Size(0, 39);
            this.lblToplamFiyat.TabIndex = 6;
            // 
            // btnSepettenCikar
            // 
            this.btnSepettenCikar.BackColor = System.Drawing.Color.Tomato;
            this.btnSepettenCikar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSepettenCikar.Location = new System.Drawing.Point(898, 499);
            this.btnSepettenCikar.Name = "btnSepettenCikar";
            this.btnSepettenCikar.Size = new System.Drawing.Size(217, 67);
            this.btnSepettenCikar.TabIndex = 7;
            this.btnSepettenCikar.Text = "Sepetten Çıkar";
            this.btnSepettenCikar.UseVisualStyleBackColor = false;
            this.btnSepettenCikar.Click += new System.EventHandler(this.btnSepettenCikar_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::stokDeneme.Properties.Resources.back41;
            this.ClientSize = new System.Drawing.Size(1145, 594);
            this.Controls.Add(this.btnSepettenCikar);
            this.Controls.Add(this.lblToplamFiyat);
            this.Controls.Add(this.btnSatisTamamla);
            this.Controls.Add(this.numUpDownAdet);
            this.Controls.Add(this.btnSepeteEkle);
            this.Controls.Add(this.txturunadi);
            this.Controls.Add(this.dataGridViewSepet);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.Text = "Satış";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSepet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownAdet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridViewSepet;
        private System.Windows.Forms.TextBox txturunadi;
        private System.Windows.Forms.Button btnSepeteEkle;
        private System.Windows.Forms.NumericUpDown numUpDownAdet;
        private System.Windows.Forms.Button btnSatisTamamla;
        private System.Windows.Forms.Label lblToplamFiyat;
        private System.Windows.Forms.Button btnSepettenCikar;
    }
}