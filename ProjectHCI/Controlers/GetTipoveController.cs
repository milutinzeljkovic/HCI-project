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
	class GetTipoveController : Controller
	{
		private static BackgroundWorker backgroundWorker;

		public void handle()
		{
			backgroundWorker = new BackgroundWorker

			{

				WorkerReportsProgress = true,
				WorkerSupportsCancellation = true

			};
			backgroundWorker.DoWork += doWork;
			backgroundWorker.RunWorkerCompleted += workCompleted;
			backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
			backgroundWorker.RunWorkerAsync("Press Enter in the next 5 seconds to Cancel operation:");
			Console.ReadLine();
		}

		private void doWork(object sender, DoWorkEventArgs e)
		{

			DBCredential db = DBCredential.Instance();
			var dbCon = DBConnection.Instance();
			dbCon.DatabaseName = db.Database;
			dbCon.Username = db.Username;
			dbCon.Server = db.Server;
			dbCon.Password = "wU17KVpis3";

			List<Tip> tipovi = new List<Tip>();

			if (dbCon.IsConnect())
			{
				try
				{
					string query = "SELECT * FROM hci_tip_table";
					var cmd = new MySqlCommand(query, dbCon.Connection);
					var reader = cmd.ExecuteReader();

					Console.WriteLine(reader);
					while (reader.Read())
					{
						tipovi.Add(new Tip() { Oznaka = reader.GetString("oznaka"), Ime = reader.GetString("ime"), Opis = reader.GetString("opis"), Icon = reader.GetString("slika") });
					}
					dbCon.Close();
					e.Result = tipovi;


				}
				catch (MySqlException ex)
				{
					e.Result = "greska";
					Console.WriteLine("greska");
				}
				finally
				{
					dbCon.Close();
				}
			}


		}

		private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{

			Console.WriteLine("Completed" + e.ProgressPercentage + "%");

		}


		private void workCompleted(object sender, RunWorkerCompletedEventArgs e)
		{

			if ((List<Tip>)e.Result != null)
			{

				MainWindow.Instance().ListTipovi = (List<Tip>)e.Result;
				Observers.App.Instance().State = "odabir_tipa";

			}

			else
			{


			}

		}

	}
}
