using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectHCI.ViewHandlers
{
	class UspesnoEtiketa : ViewHandler
	{
		public void HandleView()
		{
			MessageBox.Show("Uspesno dodato!", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
			Observers.App.Instance().PreviousState = "uspesno_etiketa";
			Observers.App.Instance().State = "inital_state";
			Console.WriteLine(Observers.App.Instance().State + "  " + Observers.App.Instance().PreviousState);

		}

	}
}
