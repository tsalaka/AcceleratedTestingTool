using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Responses
{
    public class PersonLicenseType
    {
        [XmlIgnore]
        public bool ActiveFlag { get; set; }

        [XmlAttribute("ActiveFlag")]
        public string ActiveFlagString
        {
            get { return ActiveFlag.ToString(); }
            set { ActiveFlag = value.ToApiBoolFormat(); }
        }

        [XmlAttribute]
        public string LicenseTypeName { get; set; }
    }
}
