using System;

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

		public DateTime Start {
			get;
			set;
		}

		public DateTime End {
			get;
			set;
		}

		public double Latitude {
			get;
			set;
		}

		public double Longitude {
			get;
			set;
		}

		public Presentation (string ObjectId, string Name, DateTime Start, DateTime End, double Latitude, double Longitude)
		{
			this.ObjectId = ObjectId;
			this.Name = Name;
			this.Start = Start;
			this.End = End;
			this.Latitude = Latitude;
			this.Longitude = Longitude;
		}

		public override string ToString () {
			return Name + " ("+Latitude+" -- "+Longitude+")";
		}
	}
}