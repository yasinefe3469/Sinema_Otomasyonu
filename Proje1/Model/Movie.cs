using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Proje1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Model
{
    public  class Movie
    {

       public Movie()
        {
            setDefaultSessions();
        }

        public virtual int movieId { get; set; }
        public virtual string picturePath { get; set; }
        public virtual string minute { get; set; }
        public virtual decimal price { get; set; }
        public virtual Category category { get; set; }
        public virtual List<Session>  sessions { get; set; }
        public virtual string movieName { get; set; }

        private void setDefaultSessions()
        {
            sessions = new List<Session>();
            DateTime currentDate = DateTime.Now;
            TimeSpan ts = new TimeSpan(10,30,0);
            for (int i = 0; i < 3; i++)
            {
                currentDate = currentDate.Date + ts;
                for (int k = 0; k < 3; k++)
                {
                    Session session = new Session();
                    session.date = currentDate.ToShortDateString();
                    session.time = currentDate.ToShortTimeString();
                    sessions.Add(session);
                    currentDate = currentDate.AddHours(3);
                }
                currentDate = currentDate.AddDays(1);
            }
        }
    }

    public class MoviesMapping : ClassMapping<Movie>
    {
        public MoviesMapping()
        {
            Table("Movie");
            Id(x => x.movieId, m => m.Generator(Generators.Native));
            Property(x => x.picturePath, x => x.NotNullable(true));
            Property(x => x.minute, x => x.NotNullable(true));
            Property(x => x.price, x => x.NotNullable(true));
            Property(x => x.category, x => x.NotNullable(true));
            Property(x => x.sessions, x => x.NotNullable(true));
            Property(x => x.movieName, x => x.NotNullable(true));
        }
    }
}
