using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ProjectHCI.Models;

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

			var dbCon = DBConnection.Instance();
			//
			//
			//
			//
			//
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
		public void updateView()
		{

		}
	}
}
