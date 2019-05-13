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
			
			lvUsers.ItemsSource = MainWindow.Instance().ListTipovi;

			

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
