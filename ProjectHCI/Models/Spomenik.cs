using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ProjectHCI.Models
{
    public class Spomenik
    {
        private string _ime;
        private string _era;
        private string _opis;
        private string _oznaka;
        private string _unesco;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        public string Ime
        {
            get { return _ime; }
            set
            {
                _ime = value;
                OnPropertyChanged("Ime");
                
            }
        }

        public string Era
        {
            get { return _era; }
            set { _era = value;
                OnPropertyChanged("Era");
            }
        }

        public string Opis
        {
            get { return _opis; }
            set { _opis = value; OnPropertyChanged("Opis"); }
        }

        public string Oznaka
        {
            get { return _oznaka; }
            set { _oznaka = value; OnPropertyChanged("Oznaka"); }
        }

        public string Unesco
        {
            get { return _unesco;  }
            set { _unesco = value; OnPropertyChanged("Unesco"); }
        }

        public static ObservableCollection<Spomenik> Spomenici
        {
            get;
            set;
        }

    }
}
