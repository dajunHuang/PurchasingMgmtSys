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
        public int SID { get; set; }

        [Required]
        public int MID { get; set; }

        [Required]
        public int UID { get; set; }

        [Required]
        public int BuyNumber { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public int State { get; set; } //（0申请未批准，1申请批准，2采购员确认采购）
    }
}
