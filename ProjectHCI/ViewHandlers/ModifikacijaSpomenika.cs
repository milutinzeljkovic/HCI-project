using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHCI.Models;

namespace ProjectHCI.ViewHandlers
{
	class ModifikacijaSpomenika : ViewHandler
	{
		public void HandleView()
		{
			var s = new IzmenaSpomenika();
			s.Show();
		}
	}
}
