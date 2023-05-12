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
    public class Session
    {
        public Session()
        {
            SetDefaultChairs();
        }
        public virtual int sessionId { get; set; }

        public virtual string date { get; set; }
        public virtual string time { get; set; }
        public virtual List<Chair> chairs { get; set; }

        private void SetDefaultChairs()
        {
            chairs = new List<Chair>();
            string[] rows = { "a", "b", "c", "d" };
            string[] numbers = { "1", "2", "3", "4","5","6" };
            foreach (string row in rows)
            {
                foreach (string number in numbers)
                {
                    Chair chair = new Chair(row, number);
                    chairs.Add(chair);
                }
            }
        }
    }

    public class SessionMapping : ClassMapping<Session>
    {
        public SessionMapping()
        {
            Table("Sessions");
            Id(x => x.sessionId, m => m.Generator(Generators.Native));
            Property(x => x.date, x => x.NotNullable(true));
            Property(x => x.time, x => x.NotNullable(true));
            Property(x => x.chairs, x => x.NotNullable(true));
        }
    }
}
