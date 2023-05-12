using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Model
{
    public class Salon
    {
        public virtual int Id { get; set; }
        public virtual string SalonAdi { get; set; }
        public virtual int KoltukSayisi { get; set; }

    }

    public class SalonMap : ClassMapping<Salon>
    {
        public SalonMap()
        {
            Table("Salon");
            Id(x => x.Id, m => m.Generator(Generators.Native));
            Property(x => x.SalonAdi, x => x.NotNullable(true));
            Property(x => x.KoltukSayisi, x => x.NotNullable(true));
        }
    }
}
