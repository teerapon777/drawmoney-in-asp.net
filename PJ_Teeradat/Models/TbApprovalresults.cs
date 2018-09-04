using System;
using System.Collections.Generic;

namespace PJ_Teeradat.Models
{
    public partial class TbApprovalresults
    {
        public TbApprovalresults()
        {
            TbApprove = new HashSet<TbApprove>();
        }

        public int ApprovalResultsId { get; set; }
        public string ApprovalResultsName { get; set; }

        public ICollection<TbApprove> TbApprove { get; set; }
    }
}
