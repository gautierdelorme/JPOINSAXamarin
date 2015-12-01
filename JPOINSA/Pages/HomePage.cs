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
			};
			showAllPresentations.Clicked += plusButtonClicked;
			ToolbarItems.Add (showAllPresentations);
			Content = new StackLayout {
				Children = {
					new Label { Text = "You are well connected !" }
				}
			};
		}

		void plusButtonClicked(object sender, EventArgs e)
		{
			Navigation.PushModalAsync (new PresentationsPage ());
		}
	}
}


