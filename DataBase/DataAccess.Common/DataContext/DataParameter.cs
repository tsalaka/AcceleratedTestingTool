using System.Data;

namespace AcceleratedTool.DataAccess.Common.DataContext
{
    public class DataParameter
    {
        /// <summary>
        /// Representation of parameter, to be used when query parameters include output parameters        
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="dbType"></param>
        /// <param name="direction"></param>
        /// <param name="value"></param>
        /// <param name="size">required for String dbTypes</param>
        public DataParameter(string parameterName, DbType dbType, ParameterDirection direction, object value = null, int? size = null)
        {
            DbType = dbType;
            Direction = direction;
            ParameterName = parameterName;
            Value = value;
            Size = size;
        }

        public DbType DbType { get; private set; }

        public ParameterDirection Direction { get; private set; }

        public string ParameterName { get; private set; }

        public object Value { get; internal set; }

        public int? Size { get; private set; }
    }
}
