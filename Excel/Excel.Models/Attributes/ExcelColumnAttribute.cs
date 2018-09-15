using System;

namespace AcceleratedTool.Excel.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ExcelColumnAttribute : Attribute
    {
        public string Name { get; set; }

        public int Order { get; set; }

        public ExcelColumnFormat Format { get; set; }
    }
}
