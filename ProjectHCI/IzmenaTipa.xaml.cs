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
using ProjectHCI.Controlers;
using ProjectHCI.Models;

namespace ProjectHCI
{
	/// <summary>
	/// Interaction logic for IzmenaTipa.xaml
	/// </summary>
	public partial class IzmenaTipa : Window
	{
		Tip selected;
		private Tip tip;

		public Tip SelektovaniTip
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return tip;
			});
			set { tip = value; }
		}



		private static IzmenaTipa instance = null;
		public static IzmenaTipa Instance()
		{
			return instance;
		}

		private string oznaka;

		public string Oznaka
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return textBoxTipOznaka.Text;
			});
			set { oznaka = value; }
		}


		private string opis;
		public string Opis
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return textBoxTipOpis.Text;
			});
			set { opis = value; }
		}
		private string slika;

		public string Slika
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return slika;
			});
			set { slika = value; }
		}

		private string ime;

		public string Ime
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return textboxImeTip.Text;
			});
			set { ime = value; }
		}

		private void select(object sender, RoutedEventArgs e)
		{
			Console.WriteLine("selektovano");
			selected = (Tip)lvUsers.SelectedItem;
			Slika = selected.Icon;

			try
			{
				if (!selected.Icon.Equals(""))
					PrikazIkonice.Source = new BitmapImage(new Uri(selected.Icon));
				else
					PrikazIkonice.Source = new BitmapImage(new Uri("C:/Users/milutin/source/repos/HCI-project/ProjectHCI/location.png"));
			}
			catch (Exception ex)
			{
				PrikazIkonice.Source = new BitmapImage(new Uri("C:/Users/milutin/source/repos/HCI-project/ProjectHCI/location.png"));
			}



		}


		private void odabir_ikonice(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
			dlg.DefaultExt = ".png";
			dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

			Nullable<bool> result = dlg.ShowDialog();
			if (result == true)
			{
				// Open document 
				string filename = dlg.FileName;
				string[] a = filename.Split('\\');
				int c = a.Count();
				string s = @"\";
				filename = filename.Replace(s[0], '/');

				Slika = filename;


			}
		}

		public IzmenaTipa()
		{

			InitializeComponent();
			instance = this;
			lvUsers.ItemsSource = MainWindow.Instance().ListTipovi;
		}

		private void odabir(object sender, RoutedEventArgs e)
		{

			Tip tip = ((Tip)lvUsers.SelectedItem);
			if(tip!=null)
			{
				SelektovaniTip = tip;
				textboxImeTip.Text = tip.Ime;
				textBoxTipOpis.Text = tip.Opis;
				textBoxTipOznaka.Text = tip.Oznaka;
				textBoxTipSlika.Text = tip.Icon;
			}
			odabir_etikete.Visibility = Visibility.Hidden;
			izmena_etikete.Visibility = Visibility.Visible;


		}

		private void submit(object sender, RoutedEventArgs e)
		{

			ControllerFactory factory = new ControllerFactory();
			Controller c = factory.GetController("updateTip");
			c.handle();

		}

		private void brisanje(object sender, RoutedEventArgs e)
		{
			Tip t = ((Tip)lvUsers.SelectedItem);
			if(t!=null)
			{
				this.tip = t;
				ControllerFactory factory = new ControllerFactory();
				Controller c = factory.GetController("deleteTip");
				c.handle();
			}
			


		}

		private void cancel(object sender, RoutedEventArgs e)
		{
			odabir_etikete.Visibility = Visibility.Visible;
			izmena_etikete.Visibility = Visibility.Hidden;


		}

		private void lvUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}
