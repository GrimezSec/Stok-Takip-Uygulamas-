using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace stokDeneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\urun.mdf;Integrated Security=True");
        DataSet daset = new DataSet();
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 ekle = new Form2();
            ekle.ShowDialog();
            daset.Tables["Table_1"].Clear();
            urun_goster();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            urun_goster();

            this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 22);
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }

        private void urun_goster()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from Table_1", baglanti);
            adtr.Fill(daset, "Table_1");
            dataGridView1.DataSource = daset.Tables["Table_1"];
            // DataGridView'da fiyat sütununun formatını ayarlayarak ondalık kısmın görüntülenmesini sağlayın

            baglanti.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txturunadi.Text = dataGridView1.CurrentRow.Cells["UrunAdi"].Value.ToString();
            txtfiyat.Text = dataGridView1.CurrentRow.Cells["UrunFiyat"].Value.ToString();
            txtstok.Text = dataGridView1.CurrentRow.Cells["UrunStok"].Value.ToString();
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToDeleteRows = false;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToDeleteRows = false;

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            string urunAdi = txturunadi.Text;

            if (!IsProductExist(urunAdi))
            {
                MessageBox.Show("Güncellenmek istenen ürün veritabanında bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidInput())
            {
                MessageBox.Show("Geçerli bir fiyat ve stok miktarı giriniz.");
                return;
            }

            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Table_1 set UrunFiyat=@UrunFiyat, UrunStok=@UrunStok where UrunAdi=@UrunAdi", baglanti);
            komut.Parameters.AddWithValue("@UrunAdi", txturunadi.Text);
            komut.Parameters.AddWithValue("@UrunFiyat", decimal.Parse(txtfiyat.Text));

            int stokMiktar = 0;

            if (!string.IsNullOrEmpty(txtstok.Text))
            {
                if (txtstok.Text.Contains("+") || txtstok.Text.Contains("-"))
                {
                    try
                    {
                        stokMiktar = Convert.ToInt32(new DataTable().Compute(txtstok.Text, null));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Geçerli bir matematiksel ifade girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglanti.Close();
                        return;
                    }
                }
                else
                {
                    stokMiktar = int.Parse(txtstok.Text);
                }
            }

            komut.Parameters.AddWithValue("@UrunStok", stokMiktar);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["Table_1"].Clear();
            urun_goster();
            MessageBox.Show("Ürün Güncellendi");

            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }


        private bool IsNullOrWhiteSpace(string value)
        {
            if (value == null)
                return true;

            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsWhiteSpace(value[i]))
                    return false;
            }

            return true;
        }


        private bool IsValidInput()
        {
            // Fiyat alanına yalnızca sayısal değer girilip girilmediğini kontrol et
            if (!decimal.TryParse(txtfiyat.Text, out _))
                return false;

            // Stok miktarını kontrol et
            if (txtstok.Text.Trim() == "") // Boş veya boşluk karakterlerinden oluşuyorsa
                return false;

            // Stok miktarının geçerli bir sayı veya matematiksel ifade olup olmadığını kontrol et
            try
            {
                int stokMiktar;
                if (int.TryParse(txtstok.Text, out stokMiktar)) // Eğer doğrudan tam sayı ise
                {
                    return true; // Geçerli giriş
                }
                else // Değilse, matematiksel ifade olup olmadığını kontrol et
                {
                    stokMiktar = Convert.ToInt32(new DataTable().Compute(txtstok.Text, null));
                    return true; // Geçerli giriş
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        private bool IsProductExist(string urunAdi)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT COUNT(*) FROM Table_1 WHERE UrunAdi=@UrunAdi", baglanti);
            komut.Parameters.AddWithValue("@UrunAdi", urunAdi);
            int productCount = Convert.ToInt32(komut.ExecuteScalar());
            baglanti.Close();

            return productCount > 0;
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Table_1 where UrunAdi='" + dataGridView1.CurrentRow.Cells["UrunAdi"].Value.ToString() + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["Table_1"].Clear();
            urun_goster();
            MessageBox.Show("Ürün Silindi.");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 ekle = new Form3();
            ekle.ShowDialog();
            daset.Tables["Table_1"].Clear();
            urun_goster();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 ekle = new Form4();
            ekle.ShowDialog();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "UrunFiyat")
            {
                // Hücredeki değeri al
                object value = e.Value;
                if (value != null && decimal.TryParse(value.ToString(), out decimal UrunFiyat))
                {
                    // Değeri ₺ ile birleştir ve DataGridView'e eşitle
                    e.Value = UrunFiyat.ToString("C2");
                    e.FormattingApplied = true; // Biçimlendirmenin uygulandığını işaretle
                }
            }

            if (e.RowIndex >= 0) // Geçerli bir satır dizini olup olmadığını kontrol edin
            {
                string columnName = "UrunStok"; // Bunu DataGridView'ünüzdeki stok miktarını tutan gerçek sütun adıyla değiştir

                if (dataGridView1.Columns[e.ColumnIndex].Name == columnName)
                {
                    //Stok miktarı sütununun değerini alır
                    object stockValue = e.Value;
                    if (stockValue != null && int.TryParse(stockValue.ToString(), out int stockQuantity))
                    {
                        //Stok miktarını karşılaştırın ve satır rengini buna göre ayarlayın
                        if (stockQuantity <= 0)
                        {
                            e.CellStyle.BackColor = Color.Red;
                        }
                        else if (stockQuantity <= 5)
                        {
                            e.CellStyle.BackColor = Color.Yellow;
                        }
                        else
                        {
                            // Hücre rengini varsayılan değere sıfırlayın
                            e.CellStyle.BackColor = dataGridView1.DefaultCellStyle.BackColor;
                        }
                    }
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

      

        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
{
    if (dataGridView1.Columns[e.ColumnIndex].Name == "UrunFiyat")
    {
        if (e.Value != null && decimal.TryParse(e.Value.ToString().Replace(",", ""), NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal UrunFiyat))
        {
            e.Value = UrunFiyat;
            e.ParsingApplied = true; // Dönüştürmenin uygulandığını işaretle
        }
    }
}

        private void button4_Click(object sender, EventArgs e)
        {
            string mesaj = "Nasıl Kullanılır?\n\n" +
                           "Ana Ekran:\n" +
                           "\u2022 Ana ekranda mevcut ürün ve stok bilgilerinizi görebilirsiniz.\n" +
                           "\u2022 Ürünleri güncellemek için bir ürüne çift tıklayarak sağ taraftaki güncelleme kısmını kullanabilirsiniz.\n" +
                           "\u2022 Yeni ürün eklemek, satış yapmak veya rapor almak için alt kısımdaki butonları kullanabilirsiniz.\n\n" +
                           "Ürün Güncelleme:\n" +
                           "\u2022 Ürünlerin fiyatını veya stok bilgilerini güncellemek için ana ekrandaki bir ürüne çift tıklayın.\n" +
                           "\u2022 Sağda yer alan güncelleme penceresinde istediğiniz değişiklikleri yapın ve \"Güncelle\" butonuna tıklayın.\n" +
                           "\u2022 Ürününüzün bilgileri güncellenerek kullanıma hazır olur.\n\n" +
                           "Ürün Ekleme:\n" +
                           "\u2022 Ana ekrandaki \"Ürün Ekle\" butonuna tıklayın.\n" +
                           "\u2022 Açılan pencerede yeni ürününüzün bilgilerini girin (örn. ürün adı, fiyatı, stok miktarı vb.).\n" +
                           "\u2022 \"Ürün Ekle\" butonuna tıklayarak ürününüzü stoğunuza kaydedin.\n\n" +
                           "Satış:\n" +
                           "\u2022 Ana ekrandaki \"Satış\" butonuna tıklayarak satış ekranını açın.\n" +
                           "\u2022 Sol tarafta sahip olduğunuz ürünleri görüntüleyebilir ve sepetinize ekleyebilirsiniz.\n" +
                           "\u2022 Ürünleri sepete ekledikten sonra \"Satışı Tamamla\" butonuna tıklayarak satış işlemini tamamlayın.\n" +
                           "\u2022 Sepete birden fazla ürün ekleyebilir veya sepetten ürün çıkartabilirsiniz.\n\n" +
                           "Rapor:\n" +
                           "\u2022 Ana ekrandaki \"Rapor\" butonuna tıklayarak rapor ekranını açın.\n" +
                           "\u2022 Yapılmış satış işlemlerini görüntüleyebilir ve isterseniz raporu temizleyebilirsiniz.\n\n" +
                           "Geliştiriciler: Akın Demir / Berke Can Kınay";

            MessageBox.Show(mesaj, "Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       
    }
    }
    


