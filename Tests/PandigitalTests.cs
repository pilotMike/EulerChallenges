using System;
using System.Text;
using System.Collections.Generic;
using EulerTools.Numbers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    /// <summary>
    /// Summary description for PandigitalTests
    /// </summary>
    [TestClass]
    public class PandigitalTests
    {
        private Pandigital pandigital;

        public PandigitalTests()
        {
            pandigital = new Pandigital();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void returns_true_if_pandigital()
        {
            int v1 = 39;
            int v2 = 186;
            int product = v1*v2;
            var result = pandigital.IsPandigital(v1, v2, product);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void pandigital_returns_false_if_length_not_9()
        {
            int v1 = 2;
            int v2 = 1234;
            int product = v1*v2;
            bool result = pandigital.IsPandigital(v1, v2, product);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void returns_false_if_duplicate_numbers_in_prospect()
        {
            int v1 = 458;
            int v2 = 459;
            int product = v1*v2;
            bool result = pandigital.IsPandigital(v1, v2, product);
            Assert.AreEqual(false, result);
        }
    }
}
