namespace DatabaseLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIDToScenarioLinkTables : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.MonsterScenarioTables");
            DropPrimaryKey("dbo.PlayerScenarioTables");
            AddColumn("dbo.MonsterScenarioTables", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.PlayerScenarioTables", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.MonsterScenarioTables", new[] { "Id", "ScenarioName", "MonsterName" });
            AddPrimaryKey("dbo.PlayerScenarioTables", new[] { "Id", "ScenarioName", "PlayerID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PlayerScenarioTables");
            DropPrimaryKey("dbo.MonsterScenarioTables");
            DropColumn("dbo.PlayerScenarioTables", "Id");
            DropColumn("dbo.MonsterScenarioTables", "Id");
            AddPrimaryKey("dbo.PlayerScenarioTables", new[] { "ScenarioName", "PlayerID" });
            AddPrimaryKey("dbo.MonsterScenarioTables", new[] { "ScenarioName", "MonsterName" });
        }
    }
}
