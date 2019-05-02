using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHCI.Controlers
{
	public class ControllerFactory
	{
		public Controller GetController(string controllerName)
		{
			switch (controllerName)
			{
				case "addEtiketu":
					return new AddEtiketuController();
				case "getEtikete":
					return new GetEtiketeController();
				default:
					return null;
			}
		}

	}
}
