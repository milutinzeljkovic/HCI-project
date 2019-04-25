using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ProjectHCI.Models;
using ProjectHCI.DBCredentials;

namespace ProjectHCI.Controlers
{
    class EtiketaControler
    {
		private Etiketa etiketa;
		private string result;

		public String Result
		{
			get;
			set;
		}

		public EtiketaControler(Etiketa etiketa)
		{
			this.etiketa = etiketa;
		}

		public void setEtiketaOznaka(String oznaka)
		{
			etiketa.Oznaka = oznaka;
		}
		public void setEtiketaBoja(string boja)
		{
			etiketa.Boja = boja;

		}
		public void setEtiketaOpis(string opis)
		{
			etiketa.Opis = opis;
		}

		public void saveEtiketa()
		{
			
			DBCredential db = DBCredential.Instance();
			var dbCon = DBConnection.Instance();
			dbCon.DatabaseName = db.Database;
			dbCon.Username = db.Username;
			dbCon.Server = db.Server;
			dbCon.Password = "";
			if (dbCon.IsConnect())
			{
				try { 
					//suppose col0 and col1 are defined as VARCHAR in the DB
					string query = "INSERT INTO radno_vreme_uC.hci_oznaka_table (id_oznaka, opis, boja) VALUES ('"+etiketa.Oznaka+"','"+etiketa.Opis+"','"+etiketa.Boja+"')";
					var cmd = new MySqlCommand(query, dbCon.Connection);

					cmd.ExecuteNonQuery();

					this.Result = "uspesno";
					dbCon.Close();
				}
				catch (MySqlException e)
				{
					this.Result = "greska";
				}
				finally
				{
					dbCon.Close();
				}
				
				
			}
		}

		public static List<Etiketa> fetchEtikete()
		{
			DBCredential db = DBCredential.Instance();
			var dbCon = DBConnection.Instance();
			dbCon.DatabaseName = db.Database;
			dbCon.Username = db.Username;
			dbCon.Server = db.Server;
			dbCon.Password = "";

			List<Etiketa> etikete = new List<Etiketa>();

			if (dbCon.IsConnect())
			{
				try
				{
					string query = "SELECT * FROM radno_vreme_uC.hci_oznaka_table";
					var cmd = new MySqlCommand(query, dbCon.Connection);
					var reader = cmd.ExecuteReader();

					Console.WriteLine(reader);
					while (reader.Read())
					{

						etikete.Add(new Etiketa() { Oznaka = reader.GetString("id_oznaka"), Opis = reader.GetString("opis"), Boja = reader.GetString("boja") });


					}
					dbCon.Close();
					return etikete;


				}
				catch (MySqlException e)
				{
					Console.WriteLine("greska");
				}
				finally
				{
					dbCon.Close();
				}
			}
			return etikete;

		}



		public void updateView()
		{
			
		}
		

    }
}
