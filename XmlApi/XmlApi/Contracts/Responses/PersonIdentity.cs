using System;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Responses
{
    public class PersonIdentity
    {
        [XmlAttribute]
        public string AOID { get; set; }

        [XmlAttribute]
        public string BadgeNumber { get; set; }

        [XmlIgnore]
        public long? EmployeeKey { get; set; }

        [XmlAttribute("EmployeeKey")]
        public long EmployeeKeySerializable
        {
            get { return EmployeeKey.Value; }
            set { EmployeeKey = value; }
        }

        [XmlIgnore]
        public long? PersonKey { get; set; }

        [XmlAttribute("PersonKey")]
        public long PersonKeySerializable
        {
            get { return PersonKey.Value; }
            set { PersonKey = value; }
        }

        [XmlAttribute]
        public string PersonNumber { get; set; }

        [XmlIgnore]
        public long? UserKey { get; set; }

        [XmlAttribute("UserKey")]
        public long UserKeySerializable
        {
            get { return UserKey.Value; }
            set { UserKey = value; }
        }

        [XmlAttribute]
        public string COID { get; set; }

        [XmlIgnore]
        public DateTime? EffectiveDate { get; set; }

        [XmlAttribute("EffectiveDate")]
        public string EffectiveDateSerializable
        {
            get { return EffectiveDate.ToApiDateFormat(); }
            set { EffectiveDate = value.ToApiNullableDateFormat(); }
        }

        public bool ShouldSerializePersonKeySerializable()
        {
            return PersonKey.HasValue;
        }

        public bool ShouldSerializeUserKeySerializable()
        {
            return UserKey.HasValue;
        }

        public bool ShouldSerializeEmployeeKeySerializable()
        {
            return EmployeeKey.HasValue;
        }
    }
}
