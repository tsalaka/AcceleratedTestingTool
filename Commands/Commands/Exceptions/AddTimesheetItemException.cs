using System.Collections.Generic;

namespace AcceleratedTool.Commands.Exceptions
{
    public class AddTimesheetItemException : TimesheetItemBaseException
    {
        public AddTimesheetItemException(string message, List<string> errors, TimesheetItemType itemType)
           : base(message, errors, itemType)
        {
        }
    }
}
