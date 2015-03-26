using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;
namespace TSRD.Models
{
    public class TSRDModels
    {
    }
    public class Unit
    {
        
        [Key]
        public int ID { get; set; }

        [Display(Name="名稱")]
        public string Name { get; set; }

        [Display(Name = "公司名稱")]
        public string Company { get; set; }

        [Display(Name = "聯絡人")]
        public string Contact { get; set; }

        [Display(Name = "聯絡方式")]
        public string ContactInfo { get; set; }

        [Display(Name = "櫃號/員編")]
        public string IDString { get; set; }

        [Display(Name = "樓層")]
        public string Floor { get; set; }

        [Display(Name = "區域")]
        public string Area { get; set; }

        [Display(Name = "已停用")]
        public string Enabled { get; set; }

        [Display(Name = "描述")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "備註")]
        public string Comment { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "建立時間")]
        public DateTime CreatedTime { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "修改時間")]
        public DateTime? ModifiedTime { get; set; }

        //public int CreatorID { get; set; }
        //public int ModifierID { get; set; }

        public virtual ICollection<WorkForm> WorkForms { get; set; }

        public virtual ICollection<Property> Properties { get; set; }

        
        
    }

    public class WorkForm
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "聯絡人")]
        public string Contact { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "進件時間")]
        public DateTime AcceptedTime { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "結案時間")]
        public DateTime? ClosedTime { get; set; }

        [Display(Name = "已結案")]
        public bool Closed { get; set; }

        [Display(Name = "案件類別")]
        public string Type { get; set; }        

        //public int UnitID { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "描述")]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "備註")]        
        public string Comment { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "建立時間")]
        public DateTime CreatedTime { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "修改時間")]
        public DateTime? ModifiedTime { get; set; }

        //public int CreatorID { get; set; }
        //public int ModifierID { get; set; }        

        public virtual ICollection<WorkFormProperty> WorkFormProperties { get; set; }

        public virtual ICollection<WorkFormConsumable> WorkFormConsumables { get; set; }
    }
       

    public class WorkFormProperty
    {
        
        [Key]
        public int ID { get; set; }

        [Display(Name = "數量")]
        public int Amount { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "描述")]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "備註")]
        public string Comment { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "建立時間")]
        public DateTime CreatedTime { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "修改時間")]
        public DateTime? ModifiedTime { get; set; }

        //public int CreatorID { get; set; }
        //public int ModifierID { get; set; }
    }
    public class WorkFormConsumable
    {
        
        [Key]
        public int ID { get; set; }

        [Display(Name = "數量")]
        public int Amount { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "描述")]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "備註")]
        public string Comment { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "建立時間")]
        public DateTime CreatedTime { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "修改時間")]
        public DateTime? ModifiedTime { get; set; }

        //public int CreatorID { get; set; }
        //public int ModifierID { get; set; }
    }
    public class RMAForm
    {
        
        [Key]
        public int ID { get; set; }

        [Display(Name = "RMA狀態")]
        public string Status { get; set; }

        [Display(Name = "聯絡人")]
        public string Contact { get; set; }

        [Display(Name = "聯絡資訊")]
        public string ContactInfo { get; set; }

        [Display(Name = "送件時間")]
        public DateTime? RMATime { get; set; }

        [Display(Name = "返件時間")]
        public DateTime? ReturnTime { get; set; }

        [Display(Name = "已結案")]
        public bool Closed { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "描述")]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "備註")]
        public string Comment { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "建立時間")]
        public DateTime CreatedTime { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "修改時間")]
        public DateTime? ModifiedTime { get; set; }

        [Display(Name = "財產")]
        public int PropertyID { get; set; }

        [Display(Name = "財產")]
        public virtual Property Property { get; set; }

        //public int UnitID { get; set; }
        //public virtual Unit Unit { get; set; }        
        //public int CreatorID { get; set; }
        //public int ModifierID { get; set; }
    }
    public class PropertyType
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "財產類別")]
        public string Type { get; set; }

        [Display(Name = "財產名稱")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "描述")]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "備註")]
        public string Comment { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "建立時間")]
        public DateTime CreatedTime { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "修改時間")]
        public DateTime? ModifiedTime { get; set; }

        //public int CreatorID { get; set; }
        //public int ModifierID { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
    public class Property
    {
        
        [Key]
        public int ID { get; set; }

        //public int Amount { get; set; }
        //public int PropertyTypeID { get; set; }
        //public int UnitID { get; set; }
        [Display(Name = "規格描述")]
        [DataType(DataType.MultilineText)]
        public string Specification { get; set; }

        [Display(Name = "序號")]
        public string SN { get; set; }

        [Display(Name = "財產編號")]
        public string NO { get; set; }

        [Display(Name = "MACAddress")]
        public string MACAddress { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "描述")]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "備註")]
        public string Comment { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "建立時間")]
        public DateTime CreatedTime { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "修改時間")]
        public DateTime? ModifiedTime { get; set; }

        public int? PropertyTypeID { get; set; }

        public virtual PropertyType PropertyType { get; set; }

        public int UnitID { get; set; }

        public virtual Unit Unit { get; set; }

        public virtual ICollection<WorkFormProperty> WorkFormProperties { get; set; }

        public virtual ICollection<RMAForm> RMAForms { get; set; }

        //public int CreatorID { get; set; }
        //public int ModifierID { get; set; }
    }
    public class Consumable
    {
        
        [Key]
        public int ID { get; set; }

        [Display(Name = "名稱")]
        public string Name { get; set; }

        [Display(Name = "耗材編號")]
        public string NO { get; set; }

        [Display(Name = "數量")]
        public int Amount { get; set; }

        [Display(Name = "已啟用")]
        public bool Enabled { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "描述")]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "備註")]
        public string Comment { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "建立時間")]
        public DateTime CreatedTime { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "修改時間")]
        public DateTime? ModifiedTime { get; set; }

        //public int CreatorID { get; set; }
        //public int ModifierID { get; set; }                

        public virtual ICollection<WorkFormConsumable> WorkFormConsumables { get; set; }

        public virtual ICollection<RMAForm> RMAForms { get; set; }
        
    }
    public class ConsumableForm
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "數量")]        
        public int Amount { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "描述")]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "備註")]
        public string Comment { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "建立時間")]
        public DateTime CreatedTime { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "修改時間")]
        public DateTime? ModifiedTime { get; set; }

        [Display(Name = "耗材名稱")]
        public int ConsumableID { get; set; }

        [Display(Name = "耗材")]
        public virtual Consumable Consumable { get; set; }

        //public int CreatorID { get; set; }
        //public int ModifierID { get; set; }                
        //public virtual ICollection<WorkFormConsumable> WorkFormConsumables { get; set; }
        //public virtual ICollection<RMAForm> RMAForms { get; set; }

    }
    public class TEST
    {
        [Key]
        public int ID { get; set; }        
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public int CreatorID { get; set; }
        public int ModifierID { get; set; }
    }
    public class DefaultConnection : DbContext
    {
        public DbSet<Unit> Unit { get; set; }
        public DbSet<RMAForm> RMAForm { get; set; }
        public DbSet<WorkForm> WorkForm { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<PropertyType> PropertyType { get; set; }
        public DbSet<WorkFormConsumable> WorkFormConsumable { get; set; }
        public DbSet<Consumable> Consumable { get; set; }
        public DbSet<WorkFormProperty> WorkFormProperty { get; set; }


    }
}