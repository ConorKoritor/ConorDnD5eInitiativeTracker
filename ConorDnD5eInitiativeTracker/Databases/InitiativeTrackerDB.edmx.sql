
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/07/2024 11:27:46
-- Generated from EDMX file: C:\Users\ckori\Documents\ConorDnD5eInitiativeTracker\ConorDnD5eInitiativeTracker\Databases\InitiativeTrackerDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [InitiativeTrackerDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ScenarioCharacterScenarioTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CharacterScenarioTables] DROP CONSTRAINT [FK_ScenarioCharacterScenarioTable];
GO
IF OBJECT_ID(N'[dbo].[FK_PlayerCharacterBasicCharacterScenarioTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CharacterScenarioTables] DROP CONSTRAINT [FK_PlayerCharacterBasicCharacterScenarioTable];
GO
IF OBJECT_ID(N'[dbo].[FK_ScenarioMonsterScenarioTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MonsterScenarioTables] DROP CONSTRAINT [FK_ScenarioMonsterScenarioTable];
GO
IF OBJECT_ID(N'[dbo].[FK_SpellSpellMonsterTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SpellMonsterTables] DROP CONSTRAINT [FK_SpellSpellMonsterTable];
GO
IF OBJECT_ID(N'[dbo].[FK_SpellDifficultyClass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DifficultyClasses] DROP CONSTRAINT [FK_SpellDifficultyClass];
GO
IF OBJECT_ID(N'[dbo].[FK_MonsterAction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Actions] DROP CONSTRAINT [FK_MonsterAction];
GO
IF OBJECT_ID(N'[dbo].[FK_MonsterLegendaryAction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LegendaryActions] DROP CONSTRAINT [FK_MonsterLegendaryAction];
GO
IF OBJECT_ID(N'[dbo].[FK_MonsterSpecialAbility]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SpecialAbilities] DROP CONSTRAINT [FK_MonsterSpecialAbility];
GO
IF OBJECT_ID(N'[dbo].[FK_MonsterConditionImmunity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConditionImmunities] DROP CONSTRAINT [FK_MonsterConditionImmunity];
GO
IF OBJECT_ID(N'[dbo].[FK_MonsterSpellMonsterTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SpellMonsterTables] DROP CONSTRAINT [FK_MonsterSpellMonsterTable];
GO
IF OBJECT_ID(N'[dbo].[FK_MonsterProficiency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proficiencies] DROP CONSTRAINT [FK_MonsterProficiency];
GO
IF OBJECT_ID(N'[dbo].[FK_MonsterSpellCastingStats]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SpellCastingStats] DROP CONSTRAINT [FK_MonsterSpellCastingStats];
GO
IF OBJECT_ID(N'[dbo].[FK_MonsterAbilities]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Abilities] DROP CONSTRAINT [FK_MonsterAbilities];
GO
IF OBJECT_ID(N'[dbo].[FK_MonsterArmorClass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ArmorClasses] DROP CONSTRAINT [FK_MonsterArmorClass];
GO
IF OBJECT_ID(N'[dbo].[FK_MonsterSpeed]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Speeds] DROP CONSTRAINT [FK_MonsterSpeed];
GO
IF OBJECT_ID(N'[dbo].[FK_MonsterMonsterScenarioTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MonsterScenarioTables] DROP CONSTRAINT [FK_MonsterMonsterScenarioTable];
GO
IF OBJECT_ID(N'[dbo].[FK_SpellSpellDamage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SpellDamages] DROP CONSTRAINT [FK_SpellSpellDamage];
GO
IF OBJECT_ID(N'[dbo].[FK_SpellSpellHealing]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SpellHealings] DROP CONSTRAINT [FK_SpellSpellHealing];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionDamage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Damages] DROP CONSTRAINT [FK_ActionDamage];
GO
IF OBJECT_ID(N'[dbo].[FK_LegendaryActionDamage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Damages] DROP CONSTRAINT [FK_LegendaryActionDamage];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionDifficultyClass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DifficultyClasses] DROP CONSTRAINT [FK_ActionDifficultyClass];
GO
IF OBJECT_ID(N'[dbo].[FK_LegendaryActionDifficultyClass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DifficultyClasses] DROP CONSTRAINT [FK_LegendaryActionDifficultyClass];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Monsters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Monsters];
GO
IF OBJECT_ID(N'[dbo].[Abilities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Abilities];
GO
IF OBJECT_ID(N'[dbo].[ArmorClasses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ArmorClasses];
GO
IF OBJECT_ID(N'[dbo].[ConditionImmunities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConditionImmunities];
GO
IF OBJECT_ID(N'[dbo].[Proficiencies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proficiencies];
GO
IF OBJECT_ID(N'[dbo].[Speeds]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Speeds];
GO
IF OBJECT_ID(N'[dbo].[Actions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Actions];
GO
IF OBJECT_ID(N'[dbo].[SpellCastingStats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SpellCastingStats];
GO
IF OBJECT_ID(N'[dbo].[SpecialAbilities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SpecialAbilities];
GO
IF OBJECT_ID(N'[dbo].[LegendaryActions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LegendaryActions];
GO
IF OBJECT_ID(N'[dbo].[Damages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Damages];
GO
IF OBJECT_ID(N'[dbo].[DifficultyClasses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DifficultyClasses];
GO
IF OBJECT_ID(N'[dbo].[Spells]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Spells];
GO
IF OBJECT_ID(N'[dbo].[SpellDamages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SpellDamages];
GO
IF OBJECT_ID(N'[dbo].[SpellMonsterTables]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SpellMonsterTables];
GO
IF OBJECT_ID(N'[dbo].[Scenarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Scenarios];
GO
IF OBJECT_ID(N'[dbo].[CharacterScenarioTables]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CharacterScenarioTables];
GO
IF OBJECT_ID(N'[dbo].[PlayerCharacterBasics]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlayerCharacterBasics];
GO
IF OBJECT_ID(N'[dbo].[MonsterScenarioTables]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MonsterScenarioTables];
GO
IF OBJECT_ID(N'[dbo].[SpellHealings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SpellHealings];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Monsters'
CREATE TABLE [dbo].[Monsters] (
    [Name] nvarchar(max)  NOT NULL,
    [HP] int  NOT NULL,
    [Initiative_Modifier] smallint  NOT NULL,
    [Desc] nvarchar(max)  NOT NULL,
    [Size] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Hit_Dice] nvarchar(max)  NOT NULL,
    [Hit_Points_Roll] nvarchar(max)  NOT NULL,
    [Alignment] nvarchar(max)  NOT NULL,
    [Languages] nvarchar(max)  NOT NULL,
    [Challenge_Rating] float  NOT NULL,
    [XP] int  NOT NULL,
    [Damage_Vulnerabilities] nvarchar(max)  NULL,
    [Damage_Resistances] nvarchar(max)  NULL,
    [Damage_Immunities] nvarchar(max)  NULL,
    [IsSpellcaster] bit  NOT NULL
);
GO

-- Creating table 'Abilities'
CREATE TABLE [dbo].[Abilities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Strength] smallint  NOT NULL,
    [Dexterity] smallint  NOT NULL,
    [Constitution] smallint  NOT NULL,
    [Intelligence] smallint  NOT NULL,
    [Wisdom] smallint  NOT NULL,
    [Charisma] smallint  NOT NULL,
    [Proficiency_Bonus] smallint  NOT NULL,
    [MonsterName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ArmorClasses'
CREATE TABLE [dbo].[ArmorClasses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ac_Type] nvarchar(max)  NOT NULL,
    [AC] smallint  NOT NULL,
    [MonsterName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ConditionImmunities'
CREATE TABLE [dbo].[ConditionImmunities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [URL] nvarchar(max)  NOT NULL,
    [MonsterName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Proficiencies'
CREATE TABLE [dbo].[Proficiencies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Bonus] smallint  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [MonsterName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Speeds'
CREATE TABLE [dbo].[Speeds] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Distance] nvarchar(max)  NOT NULL,
    [MonsterName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Actions'
CREATE TABLE [dbo].[Actions] (
    [Name] nvarchar(max)  NOT NULL,
    [Desc] nvarchar(max)  NOT NULL,
    [Attack_Bonus] smallint  NULL,
    [Usage_Type] nvarchar(max)  NULL,
    [Usage_Times] smallint  NULL,
    [MonsterName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SpellCastingStats'
CREATE TABLE [dbo].[SpellCastingStats] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Level] smallint  NOT NULL,
    [Ability] nvarchar(max)  NOT NULL,
    [DC] smallint  NOT NULL,
    [Modifier] smallint  NOT NULL,
    [School] nvarchar(max)  NOT NULL,
    [L1_Slots] smallint  NOT NULL,
    [L2_Slots] smallint  NULL,
    [L3_Slots] smallint  NULL,
    [L4_Slots] smallint  NULL,
    [L5_Slots] smallint  NULL,
    [L6_Slots] smallint  NULL,
    [L7_Slots] smallint  NULL,
    [L8_Slots] smallint  NULL,
    [L9_Slots] smallint  NULL,
    [MonsterName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SpecialAbilities'
CREATE TABLE [dbo].[SpecialAbilities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Desc] nvarchar(max)  NOT NULL,
    [MonsterName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'LegendaryActions'
CREATE TABLE [dbo].[LegendaryActions] (
    [Name] nvarchar(max)  NOT NULL,
    [Desc] nvarchar(max)  NOT NULL,
    [Attack_Bonus] smallint  NULL,
    [MonsterName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Damages'
CREATE TABLE [dbo].[Damages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Damage_Type] nvarchar(max)  NOT NULL,
    [Damage_Dice] nvarchar(max)  NOT NULL,
    [ActionMonsterName] nvarchar(max)  NULL,
    [ActionName] nvarchar(max)  NULL,
    [LegendaryActionMonsterName] nvarchar(max)  NULL,
    [LegendaryActionName] nvarchar(max)  NULL
);
GO

-- Creating table 'DifficultyClasses'
CREATE TABLE [dbo].[DifficultyClasses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DC_Type] nvarchar(max)  NOT NULL,
    [DC_Value] smallint  NULL,
    [SpellName] nvarchar(max)  NULL,
    [ActionMonsterName] nvarchar(max)  NULL,
    [ActionName] nvarchar(max)  NULL,
    [LegendaryActionMonsterName] nvarchar(max)  NULL,
    [LegendaryActionName] nvarchar(max)  NULL
);
GO

-- Creating table 'Spells'
CREATE TABLE [dbo].[Spells] (
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Range] nvarchar(max)  NOT NULL,
    [Components] nvarchar(max)  NOT NULL,
    [IsRitual] nvarchar(max)  NOT NULL,
    [Duration] nvarchar(max)  NOT NULL,
    [IsConcentration] nvarchar(max)  NOT NULL,
    [Casting_Time] nvarchar(max)  NOT NULL,
    [Level] smallint  NOT NULL,
    [School] nvarchar(max)  NOT NULL,
    [Higher_Level] nvarchar(max)  NULL,
    [Material] nvarchar(max)  NULL,
    [Area_Of_Effect] nvarchar(max)  NULL
);
GO

-- Creating table 'SpellDamages'
CREATE TABLE [dbo].[SpellDamages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Damage_Type] nvarchar(max)  NOT NULL,
    [Damage_L1] nvarchar(max)  NULL,
    [Damage_L2] nvarchar(max)  NULL,
    [Damage_L3] nvarchar(max)  NULL,
    [Damage_L4] nvarchar(max)  NULL,
    [Damage_L5] nvarchar(max)  NULL,
    [Damage_L6] nvarchar(max)  NULL,
    [Damage_L7] nvarchar(max)  NULL,
    [Damage_L8] nvarchar(max)  NULL,
    [Damage_L9] nvarchar(max)  NULL,
    [Damage_L0] nvarchar(max)  NULL,
    [SpellName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SpellMonsterTables'
CREATE TABLE [dbo].[SpellMonsterTables] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SpellName] nvarchar(max)  NOT NULL,
    [MonsterName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Scenarios'
CREATE TABLE [dbo].[Scenarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Scenario_Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CharacterScenarioTables'
CREATE TABLE [dbo].[CharacterScenarioTables] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ScenarioId] int  NOT NULL,
    [PlayerCharacterBasicId] int  NOT NULL
);
GO

-- Creating table 'PlayerCharacterBasics'
CREATE TABLE [dbo].[PlayerCharacterBasics] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HP] int  NOT NULL,
    [AC] smallint  NOT NULL,
    [CR_2_Score] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MonsterScenarioTables'
CREATE TABLE [dbo].[MonsterScenarioTables] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ScenarioId] int  NOT NULL,
    [MonsterName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SpellHealings'
CREATE TABLE [dbo].[SpellHealings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Healing_L1] nvarchar(max)  NULL,
    [Healing_L2] nvarchar(max)  NULL,
    [Healing_L3] nvarchar(max)  NULL,
    [Healing_L4] nvarchar(max)  NULL,
    [Healing_L5] nvarchar(max)  NULL,
    [Healing_L6] nvarchar(max)  NULL,
    [Healing_L7] nvarchar(max)  NULL,
    [Healing_L8] nvarchar(max)  NULL,
    [Healing_L9] nvarchar(max)  NULL,
    [SpellName] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Name] in table 'Monsters'
ALTER TABLE [dbo].[Monsters]
ADD CONSTRAINT [PK_Monsters]
    PRIMARY KEY CLUSTERED ([Name] ASC);
GO

-- Creating primary key on [Id] in table 'Abilities'
ALTER TABLE [dbo].[Abilities]
ADD CONSTRAINT [PK_Abilities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ArmorClasses'
ALTER TABLE [dbo].[ArmorClasses]
ADD CONSTRAINT [PK_ArmorClasses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ConditionImmunities'
ALTER TABLE [dbo].[ConditionImmunities]
ADD CONSTRAINT [PK_ConditionImmunities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Proficiencies'
ALTER TABLE [dbo].[Proficiencies]
ADD CONSTRAINT [PK_Proficiencies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Speeds'
ALTER TABLE [dbo].[Speeds]
ADD CONSTRAINT [PK_Speeds]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MonsterName], [Name] in table 'Actions'
ALTER TABLE [dbo].[Actions]
ADD CONSTRAINT [PK_Actions]
    PRIMARY KEY CLUSTERED ([MonsterName], [Name] ASC);
GO

-- Creating primary key on [Id] in table 'SpellCastingStats'
ALTER TABLE [dbo].[SpellCastingStats]
ADD CONSTRAINT [PK_SpellCastingStats]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SpecialAbilities'
ALTER TABLE [dbo].[SpecialAbilities]
ADD CONSTRAINT [PK_SpecialAbilities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MonsterName], [Name] in table 'LegendaryActions'
ALTER TABLE [dbo].[LegendaryActions]
ADD CONSTRAINT [PK_LegendaryActions]
    PRIMARY KEY CLUSTERED ([MonsterName], [Name] ASC);
GO

-- Creating primary key on [Id] in table 'Damages'
ALTER TABLE [dbo].[Damages]
ADD CONSTRAINT [PK_Damages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DifficultyClasses'
ALTER TABLE [dbo].[DifficultyClasses]
ADD CONSTRAINT [PK_DifficultyClasses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Name] in table 'Spells'
ALTER TABLE [dbo].[Spells]
ADD CONSTRAINT [PK_Spells]
    PRIMARY KEY CLUSTERED ([Name] ASC);
GO

-- Creating primary key on [Id] in table 'SpellDamages'
ALTER TABLE [dbo].[SpellDamages]
ADD CONSTRAINT [PK_SpellDamages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SpellMonsterTables'
ALTER TABLE [dbo].[SpellMonsterTables]
ADD CONSTRAINT [PK_SpellMonsterTables]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Scenarios'
ALTER TABLE [dbo].[Scenarios]
ADD CONSTRAINT [PK_Scenarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CharacterScenarioTables'
ALTER TABLE [dbo].[CharacterScenarioTables]
ADD CONSTRAINT [PK_CharacterScenarioTables]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlayerCharacterBasics'
ALTER TABLE [dbo].[PlayerCharacterBasics]
ADD CONSTRAINT [PK_PlayerCharacterBasics]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MonsterScenarioTables'
ALTER TABLE [dbo].[MonsterScenarioTables]
ADD CONSTRAINT [PK_MonsterScenarioTables]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SpellHealings'
ALTER TABLE [dbo].[SpellHealings]
ADD CONSTRAINT [PK_SpellHealings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ScenarioId] in table 'CharacterScenarioTables'
ALTER TABLE [dbo].[CharacterScenarioTables]
ADD CONSTRAINT [FK_ScenarioCharacterScenarioTable]
    FOREIGN KEY ([ScenarioId])
    REFERENCES [dbo].[Scenarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ScenarioCharacterScenarioTable'
CREATE INDEX [IX_FK_ScenarioCharacterScenarioTable]
ON [dbo].[CharacterScenarioTables]
    ([ScenarioId]);
GO

-- Creating foreign key on [PlayerCharacterBasicId] in table 'CharacterScenarioTables'
ALTER TABLE [dbo].[CharacterScenarioTables]
ADD CONSTRAINT [FK_PlayerCharacterBasicCharacterScenarioTable]
    FOREIGN KEY ([PlayerCharacterBasicId])
    REFERENCES [dbo].[PlayerCharacterBasics]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerCharacterBasicCharacterScenarioTable'
CREATE INDEX [IX_FK_PlayerCharacterBasicCharacterScenarioTable]
ON [dbo].[CharacterScenarioTables]
    ([PlayerCharacterBasicId]);
GO

-- Creating foreign key on [ScenarioId] in table 'MonsterScenarioTables'
ALTER TABLE [dbo].[MonsterScenarioTables]
ADD CONSTRAINT [FK_ScenarioMonsterScenarioTable]
    FOREIGN KEY ([ScenarioId])
    REFERENCES [dbo].[Scenarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ScenarioMonsterScenarioTable'
CREATE INDEX [IX_FK_ScenarioMonsterScenarioTable]
ON [dbo].[MonsterScenarioTables]
    ([ScenarioId]);
GO

-- Creating foreign key on [SpellName] in table 'SpellMonsterTables'
ALTER TABLE [dbo].[SpellMonsterTables]
ADD CONSTRAINT [FK_SpellSpellMonsterTable]
    FOREIGN KEY ([SpellName])
    REFERENCES [dbo].[Spells]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SpellSpellMonsterTable'
CREATE INDEX [IX_FK_SpellSpellMonsterTable]
ON [dbo].[SpellMonsterTables]
    ([SpellName]);
GO

-- Creating foreign key on [SpellName] in table 'DifficultyClasses'
ALTER TABLE [dbo].[DifficultyClasses]
ADD CONSTRAINT [FK_SpellDifficultyClass]
    FOREIGN KEY ([SpellName])
    REFERENCES [dbo].[Spells]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SpellDifficultyClass'
CREATE INDEX [IX_FK_SpellDifficultyClass]
ON [dbo].[DifficultyClasses]
    ([SpellName]);
GO

-- Creating foreign key on [MonsterName] in table 'Actions'
ALTER TABLE [dbo].[Actions]
ADD CONSTRAINT [FK_MonsterAction]
    FOREIGN KEY ([MonsterName])
    REFERENCES [dbo].[Monsters]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MonsterName] in table 'LegendaryActions'
ALTER TABLE [dbo].[LegendaryActions]
ADD CONSTRAINT [FK_MonsterLegendaryAction]
    FOREIGN KEY ([MonsterName])
    REFERENCES [dbo].[Monsters]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MonsterName] in table 'SpecialAbilities'
ALTER TABLE [dbo].[SpecialAbilities]
ADD CONSTRAINT [FK_MonsterSpecialAbility]
    FOREIGN KEY ([MonsterName])
    REFERENCES [dbo].[Monsters]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MonsterSpecialAbility'
CREATE INDEX [IX_FK_MonsterSpecialAbility]
ON [dbo].[SpecialAbilities]
    ([MonsterName]);
GO

-- Creating foreign key on [MonsterName] in table 'ConditionImmunities'
ALTER TABLE [dbo].[ConditionImmunities]
ADD CONSTRAINT [FK_MonsterConditionImmunity]
    FOREIGN KEY ([MonsterName])
    REFERENCES [dbo].[Monsters]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MonsterConditionImmunity'
CREATE INDEX [IX_FK_MonsterConditionImmunity]
ON [dbo].[ConditionImmunities]
    ([MonsterName]);
GO

-- Creating foreign key on [MonsterName] in table 'SpellMonsterTables'
ALTER TABLE [dbo].[SpellMonsterTables]
ADD CONSTRAINT [FK_MonsterSpellMonsterTable]
    FOREIGN KEY ([MonsterName])
    REFERENCES [dbo].[Monsters]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MonsterSpellMonsterTable'
CREATE INDEX [IX_FK_MonsterSpellMonsterTable]
ON [dbo].[SpellMonsterTables]
    ([MonsterName]);
GO

-- Creating foreign key on [MonsterName] in table 'Proficiencies'
ALTER TABLE [dbo].[Proficiencies]
ADD CONSTRAINT [FK_MonsterProficiency]
    FOREIGN KEY ([MonsterName])
    REFERENCES [dbo].[Monsters]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MonsterProficiency'
CREATE INDEX [IX_FK_MonsterProficiency]
ON [dbo].[Proficiencies]
    ([MonsterName]);
GO

-- Creating foreign key on [MonsterName] in table 'SpellCastingStats'
ALTER TABLE [dbo].[SpellCastingStats]
ADD CONSTRAINT [FK_MonsterSpellCastingStats]
    FOREIGN KEY ([MonsterName])
    REFERENCES [dbo].[Monsters]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MonsterSpellCastingStats'
CREATE INDEX [IX_FK_MonsterSpellCastingStats]
ON [dbo].[SpellCastingStats]
    ([MonsterName]);
GO

-- Creating foreign key on [MonsterName] in table 'Abilities'
ALTER TABLE [dbo].[Abilities]
ADD CONSTRAINT [FK_MonsterAbilities]
    FOREIGN KEY ([MonsterName])
    REFERENCES [dbo].[Monsters]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MonsterAbilities'
CREATE INDEX [IX_FK_MonsterAbilities]
ON [dbo].[Abilities]
    ([MonsterName]);
GO

-- Creating foreign key on [MonsterName] in table 'ArmorClasses'
ALTER TABLE [dbo].[ArmorClasses]
ADD CONSTRAINT [FK_MonsterArmorClass]
    FOREIGN KEY ([MonsterName])
    REFERENCES [dbo].[Monsters]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MonsterArmorClass'
CREATE INDEX [IX_FK_MonsterArmorClass]
ON [dbo].[ArmorClasses]
    ([MonsterName]);
GO

-- Creating foreign key on [MonsterName] in table 'Speeds'
ALTER TABLE [dbo].[Speeds]
ADD CONSTRAINT [FK_MonsterSpeed]
    FOREIGN KEY ([MonsterName])
    REFERENCES [dbo].[Monsters]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MonsterSpeed'
CREATE INDEX [IX_FK_MonsterSpeed]
ON [dbo].[Speeds]
    ([MonsterName]);
GO

-- Creating foreign key on [MonsterName] in table 'MonsterScenarioTables'
ALTER TABLE [dbo].[MonsterScenarioTables]
ADD CONSTRAINT [FK_MonsterMonsterScenarioTable]
    FOREIGN KEY ([MonsterName])
    REFERENCES [dbo].[Monsters]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MonsterMonsterScenarioTable'
CREATE INDEX [IX_FK_MonsterMonsterScenarioTable]
ON [dbo].[MonsterScenarioTables]
    ([MonsterName]);
GO

-- Creating foreign key on [SpellName] in table 'SpellDamages'
ALTER TABLE [dbo].[SpellDamages]
ADD CONSTRAINT [FK_SpellSpellDamage]
    FOREIGN KEY ([SpellName])
    REFERENCES [dbo].[Spells]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SpellSpellDamage'
CREATE INDEX [IX_FK_SpellSpellDamage]
ON [dbo].[SpellDamages]
    ([SpellName]);
GO

-- Creating foreign key on [SpellName] in table 'SpellHealings'
ALTER TABLE [dbo].[SpellHealings]
ADD CONSTRAINT [FK_SpellSpellHealing]
    FOREIGN KEY ([SpellName])
    REFERENCES [dbo].[Spells]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SpellSpellHealing'
CREATE INDEX [IX_FK_SpellSpellHealing]
ON [dbo].[SpellHealings]
    ([SpellName]);
GO

-- Creating foreign key on [ActionMonsterName], [ActionName] in table 'Damages'
ALTER TABLE [dbo].[Damages]
ADD CONSTRAINT [FK_ActionDamage]
    FOREIGN KEY ([ActionMonsterName], [ActionName])
    REFERENCES [dbo].[Actions]
        ([MonsterName], [Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionDamage'
CREATE INDEX [IX_FK_ActionDamage]
ON [dbo].[Damages]
    ([ActionMonsterName], [ActionName]);
GO

-- Creating foreign key on [ActionMonsterName], [ActionName] in table 'DifficultyClasses'
ALTER TABLE [dbo].[DifficultyClasses]
ADD CONSTRAINT [FK_ActionDifficultyClass]
    FOREIGN KEY ([ActionMonsterName], [ActionName])
    REFERENCES [dbo].[Actions]
        ([MonsterName], [Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionDifficultyClass'
CREATE INDEX [IX_FK_ActionDifficultyClass]
ON [dbo].[DifficultyClasses]
    ([ActionMonsterName], [ActionName]);
GO

-- Creating foreign key on [LegendaryActionMonsterName], [LegendaryActionName] in table 'Damages'
ALTER TABLE [dbo].[Damages]
ADD CONSTRAINT [FK_LegendaryActionDamage]
    FOREIGN KEY ([LegendaryActionMonsterName], [LegendaryActionName])
    REFERENCES [dbo].[LegendaryActions]
        ([MonsterName], [Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LegendaryActionDamage'
CREATE INDEX [IX_FK_LegendaryActionDamage]
ON [dbo].[Damages]
    ([LegendaryActionMonsterName], [LegendaryActionName]);
GO

-- Creating foreign key on [LegendaryActionMonsterName], [LegendaryActionName] in table 'DifficultyClasses'
ALTER TABLE [dbo].[DifficultyClasses]
ADD CONSTRAINT [FK_LegendaryActionDifficultyClass]
    FOREIGN KEY ([LegendaryActionMonsterName], [LegendaryActionName])
    REFERENCES [dbo].[LegendaryActions]
        ([MonsterName], [Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LegendaryActionDifficultyClass'
CREATE INDEX [IX_FK_LegendaryActionDifficultyClass]
ON [dbo].[DifficultyClasses]
    ([LegendaryActionMonsterName], [LegendaryActionName]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------