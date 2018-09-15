using System;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Responses
{
    public class Person
    {
        [XmlIgnore]
        public DateTime? BirthDate { get; set; }

        [XmlAttribute("BirthDate")]
        public string BirthDateSerializable
        {
            get { return BirthDate.ToApiDateFormat(); }
            set { BirthDate = value.ToApiNullableDateFormat(); }
        }

        [XmlAttribute]
        public string FirstName { get; set; }

        [XmlAttribute]
        public string FullName { get; set; }

        [XmlIgnore]
        public DateTime? HireDate { get; set; }

        [XmlAttribute("HireDate")]
        public string HireDateSerializable
        {
            get { return HireDate.ToApiDateFormat(); }
            set { HireDate = value.ToApiNullableDateFormat(); }
        }

        [XmlAttribute]
        public string LastName { get; set; }

        [XmlAttribute]
        public string PersonNumber { get; set; }

        [XmlAttribute]
        public string ShortName { get; set; }

        [XmlAttribute]
        public string AccrualProfileName { get; set; }

        [XmlIgnore]
        public long? FullTimePercentage { get; set; }

        [XmlAttribute("FullTimePercentage")]
        public long FullTimePercentageSerializable
        {
            get { return FullTimePercentage.Value; }
            set { FullTimePercentage = value; }
        }

        [XmlIgnore]
        public decimal? BaseWageHourly { get; set; }

        [XmlAttribute("BaseWageHourly")]
        public decimal BaseWageHourlySerializable
        {
            get { return BaseWageHourly.Value; }
            set { BaseWageHourly = value; }
        }

        public bool ShouldSerializeBaseWageHourly()
        {
            return BaseWageHourly.HasValue;
        }

        public bool ShouldSerializeFullTimePercentage()
        {
            return FullTimePercentage.HasValue;
        }
    }
}
