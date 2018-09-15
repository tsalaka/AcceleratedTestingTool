using System.Collections.Generic;

namespace AcceleratedTool.Commands.Exceptions
{
    public class RemoveTimesheetItemException : TimesheetItemBaseException
    {
        public RemoveTimesheetItemException(string message, List<string> errors, TimesheetItemType itemType)
           : base(message, errors, itemType)
        {
        }
    }
}
