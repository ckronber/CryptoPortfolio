﻿namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CryptoInfo", "CryptoName", c => c.String(nullable: false));
            DropColumn("dbo.CryptoInfo", "Price");
            DropColumn("dbo.CryptoInfo", "TotalValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CryptoInfo", "TotalValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.CryptoInfo", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.CryptoInfo", "CryptoName", c => c.String());
        }
    }
}
