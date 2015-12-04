using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Diagnostics;
using System.Linq;

namespace JPOINSA
{
	public class PresentationsPage : ContentPage
	{

		private ListView listView;
		private ObservableCollection<Presentation> listViewModel;

		public PresentationsPage ()
		{
			Title = "Presentations";
			/*ToolbarItems.Add (new ToolbarItem {
				Text = "Done",
				Command = new Command (() => Navigation.PopModalAsync())
			});*/

			App.parseManager.getPresentations ((IList<Presentation> presentations) => loadPresentations (presentations));

			listViewModel = new ObservableCollection<Presentation> ();
			listView = new ListView ();
			listView.ItemsSource = listViewModel;
			listView.ItemTemplate = new DataTemplate (typeof(PresentationCell));

			listView.ItemTapped += showMaps;

			Content = listView;
		}

		void showMaps(object sender, ItemTappedEventArgs e)
		{
			Navigation.PushAsync (new MapsPage (
				(e.Item as Presentation).Latitude,
				(e.Item as Presentation).Longitude)
			);
			((ListView)sender).SelectedItem = null; // de-select the row
			//await DisplayAlert("Tapped", e.Item + " row was tapped", "OK");
		}

		void loadPresentations(IList<Presentation> presentations)
		{
			foreach (Presentation p in presentations) {
				Debug.WriteLine (p);
				listViewModel.Add (p);
			}
		}
	}
}