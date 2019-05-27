using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProjectHCI.Models;
using ProjectHCI.Controlers;

namespace ProjectHCI
{
	/// <summary>
	/// Interaction logic for IzmenaSpomenika.xaml
	/// </summary>
	public partial class IzmenaSpomenika : Window
	{

		private Dictionary<string, int> comboEra;
		private Dictionary<string, int> comboTuristickiStatus;

		private Monument spomenik;

		public Monument Spomenik
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return spomenik;
			});
			set { spomenik = value; }
		}



		private string oznaka;

		public string Oznaka
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return textBoxOznaka.Text;
			});
			set { oznaka = value; }
		}

		private string ime;

		public string Ime
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return textBoxIme.Text;
			});
			set { ime = value; }
		}

		private string opis;

		public string Opis
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return textBoxOpis.Text;
			});
			set { opis = value; }
		}

		private string datum;

		public string Datum
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return calendar1.SelectedDate.ToString();
			});
			set { datum = value; }
		}

		private string unesco;

		public string Unesco
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return radioButtonDaUnesco.IsChecked==true ? "Da" : "Ne";
			});
			set { unesco = value; }
		}


		private string obradjen;

		public string Obradjen
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return  checkBox.IsChecked == true ? "Da" : "Ne";
			});
			set { obradjen = value; }
		}

		private string naselje;

		public string Naselje
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return radioButtonDaNaselje.IsChecked == true ? "Da" : "Ne";
			});
			set { naselje = value; }
		}



		private string slika;

		public string Slika
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return tbSlika.Text;
			});
			set { opis = value; }
		}


		private string etiketa;

		public string Etiketa
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return tbEtiketa.Text;
			});
			set { etiketa = value; }
		}



		private string etiketaStara;

		public string EtiketaStara
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return etiketaStara;
			});
			set { etiketaStara = value; }
		}

		private string turistickiStatus;

		public string TuristickiStatus
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return comboBoxT.SelectedItem.ToString();
			});
			set { turistickiStatus = value; }
		}

		private string era;

		public string Era
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return comboBoxEra.SelectedItem.ToString();
			});
			set { era = value; }
		}

		private string prihod;

		public string Prihod
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return textBoxPrihod.Text;
			});
			set { prihod = value; }
		}

		private string tip;

		public string Tip
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return tbTip.Text;
			});
			set { prihod = value; }
		}


		private static IzmenaSpomenika instance = null;

		public static IzmenaSpomenika Instance()
		{
			return instance;
		}

		public IzmenaSpomenika()
		{
			
			InitializeComponent();
			comboEra = new Dictionary<string, int>();
			comboTuristickiStatus = new Dictionary<string, int>();
			lvUsers.ItemsSource = MainWindow.Instance().ListSpomenik;
			
			instance = this;
			comboTuristickiStatus.Add("Eksploatisan", 0);
			comboTuristickiStatus.Add("Dostupan", 1);
			comboTuristickiStatus.Add("Nedostupan", 2);

			comboEra.Add("Paleolit", 0);
			comboEra.Add("Neolit", 1);
			comboEra.Add("Stari vek", 2);
			comboEra.Add("Srednji vek", 3);
			comboEra.Add("Rensesansa", 4);
			comboEra.Add("Moderno doba", 5);
			Observers.App.Instance().PreviousState = "izmena_spomenika";

		}

		private void odabir_click(object sender, RoutedEventArgs e)
		{
			Monument monument = ((Monument)lvUsers.SelectedItem);
			if (monument == null)
			{

			}
			else
			{
				textBoxIme.Text = monument.Ime;
				textBoxOpis.Text = monument.Opis;
				textBoxOznaka.Text = monument.Oznaka;
				textBoxPrihod.Text = monument.Prihod;
				tbEtiketa.Text = monument.Etikete;
				EtiketaStara = tbEtiketa.Text;
				if(tbSlika.Text == "")
				{
					tbSlika.Text = "";
				}
				else
				{
					tbSlika.Text = monument.Slika.Substring(0, 20);

				}
				tbTip.Text = monument.Tip;
				if (monument.Unesco.Equals("Da"))
					radioButtonDaUnesco.IsChecked = true;
				else
					radioButtonNeUnesco.IsChecked = true;

				if (monument.NaseljenoMesto.Equals("Da"))
					radioButtonDaUnesco.IsChecked = true;
				else
					radioButtonNeNaselje.IsChecked = true;

				DateTime parsedDate = DateTime.Parse(monument.Datum);
				calendar1.SelectedDate = parsedDate;
				if (monument.Obradjen.Equals("Da"))
					checkBox.IsChecked = true;
				else
					checkBox.IsChecked = false;
				string turs = monument.TuristickiStatus;
				string opcijaT = turs.Split(':')[1];
				Console.WriteLine(opcijaT);
				int opcija1=0;
				if(opcijaT.Equals("Eksploatisan"))
				{
					opcija1 = 0;
				}
				else if(opcijaT.Equals("Dostupan"))
				{
					opcija1 = 1;
				}
				else if(opcijaT.Equals("Nedostupan"))
				{
					opcija1 = 2;
				}
				comboBoxT.SelectedIndex = opcija1;
				int opcija2 = 0;
				
				string er = monument.EraPorekla;
				string opcijaE = er.Split(':')[1];

				if(opcijaE.Equals("Paleolit"))
				{
					opcija2 = 0;
				}
				else if (opcijaE.Equals("Neolit"))
				{
					opcija1 = 1;
				}
				else if (opcijaE.Equals("Stari vek"))
				{
					opcija1 = 2;
				}
				else if (opcijaE.Equals("Srednji vek"))
				{
					opcija1 = 3;
				}
				else if (opcijaT.Equals("Rensesansa"))
				{
					opcija1 = 4;
				}
				else if (opcijaT.Equals("Moderno doba"))
				{
					opcija1 = 5;
				}


				comboBoxEra.SelectedIndex = opcija2;




				odabir_spomenika.Visibility = Visibility.Hidden;
				spomenik_form.Visibility = Visibility.Visible;

			}
		}
		private void next_click(object sender, RoutedEventArgs e)
		{
			spomenik_form.Visibility = Visibility.Hidden;
			form_spomenik2.Visibility = Visibility.Visible;


		}

		private void brisanje_click(object sender, RoutedEventArgs e)
		{
			Monument monument = ((Monument)lvUsers.SelectedItem);
		

			if(monument!=null)
			{
				this.spomenik = monument;
				ControllerFactory factory = new ControllerFactory();
				Controller controller = factory.GetController("deleteSpomenik");
				controller.handle();
			}



		}

		private void add_click(object sender, RoutedEventArgs e)
		{
			ControllerFactory factory = new ControllerFactory();
			factory.GetController("updateSpomenik").handle();
			

		}
		private void back_click(object sender, RoutedEventArgs e)
		{

			form_spomenik2.Visibility = Visibility.Hidden;
			spomenik_form.Visibility = Visibility.Visible;

		}
		private void cancel_click(object sender, RoutedEventArgs e)
		{
			spomenik_form.Visibility = Visibility.Hidden;
			odabir_spomenika.Visibility = Visibility.Visible;


		}
		private void btnOdaberiTipClick(object sender, EventArgs e)
		{
			Observers.App.Instance().PreviousState = "izmena_spomenika";
			ControllerFactory factory = new ControllerFactory();
			Controller controller = factory.GetController("getTipove");
			controller.handle();

		}
		private void buttonAddEtiketuClick(object sender, EventArgs e)
		{
			Observers.App.Instance().PreviousState = "izmena_spomenika";
			ControllerFactory factory = new ControllerFactory();
			Controller controller = factory.GetController("getEtikete");
			controller.handle();
		}
	}
}
