using ProjectHCI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectHCI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private GridViewModel GridViewModel { get; set; }
        private bool _showPanel;
        
        public MainWindow()
        {
            
            InitializeComponent();
            _showPanel = false;
            GridViewModel = new GridViewModel();
            
            this.DataContext = GridViewModel;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
           
            var vis = (this.DataContext as GridViewModel).GridFormVisible;

            (this.DataContext as GridViewModel).GridFormVisible = !vis;
        }

        public bool ShowPanel
        {
            get { return _showPanel; }
        }

        private void ShowMap_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Turtorial_click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonCancelClik(object sender, RoutedEventArgs e)
        {
            //dodaj ono da li ste sigurni...
            var vis = (this.DataContext as GridViewModel).GridFormVisible;

            (this.DataContext as GridViewModel).GridFormVisible = !vis;
        }


    }
}
