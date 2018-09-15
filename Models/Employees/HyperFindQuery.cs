using System;

namespace AcceleratedTool.Models.Employees
{
    public class HyperFindQuery
    {
        public string HyperFindQueryName { get; set; }
        public string VisibilityCode { get; set; }
        public DateTime QueryDateStart { get; set; }
        public DateTime QueryDateEnd { get; set; }
    }
}
