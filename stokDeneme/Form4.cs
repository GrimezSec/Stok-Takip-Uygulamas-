using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace stokDeneme
{
    public partial class Form4 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\urun.mdf;Integrated Security=True");


        public Form4()
        {
            InitializeComponent();
        }



        private void VerileriGetir()
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();

            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT Tarih, UrunAdi, SUM(Adet) AS Adet, BirimFiyat, SUM(ToplamFiyat) AS ToplamFiyat FROM Satışlar GROUP BY Tarih, UrunAdi, BirimFiyat ORDER BY Tarih", baglanti);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable raporTablosu = new DataTable();
                adapter.Fill(raporTablosu);
                dataGridViewRapor.DataSource = raporTablosu;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler alınırken bir hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void ToplamFiyatHesapla()
        {
            decimal toplamFiyat = 0;

            // DataGridView'deki tüm satırları dönerek toplam fiyatı hesapla
            foreach (DataGridViewRow row in dataGridViewRapor.Rows)
            {
                // DataGridView'deki ToplamFiyat hücresindeki değeri al
                object value = row.Cells["ToplamFiyat"].Value;

                if (value != null && decimal.TryParse(value.ToString(), out decimal satirFiyat))
                {
                    toplamFiyat += satirFiyat;
                }
            }

            // Hesaplanan toplam fiyatı Label'a yazdır
            labelToplamSatisFiyati.Text = "Toplam Satış Fiyatı: " + toplamFiyat.ToString("C2");
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.dataGridViewRapor.DefaultCellStyle.Font = new Font("Tahoma", 20);
            dataGridViewRapor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewRapor.CellFormatting += dataGridViewRapor_CellFormatting;
            VerileriGetir();
            // Form yüklendiğinde toplam fiyatı hesaplayarak Label'a yazdır
            ToplamFiyatHesapla();

        }

        private void dataGridViewRapor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewRapor.ReadOnly = true;
            dataGridViewRapor.AllowUserToDeleteRows = false;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {

            baglanti.Open();

            // Satışlar tablosundaki tüm satırları silme sorgusu
            SqlCommand komut = new SqlCommand("DELETE FROM Satışlar", baglanti);
            komut.ExecuteNonQuery();

            // Verileri tekrar çekerek DataGridView'ı güncelleme
            VerileriGetir();

            // ToplamSatışFiyati Label'ını sıfırlama
            labelToplamSatisFiyati.Text = "Toplam Satış Fiyatı: 0,00";

            MessageBox.Show("Satışlar tablosu başarıyla temizlendi.");
            baglanti.Close();

        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
        }

        private void dataGridViewRapor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewRapor.Columns[e.ColumnIndex].Name == "BirimFiyat")
            {
                // Hücredeki değeri al
                object value = e.Value;
                if (value != null && decimal.TryParse(value.ToString(), out decimal birimFiyat))
                {
                    // Değeri ₺ ile birleştir ve DataGridView'e eşitle
                    e.Value = birimFiyat.ToString("C2");
                    e.FormattingApplied = true; // Biçimlendirmenin uygulandığını işaretle
                }
            }
            if (dataGridViewRapor.Columns[e.ColumnIndex].Name == "ToplamFiyat")
            {
                // Hücredeki değeri al
                object value = e.Value;
                if (value != null && decimal.TryParse(value.ToString(), out decimal ToplamFiyat))
                {
                    // Değeri ₺ ile birleştir ve DataGridView'e eşitle
                    e.Value = ToplamFiyat.ToString("C2");
                    e.FormattingApplied = true; // Biçimlendirmenin uygulandığını işaretle
                }
            }
        }
    }
}

