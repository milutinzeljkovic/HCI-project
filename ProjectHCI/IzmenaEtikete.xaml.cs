using ProjectHCI.Models;
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

namespace ProjectHCI
{
	/// <summary>
	/// Interaction logic for IzmenaEtikete.xaml
	/// </summary>
	public partial class IzmenaEtikete : Window
	{
		private string opis;
		private static IzmenaEtikete instance = null;
		public static IzmenaEtikete Instance()
		{
			return instance;
		}

		private string oznaka;

		public string Oznaka
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return textBoxEtiketaOznaka.Text;
			});
			set { oznaka = value; }
		}



		public string Opis
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return textBoxEtiketaOpis.Text;
			});
			set { opis = value; }
		}
		private string boja;

		public string Boja
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return cp.SelectedColor.ToString();
			});
			set { boja = value; }
		}


		public IzmenaEtikete()
		{
			InitializeComponent();
			instance = this;
			lvUsers.ItemsSource = MainWindow.Instance().ListEtikete;

		}
		private void odabir(object sender, RoutedEventArgs e)
		{
			Etiketa etiketa = ((Etiketa)lvUsers.SelectedItem);
			textBoxEtiketaOpis.Text = etiketa.Opis;
			textBoxEtiketaOznaka.Text = etiketa.Oznaka;
			textBoxEtiketaOznaka.IsEnabled = false;
			SolidColorBrush sbc = (SolidColorBrush)(new BrushConverter().ConvertFrom(etiketa.Boja));
			Color color = (Color)ColorConverter.ConvertFromString(etiketa.Boja);
			cp.SelectedColor = color;

			odabir_etikete.Visibility = Visibility.Hidden;
			izmena_etikete.Visibility = Visibility.Visible;


		}
		private void submit(object sender, RoutedEventArgs e)
		{
			ControllerFactory factory = new ControllerFactory();
			Controller c = factory.GetController("updateEtiketu");
			c.handle();


		}
		private void cancel(object sender, RoutedEventArgs e)
		{
			odabir_etikete.Visibility = Visibility.Visible;
			izmena_etikete.Visibility = Visibility.Hidden;


		}
	}
}
