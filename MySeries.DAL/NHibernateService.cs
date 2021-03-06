﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MySeries.DAL.Mappings;

namespace MySeries.DAL
{
    using global::NHibernate;
    using global::NHibernate.Cfg;
    using global::NHibernate.Tool.hbm2ddl;
    using Model;
    using Repositories;

    public class NHibernateService
    {
        private static ISessionFactory _sessionFactory;


        public static ISession OpenSession()
        {
            try
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = OpenSessionFactory();
                }
                ISession session = _sessionFactory.OpenSession();
                return session;
            }
            catch (Exception e)
            {
                throw e.InnerException ?? e;
            }
        }

        public static ISessionFactory OpenSessionFactory()
        {
            string connectionString = "server=localhost;database=test;uid=admin;";
            try
            {
                var fluentConfig = Fluently.Configure()
                                    .Database(MySQLConfiguration.Standard
                                        .ConnectionString(connectionString))
                                        //.AdoNetBatchSize(100))
                                    .Mappings(mappings => mappings.FluentMappings.AddFromAssemblyOf<UserMap>());

                var nhConfig = fluentConfig.BuildConfiguration();

                _sessionFactory = nhConfig.BuildSessionFactory();

                // this is for rebuilding the database
                ISession Session = _sessionFactory.OpenSession();
                var dir = System.IO.Directory.GetCurrentDirectory();

       /*using (var tx = Session.BeginTransaction())
                {
                    new SchemaExport(nhConfig).Execute(useStdOut: true,
                                                                execute: true,
                                                                justDrop: false,
                                                                connection: Session.Connection,
                                                                exportOutput: Console.Out);
                    tx.Commit();
                }  */
               
            }
            catch (Exception)
            {

                throw;
            }
            
            return _sessionFactory;
        }

     /*   public static void CreateUserAndSaveToDatabase()
        {
            var lovro = new User();
            lovro.name = "Lovro";
            lovro.surname = "Filipovic";

            using (var session = OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(lovro);
                    transaction.Commit();
                }
            }
        }
        */
     
    }
}
