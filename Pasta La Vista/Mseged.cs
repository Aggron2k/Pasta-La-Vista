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
    public partial class Mseged : UserControl
    {
        MySqlDataAdapter adapter;
        string connectionString = "datasource=localhost;port=3306;username=root;database=pastalavista;";
        PFseged pFseged = new PFseged();

        public Mseged()
        {
            InitializeComponent();
            
        }

        private void Arak_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = bindingSource1;
            GetPriceDatas(connectionString);

            tartalomtorles.Enabled = false;
            felvezetes.Enabled = false;
            modositas.Enabled = false;
            torles.Enabled = false;
        }

        private void GetPriceDatas(string connectionString)
        {
            try
            {
                adapter = new MySqlDataAdapter("SELECT `meretszam` AS 'Méret_szám', `ar` AS 'Ár' FROM `meret`", connectionString);
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //tartalom törlés
            dataGridView2.ClearSelection();
            textBox1.Text = "";
            textBox3.Text = "";

            felvezetes.Enabled = false;
            modositas.Enabled = false;
            tartalomtorles.Enabled = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //felvezet
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();
                string sql = $"INSERT INTO `meret`(`meretszam`, `ar`) VALUES ('{textBox1.Text}','{textBox3.Text}');";
                //pénz updatelése

                MySqlCommand insertCommand = new MySqlCommand(sql, connection);
                MySqlDataReader insertReader = insertCommand.ExecuteReader();

                MessageBox.Show("Sikeresen méret felvezetés!");
                GetPriceDatas(connectionString);
                pFseged.UpdateOrderPrices(connectionString);
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow item in dataGridView2.SelectedRows)
                {
                    if (item.Selected)
                    {
                        int putThis = (int)dataGridView2.SelectedRows[0].Cells[0].Value;

                        MySqlConnection sqlconnection = new MySqlConnection(connectionString);
                        sqlconnection.Open();
                        string sql = $"UPDATE `meret` SET `meretszam` = '{textBox1.Text}', `ar` = '{textBox3.Text}' WHERE `meret`.`meretszam` = {putThis};";

                        MySqlCommand insertCommand2 = new MySqlCommand(sql, sqlconnection);
                        MySqlDataReader insertReader2;
                        insertReader2 = insertCommand2.ExecuteReader();

                        MessageBox.Show("Sikeresen módosítottuk a méretet!");
                        GetPriceDatas(connectionString);
                        pFseged.UpdateOrderPrices(connectionString);
                        insertReader2.Close();
                        sqlconnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //töröl
            try
            {
                foreach (DataGridViewRow item in dataGridView2.SelectedRows)
                {
                    if (item.Selected)
                    {
                        int deletThisId = (int)dataGridView2.SelectedRows[0].Cells[0].Value;
                        MySqlConnection sqlconnection = new MySqlConnection(connectionString);
                        sqlconnection.Open();
                        string sqlcommand = $"DELETE FROM `meret` WHERE meretszam={deletThisId}";
                        MySqlCommand insertCommand2 = new MySqlCommand(sqlcommand, sqlconnection);
                        MySqlDataReader insertReader2;
                        insertReader2 = insertCommand2.ExecuteReader();

                        MessageBox.Show("Sikeresen töröltük a méretet!");
                        GetPriceDatas(connectionString);
                        pFseged.UpdateOrderPrices(connectionString);
                        insertReader2.Close();
                        sqlconnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void dataGridView2_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                modositas.Enabled = true;
                torles.Enabled = true;

                textBox1.Text = dataGridView2.SelectedRows[0].Cells[0].Value + string.Empty;
                textBox3.Text = dataGridView2.SelectedRows[0].Cells[1].Value + string.Empty;
            }
        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (bindingSource1.DataSource != null)
            {
                adapter.Update((DataTable)bindingSource1.DataSource);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
            if (textBox1.Text.Length > 0 && textBox3.Text.Length > 0)
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

    }
}
