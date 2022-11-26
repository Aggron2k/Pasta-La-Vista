using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
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
    public partial class Pizza : UserControl
    {
        MySqlDataAdapter adapter;
        MySqlDataAdapter adapter2;
        MySqlDataAdapter adapter3;
        MySqlDataAdapter adapter4;
        MySqlDataAdapter adapter5;
        string connectionString = "datasource=localhost;port=3306;username=root;database=pastalavista;";
        public Pizza()
        {
            InitializeComponent();
            modositas.Enabled = true;
            torles.Enabled = true;
            pFseged1.Visible = false;
            mseged1.Visible = false;
        }

        private void Pizza_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = bindingSource1;
            dataGridView2.DataSource = bindingSource2;


            dataGridView2.Columns[0].Width = 150;
            dataGridView2.Columns[1].Width = 150;
            dataGridView2.Columns[2].Width = 75;

            GetPizzakDatas(connectionString);
            GetRendelesDatas(connectionString);
        }
        private void Pizza_VisibleChanged(object sender, EventArgs e)
        {
            adapter = new MySqlDataAdapter("SELECT rendelesszam FROM rendelesek ORDER BY rendelesszam DESC", connectionString);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.ValueMember = "rendelesszam";

            adapter2 = new MySqlDataAdapter("SELECT nev,pizzaid FROM `pizzak`", connectionString);
            DataSet ds2 = new DataSet();
            adapter2.Fill(ds2);
            comboBox2.DataSource = ds2.Tables[0];
            comboBox2.DisplayMember = "nev";
            comboBox2.ValueMember = "pizzaid";

            adapter3 = new MySqlDataAdapter("SELECT meretszam FROM `meret`", connectionString);
            DataSet ds3 = new DataSet();
            adapter3.Fill(ds3);
            comboBox3.DataSource = ds3.Tables[0];
            comboBox3.ValueMember = "meretszam";

            adapter4 = new MySqlDataAdapter("SELECT ugyfelkod,nev FROM `ugyfelek` ORDER BY ugyfelkod DESC", connectionString);
            DataSet ds4 = new DataSet();
            adapter4.Fill(ds4);
            comboBox4.DataSource = ds4.Tables[0];
            comboBox4.ValueMember = "nev";
            comboBox4.ValueMember = "ugyfelkod";

            GetPizzakDatas(connectionString);
        }
        

        public void GetRendelesDatas(string connectionString)
        {
            try
            {
                pFseged1.UpdateOrderPrices(connectionString);
                adapter = new MySqlDataAdapter("SELECT `rendelesszam` AS 'Rendelés_szám', ugyfelek.nev AS 'Ügyfél_név', pizzak.nev AS 'Pizza_név', meretszam AS 'Méret_szám', fizetes.fizetestipus AS 'Fizetés_típus', osszar AS 'Össz_ár', fizetve AS 'Fizetve' FROM `rendelesek` LEFT JOIN ugyfelek ON rendelesek.ugyfelkod = ugyfelek.ugyfelkod LEFT JOIN pizzak ON rendelesek.pizzaid = pizzak.pizzaid LEFT JOIN fizetes ON rendelesek.fizetesid = fizetes.id ORDER BY rendelesszam DESC;", connectionString);
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
        public void GetPizzakDatas(string connectionString)
        {
            try
            {
                adapter = new MySqlDataAdapter("SELECT pizzak.nev as 'Pizza_Név', feltetek.nev as 'Feltét_Név',pizzak.feltetek_ara as 'Pizza_ára' FROM pizza_feltet INNER JOIN pizzak ON pizza_feltet.pizzaid = pizzak.pizzaid INNER JOIN feltetek ON feltetek.feltetid = pizza_feltet.feltetid ORDER BY pizzak.pizzaid", connectionString);
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(adapter);

                DataTable table = new DataTable();
                adapter.Fill(table);
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

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                comboBox4.Text = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                comboBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
            }
        }

        private void dataGridView2_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            
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

        private void kereses2_TextChanged(object sender, EventArgs e)
        {
            var text2 = kereses2.Text;
            bindingSource2.Filter = $"Pizza_Név LIKE '*{text2}*' OR Feltét_Név LIKE '*{text2}*'";
            bindingSource2.Sort = "Pizza_Név ASC";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //uj rendelésszám hozzáadása
            try
            {
                MySqlConnection sqlconnection = new MySqlConnection(connectionString);
                sqlconnection.Open();
                string sql = "INSERT INTO `rendelesek`(`rendelesszam`,`fizetve`) VALUES ('','0')";
                MySqlCommand insertCommand2 = new MySqlCommand(sql, sqlconnection);
                MySqlDataReader insertReader2;
                insertReader2 = insertCommand2.ExecuteReader();

                MessageBox.Show("Sikeresen módosítottuk a rendelést!");
                GetRendelesDatas(connectionString);
                pFseged1.UpdateOrderPrices(connectionString);
                insertReader2.Close();
                sqlconnection.Close();
                this.Hide();
                this.Show();
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

        private void modositas_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection sqlconnection = new MySqlConnection(connectionString);
                sqlconnection.Open();
                string sql = $"UPDATE `rendelesek` SET ugyfelkod = {comboBox4.SelectedValue}, `pizzaid` = '{comboBox2.SelectedValue}', `meretszam` = '{comboBox3.SelectedValue}' WHERE rendelesszam  = {comboBox1.SelectedValue};";

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
            try
            {
                MySqlConnection sqlconnection = new MySqlConnection(connectionString);
                sqlconnection.Open();
                string sqlcommand = $"DELETE FROM `rendelesek` WHERE rendelesszam={comboBox1.SelectedValue}";
                MySqlCommand insertCommand2 = new MySqlCommand(sqlcommand, sqlconnection);
                MySqlDataReader insertReader2;
                insertReader2 = insertCommand2.ExecuteReader();


                MessageBox.Show("Sikeresen töröltük a rendelést!");
                GetRendelesDatas(connectionString);
                insertReader2.Close();
                sqlconnection.Close();
                this.Hide();
                this.Show();

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

        private void button1_Click(object sender, EventArgs e)
        {
            pFseged1.Visible = true;
            mseged1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pFseged1.Visible = false;
            mseged1.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GetPizzakDatas(connectionString);
        }
    }
}
