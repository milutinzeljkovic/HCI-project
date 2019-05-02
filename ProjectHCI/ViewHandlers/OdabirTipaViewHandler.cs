using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectHCI.ViewHandlers
{
	class OdabirTipaViewHandler : ViewHandler
	{
		public void HandleView()
		{
			MainWindow mainWindow = MainWindow.Instance();
			var s = new ListViewTipovi();
			s.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			s.Show();


		}

	}
}