using System;
using System.Linq;
using System.Reflection;

namespace AcceleratedTool.Commands.Tests.Mappers
{
    public static class CompareByPropertiesHelper
    {
        public static bool PropertyValuesAreEqual(object actual, object expected)
        {
            PropertyInfo[] actualProperties = actual.GetType().GetProperties();
            PropertyInfo[] expectedProperties = expected.GetType().GetProperties();

            foreach (PropertyInfo actualProperty in actualProperties)
            {
                var expectedProperty = expectedProperties.FirstOrDefault(x => x.Name == actualProperty.Name);
                if (expectedProperty == null)
                {
                    throw new Exception("Property of 'actual' object is not found in 'expected' object.");
                }

                object actualValue = actualProperty.GetValue(actual, null);
                object expectedValue = expectedProperty.GetValue(expected, null);

                if (!Equals(expectedValue, actualValue))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
