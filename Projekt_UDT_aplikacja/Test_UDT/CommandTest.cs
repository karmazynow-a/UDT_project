using Projekt_UTD_aplikacja;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test_UDT
{
    
    
    /// <summary>
    ///This is a test class for CommandTest and is intended
    ///to contain all CommandTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CommandTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetInsertHelper
        ///</summary>
        [TestMethod()]
        public void GetInsertHelperTest()
        {
            Command target = new Command("s", Command.Type.Select, "Pomoc", new List<string>() {});
            string expected = "Pomoc";
            string actual;
            actual = target.GetInsertHelper();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetCommandType
        ///</summary>
        [TestMethod()]
        public void GetCommandTypeTest()
        {
            Command target = new Command("", Command.Type.Search, "", new List<string>());
            Command.Type expected = Command.Type.Search; 
            Command.Type actual;
            actual = target.GetCommandType();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetCommandType
        ///</summary>
        [TestMethod()]
        public void GetCommandType2Test()
        {
            Command target = new Command();
            Command.Type expected = Command.Type.Null;
            Command.Type actual;
            actual = target.GetCommandType();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetCommand
        ///</summary>
        [TestMethod()]
        public void GetCommandTest()
        {
            Command target = new Command("Zapytanie", Command.Type.Search, "", new List<string>());
            string expected = "Zapytanie";
            string actual;
            actual = target.GetCommand();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetAttributes
        ///</summary>
        [TestMethod()]
        public void GetAttributesTest()
        {
            Command target = new Command("", Command.Type.Search, "", new List<string>(){ "pole", "obwod" });
            List<string> expected = new List<string>() { "pole", "obwod" };
            List<string> actual;
            actual = target.GetAttributes();
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}
