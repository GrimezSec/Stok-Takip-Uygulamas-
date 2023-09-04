using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace stokDeneme
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\urun.mdf;Integrated Security=True");

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Ürün adı boş olmamalı
            if (string.IsNullOrEmpty(txturunadi.Text))
            {
                MessageBox.Show("Ürün adı boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Fiyat geçerli bir sayı olmalı
            if (!decimal.TryParse(txtfiyat.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal fiyat) || fiyat <= 0)
            {
                MessageBox.Show("Geçerli bir fiyat giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Stok miktarı geçerli bir sayı olmalı
            if (!decimal.TryParse(txtstok.Text, out decimal stok) || stok < 0)
            {
                MessageBox.Show("Geçerli bir stok miktarı giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Table_1(UrunAdi,UrunFiyat,UrunStok) values(@Urunadi,@UrunFiyat,@UrunStok)", baglanti);
            komut.Parameters.AddWithValue("@UrunAdi", txturunadi.Text);
            // Noktalı değerlere dönüştürmek için CultureInfo.InvariantCulture kullanın

            komut.Parameters.AddWithValue("@UrunFiyat", Convert.ToDecimal(txtfiyat.Text.Replace(",", "."), CultureInfo.InvariantCulture));
            komut.Parameters.AddWithValue("@UrunStok", txtstok.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Ürün Eklendi");
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            this.Close();
        }
    }
}