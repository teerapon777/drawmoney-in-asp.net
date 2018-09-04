using PJ_Teeradat.InheritModels;
using System;
using System.Collections.Generic;

namespace PJ_Teeradat.Models
{
    public partial class TbUser : MyFile
    {
        public TbUser()
        {
            TbApprove = new HashSet<TbApprove>();
            TbWithdraw = new HashSet<TbWithdraw>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? PreNameId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int? GenderId { get; set; }
        public int? DepartmentId { get; set; }
        public int? PositionId { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
        public int? UserTypeId { get; set; }

        public TbDepartment Department { get; set; }
        public TbGender Gender { get; set; }
        public TbPosition Position { get; set; }
        public TbPrename PreName { get; set; }
        public TbUsertype UserType { get; set; }
        public ICollection<TbApprove> TbApprove { get; set; }
        public ICollection<TbWithdraw> TbWithdraw { get; set; }
    }
}
