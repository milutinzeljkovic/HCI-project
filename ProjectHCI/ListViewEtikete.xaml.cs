﻿using System;
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
using System.Windows.Shapes;
using ProjectHCI.Models;
using ProjectHCI.Controlers;

namespace ProjectHCI
{
	/// <summary>
	/// Interaction logic for ListViewEtikete.xaml
	/// </summary>
	public partial class ListViewEtikete : Window
	{
		public ListViewEtikete()
		{
			InitializeComponent();
			lvUsers.ItemsSource = MainWindow.Instance().ListEtikete;
		}

		void odabir(object sender, RoutedEventArgs e)
		{
			String prikaz = lvUsers.SelectedItem == null ? "" : ((Etiketa)lvUsers.SelectedItem).Oznaka;
			String etikete = MainWindow.Instance().tbEtiketa.Text;
			string str;
			if(Observers.App.Instance().PreviousState=="izmena_spomenika")
			{
				str = IzmenaSpomenika.Instance().tbEtiketa.Text;
			}
			else
			{
				str = etikete;
			}
			if(str !="")
			{
				str += ", ";
			}
			
			str += prikaz;
			if(Observers.App.Instance().PreviousState == "izmena_spomenika")
			{
				IzmenaSpomenika.Instance().tbEtiketa.Text = str;
			}
			else
			{
				MainWindow.Instance().tbEtiketa.Text = str;
				Observers.App.Instance().State = "form_spomenik";
			}
			Observers.App.Instance().PreviousState = "";
			this.Close();

		}

	}
}
