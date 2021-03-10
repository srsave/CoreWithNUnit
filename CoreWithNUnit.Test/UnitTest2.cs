using System.Collections.Generic;
using NUnit.Framework;
using System.Web;
using System;
using System.Text.RegularExpressions;

//using System.Net.Mail;
using System.Configuration;
using System.Text;
using System.IO;
using System.Globalization;
using CoreWithNUnit.Controllers;
using CoreWithNUnit.ViewModels;

namespace SampleAdditionCore1_NUnit
{
    //TestSet
    public class TetstSetInfo2
    {

        public string l_Header { get; set; }
        
        public TetstSetInfo2(string _Header)
        {
            l_Header = _Header;

        }

    }

    [TestFixture]
    public class TestCases2
    {
        private static IEnumerable<TetstSetInfo2> ParamterValuesSet1
        {
            get
            {

                yield return new TetstSetInfo2("AWS Asp.Net Core Example (Using DevOps)");
             
            }
        }
    
        [Test, TestCaseSource("ParamterValuesSet1")]
        public void checkHeaderString(TetstSetInfo2 tci)
        {
            string header = "AWS Asp.Net Core Example (Using DevOps)";
            // Assert.AreEqual(true, flag);

            if (header == tci.l_Header)
            {
                Assert.Pass("Passed : Header is AWS Asp.Net Core Example (Using DevOps)");
            }
            else
            {
                Assert.Fail("Header Should be AWS Asp.Net Core Example (Using DevOps)");
            }

        }

    }
}

