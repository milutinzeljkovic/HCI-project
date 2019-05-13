using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectHCI.ViewHandlers
{
	class ModifikacijaEtikete : ViewHandler
	{


		public void HandleView()
		{

			var s = new IzmenaEtikete();
			s.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			s.Show();

		}

	}
}