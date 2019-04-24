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
			List<Tip> items = new List<Tip>();
			items.Add(new Tip() { Ime = "ime", Opis = "opis", Oznaka = "oznaka", Icon = "slika" });
			items.Add(new Tip() { Ime = "ime", Opis = "opis", Oznaka = "oznaka", Icon = "slika" });
			items.Add(new Tip() { Ime = "ime", Opis = "opis", Oznaka = "oznaka", Icon = "slika" });
			items.Add(new Tip() { Ime = "ime", Opis = "opis", Oznaka = "oznaka", Icon = "slika" });
			lvUsers.ItemsSource = items;
		}
	}

	
}
