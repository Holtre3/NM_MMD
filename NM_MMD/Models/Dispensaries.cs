using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace NM_MMD.Models
{

    [XmlRoot("Dispensaries")]
    public class Dispensaries
    {
        [XmlElement("Dispensary")]
        public List<Dispensary> dispensaries;
    }
}