using NUnit.Framework;
using System.Configuration;
using System.Data;
using WpfApp1;
using System.Data.SqlClient;


namespace TestProject5
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestAddReservation()
        {
            // Arrange
            var connectionString = ConfigurationManager.ConnectionStrings["RestoranConnectionString"].ConnectionString;
            var sqlConnection = new SqlConnection(connectionString);
            var sqlCommand = new SqlCommand("AddResProc", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@fio", "Иванов Иван Иванович");
            sqlCommand.Parameters.AddWithValue("@num", "8-913-123-45-67");
            sqlCommand.Parameters.AddWithValue("@tab", 1);
            sqlCommand.Parameters.AddWithValue("@time_res", new DateTime(2023, 06, 10, 14, 0, 0));
            sqlCommand.Parameters.AddWithValue("@status", "Ожидает");
            sqlCommand.Parameters.AddWithValue("@fam", "Manager");

            // Act
            sqlConnection.Open();
            var result = sqlCommand.ExecuteNonQuery();

            // Assert
            Assert.AreEqual(1, result);
        }
    }
}