using System.IO;
using System.Xml.Serialization;

namespace Infraestructure.Crosscutting
{
    public static class SerializationHelper
    {


        /// <summary>
        /// Serialize a [Serializable] object of type T into an XML/UTF8 string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string Serialize<T>(this T item)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(item.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, item);
                return textWriter.ToString();
            }

        }

        /// <summary>
        /// De-serialize an XML/UTF8 string into an object of type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T Deserialize<T>(this string xml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringReader textReader = new StringReader(xml))
            {
                return (T)xmlSerializer.Deserialize(textReader);
            }

        }

    }
}
