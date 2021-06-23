using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpheus.Common.Constant
{
    public class MethodTypeConstant
    {
        public const string GET = "GET";
        public const string POST = "POST";
        public const string PUT = "PUT";
        public const string DELETE = "DELETE";
        public const string PATCH = "PATCH";

        
    }

    public class ContentType
    {
        public const string json = "application/json";
        public const string xml = "text/xml;";
    }

    public class Accept
    {
        public const string xml = "text/xml";
    }

}
