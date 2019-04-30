using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHCI
{
	public class TipObserver : Observer
	{

		public TipObserver(ref Subject subject)
		{
			this.subject = subject;
			this.subject.attach(this);
		}

		public override void update( string destination)
		{
			Console.WriteLine("update");
			if(destination.Equals("tip"))
			{
				Console.WriteLine("updateovanje" + subject.TipState);
				MainWindow.Instance().updateTipFiled(subject.TipState);
				
				
			}
		}
	}
}
