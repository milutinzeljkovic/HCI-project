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
        private bool gridTableVisible = false;
        private bool gridForm2Visible = false;
        private bool gridMapVisible = false;
        private bool gridEtiketaVisible = false;
           

        private bool gridFormPart2Visible = false;


        public bool GridMapVisible
        {
            get { return gridMapVisible; }
            set { gridMapVisible = value;
                NotifyPropertyChanged("GridMapVisible");
            }
        }

        public bool GridEtiketaVisible
        {
            get
            {
                return gridEtiketaVisible;
            }
            set
            {
                gridEtiketaVisible = value;
                NotifyPropertyChanged("GridEtiketaVisible");

            }
        }






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

        public bool GridFormPart2Visible
        {
            get
            {
                return gridFormPart2Visible;
            }
            set
            {
                gridFormPart2Visible = value;
                NotifyPropertyChanged("GridFormPart2Visible");

            }
        }


        public bool GridForm2Visible
        {
            get
            {
                return gridForm2Visible;
            }
            set
            {
                gridForm2Visible = value;
                NotifyPropertyChanged("GridForm2Visible");

            }
        }

        public bool GridTableVisible
        {
            get
            {
                return gridTableVisible;
            }
            set
            {
                gridTableVisible = value;
                NotifyPropertyChanged("GridTableVisible");

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
