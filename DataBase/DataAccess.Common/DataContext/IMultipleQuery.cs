using System;
using System.Collections.Generic;

namespace AcceleratedTool.DataAccess.Common.DataContext
{
    public interface IMultipleQuery : IDisposable
    {
        IEnumerable<T> Read<T>();
    }
}
