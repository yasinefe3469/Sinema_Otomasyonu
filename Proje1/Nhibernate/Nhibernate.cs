using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;

namespace Proje1.Nhibernate
{
    public class NhibernateHelper
    {
        protected static Configuration NhConfiguration;
        protected static ISessionFactory LocalSessionFactory;

        private static readonly string exctLcl = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = ConfigureNhibernate();
                    var mapping = GetMappings();
                    configuration.AddDeserializedMapping(mapping, "gorseldata");
                    configuration.SetProperty(NHibernate.Cfg.Environment.Isolation, "ReadCommitted");
                    SchemaMetadataUpdater.QuoteTableAndColumns(configuration, new SQLiteDialect());
                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        public static void Setup()
        {
            CheckDatabase();
            CreateDatabaseSchema();
            try
            {
                NhConfiguration = ConfigureNhibernate();
                var mapping = GetMappings();
                NhConfiguration.AddDeserializedMapping(mapping, "gorseldata");
                //NhConfiguration.SetProperty(NHibernate.Cfg.Environment.Isolation, "ReadCommitted");
                SchemaMetadataUpdater.QuoteTableAndColumns(NhConfiguration, new SQLiteDialect());

                LocalSessionFactory = NhConfiguration.BuildSessionFactory();
            }
            catch (Exception e)
            {
                throw;
            }

        }
        protected static void CheckDatabase()
        {
            //log.Warn("Check DB");
            if (System.IO.File.Exists(exctLcl + "\\gorseldata.db")) return;
            SQLiteConnection.CreateFile(exctLcl + "\\gorseldata.db");
            using (var cn = new SQLiteConnection("Data Source=" + exctLcl + "\\gorseldata.db;Version=3;Password=;PRAGMA journal_mode=WAL;"))
            {
                //cn.ChangePassword("test");
            }
        }
        public static Configuration ConfigureNhibernate()
        {

            var configure = new Configuration();
            configure.SessionFactoryName("BuildIt");
            //log.Warn("Nhibernate Configrate");
            configure.DataBaseIntegration(db =>
            {
                db.Dialect<SQLiteDialect>();
                db.Driver<SQLite20Driver>();
                db.ConnectionString = "Data Source=" + exctLcl + "//gorseldata.db;Version=3;PRAGMA journal_mode=WAL;";
            });
            configure.SetProperty("ConnectionReleaseMode", "on_close");
            return configure;
        }
        public static Configuration ConfigureNhibernateUpdt()
        {

            var configure = new Configuration();
            configure.SessionFactoryName("BuildIt");
            //log.Warn("Nhibernate Configrate");
            configure.DataBaseIntegration(db =>
            {
                db.Dialect<SQLiteDialect>();
                db.Driver<SQLite20Driver>();
                db.ConnectionString = "Data Source=" + exctLcl + "//gorseldata.db;Version=3;PRAGMA journal_mode=WAL;";
                db.LogFormattedSql = true;
                db.LogSqlInConsole = true;
            });
            configure.SetProperty("ConnectionReleaseMode", "on_close");
            return configure;
        }
        protected static HbmMapping GetMappings()
        {
            var mapper = new ModelMapper();

            mapper.AddMapping<Model.MoviesMapping>();
            mapper.AddMapping<Model.SalesMapping>();

            var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            return mapping;
        }

        public static void CreateDatabaseSchema()
        {
            var configuration = ConfigureNhibernateUpdt();
            var mapping = GetMappings();
            configuration.AddDeserializedMapping(mapping, "stats");
            SchemaMetadataUpdater.QuoteTableAndColumns(configuration, new SQLiteDialect());
            new SchemaUpdate(configuration).Execute(false, true);
        }
    }
}
