using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProjectHCI.Models;
using ProjectHCI.Controlers;

namespace ProjectHCI.EventHandlers
{
	class FormDodajTipHandlers
	{
		static string image;

		

		public RoutedEventHandler click_event_imagechoose = new RoutedEventHandler(ImageChooseClick);

		private static void ImageChooseClick(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
			dlg.DefaultExt = ".png";
			dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

			Nullable<bool> result = dlg.ShowDialog();
			if (result == true)
			{
				string filename = dlg.FileName;
				image = dlg.FileName;
			}

		}

		public void dodajTip(Dictionary<string,string> parametri)
		{
			MessageBox.Show("dodavanje");
			Tip tip = new Tip();
			TipControler tipControler = new TipControler(tip);
			tipControler.setTipIme(parametri["ime"]);
			tipControler.setTipImg(image);
			tipControler.setTipOpis(parametri["opis"]);
			tipControler.setTipOznaka(parametri["oznaka"]);

			tipControler.saveTip();


			//ovde napraviti custom dialog za potvrdu dodavanja ili prikaz greske
			string res = tipControler.Result.Equals("greska") ? "Greska prilikom dodavanja, proverite jedinstvenost" : "Uspesno dodata etiketa!";
			MessageBoxResult result = MessageBox.Show(res,
				"Confirmation", MessageBoxButton.YesNo);

			if (result == MessageBoxResult.Yes)
			{
				// Yes code here  
			}
			else if (result == MessageBoxResult.No)
			{
				// No code here  
			}
		}
	}
}
