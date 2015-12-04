using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace JPOINSA
{
	public class PresentationCell : ViewCell
	{
		public PresentationCell ()
		{
			var label = new Label ();
			label.SetBinding(Label.TextProperty, "Name");
			View = new StackLayout {
				BackgroundColor = Color.Red,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {
					label
				}
			};
		}
	}
}

