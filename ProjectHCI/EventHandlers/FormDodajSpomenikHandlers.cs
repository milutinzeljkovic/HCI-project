using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProjectHCI.Models;

namespace ProjectHCI.EventHandlers
{
	class FormDodajSpomenikHandlers
	{

		private Tip tip;

		public Tip SelectedTip
		{
			get { return tip; }
			set { tip = value; }
		}

		private static List<Etiketa> etikete;

		public static List<Etiketa> Etikete
		{
			get { return etikete; }
			set { etikete = value; }
		}

		public FormDodajSpomenikHandlers()
		{
			Etikete = new List<Etiketa>();
		}






		public RoutedEventHandler click_event_odabirtipa = new RoutedEventHandler(OdabirTipaClick);

		private static void OdabirTipaClick(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Hendlovanje klika odabir tipa");

			var s = new ListViewTipovi();
			s.Show();



		}

		public RoutedEventHandler click_event_dodajetiketu = new RoutedEventHandler(DodajEtiketu);

		private static void DodajEtiketu(object sender, RoutedEventArgs e)
		{
			var s = new ListViewEtikete();

			s.Show();
			

		}

		public RoutedEventHandler click_event_imagechoose = new RoutedEventHandler(ImageChooseClick);

		private static void ImageChooseClick(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
			dlg.DefaultExt = ".png";
			dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

			Nullable<bool> result = dlg.ShowDialog(); 
			if (result == true)
			{
				// Open document 
				string filename = dlg.FileName;

			}

		}

		

		public class DodavanjeSpomenika
		{
			private Dictionary<string, string> dictionary;

			public DodavanjeSpomenika(Dictionary<string,string> dictionary)
			{
				this.dictionary = dictionary;
			}
			public RoutedEventHandler click_event_dodajSpomenik = new RoutedEventHandler(ButtonAddClick);

			private static void ButtonAddClick(object sender, RoutedEventArgs e)
			{
				
			}



		}

	}
}
