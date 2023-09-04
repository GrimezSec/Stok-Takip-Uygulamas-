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
    public partial class Form3 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\urun.mdf;Integrated Security=True");
        DataSet daset = new DataSet();
        decimal toplamFiyat = 0;
        DataTable sepetDataTable = new DataTable();

        public Form3()
        {
            InitializeComponent();
            sepetDataTable.Columns.Add("UrunAdi", typeof(string));
            sepetDataTable.Columns.Add("Adet", typeof(decimal));
            sepetDataTable.Columns.Add("BirimFiyat", typeof(decimal));
            sepetDataTable.Columns.Add("ToplamFiyat", typeof(decimal));
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            urun_goster();
            this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 22);
            this.dataGridViewSepet.DefaultCellStyle.Font = new Font("Tahoma", 22);
            dataGridViewSepet.CellFormatting += dataGridViewSepet_CellFormatting;
            dataGridViewSepet.Columns.Add("UrunAdiSepet", "Ürün Adı");
            dataGridViewSepet.Columns.Add("AdetSepet", "Adet");
            dataGridViewSepet.Columns.Add("BirimFiyatSepet", "Birim Fiyat");
            dataGridViewSepet.Columns.Add("ToplamFiyatSepet", "Toplam Fiyat");
            // txtUrunadi TextBox'inin salt okunur özelliğini aktifleştir
            txturunadi.ReadOnly = true;
        }

        private void urun_goster()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from Table_1", baglanti);
            adtr.Fill(daset, "Table_1");
            dataGridView1.DataSource = daset.Tables["Table_1"];
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txturunadi.Text = dataGridView1.CurrentRow.Cells["UrunAdi"].Value.ToString();
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToDeleteRows = false;
        }

        private void btnSepeteEkle_Click(object sender, EventArgs e)
        {
            string urunAdi = txturunadi.Text;
            if (!string.IsNullOrEmpty(urunAdi) && numUpDownAdet.Value > 0)
            {
                decimal adet = numUpDownAdet.Value;
                decimal birimFiyat = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["UrunFiyat"].Value);
                decimal toplamUrunFiyati = adet * birimFiyat;

                // Sepet DataGridView'ına ürünleri ekle
                dataGridViewSepet.Rows.Add(urunAdi, adet, birimFiyat, toplamUrunFiyati);

                DataRow newRow = sepetDataTable.NewRow();
                newRow["UrunAdi"] = urunAdi;
                newRow["Adet"] = adet;
                newRow["BirimFiyat"] = birimFiyat;
                newRow["ToplamFiyat"] = toplamUrunFiyati;
                sepetDataTable.Rows.Add(newRow);

                // Toplam fiyatı güncelle
                toplamFiyat += toplamUrunFiyati;
                lblToplamFiyat.Text = "Toplam Fiyat: " + toplamFiyat.ToString("C2");
            }
            else
            {
                MessageBox.Show("Ürün adı boş olamaz ve adet 0'dan büyük olmalıdır.");
            }
        }

        private void btnSatisTamamla_Click(object sender, EventArgs e)
        {
            if (dataGridViewSepet.Rows.Count > 0)
            {
                // Sepetteki ürünleri stoktan düş
                foreach (DataGridViewRow row in dataGridViewSepet.Rows)
                {
                    if (row.Cells["UrunAdiSepet"].Value != null) // Null kontrolü yapılıyor.
                    {
                        string urunAdi3 = row.Cells["UrunAdiSepet"].Value.ToString();
                        decimal adet3 = Convert.ToDecimal(row.Cells["AdetSepet"].Value);

                        // Veritabanından stok miktarını kontrol etme işlemi
                        baglanti.Open();
                        SqlCommand stokKontrolKomut = new SqlCommand("SELECT UrunStok FROM Table_1 WHERE UrunAdi=@UrunAdi", baglanti);
                        stokKontrolKomut.Parameters.AddWithValue("@UrunAdi", urunAdi3);
                        decimal mevcutStok = Convert.ToDecimal(stokKontrolKomut.ExecuteScalar());
                        baglanti.Close();

                        // Eğer stok yeterliyse satış işlemini gerçekleştir
                        if (adet3 <= mevcutStok)
                        {
                            baglanti.Open();
                            SqlCommand komut = new SqlCommand("UPDATE Table_1 SET UrunStok=UrunStok-@Adet WHERE UrunAdi=@UrunAdi", baglanti);
                            komut.Parameters.AddWithValue("@Adet", adet3);
                            komut.Parameters.AddWithValue("@UrunAdi", urunAdi3);
                            komut.ExecuteNonQuery();
                            baglanti.Close();
                        }
                        else
                        {
                            MessageBox.Show($"{urunAdi3} ürününden yeterli stok bulunmamaktadır. Satış işlemi gerçekleştirilemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                // Sepeti temizle ve toplam fiyatı sıfırla
                dataGridViewSepet.Rows.Clear();
                toplamFiyat = 0;
                lblToplamFiyat.Text = "Toplam Fiyat: 0,00";
                if (sepetDataTable.Rows.Count > 0)
                {
                    baglanti.Open();
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(baglanti))
                    {
                        bulkCopy.DestinationTableName = "SepetTablosu";
                        bulkCopy.WriteToServer(sepetDataTable);
                    }
                    baglanti.Close();
                }
                sepetDataTable.Rows.Clear();

                MessageBox.Show("Satış Başarıyla Tamamlandı!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Sepette ürün bulunmamaktadır.");
            }
        
        DateTime tarih = DateTime.Now;
            string urunAdi = txturunadi.Text;
            decimal adet = numUpDownAdet.Value;
            decimal birimFiyat = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["UrunFiyat"].Value);
            decimal toplamUrunFiyati = adet * birimFiyat;

            // SQL sorgusuyla tabloya veri ekleme işlemi
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("INSERT INTO Satışlar (Tarih, UrunAdi, Adet, BirimFiyat, ToplamFiyat) VALUES (@Tarih, @UrunAdi, @Adet, @BirimFiyat, @ToplamFiyat)", baglanti);
            komut2.Parameters.AddWithValue("@Tarih", tarih);
            komut2.Parameters.AddWithValue("@UrunAdi", urunAdi);
            komut2.Parameters.AddWithValue("@Adet", adet);
            komut2.Parameters.AddWithValue("@BirimFiyat", birimFiyat);
            komut2.Parameters.AddWithValue("@ToplamFiyat", toplamUrunFiyati);
            komut2.ExecuteNonQuery();
            baglanti.Close();

            // Sepeti temizle ve toplam fiyatı sıfırla
            dataGridViewSepet.Rows.Clear();
            toplamFiyat = 0;
            lblToplamFiyat.Text = "Toplam Fiyat: 0,00";
            sepetDataTable.Rows.Clear();
            MessageBox.Show("Satış Başarıyla Tamamlandı!");
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txturunadi.Text = dataGridView1.CurrentRow.Cells["UrunAdi"].Value.ToString();
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToDeleteRows = false;
        }

        private void btnSepeteEkle_Click_1(object sender, EventArgs e)
        {
            string urunAdi = txturunadi.Text;
            if (!string.IsNullOrEmpty(urunAdi) && numUpDownAdet.Value > 0)
            {
                decimal adet = numUpDownAdet.Value;
                decimal birimFiyat = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["UrunFiyat"].Value);
                decimal toplamUrunFiyati = adet * birimFiyat;

                // Sepet DataGridView'ına ürünleri ekle
                dataGridViewSepet.Rows.Add(urunAdi, adet, birimFiyat, toplamUrunFiyati);

                DataRow newRow = sepetDataTable.NewRow();
                newRow["UrunAdi"] = urunAdi;
                newRow["Adet"] = adet;
                newRow["BirimFiyat"] = birimFiyat;
                newRow["ToplamFiyat"] = toplamUrunFiyati;
                sepetDataTable.Rows.Add(newRow);

                // Toplam fiyatı güncelle
                toplamFiyat += toplamUrunFiyati;
                lblToplamFiyat.Text = "Toplam Fiyat: " + toplamFiyat.ToString("C2");
            }
            else
            {
                MessageBox.Show("Ürün adı boş olamaz ve adet 0'dan büyük olmalıdır.");
            }
        }

        private void btnSatisTamamla_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewSepet.Rows.Count > 0)
            {
                // Sepetteki ürünleri stoktan düş ve satışları ayrı ayrı kaydet
                DateTime tarih = DateTime.Now;

                foreach (DataGridViewRow row in dataGridViewSepet.Rows)
                {
                    if (row.Cells["UrunAdiSepet"].Value != null) // Null kontrolü yapılıyor.
                    {
                        string urunAdi = row.Cells["UrunAdiSepet"].Value.ToString();
                        decimal adet = Convert.ToDecimal(row.Cells["AdetSepet"].Value);
                        decimal birimFiyat = Convert.ToDecimal(row.Cells["BirimFiyatSepet"].Value);
                        decimal toplamUrunFiyatiSatir = adet * birimFiyat;

                        // Veritabanından stok miktarını kontrol etme işlemi
                        baglanti.Open();
                        SqlCommand stokKontrolKomut = new SqlCommand("SELECT UrunStok FROM Table_1 WHERE UrunAdi=@UrunAdi", baglanti);
                        stokKontrolKomut.Parameters.AddWithValue("@UrunAdi", urunAdi);
                        decimal mevcutStok = Convert.ToDecimal(stokKontrolKomut.ExecuteScalar());
                        baglanti.Close();

                        // Eğer stok yeterliyse satış işlemini gerçekleştir
                        if (adet <= mevcutStok)
                        {
                            // Veritabanından stok düşürme işlemi
                            baglanti.Open();
                            SqlCommand komut = new SqlCommand("UPDATE Table_1 SET UrunStok=UrunStok-@Adet WHERE UrunAdi=@UrunAdi", baglanti);
                            komut.Parameters.AddWithValue("@Adet", adet);
                            komut.Parameters.AddWithValue("@UrunAdi", urunAdi);
                            komut.ExecuteNonQuery();
                            baglanti.Close();

                            // Veritabanına satışları ayrı ayrı ekleme işlemi
                            baglanti.Open();
                            SqlCommand komut2 = new SqlCommand("INSERT INTO Satışlar (Tarih, UrunAdi, Adet, BirimFiyat, ToplamFiyat) VALUES (@Tarih, @UrunAdi, @Adet, @BirimFiyat, @ToplamFiyat)", baglanti);
                            komut2.Parameters.AddWithValue("@Tarih", tarih);
                            komut2.Parameters.AddWithValue("@UrunAdi", urunAdi);
                            komut2.Parameters.AddWithValue("@Adet", adet);
                            komut2.Parameters.AddWithValue("@BirimFiyat", birimFiyat);
                            komut2.Parameters.AddWithValue("@ToplamFiyat", toplamUrunFiyatiSatir);
                            komut2.ExecuteNonQuery();
                            baglanti.Close();
                        }
                        else
                        {
                            MessageBox.Show($"{urunAdi} ürününden yeterli stok bulunmamaktadır. Satış işlemi gerçekleştirilemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                // Sepeti temizle ve toplam fiyatı sıfırla
                dataGridViewSepet.Rows.Clear();
                toplamFiyat = 0;
                lblToplamFiyat.Text = "Toplam Fiyat: 0,00";
                sepetDataTable.Rows.Clear();

                MessageBox.Show("Satış Başarıyla Tamamlandı!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Sepette ürün bulunmamaktadır.");
            }
        }

        private void btnSepettenCikar_Click(object sender, EventArgs e)
        {
            if (dataGridViewSepet.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewSepet.SelectedRows[0];
                string urunAdi = selectedRow.Cells["UrunAdiSepet"].Value.ToString();
                decimal adet = Convert.ToDecimal(selectedRow.Cells["AdetSepet"].Value);
                decimal birimFiyat = Convert.ToDecimal(selectedRow.Cells["BirimFiyatSepet"].Value);
                decimal toplamUrunFiyati = Convert.ToDecimal(selectedRow.Cells["ToplamFiyatSepet"].Value);

                // Sepet DataGridView'ından seçilen satırı çıkar
                dataGridViewSepet.Rows.Remove(selectedRow);

                // Sepet DataTable'dan seçilen satırı çıkar
                DataRow[] rowsToDelete = sepetDataTable.Select(string.Format("UrunAdi = '{0}' AND Adet = {1} AND BirimFiyat = {2} AND ToplamFiyat = {3}", urunAdi, adet.ToString(CultureInfo.InvariantCulture), birimFiyat.ToString(CultureInfo.InvariantCulture), toplamUrunFiyati.ToString(CultureInfo.InvariantCulture)));
                if (rowsToDelete.Length > 0)
                {
                    sepetDataTable.Rows.Remove(rowsToDelete[0]);
                }

                // Toplam fiyatı güncelle
                toplamFiyat -= toplamUrunFiyati;
                lblToplamFiyat.Text = "Toplam Fiyat: " + toplamFiyat.ToString("C2");

                MessageBox.Show("Ürün sepetten çıkarıldı.");
            }
            else
            {
                MessageBox.Show("Lütfen çıkarılacak bir ürün seçin.");
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dataGridView1.Columns[e.ColumnIndex].Name == "UrunFiyat")
            {
                // Hücredeki değeri al
                object value = e.Value;
                if (value != null && decimal.TryParse(value.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal UrunFiyat))
                {
                    // Değeri ₺ ile birleştir ve DataGridView'e eşitle
                    e.Value = UrunFiyat.ToString("C2", CultureInfo.GetCultureInfo("tr-TR"));
                    e.FormattingApplied = true; // Biçimlendirmenin uygulandığını işaretle
                }
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "UrunFiyat")
            {   
                // Hücredeki değeri al
                object value = e.Value;
                if (value != null && decimal.TryParse(value.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal UrunFiyat))
                {
                    // Değeri düzgün bir şekilde DataGridView'e eşitle
                    e.Value = UrunFiyat.ToString("0.00");
                    e.FormattingApplied = true; // Biçimlendirmenin uygulandığını işaretle
                }
            }
        }

        private void dataGridViewSepet_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


            if (dataGridViewSepet.Columns[e.ColumnIndex].Name == "BirimFiyatSepet")
            {
                // Hücredeki değeri al
                object value = e.Value;
                if (value != null && decimal.TryParse(value.ToString(), out decimal BirimFiyat))
                {
                    // Değeri ₺ ile birleştir ve DataGridView'e eşitle
                    e.Value = BirimFiyat.ToString("C2");
                    e.FormattingApplied = true; // Biçimlendirmenin uygulandığını işaretle
                }
            }

            if (dataGridViewSepet.Columns[e.ColumnIndex].Name == "ToplamFiyatSepet")
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

        private void dataGridViewSepet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewSepet.ReadOnly = true;
            dataGridViewSepet.AllowUserToDeleteRows = false;
        }

        private void txturunadi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txturunadi_ReadOnlyChanged(object sender, EventArgs e)
        {

        }
    }
}
