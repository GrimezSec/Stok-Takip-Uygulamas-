namespace stokDeneme
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.dataGridViewRapor = new System.Windows.Forms.DataGridView();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.labelToplamSatisFiyati = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRapor)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRapor
            // 
            this.dataGridViewRapor.AllowUserToAddRows = false;
            this.dataGridViewRapor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRapor.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridViewRapor.BackgroundColor = System.Drawing.Color.SlateGray;
            this.dataGridViewRapor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRapor.Location = new System.Drawing.Point(22, 12);
            this.dataGridViewRapor.Name = "dataGridViewRapor";
            this.dataGridViewRapor.RowHeadersVisible = false;
            this.dataGridViewRapor.Size = new System.Drawing.Size(1232, 553);
            this.dataGridViewRapor.TabIndex = 0;
            this.dataGridViewRapor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRapor_CellContentClick);
            this.dataGridViewRapor.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewRapor_CellFormatting);
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.Color.Gold;
            this.btnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.Location = new System.Drawing.Point(22, 580);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(188, 73);
            this.btnTemizle.TabIndex = 1;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = false;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // labelToplamSatisFiyati
            // 
            this.labelToplamSatisFiyati.AutoSize = true;
            this.labelToplamSatisFiyati.BackColor = System.Drawing.Color.Transparent;
            this.labelToplamSatisFiyati.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelToplamSatisFiyati.ForeColor = System.Drawing.Color.White;
            this.labelToplamSatisFiyati.Location = new System.Drawing.Point(296, 598);
            this.labelToplamSatisFiyati.Name = "labelToplamSatisFiyati";
            this.labelToplamSatisFiyati.Size = new System.Drawing.Size(0, 39);
            this.labelToplamSatisFiyati.TabIndex = 2;
            // 
            // Form4
            // 
            this.BackgroundImage = global::stokDeneme.Properties.Resources.Rapor_Back_32;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1260, 677);
            this.Controls.Add(this.labelToplamSatisFiyati);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.dataGridViewRapor);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form4";
            this.Text = "Rapor";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRapor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRapor;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Label labelToplamSatisFiyati;
    }
}