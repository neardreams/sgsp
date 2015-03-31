using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TSRD.Enums;
using System.Web.Mvc;

namespace TSRD.Models
{
    [AdditionalMetadata("DisplayName", "單位")]
    [DisplayColumn("ListedName")]
    public class Unit : TSRDModelBase
    {

        [Display(Name = "名稱")]
        [Required(ErrorMessage = "請輸入名稱")]
        public string Name { get; set; }

        [Display(Name = "公司名稱")]
        public string Company { get; set; }

        [Display(Name = "聯絡人")]
        public string Contact { get; set; }

        [Display(Name = "聯絡方式")]
        public string ContactInfo { get; set; }

        [Display(Name = "櫃號/員編")]
        [Required(ErrorMessage = "請輸入櫃號/員編")]
        public string IDString { get; set; }


        [Display(Name = "樓層")]
        [Required(ErrorMessage = "請輸入樓層")]
        public string Floor { get; set; }

        [Display(Name = "區域/部門")]
        [Required(ErrorMessage = "請輸入區域")]
        public string Area { get; set; }

        [Display(Name = "已啟用")]
        public bool Enabled { get; set; }


        //public int CreatorID { get; set; }
        //public int ModifierID { get; set; }

        public virtual ICollection<WorkForm> WorkForms { get; set; }

        public virtual ICollection<Property> Properties { get; set; }

        public string ListedName
        {
            get
            {
                return Floor + "\t" + Area + "\t" + IDString + "\t" + Name;
            }
        }


    }    
}