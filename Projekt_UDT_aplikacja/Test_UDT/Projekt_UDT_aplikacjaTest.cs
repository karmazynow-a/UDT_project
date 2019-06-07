using Projekt_UTD_aplikacja;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Test_UDT
{
    
    
    /// <summary>
    ///This is a test class for Projekt_UDT_aplikacjaTest and is intended
    ///to contain all Projekt_UDT_aplikacjaTest Unit Tests
    ///</summary>
    [TestClass()]
    public class Projekt_UDT_aplikacjaTest
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

        /// <summary>
        ///A test for HandleMenu
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Projekt_UTD_aplikacja.exe")]
        public void HandleMenuTest()
        {
            int c = 'k';
            Projekt_UDT_aplikacja_Accessor.Figure expected = Projekt_UDT_aplikacja_Accessor.Figure.Kolo;
            Projekt_UDT_aplikacja_Accessor.Figure actual;
            actual = Projekt_UDT_aplikacja_Accessor.HandleMenu(c);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for HandleMenu
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Projekt_UTD_aplikacja.exe")]
        public void HandleMenu2Test()
        {
            int c = 'q';
            Projekt_UDT_aplikacja_Accessor.Figure expected = Projekt_UDT_aplikacja_Accessor.Figure.Nieznana;
            Projekt_UDT_aplikacja_Accessor.Figure actual;
            actual = Projekt_UDT_aplikacja_Accessor.HandleMenu(c);
            Assert.AreEqual(expected, actual);
        }
    }
}
