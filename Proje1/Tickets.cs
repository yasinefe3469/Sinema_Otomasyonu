using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proje1.Model;
using Proje1.Nhibernate;

namespace Proje1
{
    public partial class Tickets : Form
    {
        public Tickets()
        {
            InitializeComponent();
        }

        private void Tickets_Load(object sender, EventArgs e)
        {
            using (var session = NhibernateHelper.OpenSession()) //open session
            {
                var tickets = session.QueryOver<Sales>().List(); //Query to get the dealers

                dataGridView1.DataSource = tickets; // <- Code you are asking for


            }
        }
    }
}
