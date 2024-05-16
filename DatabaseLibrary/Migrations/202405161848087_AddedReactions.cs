namespace DatabaseLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReactions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Strength = c.Short(nullable: false),
                        Dexterity = c.Short(nullable: false),
                        Constitution = c.Short(nullable: false),
                        Intelligence = c.Short(nullable: false),
                        Wisdom = c.Short(nullable: false),
                        Charisma = c.Short(nullable: false),
                        Proficiency_Bonus = c.Short(nullable: false),
                        MonsterName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Monsters", t => t.MonsterName)
                .Index(t => t.MonsterName);
            
            CreateTable(
                "dbo.Monsters",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 200),
                        HP = c.Int(nullable: false),
                        Initiative_Modifier = c.Short(nullable: false),
                        Size = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        Hit_Dice = c.String(nullable: false),
                        Hit_Points_Roll = c.String(nullable: false),
                        Alignment = c.String(nullable: false),
                        Languages = c.String(),
                        Challenge_Rating = c.Double(nullable: false),
                        XP = c.Int(nullable: false),
                        Damage_Vulnerabilities = c.String(),
                        Damage_Resistances = c.String(),
                        Damage_Immunities = c.String(),
                        IsSpellcaster = c.Boolean(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.ArmorClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ac_Type = c.String(nullable: false),
                        AC = c.Short(nullable: false),
                        MonsterName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Monsters", t => t.MonsterName)
                .Index(t => t.MonsterName);
            
            CreateTable(
                "dbo.CombatActions",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 200),
                        MonsterName = c.String(nullable: false, maxLength: 200),
                        Desc = c.String(nullable: false),
                        Attack_Bonus = c.Short(),
                        IsDamage = c.Boolean(nullable: false),
                        IsDC = c.Boolean(nullable: false),
                        IsUsage = c.Boolean(nullable: false),
                        HasDamageOptions = c.Boolean(nullable: false),
                        ActionOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Name, t.MonsterName })
                .ForeignKey("dbo.Monsters", t => t.MonsterName)
                .Index(t => t.MonsterName);
            
            CreateTable(
                "dbo.ConditionImmunities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        URL = c.String(nullable: false),
                        MonsterName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Monsters", t => t.MonsterName)
                .Index(t => t.MonsterName);
            
            CreateTable(
                "dbo.LegendaryActions",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 200),
                        MonsterName = c.String(nullable: false, maxLength: 200),
                        Desc = c.String(nullable: false),
                        Attack_Bonus = c.Short(),
                        IsDamage = c.Boolean(nullable: false),
                        IsDC = c.Boolean(nullable: false),
                        HasDamageOptions = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.Name, t.MonsterName })
                .ForeignKey("dbo.Monsters", t => t.MonsterName)
                .Index(t => t.MonsterName);
            
            CreateTable(
                "dbo.MonsterScenarioTables",
                c => new
                    {
                        ScenarioID = c.Int(nullable: false),
                        MonsterName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => new { t.ScenarioID, t.MonsterName })
                .ForeignKey("dbo.Scenarios", t => t.ScenarioID)
                .ForeignKey("dbo.Monsters", t => t.MonsterName)
                .Index(t => t.ScenarioID)
                .Index(t => t.MonsterName);
            
            CreateTable(
                "dbo.Scenarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Scenario_Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlayerScenarioTables",
                c => new
                    {
                        ScenarioID = c.Int(nullable: false),
                        PlayerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ScenarioID, t.PlayerID })
                .ForeignKey("dbo.PlayerCharacterBasics", t => t.PlayerID)
                .ForeignKey("dbo.Scenarios", t => t.ScenarioID)
                .Index(t => t.ScenarioID)
                .Index(t => t.PlayerID);
            
            CreateTable(
                "dbo.PlayerCharacterBasics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HP = c.Int(nullable: false),
                        AC = c.Short(nullable: false),
                        CR_2_Score = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Proficiencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bonus = c.Short(nullable: false),
                        Name = c.String(nullable: false),
                        MonsterName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Monsters", t => t.MonsterName)
                .Index(t => t.MonsterName);
            
            CreateTable(
                "dbo.Reactions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        MonsterName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Monsters", t => t.MonsterName)
                .Index(t => t.MonsterName);
            
            CreateTable(
                "dbo.Senses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Passive_Perception = c.Short(nullable: false),
                        Darkvision = c.String(unicode: false),
                        Truesight = c.String(unicode: false),
                        Blindsight = c.String(unicode: false),
                        Tremorsense = c.String(unicode: false),
                        MonsterName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Monsters", t => t.MonsterName)
                .Index(t => t.MonsterName);
            
            CreateTable(
                "dbo.SpecialAbilities",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 200),
                        MonsterName = c.String(nullable: false, maxLength: 200),
                        Desc = c.String(nullable: false),
                        IsDC = c.Boolean(nullable: false),
                        IsUsage = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.Name, t.MonsterName })
                .ForeignKey("dbo.Monsters", t => t.MonsterName)
                .Index(t => t.MonsterName);
            
            CreateTable(
                "dbo.Speeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Distance = c.String(nullable: false),
                        MonsterName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Monsters", t => t.MonsterName)
                .Index(t => t.MonsterName);
            
            CreateTable(
                "dbo.SpellCastingStats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.Short(),
                        Ability = c.String(nullable: false),
                        DC = c.Short(),
                        Modifier = c.Short(),
                        School = c.String(),
                        L1_Slots = c.Short(),
                        L2_Slots = c.Short(),
                        L3_Slots = c.Short(),
                        L4_Slots = c.Short(),
                        L5_Slots = c.Short(),
                        L6_Slots = c.Short(),
                        L7_Slots = c.Short(),
                        L8_Slots = c.Short(),
                        L9_Slots = c.Short(),
                        MonsterName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Monsters", t => t.MonsterName)
                .Index(t => t.MonsterName);
            
            CreateTable(
                "dbo.MonsterSpellTables",
                c => new
                    {
                        MonsterName = c.String(nullable: false, maxLength: 200),
                        SpellName = c.String(nullable: false, maxLength: 200),
                        IsUsage = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.MonsterName, t.SpellName })
                .ForeignKey("dbo.Spells", t => t.SpellName)
                .ForeignKey("dbo.Monsters", t => t.MonsterName)
                .Index(t => t.MonsterName)
                .Index(t => t.SpellName);
            
            CreateTable(
                "dbo.Spells",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false),
                        Range = c.String(nullable: false),
                        Components = c.String(nullable: false),
                        IsRitual = c.Boolean(nullable: false),
                        Duration = c.String(nullable: false),
                        IsConcentration = c.Boolean(nullable: false),
                        Casting_Time = c.String(nullable: false),
                        Level = c.Int(nullable: false),
                        School = c.String(nullable: false),
                        Higher_Level = c.String(),
                        Material = c.String(),
                        Area_Of_Effect_Type = c.String(),
                        Area_Of_Effect_Size = c.Int(),
                        DC_Type = c.String(),
                        DC_Success = c.String(),
                        IsDamage = c.Boolean(nullable: false),
                        IsDC = c.Boolean(nullable: false),
                        IsHeal = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.DifficultyClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DC_Type = c.String(nullable: false),
                        DC_Value = c.Short(),
                        ActionMonsterName = c.String(maxLength: 200),
                        ActionName = c.String(maxLength: 200),
                        LegendaryActionMonsterName = c.String(maxLength: 200),
                        LegendaryActionName = c.String(maxLength: 200),
                        SpecialAbilityMonsterName = c.String(maxLength: 200),
                        SpecialAbilityName = c.String(maxLength: 200),
                        Spell_Name = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CombatActions", t => new { t.ActionName, t.ActionMonsterName })
                .ForeignKey("dbo.LegendaryActions", t => new { t.LegendaryActionName, t.LegendaryActionMonsterName })
                .ForeignKey("dbo.SpecialAbilities", t => new { t.SpecialAbilityName, t.SpecialAbilityMonsterName })
                .ForeignKey("dbo.Spells", t => t.Spell_Name)
                .Index(t => new { t.ActionName, t.ActionMonsterName })
                .Index(t => new { t.LegendaryActionName, t.LegendaryActionMonsterName })
                .Index(t => new { t.SpecialAbilityName, t.SpecialAbilityMonsterName })
                .Index(t => t.Spell_Name);
            
            CreateTable(
                "dbo.SpellDamageAtCharacterLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Damage_Type = c.String(),
                        Damage_L1 = c.String(),
                        Damage_L2 = c.String(),
                        Damage_L3 = c.String(),
                        Damage_L4 = c.String(),
                        Damage_L5 = c.String(),
                        Damage_L6 = c.String(),
                        Damage_L7 = c.String(),
                        Damage_L8 = c.String(),
                        Damage_L9 = c.String(),
                        Damage_L10 = c.String(),
                        Damage_L11 = c.String(),
                        Damage_L12 = c.String(),
                        Damage_L13 = c.String(),
                        Damage_L14 = c.String(),
                        Damage_L15 = c.String(),
                        Damage_L16 = c.String(),
                        Damage_L17 = c.String(),
                        Damage_L18 = c.String(),
                        Damage_L19 = c.String(),
                        Damage_L20 = c.String(),
                        SpellName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Spells", t => t.SpellName)
                .Index(t => t.SpellName);
            
            CreateTable(
                "dbo.SpellDamages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Damage_Type = c.String(),
                        Damage_L1 = c.String(),
                        Damage_L2 = c.String(),
                        Damage_L3 = c.String(),
                        Damage_L4 = c.String(),
                        Damage_L5 = c.String(),
                        Damage_L6 = c.String(),
                        Damage_L7 = c.String(),
                        Damage_L8 = c.String(),
                        Damage_L9 = c.String(),
                        SpellName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Spells", t => t.SpellName)
                .Index(t => t.SpellName);
            
            CreateTable(
                "dbo.SpellHealings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Healing_L1 = c.String(),
                        Healing_L2 = c.String(),
                        Healing_L3 = c.String(),
                        Healing_L4 = c.String(),
                        Healing_L5 = c.String(),
                        Healing_L6 = c.String(),
                        Healing_L7 = c.String(),
                        Healing_L8 = c.String(),
                        Healing_L9 = c.String(),
                        SpellName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Spells", t => t.SpellName)
                .Index(t => t.SpellName);
            
            CreateTable(
                "dbo.Damages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Damage_Type = c.String(),
                        IsOption = c.Boolean(nullable: false),
                        Damage_Dice = c.String(nullable: false),
                        ActionMonsterName = c.String(maxLength: 200),
                        ActionName = c.String(maxLength: 200),
                        LegendaryActionMonsterName = c.String(maxLength: 200),
                        LegendaryActionName = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CombatActions", t => new { t.ActionName, t.ActionMonsterName })
                .ForeignKey("dbo.LegendaryActions", t => new { t.LegendaryActionName, t.LegendaryActionMonsterName })
                .Index(t => new { t.ActionName, t.ActionMonsterName })
                .Index(t => new { t.LegendaryActionName, t.LegendaryActionMonsterName });
            
            CreateTable(
                "dbo.Usages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Times = c.Int(),
                        MinDiceValue = c.Int(),
                        Dice = c.String(),
                        ActionMonsterName = c.String(maxLength: 200),
                        ActionName = c.String(maxLength: 200),
                        SpecialAbilityMonsterName = c.String(maxLength: 200),
                        SpecialAbilityName = c.String(maxLength: 200),
                        MonsterSpellMonsterName = c.String(maxLength: 200),
                        MonsterSpellSpellName = c.String(maxLength: 200),
                        SpellMonster_MonsterName = c.String(maxLength: 200),
                        SpellMonster_SpellName = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CombatActions", t => new { t.ActionName, t.ActionMonsterName })
                .ForeignKey("dbo.SpecialAbilities", t => new { t.SpecialAbilityName, t.SpecialAbilityMonsterName })
                .ForeignKey("dbo.MonsterSpellTables", t => new { t.SpellMonster_MonsterName, t.SpellMonster_SpellName })
                .Index(t => new { t.ActionName, t.ActionMonsterName })
                .Index(t => new { t.SpecialAbilityName, t.SpecialAbilityMonsterName })
                .Index(t => new { t.SpellMonster_MonsterName, t.SpellMonster_SpellName });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usages", new[] { "SpellMonster_MonsterName", "SpellMonster_SpellName" }, "dbo.MonsterSpellTables");
            DropForeignKey("dbo.Usages", new[] { "SpecialAbilityName", "SpecialAbilityMonsterName" }, "dbo.SpecialAbilities");
            DropForeignKey("dbo.Usages", new[] { "ActionName", "ActionMonsterName" }, "dbo.CombatActions");
            DropForeignKey("dbo.Damages", new[] { "LegendaryActionName", "LegendaryActionMonsterName" }, "dbo.LegendaryActions");
            DropForeignKey("dbo.Damages", new[] { "ActionName", "ActionMonsterName" }, "dbo.CombatActions");
            DropForeignKey("dbo.MonsterSpellTables", "MonsterName", "dbo.Monsters");
            DropForeignKey("dbo.MonsterSpellTables", "SpellName", "dbo.Spells");
            DropForeignKey("dbo.SpellHealings", "SpellName", "dbo.Spells");
            DropForeignKey("dbo.SpellDamages", "SpellName", "dbo.Spells");
            DropForeignKey("dbo.SpellDamageAtCharacterLevels", "SpellName", "dbo.Spells");
            DropForeignKey("dbo.DifficultyClasses", "Spell_Name", "dbo.Spells");
            DropForeignKey("dbo.DifficultyClasses", new[] { "SpecialAbilityName", "SpecialAbilityMonsterName" }, "dbo.SpecialAbilities");
            DropForeignKey("dbo.DifficultyClasses", new[] { "LegendaryActionName", "LegendaryActionMonsterName" }, "dbo.LegendaryActions");
            DropForeignKey("dbo.DifficultyClasses", new[] { "ActionName", "ActionMonsterName" }, "dbo.CombatActions");
            DropForeignKey("dbo.SpellCastingStats", "MonsterName", "dbo.Monsters");
            DropForeignKey("dbo.Speeds", "MonsterName", "dbo.Monsters");
            DropForeignKey("dbo.SpecialAbilities", "MonsterName", "dbo.Monsters");
            DropForeignKey("dbo.Senses", "MonsterName", "dbo.Monsters");
            DropForeignKey("dbo.Reactions", "MonsterName", "dbo.Monsters");
            DropForeignKey("dbo.Proficiencies", "MonsterName", "dbo.Monsters");
            DropForeignKey("dbo.MonsterScenarioTables", "MonsterName", "dbo.Monsters");
            DropForeignKey("dbo.PlayerScenarioTables", "ScenarioID", "dbo.Scenarios");
            DropForeignKey("dbo.PlayerScenarioTables", "PlayerID", "dbo.PlayerCharacterBasics");
            DropForeignKey("dbo.MonsterScenarioTables", "ScenarioID", "dbo.Scenarios");
            DropForeignKey("dbo.LegendaryActions", "MonsterName", "dbo.Monsters");
            DropForeignKey("dbo.ConditionImmunities", "MonsterName", "dbo.Monsters");
            DropForeignKey("dbo.CombatActions", "MonsterName", "dbo.Monsters");
            DropForeignKey("dbo.ArmorClasses", "MonsterName", "dbo.Monsters");
            DropForeignKey("dbo.Abilities", "MonsterName", "dbo.Monsters");
            DropIndex("dbo.Usages", new[] { "SpellMonster_MonsterName", "SpellMonster_SpellName" });
            DropIndex("dbo.Usages", new[] { "SpecialAbilityName", "SpecialAbilityMonsterName" });
            DropIndex("dbo.Usages", new[] { "ActionName", "ActionMonsterName" });
            DropIndex("dbo.Damages", new[] { "LegendaryActionName", "LegendaryActionMonsterName" });
            DropIndex("dbo.Damages", new[] { "ActionName", "ActionMonsterName" });
            DropIndex("dbo.SpellHealings", new[] { "SpellName" });
            DropIndex("dbo.SpellDamages", new[] { "SpellName" });
            DropIndex("dbo.SpellDamageAtCharacterLevels", new[] { "SpellName" });
            DropIndex("dbo.DifficultyClasses", new[] { "Spell_Name" });
            DropIndex("dbo.DifficultyClasses", new[] { "SpecialAbilityName", "SpecialAbilityMonsterName" });
            DropIndex("dbo.DifficultyClasses", new[] { "LegendaryActionName", "LegendaryActionMonsterName" });
            DropIndex("dbo.DifficultyClasses", new[] { "ActionName", "ActionMonsterName" });
            DropIndex("dbo.MonsterSpellTables", new[] { "SpellName" });
            DropIndex("dbo.MonsterSpellTables", new[] { "MonsterName" });
            DropIndex("dbo.SpellCastingStats", new[] { "MonsterName" });
            DropIndex("dbo.Speeds", new[] { "MonsterName" });
            DropIndex("dbo.SpecialAbilities", new[] { "MonsterName" });
            DropIndex("dbo.Senses", new[] { "MonsterName" });
            DropIndex("dbo.Reactions", new[] { "MonsterName" });
            DropIndex("dbo.Proficiencies", new[] { "MonsterName" });
            DropIndex("dbo.PlayerScenarioTables", new[] { "PlayerID" });
            DropIndex("dbo.PlayerScenarioTables", new[] { "ScenarioID" });
            DropIndex("dbo.MonsterScenarioTables", new[] { "MonsterName" });
            DropIndex("dbo.MonsterScenarioTables", new[] { "ScenarioID" });
            DropIndex("dbo.LegendaryActions", new[] { "MonsterName" });
            DropIndex("dbo.ConditionImmunities", new[] { "MonsterName" });
            DropIndex("dbo.CombatActions", new[] { "MonsterName" });
            DropIndex("dbo.ArmorClasses", new[] { "MonsterName" });
            DropIndex("dbo.Abilities", new[] { "MonsterName" });
            DropTable("dbo.Usages");
            DropTable("dbo.Damages");
            DropTable("dbo.SpellHealings");
            DropTable("dbo.SpellDamages");
            DropTable("dbo.SpellDamageAtCharacterLevels");
            DropTable("dbo.DifficultyClasses");
            DropTable("dbo.Spells");
            DropTable("dbo.MonsterSpellTables");
            DropTable("dbo.SpellCastingStats");
            DropTable("dbo.Speeds");
            DropTable("dbo.SpecialAbilities");
            DropTable("dbo.Senses");
            DropTable("dbo.Reactions");
            DropTable("dbo.Proficiencies");
            DropTable("dbo.PlayerCharacterBasics");
            DropTable("dbo.PlayerScenarioTables");
            DropTable("dbo.Scenarios");
            DropTable("dbo.MonsterScenarioTables");
            DropTable("dbo.LegendaryActions");
            DropTable("dbo.ConditionImmunities");
            DropTable("dbo.CombatActions");
            DropTable("dbo.ArmorClasses");
            DropTable("dbo.Monsters");
            DropTable("dbo.Abilities");
        }
    }
}
