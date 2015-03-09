using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;

namespace SimpleWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public Stream GetXml()
        {
            try
            {
                XDocument doc = XDocument.Load(@"C:\Dropbox\Projects\Useful\ITypedListImpImplementation\ITypedListImpImplementation\XmlTable.xml");
                Stream stream = new MemoryStream();
                doc.Save(stream);
                stream.Position = 0;

                var t = new StreamReader(stream);
                string text = t.ReadToEnd();

                stream.Position = 0;

                return stream;
            }
            catch (IOException ex)
            {
                Console.WriteLine("An exception was thrown while trying to open file {0}");
                Console.WriteLine("Exception is: ");
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        public DataWrapper GetData()
        {
            DataWrapper result = new DataWrapper();
            result.Value = GetXml();

            return result;
        }

        public void UpdateProjectItems(Stream data)
        {
            XDocument doc = XDocument.Load(data);
        }
    }
}
