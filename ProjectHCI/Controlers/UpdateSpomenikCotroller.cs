using MySql.Data.MySqlClient;
using ProjectHCI.DBCredentials;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectHCI.Controlers
{
	class UpdateSpomenikCotroller : Controller
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
 			IzmenaSpomenika i = IzmenaSpomenika.Instance();

			//ovo za update starih etiketa ako se promene necu sad da radim ovo
			string[] stareEtikete = i.EtiketaStara.Split(',');
			string[] noveEtikete = i.Etiketa.Split(',');

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

					string query = "Update  hci_spomenik_table set opis = '" + i.Opis + "', ime = '" + i.Ime + "',tip = '" + i.Tip  + "', " +
						"era = '" + i.Era + "',turisticki_status = '" + i.TuristickiStatus + "',prihod = '" + i.Prihod +
						 "',naseljeno_mesto = '" + i.Naselje + "',datum_otkrivanja = '" + i.Datum + "',ikonica = '" + i.Slika +
						  "',obradjen = '" + i.Obradjen + "'  where oznaka = '" + i.Oznaka + "'";
					var cmd = new MySqlCommand(query, dbCon.Connection);
					if((stareEtikete.Length != noveEtikete.Length))
					{
						int cnt1 = stareEtikete.Length;
						int cnt2 = noveEtikete.Length;
						int brojac = cnt2 - cnt1;
						int pocetak = cnt1 - 1;
						for(int ii=1;ii<=brojac;ii++)
						{
							string query2 = "INSERT INTO `QlmldJccRC`.`hci_spomenik_etiketa` (`oznaka_etikete`, `oznaka_spomenika`) VALUES ('" + noveEtikete[ii+pocetak] + "', '" + i.Oznaka + "')";
							var cmd2 = new MySqlCommand(query2, dbCon.Connection);
							cmd2.ExecuteNonQuery();
						}

						
					}



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
				MessageBox.Show("Uspesno modifikovano!", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
				Load l = new Load();
				l.handle();
				//Observers.App.Instance().State = "modifikacija_etikete_uspesno";

			}

			else
			{
				Console.WriteLine(e);

			}

		}
	}
}
