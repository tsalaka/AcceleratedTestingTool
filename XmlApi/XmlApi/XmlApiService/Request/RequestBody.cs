using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Contracts;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.XmlApiService.Request
{
    public class RequestBody<TRequest>
        where TRequest : class
    {
        [XmlAttribute]
        public string Action { get; set; }

        [XmlIgnore]
        public TRequest Body { get; set; }

        [XmlAnyElement]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public List<XElement> XmlEntity
        {
            get
            {
                return Body == null ? null : XObjectExtensions.SerializeToXElements(Body);
            }

            // we have to create 'set' accessor to serialise Body property
            set
            {
                // class doesn't support 'set' property
               throw new NotSupportedException();
            }
        }
    }
}
