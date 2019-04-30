using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHCI
{
	public class Subject
	{
		public List<Observer> observers;
		private string etiketaState;
		public static Subject instance = null;

		public static Subject Instance()
		{
			if(instance != null)
			{
				return instance;
			}
			else
			{
				instance = new Subject();
				return instance;
			}
		}

		public string EtiketaState
		{
			get { return etiketaState; }
			set
			{
				etiketaState = value;
				notifyAllObservers("etiketa");
			}
		}



		private string tipState;

		public string TipState
		{
			get { return tipState; }
			set
			{
				Console.WriteLine("subject" + value);
				notifyAllObservers("tip");
				tipState = value;
				
			}
		}

		private Subject()
		{
			
			observers = new List<Observer>();
		}

		public void attach(Observer observer)
		{
			Console.WriteLine("attach"+observers.Count());
			this.observers.Add(observer);
			
		}


		public void notifyAllObservers(string destination)
		{
			Console.WriteLine("notifikacija"+observers.Count());

			foreach(Observer observer in observers)
			{
				Console.WriteLine("notify");
				observer.update(destination);
			}
		}


	}
}
