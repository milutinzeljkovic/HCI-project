using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHCI.Models
{
   public class Etiketa
    {
        private string _opis;
        private string _oznaka;
        private string _boja;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string Opis
        {
            get { return _opis; }
            set { _opis = value; OnPropertyChanged("Opis"); }
        }

		public string Boja
		{
			get { return _boja; }
			set { _boja = value; OnPropertyChanged("Boja"); }
		}

		public string Oznaka
        {
            get { return _oznaka; }
            set { _oznaka = value; OnPropertyChanged("Oznaka"); }
        }

        public static ObservableCollection<Etiketa> Etikete
        {
            get;
            set;
        }


    }
}
