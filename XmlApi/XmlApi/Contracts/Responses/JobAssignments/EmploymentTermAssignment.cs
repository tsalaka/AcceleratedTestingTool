using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Responses.JobAssignments
{
    public class EmploymentTermAssignment
    {
        public string Name { get; set; }

        [XmlIgnore]
        public DateTime? StartDate { get; set; }

        [XmlAttribute("StartDate")]
        public string StartDateString
        {
            get { return StartDate.ToApiDateFormat(); }
            set { StartDate = value.ToApiNullableDateFormat(); }
        }

        [XmlIgnore]
        public DateTime? EndDate { get; set; }

        [XmlAttribute("EndDate")]
        public string EndDateString
        {
            get { return EndDate.ToApiDateFormat(); }
            set { EndDate = value.ToApiNullableDateFormat(); }
        }
    }
}
