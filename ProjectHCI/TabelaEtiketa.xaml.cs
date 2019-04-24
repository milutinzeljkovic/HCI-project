using ProjectHCI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ProjectHCI.EventHandlers;

namespace ProjectHCI
{
    /// <summary>
    /// Interaction logic for TabelaEtiketa.xaml
    /// </summary>
    public partial class TabelaEtiketa : Window
    {
		private Etiketa etiketa;

		public Etiketa SelectedItem
		{
			get { return etiketa; }
			set
			{
				etiketa = value;
				
				
			}
		}
		private void dodajEtiketu(object sender, RoutedEventArgs e)
		{

			FormDodajSpomenikHandlers.Etikete.Add(SelectedItem);
		}


		public static ObservableCollection<Etiketa> Etikete
        {
            get;
            set;
        }
        public TabelaEtiketa()
        {
            InitializeComponent();
            this.DataContext = this;
            Etikete = new ObservableCollection<Etiketa>();
            Etikete.Add(new Etiketa { Opis = "opis jedne etikete", Oznaka = "oznaka123" });
            Etikete.Add(new Etiketa { Opis = "opis druge etikete", Oznaka = "oznaka321" });
            Etikete.Add(new Etiketa { Opis = "opis druge etikete", Oznaka = "oznaka321" });
            Etikete.Add(new Etiketa { Opis = "opis jedne etikete", Oznaka = "oznaka123" });
            Etikete.Add(new Etiketa { Opis = "opis druge etikete", Oznaka = "oznaka321" });
            Etikete.Add(new Etiketa { Opis = "opis druge etikete", Oznaka = "oznaka321" });
            Etikete.Add(new Etiketa { Opis = "opis jedne etikete", Oznaka = "oznaka123" });
            Etikete.Add(new Etiketa { Opis = "opis druge etikete", Oznaka = "oznaka321" });
            Etikete.Add(new Etiketa { Opis = "opis druge etikete", Oznaka = "oznaka321" });
        }

		

    }
}
