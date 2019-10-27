using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace FooBar
{
	[Serializable]
	[XmlRoot("Foo")]
	public class Foo
	{
		[XmlArray("BarList"), XmlArrayItem(typeof(Bar), ElementName = "Bar")]
		public List<Bar> BarList { get; set; }
	}

	[Serializable]
	public class Bar
	{
		public string Property1 { get; set; }
		public string Property2 { get; set; }
	}

	class Program
	{
		static void Main(string[] args)
		{
			Foo f = new Foo();
			f.BarList = new List<Bar>();
			f.BarList.Add(new Bar() { Property1 = "s", Property2 = "2" });
			f.BarList.Add(new Bar() { Property1 = "s", Property2 = "2" });

			FileStream fs = new FileStream("d:\\git\\test27.xml", FileMode.OpenOrCreate);
			XmlSerializer s = new XmlSerializer(typeof(Foo));
			s.Serialize(fs, f);
		}
	}
}
