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
    public partial class PFseged : UserControl
    {
        MySqlDataAdapter adapter, adapter2, adapter3, adapter4;
        string connectionString = "datasource=localhost;port=3306;username=root;database=pastalavista;";

        public PFseged()
        {
            InitializeComponent();
            
        }
        private void PFseged_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = bindingSource1;
            dataGridView2.DataSource = bindingSource2;

            GetPizzaDatas(connectionString);
            GetFeltetDatas(connectionString);

            adapter3 = new MySqlDataAdapter("SELECT nev,pizzaid FROM `pizzak`", connectionString);
            DataSet ds3 = new DataSet();
            adapter3.Fill(ds3);
            comboBox1.DataSource = ds3.Tables[0];
            comboBox1.DisplayMember = "nev";
            comboBox1.ValueMember = "pizzaid";

            adapter4 = new MySqlDataAdapter("SELECT nev,feltetid FROM `feltetek`", connectionString);
            DataSet ds4 = new DataSet();
            adapter4.Fill(ds4);
            comboBox2.DataSource = ds4.Tables[0];
            comboBox2.DisplayMember = "nev";
            comboBox2.ValueMember = "feltetid";


            button3.Enabled = false;
            button2.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        private void GetPizzaDatas(string connectionString)
        {
            try
            {
                adapter2 = new MySqlDataAdapter("SELECT pizzak.pizzaid as 'Pizza_ID', pizzak.nev AS 'Pizza_név', feltetek.feltetid AS 'Feltét_ID', feltetek.nev AS 'Feltét_név' FROM `pizza_feltet` INNER JOIN pizzak ON pizza_feltet.pizzaid = pizzak.pizzaid INNER JOIN feltetek ON pizza_feltet.feltetid = feltetek.feltetid ORDER BY pizzak.nev", connectionString);
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
        private void GetFeltetDatas(string connectionString)
        {
            try
            {
                adapter = new MySqlDataAdapter("SELECT feltetid AS 'Feltét_ID',nev AS 'Feltét_név',ar AS 'Feltét_ár' FROM `feltetek` ORDER BY `feltetid` ASC", connectionString);
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(adapter);

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
        public void UpdatePrices(string connectionString)
        {
            try
            {
                for (int i = 1; i < (dataGridView1.Rows.Count); i++)
                {
                    MySqlConnection sqlconnection = new MySqlConnection(connectionString);
                    sqlconnection.Open();
                    string sql = $"UPDATE `pizzak` SET feltetek_ara=(SELECT SUM(feltetek.ar) FROM `pizzak` INNER JOIN pizza_feltet ON pizzak.pizzaid = pizza_feltet.pizzaid INNER JOIN feltetek ON pizza_feltet.feltetid = feltetek.feltetid WHERE pizzak.pizzaid = {i}) WHERE pizzak.pizzaid = {i};";

                    MySqlCommand insertCommand2 = new MySqlCommand(sql, sqlconnection);
                    MySqlDataReader insertReader2;
                    insertReader2 = insertCommand2.ExecuteReader();
                    UpdateOrderPrices(connectionString);
                }
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
        public void UpdateOrderPrices(string connectionString)
        {
            try
            {
                MySqlConnection sqlconnection = new MySqlConnection(connectionString);
                sqlconnection.Open();
                string sql = $"UPDATE `rendelesek` INNER JOIN pizzak ON rendelesek.pizzaid = pizzak.pizzaid INNER JOIN meret ON rendelesek.meretszam = meret.meretszam SET rendelesek.osszar=(pizzak.feltetek_ara+meret.ar) WHERE rendelesek.fizetve = 0;";

                MySqlCommand insertCommand2 = new MySqlCommand(sql, sqlconnection);
                MySqlDataReader insertReader2;
                insertReader2 = insertCommand2.ExecuteReader();
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

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (bindingSource2.DataSource != null)
            {
                dataGridView2.Columns[0].Width = 0;
                dataGridView2.Columns[1].Width = 150;
                dataGridView2.Columns[2].Width = 0;
                dataGridView2.Columns[3].Width = 150;


                adapter2.Update((DataTable)bindingSource2.DataSource);
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (bindingSource1.DataSource != null)
            {
                dataGridView1.Columns[0].Width = 0;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 150;

                adapter.Update((DataTable)bindingSource1.DataSource);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //felvezetes-pizza
            try
            {
                MySqlConnection sqlconnection = new MySqlConnection(connectionString);
                sqlconnection.Open();
                string sql = $"INSERT INTO `pizza_feltet` (`pizzaid`,`feltetid`) VALUES ('{comboBox1.SelectedValue}','{comboBox2.SelectedValue}');";

                MySqlCommand insertCommand2 = new MySqlCommand(sql, sqlconnection);
                MySqlDataReader insertReader2;
                insertReader2 = insertCommand2.ExecuteReader();

                MessageBox.Show("Sikeres pizza feltétének felvezetése!");
                GetPizzaDatas(connectionString);
                UpdatePrices(connectionString);
                //rendelesek-pizzak
                
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

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var text = textBox2.Text;
            bindingSource2.Filter = $"Pizza_név LIKE '*{text}*' OR Feltét_név LIKE '*{text}*'";
            bindingSource2.Sort = "Pizza_név ASC";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //modosit-pizza
            try
            {
                bool talalat = false;
                foreach (DataGridViewRow item in dataGridView2.SelectedRows)
                {
                    if (item.Selected)
                    {
                        int pizzaid = (int)dataGridView2.SelectedRows[0].Cells[0].Value;
                        int feltetid = (int)dataGridView2.SelectedRows[0].Cells[2].Value;

                        MySqlConnection sqlconnection = new MySqlConnection(connectionString);
                        sqlconnection.Open();
                        string sql = $"UPDATE `pizza_feltet` SET `pizzaid`='{comboBox1.SelectedValue}',`feltetid`='{comboBox2.SelectedValue}' WHERE pizzaid = '{pizzaid}' AND feltetid='{feltetid}'";

                        MySqlCommand insertCommand2 = new MySqlCommand(sql, sqlconnection);
                        MySqlDataReader insertReader2;
                        insertReader2 = insertCommand2.ExecuteReader();

                        MessageBox.Show("Sikeresen módosítottuk a Pizza feltétét!");
                        GetPizzaDatas(connectionString);
                        UpdatePrices(connectionString);
                        insertReader2.Close();
                        sqlconnection.Close();
                        talalat = true;
                    }
                    
                }
                if (!talalat)
                {
                    MessageBox.Show("Nincs kijelölve a módosítandó feltét!");
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Valami hiba történt!");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Nincs kijelölve a törlendő feltét!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            //delet-pizza
            try
            {
                int pizzaid = (int)dataGridView2.SelectedRows[0].Cells[0].Value;
                int feltetid = (int)dataGridView2.SelectedRows[0].Cells[2].Value;

                MySqlConnection sqlconnection = new MySqlConnection(connectionString);
                sqlconnection.Open();
                string sqlcommand = $"DELETE FROM `pizza_feltet` WHERE pizzaid = '{pizzaid}' AND feltetid='{feltetid}'";
                MySqlCommand insertCommand2 = new MySqlCommand(sqlcommand, sqlconnection);
                MySqlDataReader insertReader2;
                insertReader2 = insertCommand2.ExecuteReader();

                MessageBox.Show("Sikeresen töröltük a feltétet a pizzáról!");
                GetPizzaDatas(connectionString);
                UpdatePrices(connectionString);
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

        private void dataGridView2_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                button3.Enabled = true;
                button2.Enabled = true;

                comboBox1.Text = dataGridView2.SelectedRows[0].Cells[1].Value + string.Empty;
                comboBox2.Text = dataGridView2.SelectedRows[0].Cells[3].Value + string.Empty;
            }
        }
        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                modositas.Enabled = true;
                torles.Enabled = true;

                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
            }
        }

        private void felvezetes_Click(object sender, EventArgs e)
        {
            try
            {
                bool szabad = false;
                string keresendo = textBox1.Text;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string atnez = (string)row.Cells[1].Value;
                    if (keresendo.Equals(atnez))
                    {
                        MessageBox.Show("Már létezik ilyen feltét");
                        return;
                    }
                    else
                    {
                        szabad = true;
                    }
                }
                if (szabad)
                {
                    MySqlConnection sqlconnection = new MySqlConnection(connectionString);
                    sqlconnection.Open();
                    string sql = $"INSERT INTO feltetek (`nev`,`ar`) VALUES ('{textBox1.Text}','{textBox3.Text}');";

                    MySqlCommand insertCommand2 = new MySqlCommand(sql, sqlconnection);
                    MySqlDataReader insertReader2;
                    insertReader2 = insertCommand2.ExecuteReader();

                    MessageBox.Show("Sikeres feltét felvezetése!");
                    UpdatePrices(connectionString);
                    GetPizzaDatas(connectionString);
                    GetFeltetDatas(connectionString);
                    insertReader2.Close();
                    sqlconnection.Close();
                }
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
                bool talalat = false;
                foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                {
                    if (item.Selected)
                    {
                        int feltetid = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

                        MySqlConnection sqlconnection = new MySqlConnection(connectionString);
                        sqlconnection.Open();
                        string sql = $"UPDATE `feltetek` SET `nev`='{textBox1.Text}',`ar`='{textBox3.Text}' WHERE feltetid='{feltetid}';";

                        MySqlCommand insertCommand2 = new MySqlCommand(sql, sqlconnection);
                        MySqlDataReader insertReader2;
                        insertReader2 = insertCommand2.ExecuteReader();

                        MessageBox.Show("Sikeresen módosítottuk a feltétet!");
                        UpdatePrices(connectionString);
                        GetFeltetDatas(connectionString);
                        insertReader2.Close();
                        sqlconnection.Close();
                        talalat = true;
                    }

                }
                if (!talalat)
                {
                    MessageBox.Show("Nincs kijelölve a módosítandó feltét!");
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Valami hiba történt!");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Nincs kijelölve a törlendő feltét!");
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
                int feltetid = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                

                MySqlConnection sqlconnection = new MySqlConnection(connectionString);
                sqlconnection.Open();
                string sqlcommand = $"DELETE FROM `pizza_feltet` WHERE feltetid='{feltetid}'; DELETE FROM `feltetek` WHERE feltetid = '{feltetid}' AND feltetid='{feltetid}';";
                MySqlCommand insertCommand2 = new MySqlCommand(sqlcommand, sqlconnection);
                MySqlDataReader insertReader2;
                insertReader2 = insertCommand2.ExecuteReader();

                MessageBox.Show("Sikeresen töröltük a feltétet!");
                GetPizzaDatas(connectionString);
                GetFeltetDatas(connectionString);
                UpdatePrices(connectionString);
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

        private void tartalomtorles_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox3.Text = "";
            dataGridView1.ClearSelection();


            modositas.Enabled = false;
            torles.Enabled = false;
            tartalomtorles.Enabled = false;

        }

        private void kereses_TextChanged(object sender, EventArgs e)
        {
            var text = kereses.Text;
            bindingSource1.Filter = $"Convert(Feltét_ID, 'System.String') LIKE '*{text}*' OR Feltét_név LIKE '*{text}*' OR Feltét_ár LIKE '*{text}*'";
            bindingSource1.Sort = "Feltét_ID ASC";
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            button2.Enabled = false;
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
            if (textBox3.Text.Length > 0)
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
