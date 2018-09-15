using System;
using System.IO;

namespace AcceleratedTool.Jobs.JobStatusTracking
{
    public class JobStatusTracker
    {
        private readonly JobStatusNotifier _statusNotifier;
        private int _currentStep;
        private int _stepsCount;

        public JobStatusTracker(JobStatusNotifier statusNotifier)
        {
            _statusNotifier = statusNotifier;
        }

        public void ShowInitialStep(string message)
        {
            _statusNotifier.NotifyInitialStep(message);
        }

        public void Initialize(int stepsCount)
        {
            _stepsCount = stepsCount;
        }

        public void NotifyNewStep(string description, int rank = 1)
        {
            if (_stepsCount == 0)
                throw new InvalidDataException(string.Format("StepsCount is not specified. Be sure you call {0} method", nameof(Initialize)));
            _currentStep++;

            _statusNotifier.NotifyNewStep(_currentStep, description, _stepsCount, rank);
        }
    }
}
