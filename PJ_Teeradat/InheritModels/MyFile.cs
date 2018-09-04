using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PJ_Teeradat.InheritModels
{
    public class MyFile
    {
        [NotMapped] //ไม่นำไป generate เราต้องทำเอง
        public IFormFile File { get; set; }
    }
}
