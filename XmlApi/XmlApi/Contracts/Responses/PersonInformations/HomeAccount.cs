using System;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Responses.PersonInformations
{
    public class HomeAccount
    {
        [XmlIgnore]
        public DateTime EffectiveDate { get; set; }

        [XmlAttribute("EffectiveDate")]
        public string EffectiveDateSerializable
        {
            get { return EffectiveDate.ToApiDateFormat(); }
            set { EffectiveDate = value.ToApiDateFormat(); }
        }

        [XmlIgnore]
        public DateTime? ExpirationDate { get; set; }

        [XmlAttribute("ExpirationDate")]
        public string ExpirationDateSerializable
        {
            get { return ExpirationDate.ToApiDateFormat(); }
            set { ExpirationDate = value.ToApiNullableDateFormat(); }
        }

        [XmlAttribute]
        public string LaborAccountName { get; set; }
    }
}
