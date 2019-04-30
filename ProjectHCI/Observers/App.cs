using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHCI.Observers
{
	public class App
	{

		private List<MainObserver> observers;
		private static App instance = null;
		private App()
		{
			observers = new List<MainObserver>();
		}
		public static App Instance()
		{
			if(instance == null)
			{
				instance = new App();

			}
			return instance;
		}

		private string previousState;
				
		public string PreviousState
		{
			get { return previousState; }
			set { previousState = value; }
		}



		private string state;

		public string State
		{
			get { return state; }
			set
			{
				
				state = value;
				notifyAllObservers();
			}
		}

		private void notifyAllObservers()
		{
			foreach (MainObserver item in observers)
			{
				item.update();
			}
		}

		public void attach(MainObserver mainObserver )
		{
			this.observers.Add(mainObserver);
		}



	}
}
