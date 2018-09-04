using System;
using System.Collections.Generic;

namespace PJ_Teeradat.Models
{
    public partial class TbUsertype
    {
        public TbUsertype()
        {
            TbUser = new HashSet<TbUser>();
        }

        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }

        public ICollection<TbUser> TbUser { get; set; }
    }
}
