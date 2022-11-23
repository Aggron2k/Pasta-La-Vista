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

namespace Pasta_La_Vista
{
    public partial class Ugyfel : UserControl
    {
        MySqlDataAdapter adapter;
        string connectionString = "datasource=localhost;port=3306;username=root;database=pastalavista;";

        public Ugyfel()
        {
            InitializeComponent();
        }

        private void Ugyfel_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource1;
            GetDatas(connectionString);

            dataGridView1.Columns[0].Width = 0;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 150;

            felvezetes.Enabled = false;
            modositas.Enabled = false;
            torles.Enabled = false;
            tartalomtorles.Enabled = false;
        }

        private void GetDatas(string connectionString)
        {
            try
            {
                adapter = new MySqlDataAdapter("SELECT `ugyfelkod` AS 'Ügyfél_kód', `nev` AS 'Ügyfél_Neve', `cim` AS 'Cím', `telefon` AS 'Telefonszám' FROM `ugyfelek`", connectionString);
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
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (bindingSource1.DataSource != null)
            {
                adapter.Update((DataTable)bindingSource1.DataSource);
            }
        }

        private void felvezetes_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();
            string sql = $"INSERT INTO `ugyfelek`(`nev`, `cim`, `telefon`) VALUES ('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}');INSERT INTO `rendelesek`(`ugyfelkod`) SELECT ugyfelkod FROM `ugyfelek` ORDER BY ugyfelkod DESC LIMIT 1;UPDATE `rendelesek` SET `fizetve`=0 WHERE ugyfelkod = (SELECT ugyfelkod FROM `ugyfelek` ORDER BY ugyfelkod DESC LIMIT 1);";

            MySqlCommand insertCommand = new MySqlCommand(sql, connection);
            MySqlDataReader insertReader = insertCommand.ExecuteReader();
            
            MessageBox.Show("Sikeresen Ügyfél felvezetés!");
            GetDatas(connectionString);
            connection.Close();
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                modositas.Enabled = true;
                torles.Enabled = true;
                tartalomtorles.Enabled = true;


                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
            }
        }

        private void tartalomtorles_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            modositas.Enabled = false;
            torles.Enabled = false;
            tartalomtorles.Enabled = false;
        }

        private void modositas_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                if (item.Selected)
                {
                    int putThis = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

                    MySqlConnection sqlconnection = new MySqlConnection(connectionString);
                    sqlconnection.Open();
                    string sql = $"UPDATE `ugyfelek` SET `nev`='{textBox1.Text}',`cim`='{textBox2.Text}',`telefon`='{textBox3.Text}' WHERE `ugyfelkod`={putThis}";

                    MySqlCommand insertCommand2 = new MySqlCommand(sql, sqlconnection);
                    MySqlDataReader insertReader2;
                    insertReader2 = insertCommand2.ExecuteReader();

                    MessageBox.Show("Sikeresen módosítottuk az ügyfelet!");
                    GetDatas(connectionString);
                    insertReader2.Close();
                    sqlconnection.Close();
                }
            }
        }
        private void torles_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                if (item.Selected)
                {
                    dataGridView1.Rows.RemoveAt(item.Index - 1);
                    int deletThisId = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

                    MySqlConnection sqlconnection = new MySqlConnection(connectionString);
                    sqlconnection.Open();
                    string sqlcommand = $"DELETE FROM `ugyfelek` WHERE ugyfelkod={deletThisId}";
                    MySqlCommand insertCommand2 = new MySqlCommand(sqlcommand, sqlconnection);
                    MySqlDataReader insertReader2;
                    insertReader2 = insertCommand2.ExecuteReader();


                    MessageBox.Show("Sikeresen töröltük az ügyfelet!");
                    GetDatas(connectionString);
                    insertReader2.Close();
                    sqlconnection.Close();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SzovegDobozValtozas();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SzovegDobozValtozas();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SzovegDobozValtozas();
        }
        private void SzovegDobozValtozas()
        {
            tartalomtorles.Enabled = true;
            if (textBox1.Text.Length > 0)
            {
                felvezetes.Enabled = true;
                modositas.Enabled = true;
                torles.Enabled = true;
            }
            else
            {
                felvezetes.Enabled = false;
                modositas.Enabled = false;
                torles.Enabled = false;
            }
        }

        private void kereses_TextChanged(object sender, EventArgs e)
        {
            var text = kereses.Text;
            bindingSource1.Filter = $"Ügyfél_Neve LIKE '*{text}*' OR Cím LIKE '*{text}*' OR Telefonszám LIKE '*{text}*'";
            bindingSource1.Sort = "Ügyfél_kód ASC";
        }
    }
}
