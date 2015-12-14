using System;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Net;
using System.Linq;

namespace JPOINSA
{
	public class PresentationPage : ContentPage
	{
		public Presentation Prez {
			get;
			set;
		}

		public PresentationPage (Presentation Prez)
		{
			this.Prez = Prez;

			var scrollView = new ScrollView {
				Content = new StackLayout { 
					Children = {
						buildHeader(),
						buildMap(),
						buildBody()
					},
					Spacing = 0
				}
			};

			Content = new StackLayout { 
				Children = {
					scrollView
				},
			};
		}

		private ContentView buildHeader() {
			var image = new Image {
				Aspect = Aspect.AspectFill,
				Source = Prez.ImageSource
			};
			var overlay = new ContentView {
				BackgroundColor = Color.FromRgba (0, 0, 0, 0.6)
			};

			var labelTitle = new Label {
				Text = Prez.Name,
				TextColor = Color.White,
				FontSize = 30,
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalTextAlignment = TextAlignment.Center
			};
					
			RelativeLayout layout = new RelativeLayout ();

			layout.Children.Add (image, 
				Constraint.Constant (0), 
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => { return parent.Width; }),
				Constraint.RelativeToParent ((parent) => { return parent.Height; }));
			layout.Children.Add (overlay, 
				Constraint.Constant (0), 
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => { return parent.Width; }),
				Constraint.RelativeToParent ((parent) => { return parent.Height; }));
			layout.Children.Add (labelTitle, 
				Constraint.Constant (0), 
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => { return parent.Width; }),
				Constraint.RelativeToParent ((parent) => { return parent.Height; }));

			var headerView = new ContentView {
				HeightRequest = 150,
				Content = layout
			};

			return headerView;
		}

		private ContentView buildMap() {
			var map = new Map(
				MapSpan.FromCenterAndRadius(this.Prez.Position, Distance.FromMiles(0.2))) {
				IsShowingUser = true,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			var pin = new Pin {
				Type = PinType.Place,
				Position = this.Prez.Position,
				Label = this.Prez.Name,
				Address = "custom detail info"
			};
			pin.Clicked += pinTouched;
			map.Pins.Add(pin);

			RelativeLayout layout = new RelativeLayout ();

			layout.Children.Add (map, 
				Constraint.Constant (0), 
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => { return parent.Width; }),
				Constraint.RelativeToParent ((parent) => { return parent.Height; }));

			var mapView = new ContentView {
				HeightRequest = 100,
				Content = layout
			};

			return mapView;
		}

		private ContentView buildBody() {
			var labelDescription = new Label {
				Text = "Description : ",
				TextColor = Color.Black,
				FontSize = 20,
			};

			var descriptionBody = new Label {
				Text = Prez.Description,
				TextColor = Color.Black,
				FontSize = 12,
			};

			var bodyView = new ContentView {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Content = new StackLayout { 
					Children = {
						labelDescription,
						descriptionBody
					},
				}
			};

			return bodyView;
		}

		private async void pinTouched (object sender, EventArgs e) {
			Geocoder geoCoder = new Geocoder ();
			var addresses = await geoCoder.GetAddressesForPositionAsync (this.Prez.Position);

			switch (Device.OS) {
			case TargetPlatform.iOS:
				Device.OpenUri (
					new Uri (string.Format ("http://maps.apple.com/?q={0}", WebUtility.UrlEncode(addresses.FirstOrDefault()))));
				break;
			case TargetPlatform.Android:
				Device.OpenUri (
					new Uri (string.Format ("geo:0,0?q={0}", WebUtility.UrlEncode(addresses.FirstOrDefault()))));
				break;
			case TargetPlatform.Windows:
			case TargetPlatform.WinPhone:
				Device.OpenUri (
					new Uri (string.Format ("bingmaps:?where={0}", Uri.EscapeDataString(addresses.FirstOrDefault()))));
				break;
			}
		}
	}
}


