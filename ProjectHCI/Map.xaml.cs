using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using ProjectHCI.Models;
using ProjectHCI.Controlers;

namespace ProjectHCI
{
	/// <summary>
	/// Interaction logic for Map.xaml
	/// </summary>
	/// 

	

	public partial class Map : Window
    {
		Monument selected=null;
		Point startPoint = new Point();
		public ObservableCollection<Monument> Spomenici
		{
			get;
			set;
		}



		public Map()
        {
            InitializeComponent();
			this.DataContext = this;
			Spomenici = new ObservableCollection<Monument>(MainWindow.Instance().ListSpomenik);
			loadImages();
		}

		private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Console.WriteLine("mouse down");
			startPoint = e.GetPosition(null);
		}

		private void ListView_MouseMove(object sender, MouseEventArgs e)
		{
			
			Point mousePos = e.GetPosition(null);
			Vector diff = startPoint - mousePos;

			if (e.LeftButton == MouseButtonState.Pressed &&
				(Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
				Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
			{
				// Get the dragged ListViewItem
				ListView listView = sender as ListView;
				ListViewItem listViewItem =
					FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

				// Find the data behind the ListViewItem
				Monument monument = null;
				try
				{
					 monument = (Monument)listView.ItemContainerGenerator.
						ItemFromContainer(listViewItem);
				}
				catch(Exception ex)
				{

				}
				try
				{
					if (!monument.Slika.Equals(""))
						PrikazIkonice2.Source = new BitmapImage(new Uri(monument.Slika));
					else
						PrikazIkonice2.Source = new BitmapImage(new Uri("C:/Users/milutin/source/repos/HCI-project/ProjectHCI/location.png"));
				}
				catch (Exception ex)
				{
					PrikazIkonice2.Source = new BitmapImage(new Uri("C:/Users/milutin/source/repos/HCI-project/ProjectHCI/location.png"));
				}


				try
				{
					if (!monument.Slika.Equals(""))
						PrikazIkonice.Source = new BitmapImage(new Uri(monument.Slika));
					else
						PrikazIkonice.Source = new BitmapImage(new Uri("C:/Users/milutin/source/repos/HCI-project/ProjectHCI/location.png"));
				}
				catch(Exception ex)
				{
					PrikazIkonice.Source = new BitmapImage(new Uri("C:/Users/milutin/source/repos/HCI-project/ProjectHCI/location.png"));
				}
				// Initialize the drag & drop operation
				DataObject dragData = new DataObject("myFormat", monument);
				DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
			}
		}

		private void loadImages()
		{
			
			foreach (Monument m in MainWindow.Instance().ListSpomenik)
			{
				Console.WriteLine("dodajem");

				if (m.X != 0 && m.Y != 0)
				{
					Console.WriteLine("dodajem"+ m.X);
					Image img = new Image();

					try
					{
						img.Source = new BitmapImage(new Uri(m.Slika));
					}
					catch(Exception e)
					{
						img.Source = new BitmapImage(new Uri("C:/Users/milutin/source/repos/HCI-project/ProjectHCI/location.png"));
					}
					img.Width = 50;
					img.Height = 50;
					img.Tag = m.Oznaka;
					img.PreviewMouseLeftButtonDown += DraggedImagePreviewMouseLeftButtonDown;
					img.MouseMove += DraggedImageMouseMove;

					WrapPanel wp = new WrapPanel();
					
					wp.Orientation = Orientation.Vertical;

					TextBox oznaka = new TextBox();
					oznaka.IsEnabled = false;
					oznaka.Text = "Oznaka: " + m.Oznaka;
					wp.Children.Add(oznaka);

					TextBox naziv = new TextBox();
					naziv.IsEnabled = false;
					naziv.Text = "Naziv: " + m.Ime;
					wp.Children.Add(naziv);


					TextBox tip = new TextBox();
					tip.IsEnabled = false;
					tip.Text = "Tip: " + m.Tip;
					wp.Children.Add(tip);

					ToolTip tt = new ToolTip();
					tt.Content = wp;
					img.ToolTip = tt;

					Spomenici.Remove(m);
					img.ToolTip = tt;
					canvasMap.Children.Add(img);
					Canvas.SetLeft(img, m.X - 20);
					Canvas.SetTop(img, m.Y - 20);
				}

			}
		}

		private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
		{
			do
			{
				if (current is T)
				{
					return (T)current;
				}
				current = VisualTreeHelper.GetParent(current);
			}
			while (current != null);
			return null;
		}

		private void ListView_DragEnter(object sender, DragEventArgs e)
		{
			if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
			{
				e.Effects = DragDropEffects.None;
			}
		}

		private void DraggedImagePreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Console.WriteLine("dogadjaj neki");
			startPoint = e.GetPosition(null);
			Image img = sender as Image;

			foreach (Monument man in MainWindow.Instance().ListSpomenik)
			{
				if (man.Oznaka.Equals(img.Tag))
				{

					selected = (Monument)man;
					try
					{
						if (!man.Slika.Equals(""))
							PrikazIkonice.Source = new BitmapImage(new Uri(man.Slika));
						else
							PrikazIkonice.Source = new BitmapImage(new Uri("C:/Users/milutin/source/repos/HCI-project/ProjectHCI/location.png"));
					}
					catch (Exception ex)
					{
						PrikazIkonice.Source = new BitmapImage(new Uri("C:/Users/milutin/source/repos/HCI-project/ProjectHCI/location.png"));
					}
				}
			}
			if (e.LeftButton == MouseButtonState.Released)
			{
				e.Handled = true;
				//PrikazIkonice.Source = new BitmapImage();
			}
				

		}

		private void DraggedImageMouseMove(object sender, MouseEventArgs e)
		{
			System.Windows.Point mousePos = e.GetPosition(null);
			Vector diff = startPoint - mousePos;
			if (e.LeftButton == MouseButtonState.Pressed &&
			   (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
			   Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
			{


				Monument selektovana = (Monument)selected;

				if (selektovana != null)
				{
					Image img = sender as Image;
					canvasMap.Children.Remove(img);
					DataObject dragData = new DataObject("myFormat", selektovana);
					DragDrop.DoDragDrop(img, dragData, DragDropEffects.Move);

				}

			}

		}

		private void delete(object sender, EventArgs e)
		{
			if(selected!= null)
			{
				DeleteSpomenikMapa d = new DeleteSpomenikMapa();
				d.handle(selected);
				Image zaBrisanje = null;
				Spomenici.Add((Monument)selected);
				foreach (Image img in canvasMap.Children)
				{
					if (selected.Oznaka.Equals(img.Tag))
					{
						zaBrisanje = img;
					}
				}
				if (zaBrisanje != null)
					canvasMap.Children.Remove(zaBrisanje);
			}
		}


		private void ListView_Drop(object sender, DragEventArgs e)
		{
			Console.WriteLine("drop");
			if (e.Data.GetDataPresent("myFormat"))
			{
				Monument m = e.Data.GetData("myFormat") as Monument;
				Spomenici.Remove(m);
				Console.WriteLine("drop");
				System.Windows.Point d0 = e.GetPosition(canvasMap);
				Console.WriteLine(d0);

				bool result = canvasMap.Children.Cast<Image>()
						   .Any(x => x.Tag != null && x.Tag.ToString() == m.Oznaka);

				Image img = new Image();

				try
				{
					img.Source = new BitmapImage(new Uri(m.Slika));
				}
				catch (Exception ex)
				{
					img.Source = new BitmapImage(new Uri("C:/Users/milutin/source/repos/HCI-project/ProjectHCI/location.png"));
				}
				WrapPanel wp = new WrapPanel();
				wp.Orientation = Orientation.Vertical;

				TextBox oznaka = new TextBox();
				oznaka.IsEnabled = false;
				oznaka.Text = "Oznaka: " + m.Oznaka;
				wp.Children.Add(oznaka);

				TextBox naziv = new TextBox();
				naziv.IsEnabled = false;
				naziv.Text = "Naziv: " + m.Ime;
				wp.Children.Add(naziv);


				TextBox tip = new TextBox();
				tip.IsEnabled = false;
				tip.Text = "Tip: " + m.Tip;
				wp.Children.Add(tip);

				ToolTip tt = new ToolTip();
				tt.Content = wp;
				img.ToolTip = tt;
				img.Width = 50;
				img.Height = 50;
				img.Tag = m.Oznaka;

				img.PreviewMouseLeftButtonDown += DraggedImagePreviewMouseLeftButtonDown;
				img.MouseMove += DraggedImageMouseMove;
				var positionX = e.GetPosition(canvasMap).X;
				var positionY = e.GetPosition(canvasMap).Y;

				m.X = (double)positionX;
				m.Y = (double)positionY;

				AddKordinate a = new AddKordinate();
				UpdateKordinate u = new UpdateKordinate();

				if(selected==null)
				{
					a.handle(m);
				}
				else
				{
					u.handle(selected);
				}
				//a.handle(m);

				canvasMap.Children.Add(img);
				Canvas.SetLeft(img, positionX - 20);
				Canvas.SetTop(img, positionY - 20);

				


				//Studenti2.Add(student);
			}
		}

	}
}
