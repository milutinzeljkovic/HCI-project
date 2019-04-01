using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectHCI.ViewModel
{
    class GridViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool gridFormVisible = false;

        public bool GridFormVisible
        {
            get
            {
                return gridFormVisible;
            }
            set
            {
                gridFormVisible = value;
                NotifyPropertyChanged("GridFormVisible");
                
            }
        }

        private void NotifyPropertyChanged(string info)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private Visibility visibility;
        public Visibility Visibility
        {
            get
            {
                return visibility;
            }
            set
            {
                visibility = value;

                NotifyPropertyChanged("Visibility");
            }
        }
    }
}
