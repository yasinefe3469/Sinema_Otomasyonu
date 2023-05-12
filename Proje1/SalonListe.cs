using Proje1.Model;
using Proje1.Nhibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje1
{
    public partial class SalonListe : Form
    {
        public SalonListe()
        {
            InitializeComponent();

            using (var session = NhibernateHelper.OpenSession()) 
            {
                var a = session.QueryOver<Salon>().List(); 

                dataGridView1.DataSource = a; 

            }
        }

        private void SalonListe_Load(object sender, EventArgs e)
        {

        }
    }
}
