using System;

namespace WorkingWithFiles
{
	/// <summary>
	/// This Monkey class is used to deserialize an XML file and display the resulting data in a list.
	/// </summary>
	/// <remarks>
	/// The code used to load the XML into this class is shown here:
	/// <code><![CDATA[
	/// List<Monkey> monkeys;
	/// 	using (var reader = new System.IO.StreamReader (stream)) {
	/// 	var serializer = new XmlSerializer(typeof(List<Monkey>));
	/// 	monkeys = (List<Monkey>)serializer.Deserialize(reader);
	/// }
	/// ]]></code>
	/// </remarks>
	public class Monkey
	{
		public string Name {get;set;}
		public string Location { get; set; }
		public string Details { get; set; }

		public override string ToString ()
		{
			return Name;
		}
	}
}

