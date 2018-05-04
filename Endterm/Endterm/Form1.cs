using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Endterm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string connect = String.Format("Server={0}; Port={1}; User Id={2}; Password={3}; Database={4};", "localhost", "5432", "postgres", "lituania", "net");
                NpgsqlConnection conn = new NpgsqlConnection(connect);
                conn.Open();

            }
        }




    }
}
