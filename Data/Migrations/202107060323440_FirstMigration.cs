namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CryptoInfo",
                c => new
                    {
                        CryptoId = c.Int(nullable: false, identity: true),
                        Currency = c.String(nullable: false),
                        PurchaseId = c.Int(),
                        CryptoName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CryptoId);
            
            CreateTable(
                "dbo.CryptoUser",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        LogId = c.Guid(nullable: false),
                        PreferredExchange = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Portfolio",
                c => new
                    {
                        PortfolioId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BullBear = c.String(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.PortfolioId)
                .ForeignKey("dbo.CryptoUser", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.CryptoPurchase",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Gain = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalGain = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseDate = c.DateTimeOffset(nullable: false, precision: 7),
                        CryptoInfo_CryptoId = c.Int(),
                        Portfolio_PortfolioId = c.Int(),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.CryptoInfo", t => t.CryptoInfo_CryptoId)
                .ForeignKey("dbo.Portfolio", t => t.Portfolio_PortfolioId)
                .Index(t => t.CryptoInfo_CryptoId)
                .Index(t => t.Portfolio_PortfolioId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Portfolio", "User_UserId", "dbo.CryptoUser");
            DropForeignKey("dbo.CryptoPurchase", "Portfolio_PortfolioId", "dbo.Portfolio");
            DropForeignKey("dbo.CryptoPurchase", "CryptoInfo_CryptoId", "dbo.CryptoInfo");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.CryptoPurchase", new[] { "Portfolio_PortfolioId" });
            DropIndex("dbo.CryptoPurchase", new[] { "CryptoInfo_CryptoId" });
            DropIndex("dbo.Portfolio", new[] { "User_UserId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.CryptoPurchase");
            DropTable("dbo.Portfolio");
            DropTable("dbo.CryptoUser");
            DropTable("dbo.CryptoInfo");
        }
    }
}
