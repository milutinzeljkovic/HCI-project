﻿using MySql.Data.MySqlClient;
using ProjectHCI.DBCredentials;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProjectHCI.Models;

namespace ProjectHCI.Controlers
{
    class DeleteSpomenikMapa
    {
		Monument m;
		private static BackgroundWorker backgroundWorker;
		private Dictionary<string, Dictionary<string, string>> resultSet;
		public void handle(Monument m)
		{
			this.m = m;
			resultSet = new Dictionary<string, Dictionary<string, string>>();
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



			if (dbCon.IsConnect())
			{
				try
				{
					
					string query = "delete from hci_spomenik_mapa where oznakas ='" + m.Oznaka + "'";
					var cmd = new MySqlCommand(query, dbCon.Connection);
					var reader = cmd.ExecuteNonQuery();
					dbCon.Close();
					e.Result = "uspesno";


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

			if (e.Result.Equals("uspesno"))
			{
				MainWindow.Instance().ListSpomenik.Remove(m);
				MessageBox.Show("Uspesno izbrisano!", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
				Observers.App.Instance().State = "inital_state";
			}
		}
	}
}