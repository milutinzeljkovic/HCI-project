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
	/// Interaction logic for ListViewTipovi.xaml
	/// </summary>
	public partial class ListViewTipovi : Window
	{
		
		public ListViewTipovi()
		{
			InitializeComponent();
			List<Tip> items = TipControler.fetchTip();
			
			lvUsers.ItemsSource = items;

			

		}

		void odabir(object sender, RoutedEventArgs e)
		{
			Console.WriteLine("klik odabir");
			String prikaz = lvUsers.SelectedItem == null ? "" : ((Tip)lvUsers.SelectedItem).Oznaka;
			
			MainWindow.Instance().tbTip.Text = prikaz;
			Observers.App.Instance().State = "form_spomenik";
			this.Close();
			
		}



	}

	
}
