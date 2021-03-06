﻿using MySql.Data.MySqlClient;
using ProjectHCI.DBCredentials;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ProjectHCI.Controlers
{
	public class AddEtiketuController : Controller
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
			
			Console.WriteLine("asdasdasdasdsadasds");
			MainWindow main = MainWindow.Instance();

			string oznaka = main.EOznaka;
			string opis = main.EOpis;
			string boja = main.EBoja;
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
				
					string query = "INSERT INTO hci_etiketa_table (id_oznaka, opis, boja) VALUES ('" + oznaka + "','" + opis + "','" + boja + "')";
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


		private  void workCompleted(object sender, RunWorkerCompletedEventArgs e)
		{

			MainWindow.Instance().BtnAddEtiketu = true;

			if ((string)e.Result == "uspesno")
			{
				Observers.App.Instance().State = "uspesno_etiketa";
				Console.WriteLine("completed");

			}

			else
			{
				Observers.App.Instance().State = "neuspesno_etiketa";
				Console.WriteLine(e);

			}

		}


	}
}
