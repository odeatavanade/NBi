﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using NBi.Xml;
using NUnit.Framework;
using NBi.NUnit;
using NUnitCtr = NUnit.Framework.Constraints;

namespace NBi.NUnit.Runtime
{
    /// <summary>
    /// This Class is the entry point for NUnit.Framework
    /// In reality the NUnit.Framework think this class is the class containing all the fixtures. But
    /// in reality this class will just call the NBi 
    /// </summary>
    [TestFixture]
    public class TestSuite
    {
        public const string DEFAULT_TESTSUITE = "TestSuite.xml";

        [Test, TestCaseSource("GetTestCases")]
        public virtual void ExecuteTestCases(TestXml test)
        {
            Console.Out.WriteLine(string.Format("Loading TestSuite from {0}", GetOwnFilename()));
            Console.Out.WriteLine("Test suite defined in " + GetTestSuiteFileDefinition());

            //check if ignore is set to true
            if (test.Ignore)
                Assert.Ignore();
            else
            {
                foreach (var tc in test.Systems)
                {
                    foreach (var ctr in test.Constraints)
                    {
                        var testCase = new TestCaseFactory().Instantiate(tc, ctr);
                        Assert.That(testCase.SystemUnderTest, testCase.Constraint);
                    }
                }
            }
        }

        public IEnumerable<TestCaseData> GetTestCases()
        {
            var mgr = new XmlManager();

            mgr.Load(GetTestSuiteFileDefinition());

            List<TestCaseData> testCasesNUnit = new List<TestCaseData>();

            foreach (var test in mgr.TestSuite.Tests)
            {
                TestCaseData testCaseDataNUnit = new TestCaseData(test);
                testCaseDataNUnit.SetName(test.Name);
                testCaseDataNUnit.SetDescription(test.Description);
                foreach (var category in test.Categories)
                {
                    testCaseDataNUnit.SetCategory(category);
                }
                testCasesNUnit.Add(testCaseDataNUnit);
            }
            return testCasesNUnit;
        }

        protected virtual string GetTestSuiteFileDefinition()
        {
            string assem = Path.GetFullPath((new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath).Replace("%20"," ");
            string configFile = Path.Combine(Path.GetDirectoryName(assem), Path.GetFileNameWithoutExtension(assem) + ".config");
            
            //Set the default TestSuite
            string testSuiteFile = DEFAULT_TESTSUITE;
            
            //Try to find a config file, if existing take the path inside for the TestSuite
            Console.Out.WriteLine("Looking after config file located at '{0}'", configFile);
            if (File.Exists(configFile))
            {
                Console.Out.WriteLine("Config File found!");
                using (var sr = new StreamReader(configFile))
                {
                    testSuiteFile = sr.ReadToEnd();
                }
            }
            else
            {
                // If no config file is registered then search the first "nbits" (NBi Test Suite) file
                Console.Out.WriteLine("No config file found.");

                if (GetOwnFilename() != GetManifestName())
                {
                    var testSuiteName = Path.GetDirectoryName(assem) + Path.GetFileNameWithoutExtension(GetOwnFilename()) + ".nbits";
                    Console.Out.WriteLine(string.Format("Dll for runtime renamed, looking after {0}", testSuiteName));
                    if (File.Exists(testSuiteName))
                    {
                        testSuiteFile = testSuiteName;
                        Console.Out.WriteLine("TestSuite File found!");
                    }
                    else
                        Console.Out.WriteLine("TestSuite file NOT found!");
                }
                else
                {
                    Console.Out.WriteLine("Looking after 'nbits' files ...");
                    var files = System.IO.Directory.GetFiles(Path.GetDirectoryName(assem), "*.nbits");
                    if (files.Count() == 1)
                    {
                        Console.Out.WriteLine("'{0}' found, using it!", files[0]);
                        testSuiteFile = files[0];
                    }
                    else if (files.Count() > 1)
                    {
                        Console.Out.WriteLine("{0} 'nbits' files found, using the first found: '{1}'!", files.Count(), files[0]);
                        testSuiteFile = files[0];
                    }
                    else
                        Console.Out.WriteLine("No 'nbits' file found");
                }
            }

            return testSuiteFile;
        }

        protected internal string GetOwnFilename()
        {
            //get the full location of the assembly with DaoTests in it
            var fullPath = System.Reflection.Assembly.GetAssembly(typeof(TestSuite)).Location;

            //get the filename that's in
            var fileName = Path.GetFileName( fullPath );

            return fileName;
        }

        protected internal string GetManifestName()
        {
            //get the full location of the assembly with DaoTests in it
            var fullName = System.Reflection.Assembly.GetAssembly(typeof(TestSuite)).ManifestModule.Name;

            return fullName;
        }
    }
}
