using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHCI
{
	public class EtiketaObserver : Observer
	{
		public EtiketaObserver(Subject subject)
		{
			this.subject = subject;
			this.subject.attach(this);
		}


		public override void update(string destination)
		{
			if(destination.Equals("etiketa"))
			{
				//
			}
		}
	}
}
