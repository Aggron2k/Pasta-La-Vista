using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Pasta_La_Vista
{
    public partial class Home : Form
    {
        string connectionString = "datasource=localhost;port=3306;username=root;database=pastalavista;";


        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            ugyfel1.Visible = false;
            pizza1.Visible = false;
            fizetes1.Visible = false;
            statisztika1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ugyfel1.Visible = true;
            pizza1.Visible = false;
            fizetes1.Visible = false;
            statisztika1.Visible = false;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            ugyfel1.Visible = false;
            pizza1.Visible = true;
            fizetes1.Visible = false;
            statisztika1.Visible = false;
            pizza1.GetRendelesDatas(connectionString);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ugyfel1.Visible = false;
            pizza1.Visible = false;
            fizetes1.Visible = true;
            statisztika1.Visible = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ugyfel1.Visible = false;
            pizza1.Visible = false;
            fizetes1.Visible = false;
            statisztika1.Visible = true;
        }

        private void kilepes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}