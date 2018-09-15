namespace AcceleratedTool.Commands.Mappers
{
    public class TestNameMapper
    {
        private const string ExceptionTestName = "Exception Test";
        private const string OverTimeTestName = "Overtime Test";
        private const string TimeCardTestName = "Timecard Test";
        private const string ShiftGuaranteeTestName = "Shift Guarantee Test";
        private const string PunchRoundTestName = "Punch Round Test";

        public string GetTestNameBySequence(int sequence)
        {
            switch (sequence)
            {
                case 1:
                    return ExceptionTestName;
                case 2:
                    return OverTimeTestName;
                case 3:
                    return TimeCardTestName;
                case 4:
                    return ShiftGuaranteeTestName;
                default:
                    return PunchRoundTestName;
            }
        }
    }
}
