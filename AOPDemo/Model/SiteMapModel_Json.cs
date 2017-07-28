using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AOPDemo.Model
{

    [DataContract]
    public class SiteMapModel_Json
    {
        [DataMember(Name = "sitemap")]
        public SiteMapDTDItem_Json MasterNode { get; set; }
    }

    [DataContract]
    public class SiteMapDTDItem_Json
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "nobreadcrumb")]
        public bool NoBreadCrumb { get; set; }

        [DataMember(Name = "nositeexplorer")]
        public bool NoSiteExplorer { get; set; }

        [DataMember(Name = "notshowindiv")]
        public bool NotShowindiv { get; set; }

        [DataMember(Name = "nochild")]
        public bool NoChild { get; set; }

        [DataMember(Name = "dtd")]
        public List<SiteMapDTDItem_Json> SonItem { get; set; }
    }
}
