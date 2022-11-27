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
    public partial class Statisztika : UserControl
    {
        MySqlDataAdapter adapter, adapter2;
        string connectionString = "datasource=localhost;port=3306;username=root;database=pastalavista;";

        public Statisztika()
        {
            InitializeComponent();
        }

        private void Statisztika_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource1;
            dataGridView2.DataSource = bindingSource2;
            GetP(connectionString);
            GetTorzs(connectionString);
        }

        private void Statisztika_VisibleChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource1;
            dataGridView2.DataSource = bindingSource2;
            GetP(connectionString);
            GetTorzs(connectionString);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void GetP(string connectionString)
        {
            try
            {
                adapter = new MySqlDataAdapter("SELECT DISTINCT ugyfelek.nev AS 'Ügyfél Név', pizzak.nev AS 'Pizza Név' FROM `rendelesek` INNER JOIN ugyfelek ON rendelesek.ugyfelkod = ugyfelek.ugyfelkod INNER JOIN pizzak ON rendelesek.pizzaid = pizzak.pizzaid WHERE rendelesek.ugyfelkod IN (SELECT rendelesek.ugyfelkod FROM rendelesek INNER JOIN ugyfelek ON rendelesek.ugyfelkod = ugyfelek.ugyfelkod WHERE ugyfelek.nev LIKE \"P%\") ORDER BY 'Ügyfél Név';", connectionString);
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(adapter2);

                DataTable table = new DataTable();
                adapter.Fill(table);
                bindingSource1.DataSource = table;
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

        private void GetTorzs (string connectionString)
        {
            try
            {
                adapter2 = new MySqlDataAdapter("SELECT ugyfelek.nev AS 'Ügyfél Név', COUNT(*) AS Rendelések_száma FROM `rendelesek` INNER JOIN ugyfelek ON rendelesek.ugyfelkod = ugyfelek.ugyfelkod GROUP BY rendelesek.ugyfelkod ORDER BY Rendelések_száma DESC LIMIT 10;", connectionString);
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(adapter2);

                DataTable table2 = new DataTable();
                adapter2.Fill(table2);
                bindingSource2.DataSource = table2;
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

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (bindingSource1.DataSource != null)
            {
                adapter.Update((DataTable)bindingSource1.DataSource);
                dataGridView1.Columns[0].Width =150;
                dataGridView1.Columns[1].Width =150;

            }
        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (bindingSource2.DataSource != null)
            {
                adapter2.Update((DataTable)bindingSource2.DataSource);
                dataGridView2.Columns[0].Width = 150;
                dataGridView2.Columns[1].Width = 150;
            }
        }

        
    }
}
