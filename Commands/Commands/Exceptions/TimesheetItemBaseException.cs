using System;
using System.Collections.Generic;

namespace AcceleratedTool.Commands.Exceptions
{
    public class TimesheetItemBaseException : Exception
    {
        public TimesheetItemBaseException()
        {
        }

        public TimesheetItemBaseException(string message)
            : base(message)
        {
        }

        public TimesheetItemBaseException(string message, List<string> errors, TimesheetItemType itemType)
           : base(message)
        {
            Errors = errors;
            ItemType = itemType;
        }

        public List<string> Errors { get; private set; }

        public TimesheetItemType ItemType { get; private set; }
    }
}
