using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace JPOINSA
{
	public class MapsPage : ContentPage
	{
		
		public double Latitude {
			get;
			set;
		}

		public double Longitude {
			get;
			set;
		}

		public MapsPage (double Latitude, double Longitude)
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "point (" + Latitude + ", " + Longitude + ")" }
				}
			};
		}
	}
}


