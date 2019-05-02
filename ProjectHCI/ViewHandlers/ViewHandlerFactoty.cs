using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHCI.ViewHandlers
{
	public class ViewHandlerFactoty
	{
		public ViewHandler GetViewHandler(string viewHandlerName)
		{
			switch (viewHandlerName)
			{
				case "FormSpomenik":
					return new FormSpomenik();
				case "FormEtiketa":
					return new FormEtiketa();
				case "FormTip":
					return new FormTip();
				case "SideBar":
					return new SideBarHandler();
				case "UspesnoEtiketa":
					return new UspesnoEtiketa();
				case "NeuspesnoEtiketaHandler":
					return new NeuspesnoEtiketaHandler();
				case "FirstPage":
					return new FirstPage();
				case "OdabirTipa":
					return new OdabirTipaViewHandler();
				case "OdabirEtikete":
					return new OdabirEtiketeViewHandler();
				default:
					return null;
			}
		}
	}
}
