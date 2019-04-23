using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ProjectHCI.Models;

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
			
			var dbCon = DBConnection.Instance();
			//
			//
			//
			//
			//
			//
			if (dbCon.IsConnect())
			{
				//suppose col0 and col1 are defined as VARCHAR in the DB
				string query = "INSERT INTO radno_vreme_uC.hci_oznaka_table (id_oznaka, opis, boja) VALUES ('"+etiketa.Oznaka+"','"+etiketa.Opis+"','"+etiketa.Boja+"')";
				var cmd = new MySqlCommand(query, dbCon.Connection);
				
				try
				{
					var reader = cmd.ExecuteReader();
					this.Result = reader.Read().ToString();
					dbCon.Close();
				}
				catch (MySqlException e)
				{
					this.Result = "greska";
				}
				
				
			}
		}
		public void updateView()
		{
			
		}
		

    }
}
