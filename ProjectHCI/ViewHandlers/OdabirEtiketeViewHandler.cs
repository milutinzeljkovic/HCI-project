using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProjectHCI.Controlers;
using ProjectHCI.Models;
using System.Threading;

namespace ProjectHCI.ViewHandlers
{
	class OdabirEtiketeViewHandler : ViewHandler
	{
		

		public void HandleView()
		{
			
			var s = new ListViewEtikete();
			s.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			s.Show();

		}

	}
}