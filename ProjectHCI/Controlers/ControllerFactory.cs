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
				case "getTipove":
					return new GetTipoveController();
				case "addTip":
					return new AddTipController();
				case "addSpomenik":
					return new AddSpomenikController();
				case "updateEtiketu":
					return new UpdateEtiketuController();
				case "getSpomenike":
					return new GetSpomenikeControllercs();
				case "updateSpomenik":
					return new UpdateSpomenikCotroller();
				case "updateTip":
					return new UpdateTipController();
				case "deleteSpomenik":
					return new DeleteSpomenikController();
				case "deleteTip":
					return new DeleteTipController();
				case "deleteEtiketa":
					return new DeleteEtiketaController();
				default:
					return null;
			}
		}

	}
}
