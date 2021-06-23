using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpheusCommon.Constant
{
    public class ZohoAPIURLConstant
    {
        public const string GetAccounts = "https://desk.zoho.com/api/v1/accounts";
        public const string GetContacts = "https://desk.zoho.com/api/v1/contacts";
        public const string GetContactsByAccountId = "https://desk.zoho.com/api/v1/accounts/[AccountId]/contacts";
        public const string AddContact = "https://desk.zoho.com/api/v1/contacts";
        public const string AddAccount = "https://desk.zoho.com/api/v1/accounts";
        public const string UpdateContact = "https://desk.zoho.com/api/v1/contacts/";
        public const string GetTicketById = "https://desk.zoho.com/api/v1/tickets/[TicketID]?include=contacts,products,assignee,departments,team";
        public const string GetContactById = "https://desk.zoho.com/api/v1/contacts/[ContactID]?include=owner";
        public const string GetTicketHistoryById = "https://desk.zoho.com/api/v1/tickets/[TicketId]/History?eventFilter=CommentHistory";

        public const string GetInvoiceContacts = "https://invoice.zoho.com/api/v3/contacts";
        public const string GetInvoiceItems = "https://invoice.zoho.com/api/v3/items";
        public const string PostInvoice = "https://invoice.zoho.com/api/v3/invoices?send=false&ignore_auto_number_generation=false";
        public const string GETInvoice = "https://invoice.zoho.com/api/v3/invoices/[InvoiceId]";

    }

    public class ZohoQueryStringFields
    {
        public const string GetAccoutListFields = "?fields=ownerId,cf_association_code&include=owner&limit=99&from=[FromCount]";
    }
}
