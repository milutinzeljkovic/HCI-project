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
				return textBoxTipSlika.Text;
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
	}
}
