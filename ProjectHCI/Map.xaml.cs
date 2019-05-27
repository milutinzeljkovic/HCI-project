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
				Monument monument = (Monument)listView.ItemContainerGenerator.
					ItemFromContainer(listViewItem);

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


					Spomenici.Remove(m);
					ToolTip tt = new ToolTip();
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
				img.Width = 50;
				img.Height = 50;
				img.Tag = m.Oznaka;
				var positionX = e.GetPosition(canvasMap).X;
				var positionY = e.GetPosition(canvasMap).Y;

				m.X = (double)positionX;
				m.Y = (double)positionY;

				AddKordinate a = new AddKordinate();

				a.handle(m);


				ToolTip tt = new ToolTip();
				img.ToolTip = tt;
				canvasMap.Children.Add(img);
				Canvas.SetLeft(img, positionX - 20);
				Canvas.SetTop(img, positionY - 20);

				


				//Studenti2.Add(student);
			}
		}

	}
}
