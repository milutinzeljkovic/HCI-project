﻿using MySql.Data.MySqlClient;
using ProjectHCI.DBCredentials;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHCI.Controlers
{
	class UpdateEtiketuController : Controller
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
			Console.WriteLine("update");

			IzmenaEtikete i = IzmenaEtikete.Instance();
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

					string query = "Update  hci_etiketa_table set opis = '"+i.Opis+"', boja = '"+i.Boja+"' where id_oznaka = '"+i.Oznaka+"'";
					var cmd = new MySqlCommand(query, dbCon.Connection);
					cmd.ExecuteNonQuery();
					dbCon.Close();
					e.Result = "uspesno";

				}
				catch (MySqlException ex)
				{
					Console.WriteLine(ex);
					e.Result = ex.Message;
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

			MainWindow.Instance().BtnAddEtiketu = true;

			if ((string)e.Result == "uspesno")
			{
				Console.WriteLine("completed");
				Observers.App.Instance().State = "modifikacija_etikete_uspesno";

			}

			else
			{
				Console.WriteLine(e);

			}

		}


	}
}