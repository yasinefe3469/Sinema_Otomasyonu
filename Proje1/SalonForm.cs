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
    public partial class SalonForm : Form
    {
        public SalonForm()
        {
            InitializeComponent();
        }

        private void SalonForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var salon = new Model.Salon
                    {
                        SalonAdi = textBox2.Text,
                        KoltukSayisi = Convert.ToInt32(numericUpDown1.Text)
                    };
                    session.Save(salon);
                    transaction.Commit();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SalonListe salonListe = new SalonListe();
            salonListe.Show();
        }
    }
}
