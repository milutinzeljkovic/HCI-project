using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHCI.ViewHandlers
{
	public class FormEtiketa : ViewHandler
	{
		public void HandleView()
		{
			MainWindow mainWindow = MainWindow.Instance();
			if (Observers.App.Instance().PreviousState=="uspesno_etiketa")
			{
				mainWindow.textBoxEtiketaOpis.Text = "";
				mainWindow.textBoxEtiketaOznaka.Text = "";
				mainWindow.cp.SelectedColor = null;
			}
			mainWindow.showEtiketaForm();

		}

	}
}