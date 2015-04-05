using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TSRD.Enums;
using System.Web.Mvc;

namespace TSRD.Models
{
    public class Consumable : TSRDModelBase
    {
        public string ListedName
        {
            get { return NO + " " + Name + "(" + Amount + ")"; }
        }

        [Display(Name = "名稱")]
        public string Name { get; set; }

        [Display(Name = "耗材編號")]
        public string NO { get; set; }

        [Display(Name = "數量")]
        public virtual int Amount {
            get{

                var cosumableFormsSum =0;
                var workformConsumables=0;
                var rmaforms = 0;
                if (ConsumableForms != null)
                    cosumableFormsSum = ConsumableForms.Sum(m => m.Amount);
                if (WorkFormConsumables != null)
                    workformConsumables = WorkFormConsumables.Sum(m => m.Amount);
                if (RMAForms!=null)
                    rmaforms = RMAForms.Where(m => m.Closed == false).Count();
                return cosumableFormsSum - workformConsumables - rmaforms;
            }
        }

        [Display(Name = "已啟用")]
        public bool Enabled { get; set; }


        //public int CreatorID { get; set; }
        //public int ModifierID { get; set; }                
        public virtual ICollection<ConsumableForm> ConsumableForms { get; set; }
        public virtual ICollection<WorkFormConsumable> WorkFormConsumables { get; set; }
        public virtual ICollection<RMAForm> RMAForms { get; set; }

        //public virtual ICollection<RMAForm> RMAForms { get; set; }



    }
}