using System;

using Xamarin.Forms;

namespace JPOINSA
{
	public class PresentationsPage : ContentPage
	{
		public PresentationsPage ()
		{
			Title = "Presentations";
			ToolbarItems.Add (new ToolbarItem {
				Text = "Done",
				Command = new Command (() => Navigation.PopModalAsync())
			});

			Content = new TableView {
				Root = new TableRoot {
					new TableSection {
						new TextCell {
							Text = "Lolo",
							Detail = "TextCell Detail"
						}
					}
				},
				Intent = TableIntent.Data
			};
		}
	}
}