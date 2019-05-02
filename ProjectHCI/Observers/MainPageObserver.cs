using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHCI.ViewHandlers;

namespace ProjectHCI.Observers
{
	public class MainPageObserver : MainObserver
	{
		public MainPageObserver(App app)
		{
			this.app = app;
			this.app.attach(this);
		}

		public override void update()
		{
			ViewHandlerFactoty factoty = new ViewHandlerFactoty();
			if (app.State == "form_spomenik")
			{
				(factoty.GetViewHandler("FormSpomenik")).HandleView();
				(factoty.GetViewHandler("SideBar")).HandleView();
			}
			else if (app.State == "form_tip")
			{
				(factoty.GetViewHandler("FormTip")).HandleView();
			}
			else if (app.State == "form_etiketa")
			{
				(factoty.GetViewHandler("FormEtiketa")).HandleView();
			}
			else if(app.State == "uspesno_etiketa")
			{
				(factoty.GetViewHandler("UspesnoEtiketa")).HandleView();
			}
			else if(app.State == "neuspesno_etiketa")
			{
				(factoty.GetViewHandler("NeuspesnoEtiketaHandler")).HandleView();
			}
			else if(app.State == "inital_state")
			{
				(factoty.GetViewHandler("FirstPage")).HandleView();
			}
			else if(app.State == "odabir_tipa")
			{
				(factoty.GetViewHandler("OdabirTipa")).HandleView();
			}
			else if (app.State == "odabir_etikete")
			{
				(factoty.GetViewHandler("OdabirEtikete")).HandleView();
			}



		}
	}
}
