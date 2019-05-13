using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectHCI.ViewHandlers
{
	class ModifikacijaEtiketeUspesno : ViewHandler
	{
		public void HandleView()
		{
			MessageBox.Show("Uspesno izmenjena etiketa!", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
			Observers.App.Instance().State = "inital_state";
		}
	}
}
