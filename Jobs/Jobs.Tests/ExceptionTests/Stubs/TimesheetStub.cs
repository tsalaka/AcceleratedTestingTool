using System;
using System.Collections.Generic;
using Kronos.AcceleratedTool.Models.TestSharedModel;
using Kronos.AcceleratedTool.Models.TestSharedModel.Punches;

namespace Kronos.AcceleratedTool.Jobs.Tests.ExceptionTests.Stubs
{
    public static class TimesheetStub
    {
        public static List<Timesheet> GetData()
        {
            var timesheets = new List<Timesheet>();
            var timesheet1 = new Timesheet
            {
                PersonNumber = "PersonNumber1",
                TotalsUpToDateFlag = true,
                Exceptions = new List<PersonTimekeepingException>
                {
                    new PersonTimekeepingException
                    {
                        ExceptionTypeName = "ExceptionTypeName1_1",
                        Date = new DateTime(2017, 1, 1)
                    },
                    new PersonTimekeepingException
                    {
                        ExceptionTypeName = "ExceptionTypeName1_2",
                        Date = new DateTime(2017, 1, 1)
                    },
                    new PersonTimekeepingException
                    {
                        ExceptionTypeName = "ExceptionTypeName1_3",
                        Date = new DateTime(2017, 1, 3)
                    },
                    new PersonTimekeepingException
                    {
                        ExceptionTypeName = "ExceptionTypeName1_3",
                        Date = new DateTime(2017, 1, 4)
                    }
                },
                TotaledSpans = new List<TotaledSpan>()
                {
                    new TotaledSpan
                    {
                        PersonNumber = "PersonNumber1",
                        Date = new DateTime(2017, 1, 1),
                        InPunch =  new PersonPunch {Date = new DateTime(2017, 1, 1), Time = new TimeSpan(12, 31, 0)},
                        OutPunch = new PersonPunch {Date = new DateTime(2017, 1, 1), Time = new TimeSpan(13, 31, 0)}
                    },
                    new TotaledSpan
                    {
                        PersonNumber = "PersonNumber1",
                        Date = new DateTime(2017, 1, 5),
                        InPunch =  new PersonPunch {Date = new DateTime(2017, 1, 2), Time = new TimeSpan(12, 32, 0)},
                        OutPunch = new PersonPunch {Date = new DateTime(2017, 1, 4), Time = new TimeSpan(13, 34, 0)}
                    },

                    new TotaledSpan
                    {
                        PersonNumber = "PersonNumber1",
                        Date = new DateTime(2017, 1, 2),
                        InPunch =  new PersonPunch {Date = new DateTime(2017, 1, 3), Time = new TimeSpan(12, 33, 0)},
                        OutPunch = new PersonPunch {Date = new DateTime(2017, 1, 5), Time = new TimeSpan(12, 35, 0)}
                    },

                    new TotaledSpan
                    {
                        PersonNumber = "PersonNumber1",
                        Date = new DateTime(2017, 1, 3),
                        InPunch =  new PersonPunch {Date = new DateTime(2017, 1, 4), Time = new TimeSpan(12, 34, 0)}
                    }
                },
                DateTotals = new List<DateTotal>
                {
                    new DateTotal
                    {
                        Date = new DateTime(2017, 1, 1),
                        Totals = new List<Total> {new Total
                        {
                            AmountInTime = new TimeSpan(9, 0, 0),
                            LaborAccountDescription = "LaborAccountDescription",
                            PayCodeName = "PayCodeName"
                        } }
                    }
                }
            };

            timesheets.Add(timesheet1);

            var timesheet2 = new Timesheet
            {
                PersonNumber = "PersonNumber2",
                TotalsUpToDateFlag = true,
                Exceptions = new List<PersonTimekeepingException>
                {
                    new PersonTimekeepingException
                    {
                        ExceptionTypeName = "ExceptionTypeName2_1",
                        Date = new DateTime(2017, 1, 2)
                    }
                },
                TotaledSpans = new List<TotaledSpan>()
                {
                    new TotaledSpan
                    {
                        PersonNumber = "PersonNumber2",
                        Date = new DateTime(2017, 1, 1),
                        InPunch =  new PersonPunch {Date = new DateTime(2017, 1, 1), Time = new TimeSpan(12, 31, 0)},
                        OutPunch = new PersonPunch {Date = new DateTime(2017, 1, 2), Time = new TimeSpan(13, 34, 0)}
                    },
                    new TotaledSpan
                    {
                        PersonNumber = "PersonNumber2",
                        Date = new DateTime(2017, 1, 2),
                        InPunch =  new PersonPunch {Date = new DateTime(2017, 1, 3), Time = new TimeSpan(12, 33, 0)},
                        OutPunch = new PersonPunch {Date = new DateTime(2017, 1, 5), Time = new TimeSpan(12, 35, 0)}
                    },

                    new TotaledSpan
                    {
                        PersonNumber = "PersonNumber2",
                        Date = new DateTime(2017, 1, 3),
                        InPunch =  new PersonPunch {Date = new DateTime(2017, 1, 4), Time = new TimeSpan(12, 34, 0)}
                    }
                },
                DateTotals = new List<DateTotal>
                {
                    new DateTotal
                    {
                        Date = new DateTime(2017, 1, 1),
                        Totals = new List<Total> {new Total { AmountInTime = new TimeSpan(9, 0, 0)} }
                    }
                }
            };
            timesheets.Add(timesheet2);
            return timesheets;
        }
    }
}
