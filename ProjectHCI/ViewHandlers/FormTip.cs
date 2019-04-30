using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHCI.ViewHandlers
{
	class FormTip : ViewHandler
	{
		public void HandleView()
		{
			MainWindow mainWindow = MainWindow.Instance();
			Console.WriteLine("form tip view handler pozvan");
			mainWindow.showTipForm();
		}

	}
}