using System;
using System.Collections.Generic;
using Kronos.AcceleratedTool.Models.Employees;
using Kronos.AcceleratedTool.Models.ExceptionRules;

namespace Kronos.AcceleratedTool.Jobs.Tests.ExceptionTests.Stubs
{
    public static class ExceptionRulePerPayRuleStub
    {
        public static List<ExceptionRulePerPayRule> GetData()
        {
            var exceptionPerPayRules = new List<ExceptionRulePerPayRule>();
            var exceptionPerPayRule1 = new ExceptionRulePerPayRule();
            exceptionPerPayRule1.PayRule = new PayRule
            {
                PersonNumber = "PersonNumber1",
                PayRuleName = "PayRuleName1",
                FullName = "FullName1"
            };
            exceptionPerPayRule1.ExceptionRule = new ExceptionRule
            {
                InLate = new TimeSpan(5, 8, 0),
                OutLate = new TimeSpan(4, 9, 0),
                InEarly = new TimeSpan(22, 0, 0),
                OutEarly = new TimeSpan(5, 13, 0),
                Unscheduled = true
            };
            exceptionPerPayRules.Add(exceptionPerPayRule1);

            var exceptionPerPayRule2 = new ExceptionRulePerPayRule();
            exceptionPerPayRule2.PayRule = new PayRule
            {
                PersonNumber = "PersonNumber2",
                PayRuleName = "PayRuleName2",
                FullName = "FullName2"
            };
            exceptionPerPayRule2.ExceptionRule = new ExceptionRule
            {
                InLate = new TimeSpan(8, 0, 0),
                OutLate = new TimeSpan(5, 1, 0),
                InEarly = new TimeSpan(13, 1, 45),
                OutEarly = new TimeSpan(21, 0, 29)
            };
            exceptionPerPayRules.Add(exceptionPerPayRule2);

            var exceptionPerPayRule3 = new ExceptionRulePerPayRule();
            exceptionPerPayRule3.PayRule = new PayRule
            {
                PersonNumber = "PersonNumber3"
            };
            exceptionPerPayRule3.ExceptionRule = new ExceptionRule
            {
                InLate = new TimeSpan(8, 0, 0), //8:0
                OutLate = new TimeSpan(5, 0, 0), //22:00
                InEarly = new TimeSpan(3, 20, 0), //4:41
                OutEarly = new TimeSpan(23, 1, 0) //17:00
            };
            exceptionPerPayRules.Add(exceptionPerPayRule3);

            return exceptionPerPayRules;
        }
    }
}
