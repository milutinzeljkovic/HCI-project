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
	class AddTipController : Controller
	{
		private static BackgroundWorker backgroundWorker;

		public void handle()
		{
			Console.WriteLine("krenuo");
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

			MainWindow main = MainWindow.Instance();
			string oznaka = main.TOznaka;
			string opis = main.TOpis;
			string slika = main.TSlika;
			string ime = main.TIme;
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
					string query = "INSERT INTO hci_tip_table (oznaka, ime, opis, slika) VALUES ('" + oznaka + "','" + ime + "','" + opis + "','" +slika + "')";
					var cmd = new MySqlCommand(query, dbCon.Connection);
					cmd.ExecuteNonQuery();
					dbCon.Close();
					e.Result = "uspesno";

				}
				catch (MySqlException ex)
				{
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

			MainWindow.Instance().BtnAddTip = true;

			if ((string)e.Result == "uspesno")
			{
				
				Observers.App.Instance().State = "uspesno_tip";
				Console.WriteLine("completed");

			}

			else
			{
				Observers.App.Instance().State = "neuspesno_tip";
				Console.WriteLine(e);

			}

		}
	}
}
