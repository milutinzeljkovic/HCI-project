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
	/// Interaction logic for ListViewEtikete.xaml
	/// </summary>
	public partial class ListViewEtikete : Window
	{
		public ListViewEtikete()
		{
			InitializeComponent();
			List<Etiketa> items = EtiketaControler.fetchEtikete();

			lvUsers.ItemsSource = items;
		}
	}
}
