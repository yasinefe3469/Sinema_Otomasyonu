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
using Proje1.Nhibernate;
using Proje1.Enums;
using System.Security.Cryptography.X509Certificates;

namespace Proje1
{
    public partial class SelectionPage : Form
    {
        public SelectionPage(List<Movie> _movies, MainPage _mainpage)
        {
            InitializeComponent();
            movies = _movies;
            mainpage = _mainpage;
        }
        List<Movie> movies;
        MainPage mainpage;
        Movie selectedMovie;
        Session selectedSession;

        private void SelectionPage_Load(object sender, EventArgs e)
        {
            
        }

        public void ListDetail(int movieIndex, string _time, string _date)
        {
            selectedMovie = movies[movieIndex];
            selectedSession = selectedMovie.sessions.Find(n => n.date == _date && n.time == _time);
            lbltime.Text = $"{_date} - {_time}";
            lblminute.Text = selectedMovie.minute;
            lblprice.Text = selectedMovie.price.ToString() + " ₺";
            selectedPicture.Image = Image.FromFile(selectedMovie.picturePath);
            lblcat.Text = selectedMovie.category.ToString();
            CheckChairStatus();
        }

        private void CheckChairStatus()
        {
            foreach (Control item in grbChairs.Controls)
            {
                if (item is Button)
                {

                    string row = item.Tag.ToString();
                    string number = item.Text;
                    item.Enabled = true;
                    foreach (Chair chair in selectedSession.chairs)
                    {

                        if (chair.row == row && chair.number == number)
                        {


                            if (chair.status)
                            {

                                item.BackColor = Color.DarkRed;
                                item.Enabled = false;
                            }
                            else
                            {

                                item.BackColor = Color.LightGreen;
                            }
                            break;
                        }


                    }
                }
            }
        }

        List<Chair> chairs = new List<Chair>();
        private void button24_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string row = button.Tag.ToString();
            string number = button.Text;
            Chair chair = selectedSession.chairs.Find(c => c.row == row && c.number == number);
            if (button.BackColor.Name != "Blue")
            {
                chairs.Add(chair);
                button.BackColor = Color.Blue;
            }
            else
            {
                chairs.Remove(chair);
                button.BackColor = Color.LightGreen;
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            UserInformation infoscreen = new UserInformation();
            DialogResult result = infoscreen.ShowDialog();

            if (result == DialogResult.OK)
            {
                string veri1 = infoscreen.NameValue;

                using (var session = NhibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {

                        string a ="";
                        foreach (var item in chairs)
                        {
                            a += item.row + item.number + " ";

                        }

         
                        var salesclass = new Model.Sales()
                        {
                            creationDate = DateTime.Now.ToString(),
                            totalPrice = CalculatePrice(),
                            count = chairs.Count(),
                            sessionTime = selectedSession.date + selectedSession.time,
                            customerInfo = veri1,
                            chairs =a
                            
                            
                          
                            
                        };

                        session.Save(salesclass);
                        transaction.Commit();
                    }
                }


            }
            else if (result == DialogResult.Cancel)
            {
                MessageBox.Show("İsim Girmeniz Gerekmektedir.","Sistem Mesajı", MessageBoxButtons.OK);

                return;
            }

     
            if (chairs.Count == 0)
            {
                MessageBox.Show("Lütfen En Az 1 Koltuk Seçiniz.", "Sistem Mesajı", MessageBoxButtons.OK);
                return;
            }
            Sales sales = new Sales();
            Movie moviee = new Movie();
            moviee.movieName = selectedMovie.movieName;
            sales.count = chairs.Count;
            sales.sessionTime = $"{selectedSession.date} - {selectedSession.time}";
            sales.totalPrice = CalculatePrice();

            foreach (Chair chair in chairs)
            {
                chair.status = true;
            }
            MessageBox.Show(sales.ToString());
            ChangePage();
        }

        private void ChangePage()
        {
            chairs.Clear();
            this.Hide();
            mainpage.Show();
        }

        private decimal CalculatePrice()
        {
            decimal price = selectedMovie.price * chairs.Count;
            return price;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ChangePage();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
