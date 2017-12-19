﻿#region Using directives
using System;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using Microsoft.AnalysisServices.AdomdClient;
using NBi.Core.Query.Connection;
using NUnit.Framework;
using System.Collections.Generic;
using NBi.Core.PowerBiDesktop;

#endregion

namespace NBi.Testing.Unit.Core.Query.Connection
{
    [TestFixture]
    public class SqlConnectionFactoryTest
    {

        #region SetUp & TearDown
        //Called only at instance creation
        [TestFixtureSetUp]
        public void SetupMethods()
        {

        }

        //Called only at instance destruction
        [TestFixtureTearDown]
        public void TearDownMethods()
        {
        }

        //Called before each test
        [SetUp]
        public void SetupTest()
        {
        }

        //Called after each test
        [TearDown]
        public void TearDownTest()
        {
        }
        #endregion

        [Test]
        public void Get_NoProviderDefined_SqlConnection()
        {
            var connStr = "Data Source=ds;Initial Catalog=ic";
            var actual = new SqlConnectionFactory().Instantiate(connStr);

            Assert.That(actual, Is.InstanceOf<DbConnection>());
            Assert.That(actual.ConnectionString, Is.EqualTo(connStr));
            var conn = actual.CreateNew();

            Assert.That(conn, Is.InstanceOf<SqlConnection>());
            Assert.That((conn as SqlConnection).ConnectionString, Is.EqualTo(connStr));
        }
    }
}
