using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;

namespace Test_UDT_Kwadrat
{
    /// <summary>
    /// Summary description for UDTTest
    /// </summary>
    [TestClass]
    public class UDTKwadratTest
    {
        private static string sqlconnection = @"DATA SOURCE=MSSQLServer;"
                + "INITIAL CATALOG=projektUDT; INTEGRATED SECURITY=SSPI;";

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            SqlConnection connection = new SqlConnection(sqlconnection);
            String sqlcommand = "CREATE TABLE testK (k dbo.Kwadrat); "
                              + "INSERT INTO testK (k) VALUES ('0 0 4 0 4 4 4 0');";
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
            String sqlcommand = "DROP TABLE testK;";
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
        public void TestKwToString()
        {
            SqlConnection connection = new SqlConnection(sqlconnection);
            String sqlcommand = "SELECT k.ToString() as opis FROM testK;";
            String expected = "Kwadrat o wierzchołkach A( 0 , 0 ), B( 4 , 0 ), C( 4 , 4 ), D( 4 , 0 )";
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
        public void TestKwPole()
        {
            SqlConnection connection = new SqlConnection(sqlconnection);
            String sqlcommand = "SELECT k.Pole() as pole FROM testK;";
            Double expected = 16;
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
        public void TestKwObwod()
        {
            SqlConnection connection = new SqlConnection(sqlconnection);
            String sqlcommand = "SELECT k.Obwod() as obwod FROM testK;";
            Double expected = 16;
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
        public void TestKwNotSquare()
        {
            SqlConnection connection = new SqlConnection(sqlconnection);
            String sqlcommand = "INSERT INTO testK(k) VALUES ('1 1 2 2 2 2 5 5');";

            connection.Open();
            SqlCommand command = new SqlCommand(sqlcommand, connection);
            SqlDataReader datareader = command.ExecuteReader();
            datareader.Read();
        }
    }
}
