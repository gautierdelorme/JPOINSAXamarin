using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace JPOINSA
{
	public class PresentationCell : ViewCell
	{
		public PresentationCell ()
		{
			var label = new Label {
				TextColor = Color.White,
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalTextAlignment = TextAlignment.Center,
				FontSize = 20
			};
			label.SetBinding(Label.TextProperty, "Name");

			var image = new Image {
				Aspect = Aspect.AspectFill,
			};
			image.SetBinding (Image.SourceProperty, "ImageSource");

			var overlay = new ContentView {
				BackgroundColor = Color.FromRgba (0, 0, 0, 0.5)
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
			layout.Children.Add (label, 
				Constraint.Constant (0), 
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => { return parent.Width; }),
				Constraint.RelativeToParent ((parent) => { return parent.Height; }));
			
			View = layout;


			/*View = new StackLayout {
				//Orientation = StackOrientation.Horizontal,
				//HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {
					image,
					//label
				}
			};*/
		}
	}
}

