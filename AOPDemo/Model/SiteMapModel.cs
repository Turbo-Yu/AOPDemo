using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AOPDemo.Model
{

    [XmlType(TypeName = "sitemap")]
    public class SiteMapModel
    {
        [XmlArray("dtd")]
        public List<SiteMapDTDItem> FatherItem { get; set; }
    }

    [XmlType(TypeName = "dtd")]
    public class SiteMapDTDItem
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("url")]
        public string Url { get; set; }

        [XmlAttribute("nobreadcrumb")]
        public bool NoBreadCrumb { get; set; }

        [XmlAttribute("nositeexplorer")]
        public bool NoSiteExplorer { get; set; }

        [XmlAttribute("notshowindiv")]
        public bool NotShowindiv { get; set; }

        [XmlAttribute("nochild")]
        public bool NoChild { get; set; }

        [XmlArray("dtd")]
        public List<SiteMapDTDItem> SonItem { get; set; }
    }
}
