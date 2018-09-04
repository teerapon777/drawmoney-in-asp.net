using System;
using System.Collections.Generic;

namespace PJ_Teeradat.Models
{
    public partial class TbProvince
    {
        public TbProvince()
        {
            TbWithdraw = new HashSet<TbWithdraw>();
        }

        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }

        public ICollection<TbWithdraw> TbWithdraw { get; set; }
    }
}
