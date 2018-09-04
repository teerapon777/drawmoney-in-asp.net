using System;
using System.Collections.Generic;

namespace PJ_Teeradat.Models
{
    public partial class TbApprove
    {
        public int ApproveId { get; set; }
        public int? ProjectId { get; set; }
        public int? UserId { get; set; }
        public int? ApprovalResultsId { get; set; }
        public DateTime? DateApprove { get; set; }

        public TbApprovalresults ApprovalResults { get; set; }
        public TbWithdraw Project { get; set; }
        public TbUser User { get; set; }
    }
}
