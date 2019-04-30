using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHCI.Observers
{
	public abstract class MainObserver
	{
		protected App app;
		public abstract void update();
	}
}
