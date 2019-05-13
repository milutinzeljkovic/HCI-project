using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;


namespace ProjectHCI.ViewHandlers
{
	class NeuspesnoTipHandler : ViewHandler
	{
		public void HandleView()
		{
			MessageBox.Show("Greska prilikom dodavanja", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Error);
			MainWindow.Instance().textboxOznakaTip.BorderBrush = Brushes.Red;
			if (MainWindow.Instance().textboxOznakaTip.IsFocused)
			{
				MainWindow.Instance().textboxOznakaTip.BorderBrush = MainWindow.Instance().color;
			}
		}

	}
}