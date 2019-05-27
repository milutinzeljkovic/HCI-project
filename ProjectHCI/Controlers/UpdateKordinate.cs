using MySql.Data.MySqlClient;
using ProjectHCI.DBCredentials;
using ProjectHCI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectHCI.Controlers
{
    class UpdateKordinate
    {

		private Monument monument;
		private static BackgroundWorker backgroundWorker;

		public void handle(Monument m)
		{
			this.monument = m;
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
			int xx = 1;
			int yy = 22;
			dbCon.Password = "wU17KVpis3";
			if (dbCon.IsConnect())
			{
				string query = "Update  hci_spomenik_mapa set x = '" + monument.X + "', y = '" + monument.Y + "' where oznakas = '" + monument.Oznaka + "'";
				var cmd = new MySqlCommand(query, dbCon.Connection);
				cmd.ExecuteNonQuery();


				dbCon.Close();
				e.Result = "uspesno";




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

				MessageBox.Show("Uspesno sacuvano!", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
			}

			else
			{


			}

		}
	}
}
