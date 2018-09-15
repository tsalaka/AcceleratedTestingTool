using System;

namespace AcceleratedTool.Jobs.JobStatusTracking
{
    /// <summary>
    /// Special Event Args used to pass the message data to the subscribers.
    /// </summary>
    public class JobStatusEventArgs : EventArgs
    {
        public JobStatusEventArgs(int step, string stepDescription, int percent, int stepsCount)
        {
            Step = step;
            StepDescription = stepDescription;
            StepsCount = stepsCount;
            Percent = percent;
        }

        public int Step { get; private set; }

        public int StepsCount { get; private set; }

        public int Percent { get; private set; }

        public string StepDescription { get; private set; }
    }
}
