namespace Movie_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIssubscribedToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IssubscribedToNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IssubscribedToNewsletter");
        }
    }
}
