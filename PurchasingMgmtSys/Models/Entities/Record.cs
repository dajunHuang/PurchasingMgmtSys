using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models.Entities
{
    public class Record
    {
        [Key]
        [Required]
        public int RID { get; set; }

        [Required]
        [Display(Name = "供方ID")]
        public Supplier_message SID { get; set; }

        [Required]
        [Display(Name = "货物ID")]
        public Material_message MID { get; set; }

        [Required]
        [Display(Name = "申请人ID")]
        public IdentityUser UID { get; set; }

        [Required]
        [Display(Name = "购买数量")]
        public int BuyNumber { get; set; }

        [Required]
        [Display(Name = "价格")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "申请时间")]
        public DateTime Time { get; set; }

        [Required]
        [Display(Name = "流程步骤")]
        public int State { get; set; } //（0申请未批准，1申请批准，2采购员确认采购）

        

    }
}
