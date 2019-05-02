﻿using ProjectHCI.ViewModel;
using ProjectHCI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Collections.ObjectModel;
using System.ComponentModel;
using ProjectHCI.Controlers;
using ProjectHCI.EventHandlers;
using ProjectHCI.DBCredentials;
using ProjectHCI.Observers;
using System.Windows.Threading;

namespace ProjectHCI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		

        public event PropertyChangedEventHandler PropertyChanged;
        private GridViewModel GridViewModel { get; set; }
        private bool _showPanel;
        public Brush color;
        private string unetiTextIme;
        private string etiketaOznaka;
        private string unetiTextOznaka;

		private static MainWindow mainInstance = null;


        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

		public void updateTipFiled(string text)
		{
			Console.WriteLine(text);
			tbTip.Text = text;
			Console.WriteLine("tip field");
		}

		public static MainWindow Instance()
		{
			return mainInstance;
		}

		private string eOznaka;
		public string EOznaka
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return textBoxEtiketaOznaka.Text;
			});
			set { eOznaka = value; }
		}

		private string eOpis;
		public string EOpis
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return textBoxEtiketaOpis.Text;
			});
			set { eOpis = value; }
		}

		private string eBoja;
		public string EBoja
		{
			get => this.Dispatcher.Invoke(() =>
			{
				return cp.SelectedColor.ToString();
			});
			set { eBoja = value; }
		}


		private bool btnE = true;

		public bool BtnAddEtiketu
		{
			get => btnE;
			set => this.Dispatcher.Invoke(() =>
			{
				if(value == true)
				{
					btnAddEtiketu.IsEnabled = true;
				}
				else
				{
					btnAddEtiketu.IsEnabled = false;
				}
			});

		}






		public static ObservableCollection<Spomenik> Spomenici
        {
            get;
            set;
        }

        public static ObservableCollection<Etiketa> Etikete
        {
            get;
            set;
        }

        

        public MainWindow()
        {
            InitializeComponent();
			mainInstance = this;
			Subject instance = Subject.Instance();
			new EtiketaObserver(instance);
			new TipObserver(ref instance);
			this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			Observers.App app = Observers.App.Instance();
			new MainPageObserver(app);
			new SideBarObserver(app);
			app.State = "state";


			Console.WriteLine(instance.observers.Count());

			FormDodajSpomenikHandlers formDodajSpomenikHandlers = new FormDodajSpomenikHandlers();
			//btnOdabirTip.Click += formDodajSpomenikHandlers.click_event_odabirtipa;
			//btnDodajEtiketu.Click += formDodajSpomenikHandlers.click_event_dodajetiketu;
			btnDodajIkonicu.Click += formDodajSpomenikHandlers.click_event_imagechoose;
			btnAddSpomenikClick.Click += (new FormDodajSpomenikHandlers.DodavanjeSpomenika(null)).click_event_dodajSpomenik;


			FormDodajTipHandlers formDodajTipHandlers = new FormDodajTipHandlers();
			buttonIkonicaTip.Click += formDodajTipHandlers.click_event_imagechoose;
			

			this.DataContext = this;
            color = textBoxIme.BorderBrush;
            _showPanel = false;
            GridViewModel = new GridViewModel();
            Console.WriteLine("asidjsaildjas");
            this.DataContext = GridViewModel;
            (this.DataContext as GridViewModel).GridFormVisible = false;
            (this.DataContext as GridViewModel).GridFormPart2Visible = false;

            Etikete = new ObservableCollection<Etiketa>();
            Etikete.Add(new Etiketa { Opis = "opis jedne etikete", Oznaka = "oznaka123" });
            Etikete.Add(new Etiketa { Opis = "opis druge etikete", Oznaka = "oznaka321" });
            Etikete.Add(new Etiketa { Opis = "opis druge etikete", Oznaka = "oznaka321" });


            Spomenici = new ObservableCollection<Spomenik>();
            Spomenici.Add(new Spomenik { Ime = "Spomenik1", Opis = "opis", Era = "paleolit", Oznaka = "oznak", Unesco = "unesco" });
            Spomenici.Add(new Spomenik { Ime = "Spomenik1", Opis = "opis", Era = "paleolit", Oznaka = "oznak", Unesco = "unesco" });
            Spomenici.Add(new Spomenik { Ime = "Spomenik1", Opis = "opis", Era = "paleolit", Oznaka = "oznak", Unesco = "unesco" });
            Spomenici.Add(new Spomenik { Ime = "Spomenik1", Opis = "opis", Era = "paleolit", Oznaka = "oznak", Unesco = "unesco" });
            Spomenici.Add(new Spomenik { Ime = "Spomenik1", Opis = "opis", Era = "paleolit", Oznaka = "oznak", Unesco = "unesco" });
            
        }

		

		private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = GridViewModel;
            var vis = (this.DataContext as GridViewModel).GridFormVisible;
			Observers.App app = Observers.App.Instance();
			app.State = "form_spomenik";
            

        }

        public bool ShowPanel
        {
            get { return _showPanel; }
        }

		public void hideAll()
		{
			this.DataContext = GridViewModel;
			(this.DataContext as GridViewModel).GridFormVisible = false;
			(this.DataContext as GridViewModel).GridFormPart2Visible = false;
			(this.DataContext as GridViewModel).GridEtiketaVisible = false;
			(this.DataContext as GridViewModel).GridForm2Visible = false;
			(this.DataContext as GridViewModel).GridTipVisible = false;
			(this.DataContext as GridViewModel).GridEtiketaTableVisible = false;
			(this.DataContext as GridViewModel).GridMapVisible = false;
		}

		public void showSpomenikForm()
		{
			hideAll();
			(this.DataContext as GridViewModel).GridFormVisible = true;
		}
		public void showEtiketaForm()
		{
			hideAll();
			(this.DataContext as GridViewModel).GridEtiketaVisible = true;
		}
		public void showTipForm()
		{
			hideAll();
			(this.DataContext as GridViewModel).GridTipVisible = true;
		}

        

        private void ShowMap_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = GridViewModel;
            var vis = (this.DataContext as GridViewModel).GridForm2Visible;

            (this.DataContext as GridViewModel).GridFormVisible = false;
            (this.DataContext as GridViewModel).GridFormPart2Visible = false;
            (this.DataContext as GridViewModel).GridEtiketaVisible = false;
            (this.DataContext as GridViewModel).GridForm2Visible = false;
            (this.DataContext as GridViewModel).GridTipVisible = false;
            (this.DataContext as GridViewModel).GridEtiketaTableVisible = false;
            (this.DataContext as GridViewModel).GridMapVisible = true;

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = GridViewModel;
            var vis = (this.DataContext as GridViewModel).GridForm2Visible;

            (this.DataContext as GridViewModel).GridFormVisible = false;
            (this.DataContext as GridViewModel).GridFormPart2Visible = false;
            (this.DataContext as GridViewModel).GridMapVisible = false;
            (this.DataContext as GridViewModel).GridEtiketaVisible = false;
            (this.DataContext as GridViewModel).GridTipVisible = false;
            (this.DataContext as GridViewModel).GridEtiketaTableVisible = false;
            (this.DataContext as GridViewModel).GridForm2Visible = true;
            this.DataContext = this;
        }

        private void PretragaEtiketeClick(object sender, RoutedEventArgs e)
        {
            this.DataContext = GridViewModel;
            var vis = (this.DataContext as GridViewModel).GridForm2Visible;

            (this.DataContext as GridViewModel).GridFormVisible = false;
            (this.DataContext as GridViewModel).GridFormPart2Visible = false;
            (this.DataContext as GridViewModel).GridMapVisible = false;
            (this.DataContext as GridViewModel).GridEtiketaVisible = false;
            (this.DataContext as GridViewModel).GridTipVisible = false;
            (this.DataContext as GridViewModel).GridForm2Visible = false;
            (this.DataContext as GridViewModel).GridEtiketaTableVisible = false;
            this.DataContext = this;
            this.DataContext = GridViewModel;
            var s = new TabelaEtiketa();
            s.Show();
            //tabela spomenika prekrije ovu tabelu

        }



        private void Turtorial_click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCancelClik(object sender, RoutedEventArgs e)
        {
			Observers.App.Instance().State = "inital_state";

        }

        private void AddEtiketuClick(object sender, RoutedEventArgs e)
        {
			Observers.App app = Observers.App.Instance();
			app.State = "form_etiketa";
        }
		

		private void etiketaCancel(object sender, RoutedEventArgs e)
		{			
			Observers.App app = Observers.App.Instance();
			app.State = "inital_state";
		}
		

		private void tipCancel(object sender, RoutedEventArgs e)
		{

			Observers.App app = Observers.App.Instance();
			app.State = "inital_state";
		}

		private void AddOznakuClick(object sender, RoutedEventArgs e)
        {

			Observers.App app = Observers.App.Instance();
			app.State = "form_tip";
        }




        private void ButtonAddSpomenikClik(object sender, RoutedEventArgs e)
        {
            //dodaj ono da li ste sigurni...
            this.DataContext = GridViewModel;
            var vis = (this.DataContext as GridViewModel).GridFormVisible;
            (this.DataContext as GridViewModel).GridFormVisible = false;
            (this.DataContext as GridViewModel).GridForm2Visible = false;
            (this.DataContext as GridViewModel).GridEtiketaVisible = false;
            (this.DataContext as GridViewModel).GridTipVisible = false;
            (this.DataContext as GridViewModel).GridEtiketaTableVisible = false;
            (this.DataContext as GridViewModel).GridFormPart2Visible = true;
         
        }

        private void ButtonBackClick(object sender, RoutedEventArgs e)
        {
            //dodaj ono da li ste sigurni...
            this.DataContext = GridViewModel;
            var vis = (this.DataContext as GridViewModel).GridFormVisible;
            (this.DataContext as GridViewModel).GridFormVisible = true;
            (this.DataContext as GridViewModel).GridForm2Visible = false;
            (this.DataContext as GridViewModel).GridEtiketaVisible = false;
            (this.DataContext as GridViewModel).GridTipVisible = false;
            (this.DataContext as GridViewModel).GridEtiketaTableVisible = false;
            (this.DataContext as GridViewModel).GridFormPart2Visible = false;

        }

		private string myVar;

		public string MyProperty
		{
			get => this.Dispatcher.Invoke(() =>
   {
	   return "dssasda111111111111111";
   });
			set { myVar = value; }
		}



		private void AddEtiketuButtonClick(object sender, RoutedEventArgs e)
		{
			BtnAddEtiketu = false;
			ControllerFactory factory = new ControllerFactory();
			
			(factory.GetController("addEtiketu")).handle();

		}

		private void buttonAddTipClick(object sender, RoutedEventArgs e)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("oznaka", textboxOznakaTip.Text);
			dictionary.Add("opis", textboxOpisTip.Text);
			dictionary.Add("ime", textboxImeTip.Text);
			(new FormDodajTipHandlers()).dodajTip(dictionary);
		}


		



		private void textImeChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void lostFocusIme(object sender, EventArgs e)
        {
             unetiTextIme = textBoxIme.Text;
            // do your stuff
            if (textBoxIme.Text == "")
            {
                textBoxIme.BorderBrush = Brushes.Red;
                textBoxIme.Text = "Obavezno polje";
                textBoxIme.Foreground = Brushes.Red;

            }
            else
            {

                textBoxIme.BorderBrush = color;
            }
        }

        private void textBoxImeFocus(object sender, EventArgs e)
        {
            textBoxIme.Text = unetiTextIme;
            textBoxIme.Foreground = Brushes.Black;
            textBoxIme.BorderBrush = color;
            
        }




        private void lostFocusOznaka(object sender, EventArgs e)
        {
            unetiTextOznaka = textBoxOznaka.Text;
            // do your stuff
            if (textBoxOznaka.Text == "")
            {
                textBoxOznaka.BorderBrush = Brushes.Red;
                textBoxOznaka.Text = "Obavezno polje";
                textBoxOznaka.Foreground = Brushes.Red;

            }
            else
            {

                textBoxOznaka.BorderBrush = color;
            }
        }

        private void gotFocusOznaka(object sender, EventArgs e)
        {
            textBoxOznaka.Text = unetiTextOznaka;
            textBoxOznaka.Foreground = Brushes.Black;
            textBoxOznaka.BorderBrush = color;

        }
		
		 private void textChanged(object sender, EventArgs e)
		{
			Console.WriteLine("text");
			Observers.App.Instance().State = "form_spomenik";

		}

		private void lostFocusPrihod(object sender, EventArgs e)
        {

            // do your stuff
            if (textBoxPrihod.Text == "")
            {
                textBoxPrihod.BorderBrush = Brushes.Red;
			

            }
            else
            {
                
                textBoxPrihod.BorderBrush = color;
                double r;
                string value = textBoxPrihod.Text;
                if (double.TryParse(value, out r))
                {
                    textBoxPrihod.BorderBrush = color;
                }
                else
                {
                    textBoxPrihod.Text = "Neispravan unos";
                    textBoxPrihod.Foreground = Brushes.Red;
                    textBoxPrihod.BorderBrush = Brushes.Red;
                }
            }

        }
        private void mouseEnter(object sender, EventArgs e)
        {
         if(textBoxPrihod.Text== "Neispravan unos")
            {
                textBoxPrihod.Text = "";
            }

        }

        private void gotFocusPrihod(object sender, EventArgs e)
        {
            textBoxPrihod.Text = "";
            textBoxPrihod.Foreground = Brushes.Black;
            textBoxPrihod.BorderBrush = color;

        }

        private void comboBoxTLostFocus(object sender, EventArgs e)
        {

            // do your stuff

            if(comboBoxT.SelectedValue == null )
            {
                comboBoxT.Background = Brushes.Red;
            }

        }

        private void textBoxPrihodChanged(object sender, EventArgs e)
        {
           
   
        }

		private List<Etiketa> listEtikete;
		public List<Etiketa> ListEtikete
		{
			get { return listEtikete; }
			set => this.Dispatcher.Invoke(() =>
			{
				this.listEtikete = value;
			});
		}


		private void buttonAddEtiketuClick(object sender, EventArgs e)
		{
			
			ControllerFactory factory = new ControllerFactory();
			Controller controller = factory.GetController("getEtikete");
			controller.handle();
		}

		private void btnOdaberiTipClick(object sender, EventArgs e)
		{
			Observers.App.Instance().State = "odabir_tipa";

		}


		private void textBoxEtiketaOznakaLost(object sender, EventArgs e)
        {
            etiketaOznaka = textBoxEtiketaOznaka.Text;
            // do your stuff
            if (textBoxEtiketaOznaka.Text == "")
            {
                textBoxEtiketaOznaka.BorderBrush = Brushes.Red;
                textBoxEtiketaOznaka.Text = "Obavezno polje";
                textBoxEtiketaOznaka.Foreground = Brushes.Red;

            }
            else
            {

                textBoxEtiketaOznaka.BorderBrush = color;
            }
        }

        private void textBoxEtiketaOznakaGot(object sender, EventArgs e)
        {
            textBoxEtiketaOznaka.Text = etiketaOznaka;
            textBoxEtiketaOznaka.Foreground = Brushes.Black;
            textBoxEtiketaOznaka.BorderBrush = color;

        }





    }
}
