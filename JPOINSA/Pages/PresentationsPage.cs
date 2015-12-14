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

			App.parseManager.getPresentations ((IList<Presentation> presentations) => loadPresentations (presentations));

			listViewModel = new ObservableCollection<Presentation> ();
			listView = new ListView ();
			listView.ItemsSource = listViewModel;
			listView.ItemTemplate = new DataTemplate (typeof(PresentationCell));
			listView.RowHeight = 100;
			listView.ItemTapped += showPresentation;

			Content = listView;
		}

		void showPresentation(object sender, ItemTappedEventArgs e)
		{
			Navigation.PushAsync (new PresentationPage (
				(e.Item as Presentation)
			));
			((ListView)sender).SelectedItem = null; // de-select the row
		}

		void loadPresentations(IList<Presentation> presentations)
		{
			foreach (Presentation p in presentations) {
				listViewModel.Add (p);
			}
		}
	}
}