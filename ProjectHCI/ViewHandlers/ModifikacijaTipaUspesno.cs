using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectHCI.ViewHandlers
{
	class ModifikacijaTipaUspesno : ViewHandler
	{
		public void HandleView()
		{
			MessageBox.Show("Uspesno izmenjen tip!", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
			Observers.App.Instance().State = "inital_state";
		}
	}
}
