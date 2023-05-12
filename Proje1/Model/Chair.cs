using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Proje1.Model
{
    [Serializable]
    public class Chair
    {
        public Chair(string _row, string _number)
        {
            row = _row;
            number = _number;
          
        }

        public virtual int chairId { get; set; }
        public virtual string row { get; set; }
        public virtual string number  { get; set; }
        public virtual bool status { get; set; }
    }

    public class chairMap : ClassMapping<Chair>
    {
        public chairMap()
        {
            Table("chairs");
            Id(x => x.chairId, m => m.Generator(Generators.Native));
            Property(x => x.row, x => x.NotNullable(true));
            Property(x => x.number, x => x.NotNullable(true));
            Property(x => x.status, x => x.NotNullable(true));
        }
    }
}
