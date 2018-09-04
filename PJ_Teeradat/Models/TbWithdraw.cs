using System;
using System.Collections.Generic;

namespace PJ_Teeradat.Models
{
    public partial class TbWithdraw
    {
        public TbWithdraw()
        {
            TbApprove = new HashSet<TbApprove>();
        }

        public int ProjectId { get; set; }
        public int? UserId { get; set; }
        public string ProjectName { get; set; }
        public DateTime? DateGo { get; set; }
        public int? Amount { get; set; }
        public string Location { get; set; }
        public int? ProvinceId { get; set; }
        public string Detail { get; set; }
        public DateTime? DateApplicant { get; set; }
        public int? StatusId { get; set; }

        public TbProvince Province { get; set; }
        public TbStatus Status { get; set; }
        public TbUser User { get; set; }
        public ICollection<TbApprove> TbApprove { get; set; }
    }
}
