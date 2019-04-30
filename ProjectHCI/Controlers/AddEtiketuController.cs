using MySql.Data.MySqlClient;
using ProjectHCI.DBCredentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHCI.Controlers
{
	public class AddEtiketuController : Controller
	{
		public void handle()
		{

			MainWindow main = MainWindow.Instance();
			string oznaka = main.textBoxEtiketaOznaka.Text;
			string opis = main.textBoxEtiketaOpis.Text;
			string boja = main.cp.SelectedColor.ToString();
			DBCredential db = DBCredential.Instance();
			var dbCon = DBConnection.Instance();
			dbCon.DatabaseName = db.Database;
			dbCon.Username = db.Username;
			dbCon.Server = db.Server;
			dbCon.Password = "wU17KVpis3";
			if (dbCon.IsConnect())
			{
				try
				{
					//suppose col0 and col1 are defined as VARCHAR in the DB
					//string query = "INSERT INTO radno_vreme_uC.hci_oznaka_table (id_oznaka, opis, boja) VALUES ('"+etiketa.Oznaka+"','"+etiketa.Opis+"','"+etiketa.Boja+"')";
					string query = "INSERT INTO hci_etiketa_table (id_oznaka, opis, boja) VALUES ('" + oznaka + "','" + opis + "','" + boja + "')";

					var cmd = new MySqlCommand(query, dbCon.Connection);
					cmd.ExecuteNonQuery();
					dbCon.Close();
					Observers.App.Instance().State = "uspesno_etiketa";

				}
				catch (MySqlException e)
				{
					Observers.App.Instance().State = "neuspesno_etiketa";
				}
				finally
				{
					dbCon.Close();
				}


			}
		}
	}
}
