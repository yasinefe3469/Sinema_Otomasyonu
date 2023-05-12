using Proje1.Enums;
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
    public partial class UserInformation : Form
    {
        public UserInformation()
        {
            InitializeComponent();
        }

        public string NameValue;
 
        private void button1_Click(object sender, EventArgs e)
        {
             NameValue = textBox1.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
            

        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
