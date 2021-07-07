namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CryptoUser", "Currency", c => c.String(nullable: false, maxLength: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CryptoUser", "Currency", c => c.String());
        }
    }
}
