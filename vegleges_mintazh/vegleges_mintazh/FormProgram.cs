using CsvHelper;
using System.ComponentModel;
using System.Diagnostics.PerformanceData;
using System.Formats.Asn1;
using System.Globalization;

namespace vegleges_mintazh
{
    public partial class FormProgram : Form
    {
        BindingList<Versenyz�k> versenyzok = new();
        public FormProgram()
        {
            InitializeComponent();
            // dataGridView1.DataSource = versenyzok;
            versenyz�kBindingSource.DataSource = versenyzok;

        }

        private void betoltes_Click(object sender, EventArgs e)
        {

            try
            {
                StreamReader sr = new StreamReader("futoversenyzok.txt");
                var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
                var t�mb = csv.GetRecords<Versenyz�k>();

                foreach (var item in t�mb)
                {
                    versenyzok.Add(item);
                }

                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mentes_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                    var csv = new CsvWriter(sw, CultureInfo.InvariantCulture);
                    csv.WriteRecords(versenyzok);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void torles_Click(object sender, EventArgs e)
        {
            if (versenyz�kBindingSource.Current == null) return;

            if (MessageBox.Show("Biztosan szeretn� t�r�lni a kijel�lt sort?", "Nem t�rl�m.", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                versenyz�kBindingSource.RemoveCurrent();
            }
        }

        private void ujsor_Click(object sender, EventArgs e)
        {
            
            if (versenyz�kBindingSource.Current == null) return;
            �jsor ujsor = new �jsor();
            ujsor.Versenyz�k = (Versenyz�k)versenyz�kBindingSource.AddNew();
            ujsor.Show();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            int usaversenyzok = GetCompetitorsFromCountry("USA");
            string leggyorsabb = GetFastestCompetitorOverall();

            string message = $"Amerikai versenyz�k sz�ma: {usaversenyzok}\n" +
                     $"Legjobb id�t fut� versenyz�: {leggyorsabb}";

            MessageBox.Show(message, "Verseny statisztika", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private int GetCompetitorsFromCountry(string orszag)
        {
            
            int count = 0;

            foreach (var competitor in versenyzok) 
            {
                if (competitor.Nemzetiseg == orszag)
                {
                    count++;
                }
            }

            return count;
        }
        private string GetFastestCompetitorOverall()
        {
           
            string fastestCompetitorName = "Nincs adat";

            
            double minTime = double.MaxValue;

            foreach (var competitor in versenyzok) 
            {
                if (competitor.EredmenyPerc < minTime)
                {
                    minTime = competitor.EredmenyPerc;
                    fastestCompetitorName = competitor.Nev;
                }
            }

            return fastestCompetitorName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (versenyz�kBindingSource.Current == null) return;
            FormSzerkeszt�s fce = new FormSzerkeszt�s();
            fce.Verseny = versenyz�kBindingSource.Current as Versenyz�k;
            fce.Show();



        }
    }
}
