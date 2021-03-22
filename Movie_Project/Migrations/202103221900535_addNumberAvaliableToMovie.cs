namespace Movie_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNumberAvaliableToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvaliable", c => c.Byte(nullable: false));
            Sql("UPDATE MOVIES SET NumberAvaliable = NumerInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberAvaliable");
        }
    }
}
