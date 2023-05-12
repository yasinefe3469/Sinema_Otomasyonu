using Proje1.Helpers;
using Proje1.Model;
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
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        List<Movie> movies;
        DateTime currentDate = DateTime.Now;
        DateTime useDate;
        SelectionPage selectionpage;
        private void MainPage_Load(object sender, EventArgs e)
        {
            useDate = currentDate;
            lblDate.Text = useDate.ToShortDateString();
            movies = Helper.createMovies();
            ListControls();
            selectionpage = new SelectionPage(movies, this);
        }

        private void ListControls()
        {
            Size pictureSize = new Size(300, 180);
            Size buttonSize = new Size(90, 40);
            int x = 50;
            int y = 100;
            int xIncrement = 400;
            int yIncrement = 300;
            for (int i = 0; i < movies.Count; i++)
            {
                PictureBox picture = new PictureBox();
                picture.Location = new Point(x,y);
                picture.Size = pictureSize;
                picture.Image = Image.FromFile(movies[i].picturePath);
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(picture);
                int buttonX = x;
                int buttonY = picture.Bottom + 10;
                for (int index = 0; index < 3; index++)
                {
                    Button button = new Button();
                    button.Text = movies[i].sessions[index].time;
                    button.Location = new Point(buttonX, buttonY);
                    button.Size = buttonSize;
                    button.Tag = i;
                    button.Click += new EventHandler(button_Click);
                    this.Controls.Add(button);
                    buttonX += 100;
                }
                if (1200 > x + xIncrement + picture.Width)
                {
                    x += xIncrement;
                }
                else
                {
                    x = 50;
                    y += yIncrement;
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int movieIndex = Convert.ToInt32(button.Tag);
            string sessionTime = button.Text;
            string sessionDate = lblDate.Text;
            if (DateTime.Parse($"{sessionDate} {sessionTime}") < DateTime.Now)
            {
                MessageBox.Show("Seçilen Seansı Kaçırdınız. Lütfen Başka Seans Seçiniz.","Sistem Mesajı",MessageBoxButtons.OK);
                return;
            }
            this.Hide();
            selectionpage.Show();
            selectionpage.ListDetail(movieIndex, sessionTime, sessionDate);
           
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            useDate = useDate.AddDays(1);
            lblDate.Text = useDate.ToShortDateString();
            btnback.Enabled = true;
            if (currentDate.AddDays(2) == useDate)
            {
                btnnext.Enabled = false;
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            useDate = useDate.AddDays(-1);
            lblDate.Text = useDate.ToShortDateString();
            btnnext.Enabled = true;
            if (currentDate == useDate)
            {
                btnback.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tickets screen = new Tickets();
            screen.Show();
        }
    }
}
