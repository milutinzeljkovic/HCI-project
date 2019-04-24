using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHCI.Models
{
	class Tip
	{
		private string oznaka;

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string name)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(name));
			}
		}

		public string Oznaka
		{
			get { return oznaka; }
			set { oznaka = value; OnPropertyChanged("Oznaka"); }
		}

		private string ime;

		public string Ime
		{
			get { return ime; }
			set { ime = value; OnPropertyChanged("Ime"); }
		}

		private string icon;

		public string Icon
		{
			get { return icon; }
			set { icon = value; OnPropertyChanged("Icon"); }
		}

		private string opis;

		public string Opis
		{
			get { return opis; }
			set { opis = value; OnPropertyChanged("Opis"); }
		}

	}
}
