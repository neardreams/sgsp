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
            //var rmaforms = context.RMAForm.Where(a => a.ID == a.ID).ToList();
            //foreach (var rmaform in rmaforms)
            //    context.RMAForm.Remove(rmaform);
            //context.SaveChanges();

            //var workforms = context.WorkForm.Where(a => a.ID == a.ID).ToList();
            //foreach (var workform in workforms)
            //    context.WorkForm.Remove(workform);
            //context.SaveChanges();

            //var properties = context.Property.Where(a => a.ID == a.ID).ToList();
            //foreach (var property in properties)
            //    context.Property.Remove(property);
            //context.SaveChanges();

            //var units = context.Unit.Where(a => a.ID == a.ID).ToList();
            //foreach (var unit in units)
            //    context.Unit.Remove(unit);
            //context.SaveChanges();

            //var propertytypes = context.PropertyType.Where(a => a.ID == a.ID).ToList();
            //foreach (var propertytype in propertytypes)
            //    context.PropertyType.Remove(propertytype);
            //context.SaveChanges();

            //var consumables = context.Consumable.Where(a => a.ID == a.ID).ToList();
            //foreach (var consumable in consumables)
            //    context.Consumable.Remove(consumable);
            //context.SaveChanges();


            //context.Unit.AddOrUpdate(x => x.ID,
            //    new Unit { Name = "Louis Vuitton", IDString = "B1A01", Floor = "5F", Area = "A", CreatedTime = DateTime.Now, Enabled = true },
            //    new Unit { Name = "Porsche", IDString = "B1A02", Floor = "4F", Area = "X", CreatedTime = DateTime.Now, Enabled = true },
            //    new Unit { Name = "Toyota", IDString = "B3A02", Floor = "2F", Area = "Z", CreatedTime = DateTime.Now, Enabled = true },
            //    new Unit { Name = "���䫰", IDString = "B3A22", Floor = "3F", Area = "Z", CreatedTime = DateTime.Now, Enabled = true },
            //    new Unit { Name = "�W���Ѱ�", IDString = "B2A22", Floor = "3F", Area = "A", CreatedTime = DateTime.Now, Enabled = true },
            //    new Unit { Name = "Gucci", IDString = "3FA01", Floor = "3F", Area = "C", CreatedTime = DateTime.Now, Enabled = true },
            //    new Unit { Name = "�¨q�v��", IDString = "5FB01", Floor = "5F", Area = "D", CreatedTime = DateTime.Now, Enabled = true },
            //    new Unit { Name = "���j�@", IDString = "E0000001", Floor = "5F", Area = "��P��", CreatedTime = DateTime.Now, Enabled = true },
            //    new Unit { Name = "���j�G", IDString = "E0000002", Floor = "3F", Area = "��B��", CreatedTime = DateTime.Now, Enabled = true },
            //    new Unit { Name = "���j�T", IDString = "E0000003", Floor = "4F", Area = "��T��", CreatedTime = DateTime.Now, Enabled = true }
            //    );
            //context.SaveChanges();
            //context.PropertyType.AddOrUpdate(x => x.ID,
            //    new PropertyType { Name = "���O���q��", Description = "���O���q��", CreatedTime = DateTime.Now },
            //    // Properties = {
            //    //    new Property{Specification="�Ĥ@�x",MACAddress="AA:BB:CC:DD:EE:FF",SN="ABCDE00001",CreatedTime=DateTime.Now}} 
            //    //},
            //    new PropertyType { Name = "��W���q��", Description = "��W���q��", CreatedTime = DateTime.Now },
            //    new PropertyType { Name = "POS��", Description = "POS��", CreatedTime = DateTime.Now }
            //    );
            //context.SaveChanges();
            //context.Property.AddOrUpdate(x => x.ID,
            //    new Property { Name = "Lenovo X230", UnitID = context.Unit.Single(u => u.Name == "Louis Vuitton").ID, PropertyTypeID = context.PropertyType.Single(p => p.Name == "���O���q��").ID, SN = "ABCD00001", CreatedTime = DateTime.Now, MACAddress = "AA:BB:CC:DD:EE:FF", NO = "NB001" },
            //    new Property { Name = "Lenovo X230", UnitID = context.Unit.Single(u => u.Name == "���j�T").ID, PropertyTypeID = context.PropertyType.Single(p => p.Name == "���O���q��").ID, SN = "ABCD00002", CreatedTime = DateTime.Now, MACAddress = "AX:BB:CC:DD:EE:FF", NO = "NB002" },
            //    new Property { Name = "Lenovo X230", UnitID = context.Unit.Single(u => u.Name == "���j�T").ID, PropertyTypeID = context.PropertyType.Single(p => p.Name == "���O���q��").ID, SN = "ABCD00002", CreatedTime = DateTime.Now, MACAddress = "AA:BB:CC:DD:EE:FG", NO = "NB003" },
            //    new Property { Name = "Lenovo X230", UnitID = context.Unit.Single(u => u.Name == "�¨q�v��").ID, PropertyTypeID = context.PropertyType.Single(p => p.Name == "���O���q��").ID, SN = "AABBCC01", CreatedTime = DateTime.Now, MACAddress = "AA:BB:CC:DD:EE:XY", NO = "NB004" }
            //    );
            //context.SaveChanges();
            //context.Consumable.AddOrUpdate(x => x.ID,
            //    new Consumable { CreatedTime = DateTime.Now, Enabled = true, Name = "HUB (4PORT)", Description = "D-Link", NO = "HUB01" },
            //    new Consumable { CreatedTime = DateTime.Now, Enabled = true, Name = "�ƴ� (��)", Description = "�����Q��", NO = "AC01" },
            //    new Consumable { CreatedTime = DateTime.Now, Enabled = true, Name = "�����u (1��)", Description = "CAT5E", NO = "AC02" },
            //    new Consumable { CreatedTime = DateTime.Now, Enabled = false, Name = "�����u (1��)", Description = "CAT5", NO = "AC02" },
            //    new Consumable { CreatedTime = DateTime.Now, Enabled = true, Name = "�����u (1�c)", Description = "CAT5E", NO = "AC03" },
            //    new Consumable { CreatedTime = DateTime.Now, Enabled = true, Name = "�����Y", Description = "CAT5E", NO = "NA001" }
            //    );
            //context.WorkForm.AddOrUpdate(x=>x.ID,
            //    new WorkForm { AcceptedTime = DateTime.Now, Closed = false, WorkFormType = WorkFormType.�w�ˤu��, Contact = "���a��", Description = "�w��POS���@�x", CreatedTime = DateTime.Now, UnitID = context.Unit.Single(u => u.Name == "���j�@").ID },
            //    new WorkForm { AcceptedTime = DateTime.Now, Closed = false, WorkFormType = WorkFormType.���פu��, Contact = "������", Description = "POS�����}��", CreatedTime = DateTime.Now, UnitID = context.Unit.Single(u => u.Name == "�¨q�v��").ID },
            //    new WorkForm { AcceptedTime = DateTime.Now, Closed = false, WorkFormType = WorkFormType.�M�פu��, Contact = "���j��", Description = "��u", CreatedTime = DateTime.Now, UnitID = context.Unit.Single(u => u.Name == "Gucci").ID }
            //    );
            //context.SaveChanges();
            //context.RMAForm.AddOrUpdate(x=>x.ID,
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��123", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��124", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��125", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��126", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��127", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��128", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��129", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��130", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��131", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��132", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��133", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��134", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��135", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��136", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��137", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��123", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��124", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��125", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��126", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��127", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��128", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��129", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��130", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��131", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��132", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��133", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��134", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��135", Status = RMAFormStatus.�w����, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��136", Status = RMAFormStatus.�w�e��, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��123", Status = RMAFormStatus.�w�e��, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��124", Status = RMAFormStatus.�w�e��, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��125", Status = RMAFormStatus.�w�e��, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��126", Status = RMAFormStatus.�w�e��, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��127", Status = RMAFormStatus.�w�e��, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��128", Status = RMAFormStatus.�w�e��, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��129", Status = RMAFormStatus.�w�e��, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��130", Status = RMAFormStatus.�w�e��, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��131", Status = RMAFormStatus.�w�e��, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��132", Status = RMAFormStatus.�w�e��, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��133", Status = RMAFormStatus.�w�e��, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��134", Status = RMAFormStatus.�w�e��, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��135", Status = RMAFormStatus.�w�e��, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now },
            //    new RMAForm { CreatedTime = DateTime.Now, Contact = "�p�j���", ContactInfo = "06-2003000", Description = "���}��136", Status = RMAFormStatus.�w�e��, PropertyID = context.Property.Single(p => p.SN == "ABCD00001").ID, Closed = false, RMATime = DateTime.Now, ReturnTime = DateTime.Now }
            //    );
            //context.SaveChanges();

            //context.WorkFormConsumable.AddOrUpdate(m=>m.ID,
            //    new WorkFormConsumable { Amount=5,ConsumableID=context.Consumable.First().ID,WorkFormID=context.WorkForm.First().ID}
            //    );
            //context.SaveChanges();
            //context.Property.AddOrUpdate(x=>x.ID,
            //    new Property { }
            //    );
            //var units = new List<Unit>
            //{
            //    new Unit {Name="Louis Vuitton",IDString="B1A01",Floor="5F",Area="A",CreatedTime=DateTime.Now},
            //    new Unit {Name="Gucci",IDString="3FA01",Floor="3F",Area="C",CreatedTime=DateTime.Now},
            //    new Unit {Name="�¨q�v��",IDString="5FB01",Floor="5F",Area="D",CreatedTime=DateTime.Now},
            //    new Unit {Name="���j�@",IDString="E0000001",Floor="5F",Area="��P��",CreatedTime=DateTime.Now},
            //    new Unit {Name="���j�G",IDString="E0000002",Floor="3F",Area="��B��",CreatedTime=DateTime.Now},
            //    new Unit {Name="���j�T",IDString="E0000003",Floor="4F",Area="��T��",CreatedTime=DateTime.Now},
            //    new Unit {Name="�������",IDString="5FB01",Floor="5F",Area="B",CreatedTime=DateTime.Now}

            //};
            //units.ForEach(s => context.Unit.AddOrUpdate(p => p.IDString, s));
            //var propertytypes = new List<PropertyType>
            //{
            //    new PropertyType {ID=1,Type="���O���q��",Name="Lenovo X230",Description="I5/8G/500G Windows 8",CreatedTime=DateTime.Now},
            //    new PropertyType {ID=2,Type="���O���q��",Name="Asus X550VC",Description="I5/4G/500G Windows 8",CreatedTime=DateTime.Now},
            //    new PropertyType {ID=3,Type="���O���q��",Name="Asus T100",Description="Atom/2G/32G Windows 8",CreatedTime=DateTime.Now},
            //    new PropertyType {ID=4,Type="��W���q��",Name="2014�ո�I5",Description="I5/4G/500G Windows 8",CreatedTime=DateTime.Now},
            //    new PropertyType {ID=5,Type="��W���q��",Name="2015�ո�I3",Description="I5/4G/500G Windows 8",CreatedTime=DateTime.Now},
            //    new PropertyType {ID=6,Type="POS��",Name="���xPOS��",Description="ATOM/2G/8G Windows XP"}
            //};
            //propertytypes.ForEach(s => context.PropertyType.AddOrUpdate(p => p.ID, s));

            //context.SaveChanges();
            //var units = new List<TSRD_Unit>
            //{
            //    new TSRD_Unit {Floor="B1",Area="A",IDString="B1A01",Name="�p�M�h",CreatedTime = DateTime.Now},
            //    new TSRD_Unit {Floor="1F",Area="A",IDString="F1A01+F2A01+F2A02",Name="Zara",CreatedTime = DateTime.Now},
            //    new TSRD_Unit {Floor="1F",Area="D",IDString="F1D01",Name="Massimo Dutti",CreatedTime = DateTime.Now},
            //    new TSRD_Unit {Floor="2F",Area="�ɩ|�W�~Team",IDString="2014000050",Name="�J�Y��",CreatedTime = DateTime.Now},
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
