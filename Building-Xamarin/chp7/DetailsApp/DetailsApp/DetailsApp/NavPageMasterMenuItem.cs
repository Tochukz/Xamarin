using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailsApp
{

	public class NavPageMasterMenuItem
	{
		public NavPageMasterMenuItem()
		{
			// TargetType = typeof(NavPageMasterMenuItem);
		}
		public int Id { get; set; }
		public string Title { get; set; }

		public Type TargetType { get; set; }
	}
}