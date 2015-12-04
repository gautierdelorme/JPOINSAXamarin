using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

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
			var map = new Map(
				MapSpan.FromCenterAndRadius(
					new Position(Latitude, Longitude), Distance.FromMiles(0.2))) {
				IsShowingUser = true,
				HeightRequest = 100,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			Content = new StackLayout { 
				Children = {
					map
					//new Label { Text = "point (" + Latitude + ", " + Longitude + ")" }
				}
			};
		}
	}
}


