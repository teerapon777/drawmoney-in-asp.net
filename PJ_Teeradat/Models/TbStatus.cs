using System;
using System.Collections.Generic;

namespace PJ_Teeradat.Models
{
    public partial class TbStatus
    {
        public TbStatus()
        {
            TbWithdraw = new HashSet<TbWithdraw>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public ICollection<TbWithdraw> TbWithdraw { get; set; }
    }
}
