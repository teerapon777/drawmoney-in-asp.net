using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PJ_Teeradat.Models
{
    public class Validate_User
    {
        [Display(Name = "รหัสผู้ใช้")]
        public int UserId { get; set; }

        [Display(Name = "ชื่อผู้ใช้")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string Username { get; set; }

        [Display(Name = "รหัสผ่าน")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "คำนำหน้าชื่อ")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public int? PreNameId { get; set; }

        [Display(Name = "ชื่อ")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string Firstname { get; set; }

        [Display(Name = "นามสกุล")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string Lastname { get; set; }

        [Display(Name = "เพศ")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public int? GenderId { get; set; }

        [Display(Name = "หน่วยงาน/คณะ")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public int? DepartmentId { get; set; }

        [Display(Name = "ตำแหน่ง")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public int? PositionId { get; set; }

        [Display(Name = "เบอร์โทรศัทพ์")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string Phonenumber { get; set; }

        [Display(Name = "อีเมล์")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "รูปภาพ")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public byte[] Image { get; set; }

        [Display(Name = "ระดับผู้ใช้")]
        public int? UserTypeId { get; set; }
    }

    [ModelMetadataType(typeof(Validate_User))]
    public partial class TbUser { }

    public class Validate_Withdraw
    {
        [Display(Name = "รหัสโครงการ")]
        public int ProjectId { get; set; }

        [Display(Name = "ชื่อผู้ขอเบิก")]
        public int? UserId { get; set; }

        [Display(Name = "ชื่่อโครงการ")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string ProjectName { get; set; }

        [Display(Name = "วันที่่่ไป")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public DateTime? DateGo { get; set; }

        [Display(Name = "จำนวนเงิน")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public int? Amount { get; set; }

        [Display(Name = "สถานที่่")]
        public string Location { get; set; }

        [Display(Name = "จังหวัด")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public int? ProvinceId { get; set; }

        [Display(Name = "รายละเอียกโครงการ")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string Detail { get; set; }

        [Display(Name = "วันที่่่่ขอเบิก")]
        [DataType(DataType.Date)]
        public DateTime? DateApplicant { get; set; }

        [Display(Name = "สถานะ")]
        public int? StatusId { get; set; }
    }
    [ModelMetadataType(typeof(Validate_Withdraw))]
    public partial class TbWithdraw { }
    
    public class Validate_Approv
    {
        [Display(Name = "รัหัสผลอนุมัติ")]
        public int ApproveId { get; set; }
        [Display(Name = "ชื่อโครงการ")]
        public int? ProjectId { get; set; }

        [Display(Name = "ผู้อนุมัติ")]
        public int? UserId { get; set; }

        [Display(Name = "ผลอนุมัติ")]
        public int? ApprovalResultsId { get; set; }

        [Display(Name = "วันที่อนุมัติ")]
        public DateTime? DateApprove { get; set; }
    }
    [ModelMetadataType(typeof(Validate_Approv))]
    public partial class TbApprove { }
}

