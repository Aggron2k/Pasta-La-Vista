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
        MySqlDataAdapter adapter, adapter2;
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
        private void Fizetes_VisibleChanged(object sender, EventArgs e)
        {
            GetRendelesDatas(connectionString);

            adapter = new MySqlDataAdapter("SELECT id,fizetestipus FROM fizetes", connectionString);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            tipus.DataSource = ds.Tables[0];
            tipus.ValueMember = "id";
            tipus.DisplayMember = "fizetestipus";
        }

        public void GetRendelesDatas(string connectionString)
        {
            try
            {
                adapter = new MySqlDataAdapter("SELECT `rendelesszam` AS 'Rendelés_szám', ugyfelek.nev AS 'Ügyfél_név', pizzak.nev AS 'Pizza_név', meretszam AS 'Méret_szám', fizetes.fizetestipus AS 'Fizetés_típus', osszar AS 'Össz_ár', fizetve AS 'Fizetve' FROM `rendelesek` LEFT JOIN ugyfelek ON rendelesek.ugyfelkod = ugyfelek.ugyfelkod LEFT JOIN pizzak ON rendelesek.pizzaid = pizzak.pizzaid LEFT JOIN fizetes ON rendelesek.fizetesid = fizetes.id WHERE pizzak.nev IS NOT NULL ORDER BY rendelesszam DESC;", connectionString);
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(adapter);

                DataTable table = new DataTable();
                adapter.Fill(table);
                bindingSource1.DataSource = table;

            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
        public void HiddenRendelesDatas(string connectionString, string keres)
        {
            try
            {
                adapter2 = new MySqlDataAdapter($"SELECT `rendelesszam`, ugyfelek.nev, pizzak.nev, feltetek.nev, pizzak.feltetek_ara, rendelesek.meretszam, meret.ar, osszar FROM `rendelesek` LEFT JOIN ugyfelek ON rendelesek.ugyfelkod = ugyfelek.ugyfelkod LEFT JOIN pizzak ON rendelesek.pizzaid = pizzak.pizzaid LEFT JOIN meret on rendelesek.meretszam = meret.meretszam LEFT JOIN fizetes ON rendelesek.fizetesid = fizetes.id LEFT JOIN pizza_feltet ON pizzak.pizzaid = pizza_feltet.pizzaid LEFT JOIN feltetek ON pizza_feltet.feltetid = feltetek.feltetid WHERE rendelesek.rendelesszam = {keres};", connectionString);
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(adapter2);

                DataTable table = new DataTable();
                adapter2.Fill(table);
                bindingSource2.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
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
                modositas.Enabled = true;
                torles.Enabled = true;
                tartalomtorles.Enabled = true;


                fizetendo.Text = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;
                tipus.Text = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;
                checkBox1.Checked = (bool)dataGridView1.SelectedRows[0].Cells[6].Value;
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
                bool fiz = (bool)dataGridView1.SelectedRows[0].Cells[6].Value;
                string display = fiz ? "Fizetve" : "Nincs fizetve";

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
                    $"Fizetés állapota: {display}\r\n" +
                    $"-------------------------------------";
            }
        }

        private void tartalomtorles_Click(object sender, EventArgs e)
        {
            poszt.Text = "";
            fizetendo.Text = "";
            tipus.Text = "";
            checkBox1.Checked = false;
            dataGridView1.ClearSelection();

            modositas.Enabled = false;
            torles.Enabled = false;
            rendeles_torles.Enabled = false;
            tartalomtorles.Enabled = false;
        }

        private void modositas_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection sqlconnection = new MySqlConnection(connectionString);
                sqlconnection.Open();
                int frik = checkBox1.Checked == true ? 1 : 0;
                string sql = $"UPDATE `rendelesek` SET fizetesid = {tipus.SelectedValue}, `fizetve` = '{frik}' WHERE rendelesszam  = {dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty};";

                MySqlCommand insertCommand2 = new MySqlCommand(sql, sqlconnection);
                MySqlDataReader insertReader2;
                insertReader2 = insertCommand2.ExecuteReader();

                MessageBox.Show("Sikeresen módosítottuk a rendelést!");
                GetRendelesDatas(connectionString);
                insertReader2.Close();
                sqlconnection.Close();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Nincs kijelölve a törlendő feltét!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void torles_Click(object sender, EventArgs e)
        {
            //rendelés fizetés része nullázása (UPDATE)
            try
            {
                MySqlConnection sqlconnection = new MySqlConnection(connectionString);
                sqlconnection.Open();
                int frik = checkBox1.Checked == true ? 1 : 0;
                string sql = $"UPDATE `rendelesek` SET fizetesid = NULL, `fizetve` = 0 WHERE rendelesszam  = {dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty};";

                MySqlCommand insertCommand2 = new MySqlCommand(sql, sqlconnection);
                MySqlDataReader insertReader2;
                insertReader2 = insertCommand2.ExecuteReader();

                MessageBox.Show("Sikeresen módosítottuk a rendelést!");
                GetRendelesDatas(connectionString);
                insertReader2.Close();
                sqlconnection.Close();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Nincs kijelölve a törlendő feltét!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            GetRendelesDatas(connectionString);
        }

        private void rendeles_torles_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection sqlconnection = new MySqlConnection(connectionString);
                sqlconnection.Open();
                string sqlcommand = $"DELETE FROM `rendelesek` WHERE rendelesszam={dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty}";
                MySqlCommand insertCommand2 = new MySqlCommand(sqlcommand, sqlconnection);
                MySqlDataReader insertReader2;
                insertReader2 = insertCommand2.ExecuteReader();


                MessageBox.Show("Sikeresen töröltük a rendelést!");
                GetRendelesDatas(connectionString);
                insertReader2.Close();
                sqlconnection.Close();
                poszt.Text = "";
                tipus.Text = "";
                checkBox1.Checked = false;
                fizetendo.Text = "";

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Nincs kijelölve a törlendő feltét!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
