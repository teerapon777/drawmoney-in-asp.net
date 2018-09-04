using System;
using System.Collections.Generic;

namespace PJ_Teeradat.Models
{
    public partial class TbPosition
    {
        public TbPosition()
        {
            TbUser = new HashSet<TbUser>();
        }

        public int PositionId { get; set; }
        public string PositionName { get; set; }

        public ICollection<TbUser> TbUser { get; set; }
    }
}
