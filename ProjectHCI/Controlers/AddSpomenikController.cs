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
	class AddSpomenikController : Controller
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

			MainWindow main = MainWindow.Instance();
			Dictionary<string, string> dictionary = main.dictionary;
			string etikete = dictionary["etikete"];
			List<string> ee = new List<string>();
			string[] ar = etikete.Split(',');
			foreach (string item in ar)
			{
				ee.Add(item.Trim());
				Console.WriteLine(item.Trim());
			}
			
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
				string query = "INSERT INTO `QlmldJccRC`.`hci_spomenik_table` (`oznaka`, `ime`, `opis`, `tip`, `era`, `turisticki_status`, `prihod`, `unesco`, `naseljeno_mesto`, `datum_otkrivanja`, `ikonica`, `obradjen`)" +
					" VALUES ('" + dictionary["oznaka"] + "', '" + dictionary["ime"] + "', '" + dictionary["opis"] + "', '" + dictionary["tipovi"] + "', '" + dictionary["era"] + "', '" + dictionary["status"] + "', '" + dictionary["prihod"] + "', '" + dictionary["unesco"] + "', '" + dictionary["naselje"] + "', '" + dictionary["date"] + "', '" + dictionary["ikonica"] + "', '" + dictionary["obradjen"] + "')";
					var cmd = new MySqlCommand(query, dbCon.Connection);
					cmd.ExecuteNonQuery();

				int i = 0;
				foreach(string el in ee)
				{

					string query2 = "INSERT INTO `QlmldJccRC`.`hci_spomenik_etiketa` (`oznaka_etikete`, `oznaka_spomenika`) VALUES ('" + el + "', '" + dictionary["oznaka"] + "')";
					var cmd2 = new MySqlCommand(query2, dbCon.Connection);
					cmd2.ExecuteNonQuery();

				}

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
				Dictionary<string, string> dictionary = MainWindow.Instance().dictionary;
				//+ dictionary["oznaka"] + "', '" + dictionary["ime"] + "', '" + dictionary["opis"] + "', '" +
				//dictionary["tipovi"] + "', '" + dictionary["era"] + "', '" + dictionary["status"] + "', '" + dictionary["prihod"] + "', '" + dictionary["unesco"] + 
				//"', '" + dictionary["naselje"] + "', '" + dictionary["date"] + "', '" + dictionary["ikonica"] + "', '" + dictionary["obradjen"] + 
				//
				Monument m = new Monument();
				m.Datum = dictionary["date"];
				m.Oznaka = dictionary["oznaka"];
				m.Ime = dictionary["ime"];
				m.Opis = dictionary["opis"];
				m.Tip = dictionary["tipovi"];
				m.EraPorekla = dictionary["era"];
				m.TuristickiStatus = dictionary["status"];
				m.Prihod = dictionary["prihod"];
				m.Unesco = dictionary["unesco"];
				m.NaseljenoMesto = dictionary["naselje"];
				m.Slika = dictionary["ikonica"];
				m.Obradjen = dictionary["obradjen"];
				MainWindow.Instance().ListSpomenik.Add(m);

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
