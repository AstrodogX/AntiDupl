using System.IO;
using System.Windows.Forms;
using System.Xml;

using ExtendedXmlSerializer;
using ExtendedXmlSerializer.Configuration;

namespace AntiDupl.NET.Common
{
	public static class Serializer
	{
		private static ConfigurationContainer CC
		{
			get => new();
		}

		private static ConfigurationContainer Configure<TType>()
		{
			return (ConfigurationContainer) CC.UseOptimizedNamespaces().EnableImplicitTypingFromAll(typeof(TType));
		}

		private static void Serialize<TType>(IExtendedXmlSerializer serializer, TType target, string filename)
		{
			string result;

			try {
				result = serializer.Serialize(new XmlWriterSettings { Indent = true }, target);
			} catch (XmlException exception) {
				MessageBox.Show("Error while writing XML to the file:\n" + filename + "\n\n" + exception.Message);
				return;
			}

			// for some reason using stream writer directly with the serializer results in a broken file
			StreamWriter writer = new(filename);
			writer.Write(result);
			writer.Close();
		}

		public static void Serialize<TType>(TType target, string filename)
		{
			Serialize(Configure<TType>().Create(), target, filename);
		}

		public static TType Deserialize<TType>(IExtendedXmlSerializer serializer, string filename)
		{
			FileInfo fileInfo = new(filename);
			if (fileInfo.Exists == false) {
				return default;
			}

			FileStream stream = new(filename, FileMode.Open, FileAccess.Read);

			TType result = default;

			try {
				result = serializer.Deserialize<TType>(stream);
			} catch (XmlException exception) {
				MessageBox.Show("Error while loading XML from the file:\n" + filename + "\n\n" + exception.Message);
			}
			
			stream.Close();

			return result;
		}

		public static TType Deserialize<TType>(string filename)
		{
			return Deserialize<TType>(Configure<TType>().Create(), filename);
		}

		public class Custom
		{
			public Custom()
			{ }

			public bool UseAttributes { get; set; } = false;

			private ConfigurationContainer Configure<TType>()
			{
				ConfigurationContainer container = Serializer.Configure<TType>();

				if (UseAttributes) {
					container.UseAutoFormatting();
				}

				return container;
			}

			public void Serialize<TType>(TType target, string filename)
			{				
				Serializer.Serialize(Configure<TType>().Create(), target, filename);
			}

			public TType Deserialize<TType>(string filename)
			{
				return Serializer.Deserialize<TType>(Configure<TType>().Create(), filename);
			}
		}
	}
}
