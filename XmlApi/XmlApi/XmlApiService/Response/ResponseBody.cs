using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.XmlApiService.Response
{
    public class ResponseBody<TResponse>
        where TResponse : class
    {
        private readonly dynamic _genericList;
        private readonly bool _isBodyList;
        private readonly Type _elementType;
        private TResponse _body;

        public ResponseBody()
        {
            var type = typeof(TResponse);
            if (type.IsGenericType &&
                type.GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>)))
            {
                _isBodyList = true;
                _elementType = type.GetGenericArguments()[0];
                var listType = typeof(List<>).MakeGenericType(_elementType);
                _genericList = Activator.CreateInstance(listType);
            }
        }

        [XmlAttribute]
        public string Action { get; set; }

        [XmlAttribute]
        public string Status { get; set; }

        [XmlIgnore]
        public TResponse Body
        {
            get { return _isBodyList ? _genericList : _body; }
        }

        [XmlAnyElement]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public XElement XmlEntity
        {
            // we have to create 'get' accessor to deserialise data to Body property
            get
            {
                // class doesn't suppport 'get' property
                throw new NotSupportedException();
            }
            set
            {
                var item = XObjectExtensions.Deserialize<TResponse>(value);
                if (_isBodyList)
                {
                    _genericList.Add(Cast(item, _elementType));
                }
                else
                {
                    _body = item as TResponse;
                }
            }
        }

        private static dynamic Cast(object obj, Type t)
        {
            if (obj is IConvertible)
                return Convert.ChangeType(obj, t) as dynamic;
            try
            {
                var param = Expression.Parameter(typeof(object));
                return Expression.Lambda(Expression.Convert(param, t), param)
                    .Compile().DynamicInvoke(obj) as dynamic;
            }
            catch (TargetInvocationException ex)
            {
                if (ex.InnerException != null) throw ex.InnerException;
                throw;
            }
        }
    }
}
