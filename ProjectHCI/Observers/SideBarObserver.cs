using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHCI.ViewHandlers;

namespace ProjectHCI.Observers
{
	class SideBarObserver : MainObserver
	{
		public SideBarObserver(App app)
		{
			this.app = app;
			this.app.attach(this);
		}

		public override void update()
		{
			/*ViewHandlerFactoty factoty = new ViewHandlerFactoty();
			ViewHandler handler = factoty.GetViewHandler("SideBar");
			handler.HandleView();*/

			if(app.State=="inital_state")
			{
				MainWindow.Instance().dodaj_spomenik.IsEnabled = true;
			}
			if(app.PreviousState == "form_spomenik")
			{
				MainWindow.Instance().dodaj_spomenik.IsEnabled = true;
			}
			if(app.State == "form_spomenik")
			{
				MainWindow.Instance().dodaj_spomenik.IsEnabled = false;
			}
			


		}
	}
}