using MorpheusCommon.Helper; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpheusCommon.Constant
{
    class GenericObjectConstant
    {

    }
    public class HeaderConstant
    {
        /// <summary>
        /// For Zoho/Genesys API
        /// </summary>
        public const string OrganizationId = "orgId";
        public const string Authorization = "Authorization";
        public const string Content_Type = "Content-Type";
        /// <summary>
        /// For Zoho Invoice API
        /// </summary>
        public const string Zoho_OrganizationId = "X-com-zoho-invoice-organizationid";
        public const string Zoho_Authorization = "Authorization";

        /// <summary>
        /// For Senta API
        /// </summary>
        public const string Senta_Auth = "x-auth";



    }

   

}
