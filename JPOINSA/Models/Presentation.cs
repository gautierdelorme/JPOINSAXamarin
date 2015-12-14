using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace JPOINSA
{
	public class Presentation
	{
		public string ObjectId {
			get;
			set;
		}

		public string Name {
			get;
			set;
		}

		public string Description {
			get;
			set;
		}

		public DateTime Start {
			get;
			set;
		}

		public DateTime End {
			get;
			set;
		}

		public Position Position {
			get;
			set;
		}

		public UriImageSource ImageSource {
			get;
			set;
		}

		public Presentation (string ObjectId, string Name, string Description, DateTime Start, DateTime End, double Latitude, double Longitude, Uri urlImage)
		{
			this.ImageSource = new UriImageSource {
				Uri =urlImage
			};
			this.ObjectId = ObjectId;
			this.Name = Name;
			this.Description = Description;
			this.Start = Start;
			this.End = End;
			this.Position = new Position (Latitude, Longitude);
		}

		public override string ToString () {
			return Name;
		}
	}
}