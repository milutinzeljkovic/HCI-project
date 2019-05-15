using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectHCI.ViewHandlers
{
	class ModifikacijaTipa : ViewHandler
	{
		public void HandleView()
		{
			var s = new IzmenaTipa();
			s.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			s.Show();
		}
	}
}
