using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraspCorn.Common.Enum
{
    public enum LineItemEnum
    {

        [Description("Monthly Accounting Services fee per association (Accrual)")]
        Accrual = 1,
        [Description("Monthly Accounting Services fee per association (Cash)")]
        Cash = 1,
        [Description("Monthly Accounting Services fee per association (Modified Accrual)")]
        ModifiedAccrual = 3,
        [Description("Monthly Accounting Services fee per door")]
        FeePerDoor = 4,
        [Description("Manual Reconciliation of Non Partner Bank Accounts")]
        NonPartnerBankAccounts = 5

    }
}
