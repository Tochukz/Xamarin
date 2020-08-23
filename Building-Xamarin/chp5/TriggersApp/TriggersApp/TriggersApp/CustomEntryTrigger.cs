using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TriggersApp
{
	class CustomEntryTrigger: TriggerAction<Entry>
	{
		protected override void  Invoke(Entry entry)
		{
			double salary;			
			bool isValid = Double.TryParse(entry.Text, out salary);
			entry.TextColor = isValid ? Color.Default : Color.Red; 
		}
	}
}
