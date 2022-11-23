using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pasta_La_Vista
{
    public partial class Fizetes : UserControl
    {
        MySqlDataAdapter adapter;
        MySqlDataAdapter adapter2;
        string connectionString = "datasource=localhost;port=3306;username=root;database=pastalavista;";


        public Fizetes()
        {
            InitializeComponent();
        }

        private void Fizetes_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource1;
            dataGridView2.DataSource = bindingSource2;
            GetRendelesDatas(connectionString);
            poszt.ScrollBars = ScrollBars.Vertical;
        }
        public void GetRendelesDatas(string connectionString)
        {
            try
            {
                adapter = new MySqlDataAdapter("SELECT `rendelesszam` AS 'Rendelés_szám', ugyfelek.nev AS 'Ügyfél_név', pizzak.nev AS 'Pizza_név', meretszam AS 'Méret_szám', fizetes.fizetestipus AS 'Fizetés_típus', osszar AS 'Össz_ár', fizetve AS 'Fizetve' FROM `rendelesek` LEFT JOIN ugyfelek ON rendelesek.ugyfelkod = ugyfelek.ugyfelkod LEFT JOIN pizzak ON rendelesek.pizzaid = pizzak.pizzaid LEFT JOIN fizetes ON rendelesek.fizetesid = fizetes.id WHERE pizzak.nev IS NOT NULL;", connectionString);
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(adapter);

                DataTable table = new DataTable();
                adapter.Fill(table);
                bindingSource1.DataSource = table;

            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
                throw;
            }
        }
        public void HiddenRendelesDatas(string connectionString, string keres)
        {
            adapter2 = new MySqlDataAdapter($"SELECT `rendelesszam`, ugyfelek.nev, pizzak.nev, feltetek.nev, pizzak.feltetek_ara, rendelesek.meretszam, meret.ar, osszar FROM `rendelesek` LEFT JOIN ugyfelek ON rendelesek.ugyfelkod = ugyfelek.ugyfelkod LEFT JOIN pizzak ON rendelesek.pizzaid = pizzak.pizzaid LEFT JOIN meret on rendelesek.meretszam = meret.meretszam LEFT JOIN fizetes ON rendelesek.fizetesid = fizetes.id LEFT JOIN pizza_feltet ON pizzak.pizzaid = pizza_feltet.pizzaid LEFT JOIN feltetek ON pizza_feltet.feltetid = feltetek.feltetid WHERE rendelesek.rendelesszam = {keres};", connectionString);
            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(adapter2);

            DataTable table = new DataTable();
            adapter2.Fill(table);
            bindingSource2.DataSource = table;
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (bindingSource1.DataSource != null)
            {
                adapter.Update((DataTable)bindingSource1.DataSource);
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 125;
                dataGridView1.Columns[3].Width = 40;
                dataGridView1.Columns[4].Width = 75;
                dataGridView1.Columns[5].Width = 50;
                dataGridView1.Columns[6].Width = 60;

            }
        }
        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (bindingSource2.DataSource != null)
            {
                adapter2.Update((DataTable)bindingSource2.DataSource);
            }
        }

        private void kereses_TextChanged(object sender, EventArgs e)
        {
            var text = kereses.Text;
            if (int.TryParse(text, out int value))
            {
                bindingSource1.Filter = $"Convert(Rendelés_Szám, 'System.String') Like '*{text}*'";
            }
            else
            {
                bindingSource1.Filter = $"`Ügyfél_Név` LIKE '*{text}*' OR `Pizza_Név` LIKE '*{text}*'";
            }
            bindingSource1.Sort = "Rendelés_Szám ASC";
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                fizetendo.Text = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                tipus.Text = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                fizetett.Text = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                string keresendoszam = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                HiddenRendelesDatas(connectionString, keresendoszam);

                string trend = dataGridView2.Rows[0].Cells[0].Value + string.Empty;
                string tnev = dataGridView2.Rows[0].Cells[1].Value + string.Empty;
                string tpizza = dataGridView2.Rows[0].Cells[2].Value + string.Empty;
                string tfeltet = "";
                for (int i = 0; i < dataGridView2.Rows.Count-1; i++)
                {
                    tfeltet += $"    -{dataGridView2.Rows[i].Cells[3].Value + string.Empty},\r\n";
                }
                string tfar = dataGridView2.Rows[0].Cells[4].Value + string.Empty;
                string meretszam = dataGridView2.Rows[0].Cells[5].Value + string.Empty;
                string meretar = dataGridView2.Rows[0].Cells[6].Value + string.Empty;
                string osszar = dataGridView2.Rows[0].Cells[7].Value + string.Empty;

                poszt.Text = $"-------------------------------------\r\n" +
                    $"Rendelés szám: {trend}\r\nÜgyfél neve: {tnev}" +
                    $"\r\n-------------------------------------\r\n" +
                    $"Rendelt pizzája: {tpizza}\r\n" +
                    $"Pizza feltétei:\r\n{tfeltet}\r\n" +
                    $"Feltétek ára: {tfar}\r\n" +
                    $"-------------------------------------\r\n" +
                    $"Kívánt méret: {meretszam} cm\r\n" +
                    $"Méret ára: {meretar}\r\n" +
                    $"-------------------------------------\r\n" +
                    $"Fizetendő: {osszar}\r\n" +
                    $"-------------------------------------";
            }
        }

        private void tartalomtorles_Click(object sender, EventArgs e)
        {
            poszt.Text = "";
            fizetendo.Text = "";
            tipus.Text = "";
            fizetett.Text = "";
            //gomb funckiokat megcsinálni
        }

        
    }
}
