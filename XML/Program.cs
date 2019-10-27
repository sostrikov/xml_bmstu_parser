using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace XML
{

	[Serializable]
	[XmlRoot("BMSTUoU")]
	public class BMSTUoU
	{
		[XmlArray("ouList"), XmlArrayItem(typeof(MyOrgUnit), ElementName = "OrgUnit")]
		public List<MyOrgUnit> ouList { get; set; }
	}


	[Serializable]
	public class MyOrgUnit
	{
		[XmlAttribute]
		public string name { get; set; }
		[XmlAttribute]
		public string id { get; set; }
		[XmlAttribute]
		public string parentid { get; set; }
		//[XmlElement(ElementName = "BMSTUouGuid")]
		[XmlAttribute]
		public Guid ouguid { get; set; }

		[XmlAttribute(AttributeName ="OULevel")]
		public int oulevel { get; set; }


		public MyOrgUnit() { }
		public MyOrgUnit(string name01, string id01, string parentid01, Guid ouguid01, int oulevel01)
		{
			name = name01;
			id = id01;
			parentid = parentid01;
			ouguid = ouguid01;
			oulevel = oulevel01;
		}

	}

	//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	[Serializable]
	[XmlRoot("persons")]
	public class persons
	{
		[XmlArray("personsList"), XmlArrayItem(typeof(Person), ElementName = "Person")]
		public List<Person> personsList { get; set; }
	}

	[Serializable]
	public class Person
	{
		[XmlAttribute]
		public string lastname { get; set; }
		[XmlAttribute]
		public string firstname { get; set; }
		[XmlAttribute]
		public string middlename { get; set; }
		[XmlAttribute]
		public string id { get; set; }
		[XmlAttribute]
		public string birthday { get; set; }
		[XmlAttribute]
		public Guid personguid { get; set; }

		public Person() { }
		public Person(string lastname01, string firstname01, string middlename01, string id01, string birthday01, Guid personguid01)
		{
			lastname = lastname01;
			firstname = firstname01;
			middlename = middlename01;
			id = id01;
			birthday = birthday01;
			personguid = personguid01;
		}

	}

	

	class Program
	{
		

		static void Main(string[] args)
		{
			//Создаем объект для загрузки структуры
			BMSTUoU f = new BMSTUoU();
			f.ouList = new List<MyOrgUnit>();

			//Создаем объект для загрузки сотрудников
			persons f2 = new persons();
			f2.personsList = new List<Person>();

			//List<MyOrgUnit> orgUnit = new List<MyOrgUnit>();

			XmlDocument xDoc3 = new XmlDocument();
			xDoc3.Load("struct.xml");
			// получим корневой элемент
			XmlElement xRoot3 = xDoc3.DocumentElement;
			XmlNodeList nodes1 = xRoot3.SelectNodes("item/item");

			// обход всех узлов в корневом элементе
			foreach (XmlNode xnode in nodes1)
			{
				
				if (xnode.Attributes.Count > 0)
				{
					//int i = xnode.Attributes.Count;
					// получаем атрибут name
					XmlNode attr1 = xnode.Attributes.GetNamedItem("name");
					//if (attr1 != null)
						//Console.Write("1");
						//Console.Write($"{attr1.Value}\t");
					// получаем атрибут id
					XmlNode attr2 = xnode.Attributes.GetNamedItem("id");
					//if (attr2 != null)
						//Console.Write("+");
						//Console.Write($"{attr2.Value}\t");
					// получаем атрибут parentid
					XmlNode attr3 = xnode.Attributes.GetNamedItem("parentid");
					//if (attr3 != null)
						//Console.Write("+");
						//Console.Write($"{attr3.Value}\t");
					// получаем атрибут Guid
					XmlNode attr4 = xnode.Attributes.GetNamedItem("guid");
					//if (attr4 != null)
						//Console.Write("+");
					//Console.Write($"{attr4.Value}\t");
					//Заносим результат в список объектов MyOrgUnit
					if (attr1 != null && attr2 != null && attr3 != null && attr4 != null)

						f.ouList.Add(new MyOrgUnit() { name = attr1.Value, id = attr2.Value, parentid = attr3.Value, ouguid = new Guid(attr4.Value), oulevel =1 });
					
				}


				// выбираем все дочерние узлы 2-го уровня

				//var nodes2 = xnode.ChildNodes;
				foreach (XmlNode xnode2 in xnode.ChildNodes)
				{
					if (xnode.Attributes.Count > 0)
					{
						//int i = xnode.Attributes.Count;
						// получаем атрибут name
						XmlNode attr1 = xnode2.Attributes.GetNamedItem("name");
						//if (attr1 != null)
							//Console.Write("2");
							//Console.Write($" 2 => {attr1.Value}\t");
						// получаем атрибут id
						XmlNode attr2 = xnode2.Attributes.GetNamedItem("id");
						//if (attr2 != null)
							//Console.Write("*");
							//Console.Write($" 2 => {attr2.Value}\t");
						// получаем атрибут parentid
						XmlNode attr3 = xnode2.Attributes.GetNamedItem("parentid");
						//if (attr3 != null)
							//Console.Write("*");
						//Console.Write($" 2 => {attr3.Value}\t");
						// получаем атрибут Guid
						XmlNode attr4 = xnode2.Attributes.GetNamedItem("guid");
						//if (attr4 != null)
							//Console.Write("*");
						//Console.Write($" 2 => {attr4.Value}\t");
						//Заносим результат в список объектов MyOrgUnit
						if (attr1 != null && attr2 != null && attr3 != null && attr4 != null)
							f.ouList.Add(new MyOrgUnit() { name = attr1.Value, id = attr2.Value, parentid = attr3.Value, ouguid = new Guid(attr4.Value), oulevel = 2 });
						

					}
					// выбираем все дочерние узлы 3-го уровня
					//var nodes3 = xnode2.ChildNodes;
					foreach (XmlNode xnode3 in xnode2.ChildNodes)
					{
						if (xnode.Attributes.Count > 0)
						{
							//int i = xnode.Attributes.Count;
							// получаем атрибут name
							XmlNode attr1 = xnode3.Attributes.GetNamedItem("name");
							//if (attr1 != null)
								//Console.Write("3");
							//Console.Write($" 3 => {attr1.Value}\t");
							// получаем атрибут id
							XmlNode attr2 = xnode3.Attributes.GetNamedItem("id");
							//if (attr2 != null)
								//Console.Write("*");
							//Console.Write($" 3 => {attr2.Value}\t");
							// получаем атрибут parentid
							XmlNode attr3 = xnode3.Attributes.GetNamedItem("parentid");
							//if (attr3 != null)
								//Console.Write("*");
							//Console.Write($" 3 => {attr3.Value}\t");
							// получаем атрибут Guid
							XmlNode attr4 = xnode3.Attributes.GetNamedItem("guid");
							//if (attr4 != null)
								//Console.Write("*");
							//Console.Write($" 3 => {attr4.Value}\t");
							//Заносим результат в список объектов MyOrgUnit
							if (attr1 != null && attr2 != null && attr3 != null && attr4 != null)
								f.ouList.Add(new MyOrgUnit() { name = attr1.Value, id = attr2.Value, parentid = attr3.Value, ouguid = new Guid(attr4.Value), oulevel = 3 });
							
						}
						// выбираем все дочерние узлы 4-го уровня
						//var nodes4 = xnode3.ChildNodes;
						foreach (XmlNode xnode4 in xnode3.ChildNodes)
						{
							if (xnode.Attributes.Count > 0)
							{
								//int i = xnode.Attributes.Count;
								// получаем атрибут name
								XmlNode attr1 = xnode4.Attributes.GetNamedItem("name");
								if (attr1 != null)
									Console.Write("4");
								//Console.Write($" 4 => {attr1.Value}\t");
								// получаем атрибут id
								XmlNode attr2 = xnode4.Attributes.GetNamedItem("id");
								//if (attr2 != null)
									//Console.Write("*");
								//Console.Write($" 4 => {attr2.Value}\t");
								// получаем атрибут parentid
								XmlNode attr3 = xnode4.Attributes.GetNamedItem("parentid");
								//if (attr3 != null)
									//Console.Write("*");
								//Console.Write($" 4 => {attr3.Value}\t");
								// получаем атрибут Guid
								XmlNode attr4 = xnode4.Attributes.GetNamedItem("guid");
								//if (attr4 != null)
								//Console.Write("*");
								//Console.Write($" 4 => {attr4.Value}\t");
								//Заносим результат в список объектов MyOrgUnit
								if (attr1 != null && attr2 != null && attr3 != null && attr4 != null)
									f.ouList.Add(new MyOrgUnit() { name = attr1.Value, id = attr2.Value, parentid = attr3.Value, ouguid = new Guid(attr4.Value), oulevel = 4 });
									
							}
						}
					}
				}
			}

			

			//Сериализация в XML
			// передаем в конструктор тип класса
			XmlSerializer s = new XmlSerializer(typeof(BMSTUoU));

			//Чистим пространство имен в XML
			XmlSerializerNamespaces ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });



			// получаем поток, куда будем записывать сериализованный объект
			using (FileStream fs = new FileStream("struct2.xml", FileMode.OpenOrCreate))
			{
				s.Serialize(fs, f);
			}
			
			

			//=================== persons =====================================
			//List<Person> personList = new List<Person>();

			XmlDocument xDoc4 = new XmlDocument();
			xDoc4.Load("persons.xml");
			// получим корневой элемент
			XmlElement xRootPerson = xDoc4.DocumentElement;
			XmlNodeList personsnodes = xRootPerson.SelectNodes("person");
			foreach (XmlNode xnode in personsnodes)
			{

				if (xnode.Attributes.Count > 0)
				{
					// получаем атрибут lastname
					XmlNode attr1 = xnode.Attributes.GetNamedItem("lastname");
					//Console.Write($"{attr1.Value}\t");

					// получаем атрибут firstname
					XmlNode attr2 = xnode.Attributes.GetNamedItem("firstname");
					//Console.Write($"{attr2.Value}\t");

					// получаем атрибут firstname
					XmlNode attr3 = xnode.Attributes.GetNamedItem("middlename");
					//Console.Write($"{attr3.Value}\t");

					// получаем атрибут id
					XmlNode attr4 = xnode.Attributes.GetNamedItem("id");
					//Console.Write($"{attr4.Value}\t");

					// получаем атрибут birthday
					XmlNode attr5 = xnode.Attributes.GetNamedItem("birthday");
					//Console.Write($"{attr5.Value}\t");

					// получаем атрибут birthday
					XmlNode attr6 = xnode.Attributes.GetNamedItem("guid");
					//Console.Write($"{attr6.Value}");
					//Console.WriteLine();
					//Заносим результат в список объектов MyOrgUnit
					if (attr1 != null && attr2 != null && attr3 != null && attr4 != null && attr5 != null && attr6 != null)
						f2.personsList.Add(new Person() { lastname = attr1.Value, firstname = attr2.Value, middlename = attr3.Value, id = attr4.Value, birthday = attr5.Value, personguid = new Guid(attr6.Value)});
					//personList.Add(new Person(attr1.Value, attr2.Value, attr3.Value, attr4.Value, attr5.Value, new Guid(attr6.Value)));
				}
			}
			
			//Сериализация в XML
			// передаем в конструктор тип класса
			XmlSerializer s2 = new XmlSerializer(typeof(persons));

			//Чистим пространство имен в XML
			XmlSerializerNamespaces ns2 = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

			// получаем поток, куда будем записывать сериализованный объект
			using (FileStream fs2 = new FileStream("persons2.xml", FileMode.OpenOrCreate))
			{
				s2.Serialize(fs2, f2);
			}
			// Результаты
			Console.WriteLine($"Всего организационных единиц: {f.ouList.Count()}");

			//Console.WriteLine("\nExists: : {0}", f.ouList.Exists(x => x.oulevel == 1));
			var item = f.ouList.FindAll(x => x.oulevel == 1);
			Console.WriteLine($"Из них 1-го уровня: {item.Count()}");
			item = f.ouList.FindAll(x => x.oulevel == 2);
			Console.WriteLine($"Из них 2-го уровня: {item.Count()}");
			item = f.ouList.FindAll(x => x.oulevel == 3);
			Console.WriteLine($"Из них 3-го уровня: {item.Count()}");
			item = f.ouList.FindAll(x => x.oulevel == 4);
			Console.WriteLine($"Из них 4-го уровня: {item.Count()}");


			/*
			if (item != null)
				foreach (var k in item)
				{
					int i = 0;
					Console.WriteLine(k.name);
					i++;
				}
			*/


			//Console.WriteLine("\nFind: : {0} -  ", f.ouList.Find(x => x.oulevel == 1));
			//Console.WriteLine("\nExists: : {0}", f2.personsList.Exists(x => x.lastname == "Острикова"&& x.firstname == "Ирина" ));
			Console.WriteLine($"Всего сотрудников: {f2.personsList.Count()}");
			Console.Read();
		}
	}
	
}
