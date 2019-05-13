using MySql.Data.MySqlClient;
using ProjectHCI.DBCredentials;
using ProjectHCI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHCI.Controlers
{
	class GetSpomenikeController : Controller
	{
		public void handle()
		{
			DBCredential db = DBCredential.Instance();
			var dbCon = DBConnection.Instance();
			dbCon.DatabaseName = db.Database;
			dbCon.Username = db.Username;
			dbCon.Server = db.Server;
			dbCon.Password = "wU17KVpis3";

			List<Etiketa> etikete = new List<Etiketa>();

			if (dbCon.IsConnect())
			{
				try
				{
					string query = "SELECT * FROM hci_spomenik_table left outer join hci_spomenik_etiketa on oznaka=oznaka_spomenika";
					var cmd = new MySqlCommand(query, dbCon.Connection);
					var reader = cmd.ExecuteReader();

					Console.WriteLine(reader);
					while (reader.Read())
					{

						Console.WriteLine(reader.GetString("oznaka"));

					}
					dbCon.Close();
		

				}
				catch (MySqlException ex)
				{
					Console.WriteLine("greska");
				}
				finally
				{
					dbCon.Close();
				}
			}
		}
	}
}
