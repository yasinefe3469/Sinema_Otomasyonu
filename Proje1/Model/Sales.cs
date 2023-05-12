using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Proje1.Model
{
    public class Sales 
    {
        public Sales()
        {
            creationDate = DateTime.Now.ToString();
        }
        public virtual int salesId { get; set; }
        public virtual string creationDate { get; set; }
        public virtual decimal totalPrice { get; set; }
        public virtual int count { get; set; }

        public virtual string sessionTime { get; set; }

        public virtual string customerInfo { get; set; }

        public virtual string chairs { get; set; }

        public override string ToString()
        {
            Movie movie = new Movie();
            return $"{movie.movieName} Adlı Filmin {sessionTime} Seansına {count} Adet Bilet Kesilmiştir. Toplam Tutar {totalPrice} ₺ || Satın" +
                $"Alınma Tarihi = {creationDate}";
        }
    }

    public class SalesMapping : ClassMapping<Sales>
    {
        public SalesMapping()
        {
            Table("Sales");
            Id(x => x.salesId, m => m.Generator(Generators.Native));
            Property(x => x.creationDate, x => x.NotNullable(true));
            Property(x => x.totalPrice, x => x.NotNullable(true));
            Property(x => x.count, x => x.NotNullable(true));
            Property(x => x.sessionTime, x => x.NotNullable(true));
            Property(x => x.customerInfo, x => x.NotNullable(false));
            Property(x => x.chairs, x => x.NotNullable(false));
        }
    }
}
