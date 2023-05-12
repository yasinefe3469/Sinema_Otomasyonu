using Proje1.Enums;
using Proje1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Helpers
{
    class Helper
    {
        public static List<Movie> createMovies()
        {
            string basePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            return new List<Movie>()
            {
                new Movie()
                {
                    movieName = "Terminatör",
                    category = Category.bilimKurgu,
                    minute = "2 Saat 19 Dakika",
                    price = 50,
                    picturePath = basePath + "\\4506295.jpg"
                },
                   new Movie()
                {
                    movieName = "Black Panther",
                    category = Category.macera,
                    minute = "2 Saat 10 Dakika",
                    price = 60,
                    picturePath = basePath + "\\panther.jpg"
                },
                new Movie()
                {
                    movieName = "Görevimiz Tehlike 3",
                    category = Category.bilimKurgu,
                    minute = "2 Saat 55 Dakika",
                    price = 20,
                    picturePath = basePath + "\\tehlike.jpg"
                },
                new Movie()
                {
                    movieName = "Çılgın, Aptal, Aşık",
                    category = Category.fantastik,
                    minute = "3 Saat 1 Dakika",
                    price = 30,
                    picturePath = basePath + "\\1br9qfyku28sb6s1y32.jpg"
                },
                new Movie()
                {
                    movieName = "Galaksinin Koruyucuları 3",
                    category = Category.komedi,
                    minute = "2 Saat 40 Dakika",
                    price = 50,
                    picturePath = basePath + "\\galaksinin_koruyucular__2_afis_yeni.jpg"
                },

             new Movie()
                {
                    movieName = "Ant-man ve Wasp",
                    category = Category.bilimKurgu,
                    minute = "3 Saat 30 Dakika",
                    price = 200,
                    picturePath = basePath + "\\ant-man.jpg"
                },


            };
        }
    }
}
