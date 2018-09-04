using System;
using System.Collections.Generic;

namespace PJ_Teeradat.Models
{
    public partial class TbDepartment
    {
        public TbDepartment()
        {
            TbUser = new HashSet<TbUser>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public ICollection<TbUser> TbUser { get; set; }
    }
}
