namespace TSRD.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TSRD.Models;
    using TSRD.Enums;
    
    internal sealed class Configuration : DbMigrationsConfiguration<TSRD.Models.DefaultConnection>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(TSRD.Models.DefaultConnection context)
        {
            var rmaforms = context.RMAForm.Where(a => a.ID == a.ID).ToList();
            foreach (var rmaform in rmaforms)
                context.RMAForm.Remove(rmaform);
            context.SaveChanges();

            var workforms = context.WorkForm.Where(a => a.ID == a.ID).ToList();
            foreach (var workform in workforms)
                context.WorkForm.Remove(workform);
            context.SaveChanges();

            var properties = context.Property.Where(a => a.ID == a.ID).ToList();
            foreach (var property in properties)
                context.Property.Remove(property);
            context.SaveChanges();

            var units = context.Unit.Where(a => a.ID == a.ID).ToList();
            foreach (var unit in units)
                context.Unit.Remove(unit);
            context.SaveChanges();

            var propertytypes = context.PropertyType.Where(a => a.ID == a.ID).ToList();
            foreach (var propertytype in propertytypes)
                context.PropertyType.Remove(propertytype);
            context.SaveChanges();

            var consumables = context.Consumable.Where(a => a.ID == a.ID).ToList();
            foreach (var consumable in consumables)
                context.Consumable.Remove(consumable);
            context.SaveChanges();

            var tests = context.Test.Where(a => a.ID == a.ID).ToList();
            foreach (var test in tests)
                context.Test.Remove(test);
            context.SaveChanges();

            context.Unit.AddOrUpdate(x => x.ID,
                new Unit { Name = "Louis Vuitton", IDString = "B1A01", Floor = "5F", Area = "A", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "Porsche", IDString = "B1A02", Floor = "4F", Area = "X", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "Toyota", IDString = "B3A02", Floor = "2F", Area = "Z", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "海港城", IDString = "B3A22", Floor = "3F", Area = "Z", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "饗食天堂", IDString = "B2A22", Floor = "3F", Area = "A", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "Gucci", IDString = "3FA01", Floor = "3F", Area = "C", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "威秀影城", IDString = "5FB01", Floor = "5F", Area = "D", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "陳大一", IDString = "E0000001", Floor = "5F", Area = "行銷部", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "陳大二", IDString = "E0000002", Floor = "3F", Area = "營運部", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "陳大三", IDString = "E0000003", Floor = "4F", Area = "資訊部", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "五木拉麵", IDString = "5FB01", Floor = "5F", Area = "B", CreatedTime = DateTime.Now,Enabled=true },
                new Unit { Name = "Honda", IDString = "B1A01", Floor = "5F", Area = "A", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "Ferrari", IDString = "B1A02", Floor = "4F", Area = "X", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "茶魔", IDString = "B3A02", Floor = "2F", Area = "Z", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "7-11", IDString = "B3A22", Floor = "3F", Area = "Z", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "五十嵐", IDString = "B2A22", Floor = "3F", Area = "A", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "夢時代", IDString = "3FA01", Floor = "3F", Area = "C", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "新光三越", IDString = "5FB01", Floor = "5F", Area = "D", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "小米", IDString = "E0000001", Floor = "5F", Area = "行銷部", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "Apple", IDString = "E0000002", Floor = "3F", Area = "營運部", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "Samsung", IDString = "E0000003", Floor = "4F", Area = "資訊部", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "HTC", IDString = "5FB01", Floor = "5F", Area = "B", CreatedTime = DateTime.Now,Enabled=true },
                new Unit { Name = "Uniqlo", IDString = "5FB01", Floor = "5F", Area = "B", CreatedTime = DateTime.Now,Enabled=true },
                new Unit { Name = "Levi's", IDString = "B1A01", Floor = "5F", Area = "A", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "喫茶小舖", IDString = "B1A02", Floor = "4F", Area = "X", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "華碩", IDString = "B3A02", Floor = "2F", Area = "Z", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "微星", IDString = "B3A22", Floor = "3F", Area = "Z", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "聯想", IDString = "B2A22", Floor = "3F", Area = "A", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "宏碁", IDString = "3FA01", Floor = "3F", Area = "C", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "Focus", IDString = "5FB01", Floor = "5F", Area = "D", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "南紡", IDString = "E0000001", Floor = "5F", Area = "行銷部", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "統一", IDString = "E0000002", Floor = "3F", Area = "營運部", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "全家便利商店", IDString = "E0000003", Floor = "4F", Area = "資訊部", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "OPPO", IDString = "5FB01", Floor = "5F", Area = "B", CreatedTime = DateTime.Now,Enabled=true },
                new Unit { Name = "捷元", IDString = "B1A01", Floor = "5F", Area = "A", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "聯強", IDString = "B1A02", Floor = "4F", Area = "X", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "王品牛排", IDString = "B3A02", Floor = "2F", Area = "Z", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "西提", IDString = "B3A22", Floor = "3F", Area = "Z", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "陶板屋", IDString = "B2A22", Floor = "3F", Area = "A", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "3M", IDString = "3FA01", Floor = "3F", Area = "C", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "Duskin", IDString = "5FB01", Floor = "5F", Area = "D", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "Bosch", IDString = "E0000001", Floor = "5F", Area = "行銷部", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "Panasonic", IDString = "E0000002", Floor = "3F", Area = "營運部", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "Sony", IDString = "E0000003", Floor = "4F", Area = "資訊部", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "NEC", IDString = "5FB01", Floor = "5F", Area = "B", CreatedTime = DateTime.Now,Enabled=true },
                new Unit { Name = "HP", IDString = "B1A01", Floor = "5F", Area = "A", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "DELL", IDString = "B1A02", Floor = "4F", Area = "X", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "Compaq", IDString = "B3A02", Floor = "2F", Area = "Z", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "金士頓", IDString = "B3A22", Floor = "3F", Area = "Z", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "威剛", IDString = "B2A22", Floor = "3F", Area = "A", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "美光", IDString = "3FA01", Floor = "3F", Area = "C", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "Plextor", IDString = "5FB01", Floor = "5F", Area = "D", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "Line", IDString = "E0000001", Floor = "5F", Area = "行銷部", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "Sanyo", IDString = "E0000002", Floor = "3F", Area = "營運部", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "SHARP", IDString = "E0000003", Floor = "4F", Area = "資訊部", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "Stay Real", IDString = "5FB01", Floor = "5F", Area = "B", CreatedTime = DateTime.Now,Enabled=true },
                new Unit { Name = "ANESSA", IDString = "5FB01", Floor = "5F", Area = "B", CreatedTime = DateTime.Now,Enabled=true },
                new Unit { Name = "金石堂", IDString = "B1A01", Floor = "5F", Area = "A", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "誠品", IDString = "B1A02", Floor = "4F", Area = "X", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "瀚林", IDString = "B3A02", Floor = "2F", Area = "Z", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "春水堂", IDString = "B3A22", Floor = "3F", Area = "Z", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "立頓", IDString = "B2A22", Floor = "3F", Area = "A", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "富士", IDString = "3FA01", Floor = "3F", Area = "C", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "大同", IDString = "5FB01", Floor = "5F", Area = "D", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "中衛醫療", IDString = "E0000001", Floor = "5F", Area = "行銷部", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "Clarks", IDString = "E0000002", Floor = "3F", Area = "營運部", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "Trippen", IDString = "E0000003", Floor = "4F", Area = "資訊部", CreatedTime = DateTime.Now, Enabled = true },
                new Unit { Name = "Timberland", IDString = "5FB01", Floor = "5F", Area = "B", CreatedTime = DateTime.Now,Enabled=true }
                );
            context.SaveChanges();
            context.PropertyType.AddOrUpdate(x => x.ID,
                new PropertyType {Type = "筆記型電腦", Name = "Lenovo X230", Description = "I5/8G/500G Windows 8", CreatedTime = DateTime.Now},
                // Properties = {
                //    new Property{Specification="第一台",MACAddress="AA:BB:CC:DD:EE:FF",SN="ABCDE00001",CreatedTime=DateTime.Now}} 
                //},
                new PropertyType {Type = "筆記型電腦", Name = "Asus X550VC", Description = "I5/4G/500G Windows 8", CreatedTime = DateTime.Now },
                new PropertyType {Type = "筆記型電腦", Name = "Asus T100", Description = "Atom/2G/32G Windows 8", CreatedTime = DateTime.Now },
                new PropertyType {Type = "桌上型電腦", Name = "2014組裝I5", Description = "I5/4G/500G Windows 8", CreatedTime = DateTime.Now },
                new PropertyType {Type = "桌上型電腦", Name = "2015組裝I3", Description = "I5/4G/500G Windows 8", CreatedTime = DateTime.Now }
                );
            context.SaveChanges();
            context.Property.AddOrUpdate(x => x.ID,
                new Property { UnitID = context.Unit.Single(u => u.Name == "Louis Vuitton").ID, PropertyTypeID = context.PropertyType.Single(p=>p.Name=="Lenovo X230").ID, SN = "ABCD00001", CreatedTime = DateTime.Now, MACAddress = "AA:BB:CC:DD:EE:FF",NO="NB001" },
                new Property { UnitID = context.Unit.Single(u => u.Name == "陳大三").ID, PropertyTypeID = context.PropertyType.Single(p => p.Name == "Lenovo X230").ID, SN = "ABCD00002", CreatedTime = DateTime.Now, MACAddress = "AX:BB:CC:DD:EE:FF", NO = "NB002" },
                new Property { UnitID = context.Unit.Single(u => u.Name == "陳大三").ID, PropertyTypeID = context.PropertyType.Single(p => p.Name == "Asus T100").ID, SN = "ABCD00002", CreatedTime = DateTime.Now, MACAddress = "AA:BB:CC:DD:EE:FG", NO = "NB003" },
                new Property { UnitID = context.Unit.Single(u => u.Name == "五木拉麵").ID, PropertyTypeID = context.PropertyType.Single(p => p.Name == "2015組裝I3").ID, SN = "AABBCC01", CreatedTime = DateTime.Now, MACAddress = "AA:BB:CC:DD:EE:XY", NO = "PC001" }
                );
            context.SaveChanges();
            context.Consumable.AddOrUpdate(x => x.ID,
                new Consumable { Amount = 0, CreatedTime = DateTime.Now, Enabled = true, Name = "HUB (4PORT)", Description = "D-Link", NO = "HUB01" },
                new Consumable { Amount = 0, CreatedTime = DateTime.Now, Enabled = true, Name = "排插 (白)", Description = "雙面十孔", NO = "AC01" },
                new Consumable { Amount = 0, CreatedTime = DateTime.Now, Enabled = true, Name = "網路線 (1米)", Description = "CAT5E", NO = "AC02" },
                new Consumable { Amount = 0, CreatedTime = DateTime.Now, Enabled = false, Name = "網路線 (1米)", Description = "CAT5", NO = "AC02" },
                new Consumable { Amount = 0, CreatedTime = DateTime.Now, Enabled = true, Name = "網路線 (1箱)", Description = "CAT5E", NO = "AC03" },
                new Consumable { Amount = 0, CreatedTime = DateTime.Now, Enabled = true, Name = "水晶頭", Description = "CAT5E", NO = "NA001" }
                );
            context.WorkForm.AddOrUpdate(x=>x.ID,
                new WorkForm { AcceptedTime = DateTime.Now, Closed = false, WorkFormType = WorkFormType.安裝工單, Contact = "陳冠希", Description = "安裝POS機一台", CreatedTime = DateTime.Now, UnitID = context.Unit.Single(u => u.Name == "陳大一").ID },
                new WorkForm { AcceptedTime = DateTime.Now, Closed = false, WorkFormType = WorkFormType.維修工單, Contact = "陳五木", Description = "POS機不開機", CreatedTime = DateTime.Now, UnitID = context.Unit.Single(u => u.Name == "五木拉麵").ID },
                new WorkForm { AcceptedTime = DateTime.Now, Closed = false, WorkFormType = WorkFormType.專案工單, Contact = "王古持", Description = "整線", CreatedTime = DateTime.Now, UnitID = context.Unit.Single(u => u.Name == "Gucci").ID }
                );
            context.SaveChanges();
            context.RMAForm.AddOrUpdate(x=>x.ID,
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機123", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機124", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機125", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機126", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機127", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機128", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機129", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機130", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機131", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機132", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機133", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機134", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機135", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機136", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機137", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機123", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機124", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機125", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機126", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機127", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機128", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機129", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機130", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機131", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機132", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機133", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機134", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機135", Status = RMAFormStatus.已取件, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機136", Status = RMAFormStatus.已送修, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機123", Status = RMAFormStatus.已送修, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機124", Status = RMAFormStatus.已送修, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機125", Status = RMAFormStatus.已送修, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機126", Status = RMAFormStatus.已送修, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機127", Status = RMAFormStatus.已送修, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機128", Status = RMAFormStatus.已送修, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機129", Status = RMAFormStatus.已送修, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機130", Status = RMAFormStatus.已送修, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機131", Status = RMAFormStatus.已送修, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機132", Status = RMAFormStatus.已送修, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機133", Status = RMAFormStatus.已送修, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機134", Status = RMAFormStatus.已送修, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機135", Status = RMAFormStatus.已送修, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
                new RMAForm { CreatedTime = DateTime.Now, Contact = "聯強國際", ContactInfo = "06-2003000", Description = "不開機136", Status = RMAFormStatus.已送修, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now }
                );
            context.SaveChanges();

            //context.Property.AddOrUpdate(x=>x.ID,
            //    new Property { }
            //    );
            //var units = new List<Unit>
            //{
            //    new Unit {Name="Louis Vuitton",IDString="B1A01",Floor="5F",Area="A",CreatedTime=DateTime.Now},
            //    new Unit {Name="Gucci",IDString="3FA01",Floor="3F",Area="C",CreatedTime=DateTime.Now},
            //    new Unit {Name="威秀影城",IDString="5FB01",Floor="5F",Area="D",CreatedTime=DateTime.Now},
            //    new Unit {Name="陳大一",IDString="E0000001",Floor="5F",Area="行銷部",CreatedTime=DateTime.Now},
            //    new Unit {Name="陳大二",IDString="E0000002",Floor="3F",Area="營運部",CreatedTime=DateTime.Now},
            //    new Unit {Name="陳大三",IDString="E0000003",Floor="4F",Area="資訊部",CreatedTime=DateTime.Now},
            //    new Unit {Name="五木拉麵",IDString="5FB01",Floor="5F",Area="B",CreatedTime=DateTime.Now}

            //};
            //units.ForEach(s => context.Unit.AddOrUpdate(p => p.IDString, s));
            //var propertytypes = new List<PropertyType>
            //{
            //    new PropertyType {ID=1,Type="筆記型電腦",Name="Lenovo X230",Description="I5/8G/500G Windows 8",CreatedTime=DateTime.Now},
            //    new PropertyType {ID=2,Type="筆記型電腦",Name="Asus X550VC",Description="I5/4G/500G Windows 8",CreatedTime=DateTime.Now},
            //    new PropertyType {ID=3,Type="筆記型電腦",Name="Asus T100",Description="Atom/2G/32G Windows 8",CreatedTime=DateTime.Now},
            //    new PropertyType {ID=4,Type="桌上型電腦",Name="2014組裝I5",Description="I5/4G/500G Windows 8",CreatedTime=DateTime.Now},
            //    new PropertyType {ID=5,Type="桌上型電腦",Name="2015組裝I3",Description="I5/4G/500G Windows 8",CreatedTime=DateTime.Now},
            //    new PropertyType {ID=6,Type="POS機",Name="宏誌POS機",Description="ATOM/2G/8G Windows XP"}
            //};
            //propertytypes.ForEach(s => context.PropertyType.AddOrUpdate(p => p.ID, s));

            //context.SaveChanges();
            //var units = new List<TSRD_Unit>
            //{
            //    new TSRD_Unit {Floor="B1",Area="A",IDString="B1A01",Name="小騎士",CreatedTime = DateTime.Now},
            //    new TSRD_Unit {Floor="1F",Area="A",IDString="F1A01+F2A01+F2A02",Name="Zara",CreatedTime = DateTime.Now},
            //    new TSRD_Unit {Floor="1F",Area="D",IDString="F1D01",Name="Massimo Dutti",CreatedTime = DateTime.Now},
            //    new TSRD_Unit {Floor="2F",Area="時尚名品Team",IDString="2014000050",Name="胡若珊",CreatedTime = DateTime.Now},
            //    new TSRD_Unit {Floor="3F",Area="E",IDString="F3E01",Name="La New",CreatedTime = DateTime.Now},
              
            //};
            //units.ForEach(s => context.TSRD_Unit.AddOrUpdate(p => p.IDString, s));
            //context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
