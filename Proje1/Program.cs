using Proje1.Nhibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje1
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Test();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        #region
        static void Test()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var Movie = session.Query<Model.Movie>().ToList();
            }
        }
        #endregion
    }
}
