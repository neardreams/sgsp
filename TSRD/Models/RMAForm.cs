using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TSRD.Enums;
using System.Web.Mvc;

namespace TSRD.Models
{
    public class RMAForm : TSRDModelBase
    {
        public string ListedName
        {
            get { return Property.PropertyType.Name + " (" + Property.SN + ")"; }
        }

        [Display(Name = "RMA狀態")]
        [Required(ErrorMessage = "請選擇RMA狀態")]
        public RMAFormStatus Status { get; set; }

        [Display(Name = "聯絡人")]
        public string Contact { get; set; }

        [Display(Name = "聯絡資訊")]
        public string ContactInfo { get; set; }

        [Display(Name = "送件時間")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? RMATime { get; set; }

        [Display(Name = "返件時間")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? ReturnTime { get; set; }

        [Display(Name = "已結案")]
        [Required(ErrorMessage = "請選擇結案狀態")]
        public bool Closed { get; set; }

        [Display(Name = "財產")]
        public int? PropertyID { get; set; }

        [Display(Name = "財產")]
        public Property Property { get; set; }

        [Display(Name = "耗材")]        
        public int? ConsumableID { get; set; }

        [Display(Name = "耗材")]
        public virtual Consumable Consumable { get; set; }

        //public int UnitID { get; set; }
        //public virtual Unit Unit { get; set; }        
        //public int CreatorID { get; set; }
        //public int ModifierID { get; set; }
    }
}