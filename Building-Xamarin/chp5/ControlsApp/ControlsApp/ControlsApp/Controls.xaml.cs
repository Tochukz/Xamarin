using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControlsApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Controls : ContentPage
	{
		public Controls()
		{
			InitializeComponent();
			Username.Focus(); // Returns a Boolean, true if successful 
		}

		void PickerSelectedIndexChanged(object sender, EventArgs args)
		{
			PageValue.Text = (string)ThePicker.ItemsSource[ThePicker.SelectedIndex];
		}

		void DatePicketDateSelected(object sender, DateChangedEventArgs e)
		{
			EventValue.Text = e.NewDate.ToString();
			PageValue.Text = TheDatePicker.Date.ToString();
		}

		void TimePickerPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == TimePicker.TimeProperty.PropertyName)
			{
				PageValue.Text = TheTimePicker.Time.ToString();
			}
		}

		void StepperValueChnaged(object sender, ValueChangedEventArgs e)
		{
			EventValue.Text = string.Format("{0:F1}", e.NewValue);
			PageValue.Text = TheStepper.Value.ToString();
		}

		void SliderValueChanged(object sender, ValueChangedEventArgs e)
		{
			EventValue.Text = string.Format("{0:F1}", e.NewValue);
			PageValue.Text = TheSlider.Value.ToString();
		}

		void SwitchToggled(object sender, ToggledEventArgs e)
		{
			EventValue.Text = string.Format("{0}", e.Value);
			PageValue.Text = TheSwitch.IsToggled.ToString();
		}
	}
}