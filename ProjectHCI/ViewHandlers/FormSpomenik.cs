using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHCI.ViewModel;
using System.Windows;

namespace ProjectHCI.ViewHandlers
{
	public class FormSpomenik : ViewHandler
	{
		public void HandleView()
		{
			MainWindow mainWindow = MainWindow.Instance();
			mainWindow.showSpomenikForm();
			if(mainWindow.textBoxIme.Text =="" || mainWindow.textBoxOznaka.Text == "" || mainWindow.textBoxOpis.Text == "" || mainWindow.textBoxPrihod.Text == "" || mainWindow.tbTip.Text == "" || mainWindow.comboBoxT.SelectedItem == null || mainWindow.comboBoxEra.SelectedItem == null)
			{
				mainWindow.btnNext.IsEnabled = false;
			}
			else
			{
				mainWindow.btnNext.IsEnabled = true;
			}
			
		}

	}
}
