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
		Tip selected;
		
		public ListViewTipovi()
		{
			InitializeComponent();
			foreach (var item in MainWindow.Instance().ListTipovi)
			{
				Console.WriteLine(item.Oznaka);
			}
			lvUsers.ItemsSource = MainWindow.Instance().ListTipovi;

			

		}

		private void select(object sender, RoutedEventArgs e)
		{
			Console.WriteLine("selektovano");
			selected = (Tip)lvUsers.SelectedItem;

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

		void odabir(object sender, RoutedEventArgs e)
		{
			Console.WriteLine("klik odabir");
			String prikaz = lvUsers.SelectedItem == null ? "" : ((Tip)lvUsers.SelectedItem).Oznaka;
			Console.WriteLine(Observers.App.Instance().State);
			if(Observers.App.Instance().PreviousState== "izmena_spomenika")
			{
				IzmenaSpomenika.Instance().tbTip.Text = prikaz;
			}
			else
			{
				MainWindow.Instance().tbTip.Text = prikaz;
				Observers.App.Instance().State = "form_spomenik";
			}
			Observers.App.Instance().PreviousState = "";
			this.Close();
			
		}



	}

	
}
