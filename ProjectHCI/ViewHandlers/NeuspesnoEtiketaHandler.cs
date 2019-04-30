using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ProjectHCI.ViewHandlers
{
	class NeuspesnoEtiketaHandler : ViewHandler
	{
		public void HandleView()
		{
			MessageBox.Show("Greska prilikom dodavanja", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Error);
			MainWindow.Instance().textBoxEtiketaOznaka.BorderBrush= Brushes.Red;
			if(MainWindow.Instance().textBoxEtiketaOznaka.IsFocused)
			{
				MainWindow.Instance().textBoxEtiketaOznaka.BorderBrush = MainWindow.Instance().color;
			}
		}

	}
}
