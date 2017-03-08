using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NM_MMD.Models;
using System.IO;
using System.Xml.Serialization;

namespace NM_MMD.DAL
{
    public class DispensaryXMLDataService : IDispensaryyDataService, IDisposable
    {
        

        public List<Dispensary> Read()
        {
            // a Dispensaries model is defined to pass a type to the XmlSerializer object 
            Dispensaries dispensariesObject;
            string xmlFilePath = HttpContext.Current.Application["dataFilePath"].ToString();
            // initialize a FileStream object for reading
            StreamReader sReader = new StreamReader(xmlFilePath);

            // initialize an XML seriailizer object
            XmlSerializer deserializer = new XmlSerializer(typeof(Dispensaries));

            using (sReader)
            {
                // deserialize the XML data set into a generic object
                object xmlObject = deserializer.Deserialize(sReader);

                // cast the generic object to the list class
                dispensariesObject = (Dispensaries)xmlObject;
            }

            return dispensariesObject.dispensaries;
        }


        public void Write(List<Dispensary> dispensaries)
        {
            string XmlFilePath = HttpContext.Current.Application["dataFilePath"].ToString();
            // initialize a FileStream object for reading
            StreamWriter sWriter = new StreamWriter(XmlFilePath, false);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Dispensary>), new XmlRootAttribute("Dispensaries"));

            using (sWriter)
            {
                serializer.Serialize(sWriter, dispensaries);
            }
        }
        public void Dispose()
        {
            //set resources to be cleaned up
        }
    }
}
