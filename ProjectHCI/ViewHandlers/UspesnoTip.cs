using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectHCI.ViewHandlers
{
	class UspesnoTip : ViewHandler
	{
		public void HandleView()
		{
			MessageBox.Show("Uspesno dodato!", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
			Observers.App.Instance().PreviousState = "uspesno_tip";
			Observers.App.Instance().State = "inital_state";

		}

	}
}
