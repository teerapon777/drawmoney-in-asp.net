using System;
using System.Collections.Generic;

namespace PJ_Teeradat.Models
{
    public partial class TbPrename
    {
        public TbPrename()
        {
            TbUser = new HashSet<TbUser>();
        }

        public int PrenameId { get; set; }
        public string PreName { get; set; }

        public ICollection<TbUser> TbUser { get; set; }
    }
}
