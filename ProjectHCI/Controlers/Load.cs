using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ProjectHCI.DBCredentials;
using ProjectHCI.Models;

namespace ProjectHCI.Controlers
{
	class Load
	{
		private static BackgroundWorker backgroundWorker;
		private Dictionary<string, Dictionary<string, string>> resultSet;
		Dictionary<string, List<double>> positions = new Dictionary<string, List<double>>();

		public void handle()
		{


			MainWindow.Instance().prikazi_etikete.IsEnabled = false;
			MainWindow.Instance().prikazi_spomenike.IsEnabled = false;
			MainWindow.Instance().prikazi_tipove.IsEnabled = false;

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


					string query = "select * from hci_spomenik_table left outer join hci_spomenik_etiketa on oznaka = oznaka_spomenika left outer join hci_spomenik_mapa on oznaka = oznakas";
					var cmd = new MySqlCommand(query, dbCon.Connection);
					var reader = cmd.ExecuteReader();





					Console.WriteLine(reader);
					while (reader.Read())
					{

						Console.WriteLine(reader.GetString("oznaka"));
						//etikete.Add(new Etiketa() { Oznaka = reader.GetString("id_oznaka"), Opis = reader.GetString("opis"), Boja = reader.GetString("boja") });
						if (!resultSet.ContainsKey(reader.GetString("oznaka")))
						{
							Dictionary<string, string> values = new Dictionary<string, string>();
							values.Add("ime", reader.GetString("ime"));
							values.Add("opis", reader.GetString("opis"));
							values.Add("tip", reader.GetString("tip"));
							values.Add("era", reader.GetString("era"));
							values.Add("turisticki_status", reader.GetString("turisticki_status"));
							values.Add("prihod", reader.GetString("prihod"));
							values.Add("unesco", reader.GetString("unesco"));
							values.Add("naseljeno_mesto", reader.GetString("naseljeno_mesto"));
							values.Add("datum_otkrivanja", reader.GetString("datum_otkrivanja"));
							values.Add("ikonica", reader.GetString("ikonica"));
							values.Add("obradjen", reader.GetString("obradjen"));
							List<double> l = new List<double>();



							try
							{
								if (reader.GetString("oznaka_etikete") == null)
								{
									values.Add("oznaka_etikete", "");
								}
								else
								{
									Console.WriteLine("etiketa:     " + reader.GetString("oznaka_etikete"));
									values.Add("oznaka_etikete", reader.GetString("oznaka_etikete"));
								}


							}
							catch (Exception exe)
							{
								values.Add("oznaka_etikete", "");
							}

							try
							{
								if (reader.GetString("x") == null)
								{
									l.Add(0);

								}
								else
								{
									l.Add(double.Parse(reader.GetString("x")));
								}
								if (reader.GetString("y") == null)
								{
									l.Add(0);
								}
								else
								{
									l.Add(double.Parse(reader.GetString("y")));
								}
							}
							catch (Exception exe)
							{
								l.Add(0);
								l.Add(0);
							}

							resultSet.Add(reader.GetString("oznaka"), values);
							positions.Add(reader.GetString("oznaka"), l);

						}
						else
						{
							string etikete = resultSet[reader.GetString("oznaka")]["oznaka_etikete"];
							etikete += ", ";
							etikete += reader.GetString("oznaka_etikete");
							resultSet[reader.GetString("oznaka")]["oznaka_etikete"] = etikete;

						}




					}







					dbCon.Close();
					//e.Result = etikete;


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
			//Console.WriteLine("zavrsio              " + resultSet["232"]["oznaka_etikete"]);
			List<Monument> spomenici = new List<Monument>();
			foreach (KeyValuePair<string, Dictionary<string, string>> entry in resultSet)
			{
				Monument m = new Monument();
				m.Oznaka = entry.Key;
				m.Opis = entry.Value["opis"];
				m.Etikete = entry.Value["oznaka_etikete"];
				m.Ime = entry.Value["ime"];
				m.Prihod = entry.Value["prihod"];
				m.Slika = entry.Value["ikonica"];
				m.Datum = entry.Value["datum_otkrivanja"];
				m.Obradjen = entry.Value["obradjen"];
				m.Unesco = entry.Value["unesco"];
				m.NaseljenoMesto = entry.Value["naseljeno_mesto"];
				m.Tip = entry.Value["tip"];
				m.EraPorekla = entry.Value["era"];
				m.TuristickiStatus = entry.Value["turisticki_status"];
				spomenici.Add(m);
				if (positions.ContainsKey(m.Oznaka))
				{
					m.X = positions[m.Oznaka][0];
					m.Y = positions[m.Oznaka][1];
				}
				else
				{
					m.X = 0;
					m.Y = 0;
				}



			}
			MainWindow.Instance().prikazi_etikete.IsEnabled = true;
			MainWindow.Instance().prikazi_spomenike.IsEnabled = true;
			MainWindow.Instance().prikazi_tipove.IsEnabled = true;
			MainWindow.Instance().ListSpomenik = spomenici;



		}
	}
}
