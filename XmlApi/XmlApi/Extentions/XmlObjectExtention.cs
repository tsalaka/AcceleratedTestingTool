using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.Extentions
{
    public static class XObjectExtensions
    {
        public static dynamic Deserialize<T>(this XContainer element)
            where T : class
        {
            return element.Deserialize<T>(null);
        }

        public static dynamic Deserialize<T>(this XContainer element, XmlSerializer serializer)
            where T : class
        {
            var type = typeof(T);
            if (type.IsGenericType &&
                type.GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>)))
            {
                // get type of a list element
                var elementType = type.GetGenericArguments()[0];

                // add new item to new list
                using (var reader = element.CreateReader())
                {
                    serializer = serializer ?? new XmlSerializer(elementType);
                    var result = serializer.Deserialize(reader);
                    if (result.GetType().IsAssignableFrom(elementType))
                    {
                        return Cast(result, elementType);
                    }
                }

                return null;
            }

            // just create a new instance of T if T is not List
            using (var reader = element.CreateReader())
            {
                serializer = serializer ?? new XmlSerializer(typeof(T));
                object result = serializer.Deserialize(reader);
                if (result is T)
                    return (T)result;
            }

            return default(T);
        }

        public static List<XElement> SerializeToXElements<T>(this T obj)
        {
            return obj.SerializeToXElements(null, true);
        }

        public static List<XElement> SerializeToXElements<T>(this T obj, XmlSerializer serializer, bool omitStandardNamespaces)
        {
            var list = new List<XElement>();
            var type = obj.GetType();
            if (obj is IList &&
                type.IsGenericType &&
                type.GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>)))
            {
                List<object> genericList = (obj as IEnumerable<object>).ToList();
                var elementType = type.GetGenericArguments()[0];
                foreach (var item in genericList)
                {
                    var doc = new XDocument();
                    using (var writer = doc.CreateWriter())
                    {
                        XmlSerializerNamespaces ns = null;
                        if (omitStandardNamespaces)
                            (ns = new XmlSerializerNamespaces()).Add(string.Empty, string.Empty);

                        serializer = serializer ?? new XmlSerializer(elementType);
                        serializer.Serialize(writer, item, ns);
                    }

                    var element = doc.Root;
                    if (element != null)
                        element.Remove();
                    list.Add(element);
                }
            }
            else
            {
                list.Add(SerializeToXElement(obj, null, true));
            }

            return list;
        }

        private static XElement SerializeToXElement<T>(T obj, XmlSerializer serializer, bool omitStandardNamespaces)
        {
            var doc = new XDocument();
            using (var writer = doc.CreateWriter())
            {
                XmlSerializerNamespaces ns = null;
                if (omitStandardNamespaces)
                    (ns = new XmlSerializerNamespaces()).Add(string.Empty, string.Empty);

                serializer = serializer ?? new XmlSerializer(obj.GetType());
                serializer.Serialize(writer, obj, ns);
            }

            var element = doc.Root;
            if (element != null)
                element.Remove();
            return element;
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
