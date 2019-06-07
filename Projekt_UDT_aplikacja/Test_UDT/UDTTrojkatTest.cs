using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;

namespace Test_UDT_Trojkat
{
    /// <summary>
    /// Summary description for UDTTest
    /// </summary>
    [TestClass]
    public class UDTTrojkatTest
    {
        private static string sqlconnection = @"DATA SOURCE=MSSQLServer;"
                + "INITIAL CATALOG=projektUDT; INTEGRATED SECURITY=SSPI;";

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            SqlConnection connection = new SqlConnection(sqlconnection);
            String sqlcommand = "CREATE TABLE testT (k dbo.Trojkat); "
                              + "INSERT INTO testT (k) VALUES ('0 0 4 0 4 7');";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlcommand, connection);
                SqlDataReader datareader = command.ExecuteReader();
                datareader.Read();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            SqlConnection connection = new SqlConnection(sqlconnection);
            String sqlcommand = "DROP TABLE testT;";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlcommand, connection);
                SqlDataReader datareader = command.ExecuteReader();
                datareader.Read();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
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
        public void TestTrojkatToString()
        {
            SqlConnection connection = new SqlConnection(sqlconnection);
            String sqlcommand = "SELECT k.ToString() as opis FROM testT;";
            String expected = "Trójkąt o wierzchołkach A( 0 , 0 ), B( 4 , 0 ), C( 4 , 7 )";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlcommand, connection);
                SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    Assert.AreEqual(expected, datareader["opis"].ToString());
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
        }

        [TestMethod]
        public void TestTrojkatPole()
        {
            SqlConnection connection = new SqlConnection(sqlconnection);
            String sqlcommand = "SELECT k.Pole() as pole FROM testT;";
            Double expected = 14;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlcommand, connection);
                SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    Assert.AreEqual(expected, datareader["pole"]);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
        }

        [TestMethod]
        public void TestTrojkatObwod()
        {
            SqlConnection connection = new SqlConnection(sqlconnection);
            String sqlcommand = "SELECT k.Obwod() as obwod FROM testT;";
            Double expected = 19.062;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlcommand, connection);
                SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    Assert.AreEqual(expected, datareader["obwod"]);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
        }

        [TestMethod]
        [ExpectedException(typeof(System.Data.SqlClient.SqlException))]
        public void TestTrojkatNotTriangle()
        {
            SqlConnection connection = new SqlConnection(sqlconnection);
            String sqlcommand = "INSERT INTO testT (k) VALUES ('1 1 2 2 2 2');";

            connection.Open();
            SqlCommand command = new SqlCommand(sqlcommand, connection);
            SqlDataReader datareader = command.ExecuteReader();
            datareader.Read();
        }
    }
}
