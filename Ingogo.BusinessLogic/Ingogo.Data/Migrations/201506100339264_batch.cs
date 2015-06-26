using System.Data.Entity.Migrations;

namespace Ingogo.Data.Migrations
{
    public partial class batch : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Animals", "BatchTypeid");
            AddForeignKey("dbo.Animals", "BatchTypeid", "dbo.BatchTypes", "BatchTypeid", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "BatchTypeid", "dbo.BatchTypes");
            DropIndex("dbo.Animals", new[] { "BatchTypeid" });
        }
    }
}
