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
				default:
					return null;
			}
		}

	}
}
