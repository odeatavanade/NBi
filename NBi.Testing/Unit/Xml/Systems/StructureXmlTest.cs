﻿#region Using directives
using System;
using System.Linq;
using NUnit.Framework;
#endregion

namespace NBi.Testing.Unit.Xml.Systems
{
    [TestFixture]
    public class StructureXmlTest
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

        [Ignore]
        [Test]
        public void EmptyTestFile()
        {
        }

    }
}
