using System;

using Xamarin.Forms;

namespace JPOINSA
{
	public class HomePage : ContentPage
	{
		public HomePage ()
		{
			Padding = new Thickness(20);
			NavigationPage.SetHasBackButton(this, false);
			ToolbarItem showAllPresentations = new ToolbarItem {
				Text = "+",
				Command = new Command (() => Navigation.PushModalAsync (new NavigationPage (new PresentationsPage ()) {
					BarBackgroundColor = Settings.lightColor,
					BarTextColor = Color.White
				}))
			};

			ToolbarItems.Add (showAllPresentations);

			Content = new StackLayout {
				Children = {
					new Label { Text = "You are well connected !" }
				}
			};
		}
	}
}


