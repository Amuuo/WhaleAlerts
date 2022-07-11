using System.Data.SqlClient;
using WhaleAlertsLibrary.Models;
using WhaleAlertsLibrary.Controllers;

Console.WriteLine("Hello, World!");
/*
var sql = new SqlConnection("Data Source=localhost;Initial Catalog=VAULT;Integrated Security=True");
sql.Open();

var cmd = new SqlCommand("SELECT * FROM dbo.WhaleTransaction", sql);

var reader = cmd.ExecuteReader();

var transactions = WhaleTransactionDataController.GetWhaleTransactionSQL();

while (reader.Read())
{
    Console.WriteLine($"id: {reader["id"]}");
}
*/

var controller = new CryptoCompareApiController();


Console.WriteLine(controller.GetCoinImageUrl("BTC"));
Console.WriteLine(controller.GetCoinImageUrl("ETH"));
Console.WriteLine(controller.GetCoinImageUrl("XRP"));




