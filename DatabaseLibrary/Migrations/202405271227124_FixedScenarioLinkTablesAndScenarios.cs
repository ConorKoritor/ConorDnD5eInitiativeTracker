namespace DatabaseLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedScenarioLinkTablesAndScenarios : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MonsterScenarioTables", "ScenarioID", "dbo.Scenarios");
            DropForeignKey("dbo.PlayerScenarioTables", "ScenarioID", "dbo.Scenarios");
            DropIndex("dbo.MonsterScenarioTables", new[] { "ScenarioID" });
            DropIndex("dbo.PlayerScenarioTables", new[] { "ScenarioID" });
            RenameColumn(table: "dbo.MonsterScenarioTables", name: "ScenarioID", newName: "ScenarioName");
            RenameColumn(table: "dbo.PlayerScenarioTables", name: "ScenarioID", newName: "ScenarioName");
            DropPrimaryKey("dbo.MonsterScenarioTables");
            DropPrimaryKey("dbo.Scenarios");
            DropPrimaryKey("dbo.PlayerScenarioTables");
            AlterColumn("dbo.MonsterScenarioTables", "ScenarioName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Scenarios", "Scenario_Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.PlayerScenarioTables", "ScenarioName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.MonsterScenarioTables", new[] { "ScenarioName", "MonsterName" });
            AddPrimaryKey("dbo.Scenarios", "Scenario_Name");
            AddPrimaryKey("dbo.PlayerScenarioTables", new[] { "ScenarioName", "PlayerID" });
            CreateIndex("dbo.MonsterScenarioTables", "ScenarioName");
            CreateIndex("dbo.PlayerScenarioTables", "ScenarioName");
            AddForeignKey("dbo.MonsterScenarioTables", "ScenarioName", "dbo.Scenarios", "Scenario_Name");
            AddForeignKey("dbo.PlayerScenarioTables", "ScenarioName", "dbo.Scenarios", "Scenario_Name");
            DropColumn("dbo.Scenarios", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Scenarios", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.PlayerScenarioTables", "ScenarioName", "dbo.Scenarios");
            DropForeignKey("dbo.MonsterScenarioTables", "ScenarioName", "dbo.Scenarios");
            DropIndex("dbo.PlayerScenarioTables", new[] { "ScenarioName" });
            DropIndex("dbo.MonsterScenarioTables", new[] { "ScenarioName" });
            DropPrimaryKey("dbo.PlayerScenarioTables");
            DropPrimaryKey("dbo.Scenarios");
            DropPrimaryKey("dbo.MonsterScenarioTables");
            AlterColumn("dbo.PlayerScenarioTables", "ScenarioName", c => c.Int(nullable: false));
            AlterColumn("dbo.Scenarios", "Scenario_Name", c => c.String());
            AlterColumn("dbo.MonsterScenarioTables", "ScenarioName", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.PlayerScenarioTables", new[] { "ScenarioID", "PlayerID" });
            AddPrimaryKey("dbo.Scenarios", "Id");
            AddPrimaryKey("dbo.MonsterScenarioTables", new[] { "ScenarioID", "MonsterName" });
            RenameColumn(table: "dbo.PlayerScenarioTables", name: "ScenarioName", newName: "ScenarioID");
            RenameColumn(table: "dbo.MonsterScenarioTables", name: "ScenarioName", newName: "ScenarioID");
            CreateIndex("dbo.PlayerScenarioTables", "ScenarioID");
            CreateIndex("dbo.MonsterScenarioTables", "ScenarioID");
            AddForeignKey("dbo.PlayerScenarioTables", "ScenarioID", "dbo.Scenarios", "Id");
            AddForeignKey("dbo.MonsterScenarioTables", "ScenarioID", "dbo.Scenarios", "Id");
        }
    }
}
