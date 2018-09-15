using System;

namespace AcceleratedTool.Jobs.JobStatusTracking
{
    public class JobStatusNotifier
    {
        public event EventHandler HandleMessage;

        public void NotifyNewStep(int currentStep, string description, int stepsCount, int rank = 1)
        {
            var percent = 100 * currentStep * rank / stepsCount;
            HandleMessage?.Invoke(this, new JobStatusEventArgs(currentStep, description, percent, stepsCount));
        }

        public void NotifyInitialStep(string description)
        {
            var percent = 1;
            HandleMessage?.Invoke(this, new JobStatusEventArgs(0, description, percent, 0));
        }
    }
}
