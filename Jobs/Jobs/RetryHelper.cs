using System;
using System.Threading;

namespace AcceleratedTool.Jobs
{
    public static class RetryHelper
    {
        private const int RetryCount = 3;
        private const int RetryIntervalMs = 200;

        public delegate T RetryDelegate<T>();
        public delegate void RetryDelegate();

        // Retry delegate with default retry settings.
        public static T Retry<T>(RetryDelegate<T> del)
        {
            return Retry<T>(del, RetryCount, RetryIntervalMs);
        }

        // Retry delegate with default retry settings.
        public static T Retry<T>(RetryDelegate<T> del, int numberOfRetries)
        {
            return Retry<T>(del, numberOfRetries, RetryIntervalMs);
        }

        // Retry delegate.
        public static T Retry<T>(RetryDelegate<T> del, int numberOfRetries, int msPause)
        {
            var counter = 0;
            RetryLabel:
            try
            {
                counter++;
                return del.Invoke();
            }
            catch (Exception ex)
            {
                if (counter >= numberOfRetries)
                {
                    throw ex;
                }

                if (msPause > 0)
                {
                    Thread.Sleep(msPause);
                }

                goto RetryLabel;
            }
        }

        // Retry delegate with default retry settings.
        public static bool Retry(RetryDelegate del)
        {
            return Retry(del, RetryCount, RetryIntervalMs);
        }

        public static bool Retry(RetryDelegate del, int numberOfRetries, int msPause)
        {
            int counter = 0;

            RetryLabel:
            try
            {
                counter++;
                del.Invoke();
                return true;
            }
            catch (Exception ex)
            {
                if (counter >= numberOfRetries)
                {
                    throw ex;
                }

                if (msPause > 0)
                {
                    Thread.Sleep(msPause);
                }

                goto RetryLabel;
            }
        }
    }
}
