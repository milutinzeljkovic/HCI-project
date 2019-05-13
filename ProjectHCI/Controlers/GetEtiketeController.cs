
using MySql.Data.MySqlClient;
using ProjectHCI.DBCredentials;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHCI.Models;

namespace ProjectHCI.Controlers
{
	class GetEtiketeController : Controller
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

			List<Etiketa> etikete = new List<Etiketa>();

			if (dbCon.IsConnect())
			{
				try
				{
					string query = "SELECT * FROM hci_etiketa_table";
					var cmd = new MySqlCommand(query, dbCon.Connection);
					var reader = cmd.ExecuteReader();

					Console.WriteLine(reader);
					while (reader.Read())
					{

						etikete.Add(new Etiketa() { Oznaka = reader.GetString("id_oznaka"), Opis = reader.GetString("opis"), Boja = reader.GetString("boja") });


					}
					dbCon.Close();
					e.Result = etikete;


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

			if ((List<Etiketa>)e.Result != null)
			{

				MainWindow.Instance().ListEtikete = (List<Etiketa>)e.Result;
				Observers.App app = Observers.App.Instance();
				if (app.State == "izmena_etiketa")
				{
					Observers.App.Instance().State = "modifikacija_etikete";
				}
				else
				{
					Observers.App.Instance().State = "odabir_etikete";
				}
				

			}

			else
			{
				

			}

		}


	}
}
