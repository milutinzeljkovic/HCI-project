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
	class TipControler
	{
		private Tip tip;
		private string result;

		public String Result
		{
			get;
			set;
		}

		public TipControler(Tip tip)
		{
			this.tip = tip;
		}

		public void setTipIme(string ime)
		{
			tip.Ime = ime;
		}

		public void setTipOznaka(String oznaka)
		{
			tip.Oznaka = oznaka;
		}
		
		public void setTipOpis(string opis)
		{
			tip.Opis = opis;
		}
		public void setTipImg(string img)
		{
			tip.Icon = img;
		}

		public void saveTip()
		{

			DBCredential db = DBCredential.Instance();
			var dbCon = DBConnection.Instance();
			dbCon.DatabaseName = db.Database;
			dbCon.Username = db.Username;
			dbCon.Server = db.Server;
			dbCon.Password = "";
			if (dbCon.IsConnect())
			{
				try
				{
					string query = "INSERT INTO radno_vreme_uC.hci_test_tabelatipoca (oznaka, ime, opis, slika) VALUES ('" + tip.Oznaka + "','" + tip.Ime + "','" + tip.Opis + "','" + tip.Icon + "')";
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

		public static List<Tip> fetchTip()
		{
			DBCredential db = DBCredential.Instance();
			var dbCon = DBConnection.Instance();
			dbCon.DatabaseName = db.Database;
			dbCon.Username = db.Username;
			dbCon.Server = db.Server;
			dbCon.Password = "";

			List<Tip> tipovi = new List<Tip>();

			if(dbCon.IsConnect())
			{
				try
				{
					string query = "SELECT * FROM radno_vreme_uC.hci_test_tabelatipoca";
					var cmd = new MySqlCommand(query, dbCon.Connection);
					var reader = cmd.ExecuteReader();
					
					Console.WriteLine(reader);
					while (reader.Read())
					{
						
						tipovi.Add(new Tip(){Oznaka = reader.GetString("oznaka"), Ime = reader.GetString("ime"), Opis = reader.GetString("opis"), Icon = reader.GetString("slika") });
						

					}
					dbCon.Close();
					return tipovi;


				}
				catch(MySqlException e)
				{
					Console.WriteLine("greska");
				}
				finally
				{
					dbCon.Close();
				}
			}
			return tipovi;

		}


		public void updateView()
		{

		}
	}
}
