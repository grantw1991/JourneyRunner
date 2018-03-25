using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Life.JourneyRunner
{
    public class XmlSerializer<T> where T : class, new()
    {
        public static bool CanDeserialize(string filename)
        {
            using (XmlReader reader = XmlReader.Create(filename, new XmlReaderSettings()))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                return xmlSerializer.CanDeserialize(reader);
            }
        }

        public static T Deserialize(string xml)
        {
            return Deserialize(xml, Encoding.UTF8, null);
        }

        public static T Deserialize(string xml, Encoding encoding)
        {
            return Deserialize(xml, encoding, null);
        }

        public static T Deserialize(string xml, XmlReaderSettings settings)
        {
            return Deserialize(xml, Encoding.UTF8, settings);
        }

        public static T Deserialize(string xml, Encoding encoding, XmlReaderSettings settings)
        {
            if (string.IsNullOrEmpty(xml))
                throw new ArgumentException("XML cannot be null or empty", "xml");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (MemoryStream memoryStream = new MemoryStream(encoding.GetBytes(xml)))
            {
                using (XmlReader xmlReader = XmlReader.Create(memoryStream, settings))
                {
                    return (T)xmlSerializer.Deserialize(xmlReader);
                }
            }
        }

        public static T DeserializeFromFile(string filename)
        {
            return DeserializeFromFile(filename, new XmlReaderSettings());
        }

        public static T DeserializeFromFile(string filename, XmlReaderSettings settings)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentException("filename", "XML filename cannot be null or empty");

            if (!File.Exists(filename))
                throw new FileNotFoundException("Cannot find XML file to deserialize", filename);
            
            using (XmlReader reader = XmlReader.Create(filename, settings))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(reader);
            }
        }

        public static string Serialize(T source)
        {
            return Serialize(source, null, GetIndentedSettings());
        }

        public static string Serialize(T source, XmlSerializerNamespaces namespaces)
        {
            return Serialize(source, namespaces, GetIndentedSettings());
        }

        public static string Serialize(T source, XmlWriterSettings settings)
        {
            return Serialize(source, null, settings);
        }

        public static string Serialize(T source, XmlSerializerNamespaces namespaces, XmlWriterSettings settings)
        {
            if (source == null)
                throw new ArgumentNullException("source", "Object to serialize cannot be null");

            string xml;
            XmlWriter xmlWriter;
            StreamReader sr = null;

            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {

                    xmlWriter = XmlWriter.Create(memoryStream, settings);
                    XmlSerializer x = new XmlSerializer(typeof(T));
                    x.Serialize(xmlWriter, source, namespaces);

                    memoryStream.Position = 0; 
                    sr = new StreamReader(memoryStream);
                    xml = sr.ReadToEnd();
                }
            }
            finally
            {
                if (sr != null)
                    sr.Dispose();
            }
            return xml;
        }

        public static void SerializeToFile(T source, string filename)
        {
            SerializeToFile(source, filename, null, GetIndentedSettings());
        }

        public static void SerializeToFile(T source, string filename, XmlSerializerNamespaces namespaces)
        {
            SerializeToFile(source, filename, namespaces, GetIndentedSettings());
        }

        public static void SerializeToFile(T source, string filename, XmlWriterSettings settings)
        {
            SerializeToFile(source, filename, null, settings);
        }

        public static void SerializeToFile(T source, string filename, XmlSerializerNamespaces namespaces, XmlWriterSettings settings)
        {
            if (source == null)
                throw new ArgumentNullException("source", "Object to serialize cannot be null");

            using (XmlWriter xmlWriter = XmlWriter.Create(filename, settings))
            {
                XmlSerializer x = new XmlSerializer(typeof(T));
                x.Serialize(xmlWriter, source, namespaces);
            }
        }

        private static XmlWriterSettings GetIndentedSettings()
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.IndentChars = "\t";

            return xmlWriterSettings;
        }
    }
}
