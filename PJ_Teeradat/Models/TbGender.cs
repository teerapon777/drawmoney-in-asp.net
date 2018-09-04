using System;
using System.Collections.Generic;

namespace PJ_Teeradat.Models
{
    public partial class TbGender
    {
        public TbGender()
        {
            TbUser = new HashSet<TbUser>();
        }

        public int GenderId { get; set; }
        public string GenderName { get; set; }

        public ICollection<TbUser> TbUser { get; set; }
    }
}
