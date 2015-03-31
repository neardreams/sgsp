using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TSRD.Enums;
using System.Web.Mvc;

namespace TSRD.Models
{
    public class WorkForm : TSRDModelBase
    {

        [Display(Name = "聯絡人")]
        [Required(ErrorMessage = "請輸入聯絡人")]
        public string Contact { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "進件時間")]
        [Required(ErrorMessage = "請輸入進件時間")]
        public DateTime AcceptedTime { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "結案時間")]
        public DateTime? ClosedTime { get; set; }

        [Display(Name = "已結案")]
        public bool Closed { get; set; }

        [Display(Name = "案件類別")]
        [Required(ErrorMessage = "請選擇案件類別")]
        public WorkFormType WorkFormType { get; set; }

        //public int CreatorID { get; set; }
        //public int ModifierID { get; set; }        

        [Display(Name = "單位")]
        [Required(ErrorMessage = "請選擇單位")]
        public int UnitID { get; set; }

        public virtual Unit Unit { get; set; }

        //public virtual ICollection<WorkFormProperty> WorkFormProperties { get; set; }
        public virtual ICollection<WorkFormProperty> WorkFormProperties { get; set; }

        //public virtual ICollection<WorkFormConsumable> WorkFormConsumables { get; set; }

    }
}