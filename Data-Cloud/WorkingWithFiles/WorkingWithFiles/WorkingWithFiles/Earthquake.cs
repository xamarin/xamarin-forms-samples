using System;

namespace WorkingWithFiles
{
	public class Earthquake
	{
		public string eqid { get; set; }
		public float magnitude { get; set; }
		public float lng { get; set; }
		public string src { get; set; }
		public string datetime { get; set; }
		public float depth { get; set; }
		public float lat { get; set; }

		public string Data
		{
            get { return string.Format("{0}, {1}, {2}, {3}", lat, lng, magnitude, depth); }
		}

        public override string ToString()
        {
            return string.Format("Date: {0}, Magnitude: {1}", datetime.Substring(0, 10), magnitude);
        }
    }

	public class Rootobject
	{
		public Earthquake[] earthquakes { get; set; }
	}
}
