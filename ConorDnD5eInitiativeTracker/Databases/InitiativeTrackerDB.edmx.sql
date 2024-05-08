
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/08/2024 17:22:25
-- Generated from EDMX file: C:\Users\ckori\Documents\ConorDnD5eInitiativeTracker\ConorDnD5eInitiativeTracker\Databases\InitiativeTrackerDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------
-- Drop foreign key constraints
ALTER TABLE [dbo].[CharacterScenarioTables] DROP CONSTRAINT [FK_ScenarioCharacterScenarioTable];
ALTER TABLE [dbo].[CharacterScenarioTables] DROP CONSTRAINT [FK_PlayerCharacterBasicCharacterScenarioTable];
ALTER TABLE [dbo].[MonsterScenarioTables] DROP CONSTRAINT [FK_ScenarioMonsterScenarioTable];
ALTER TABLE [dbo].[SpellMonsterTables] DROP CONSTRAINT [FK_SpellSpellMonsterTable];
ALTER TABLE [dbo].[DifficultyClasses] DROP CONSTRAINT [FK_SpellDifficultyClass];
ALTER TABLE [dbo].[Actions] DROP CONSTRAINT [FK_MonsterAction];
ALTER TABLE [dbo].[LegendaryActions] DROP CONSTRAINT [FK_MonsterLegendaryAction];
ALTER TABLE [dbo].[SpecialAbilities] DROP CONSTRAINT [FK_MonsterSpecialAbility];
ALTER TABLE [dbo].[ConditionImmunities] DROP CONSTRAINT [FK_MonsterConditionImmunity];
ALTER TABLE [dbo].[SpellMonsterTables] DROP CONSTRAINT [FK_MonsterSpellMonsterTable];
ALTER TABLE [dbo].[SpellCastingStats] DROP CONSTRAINT [FK_MonsterSpellCastingStats];
ALTER TABLE [dbo].[Abilities] DROP CONSTRAINT [FK_MonsterAbilities];
ALTER TABLE [dbo].[ArmorClasses] DROP CONSTRAINT [FK_MonsterArmorClass];
ALTER TABLE [dbo].[Speeds] DROP CONSTRAINT [FK_MonsterSpeed];
ALTER TABLE [dbo].[MonsterScenarioTables] DROP CONSTRAINT [FK_MonsterMonsterScenarioTable];
ALTER TABLE [dbo].[SpellDamages] DROP CONSTRAINT [FK_SpellSpellDamage];
ALTER TABLE [dbo].[SpellHealings] DROP CONSTRAINT [FK_SpellSpellHealing];
ALTER TABLE [dbo].[Damages] DROP CONSTRAINT [FK_ActionDamage];
ALTER TABLE [dbo].[DifficultyClasses] DROP CONSTRAINT [FK_ActionDifficultyClass];
ALTER TABLE [dbo].[Damages] DROP CONSTRAINT [FK_LegendaryActionDamage];
ALTER TABLE [dbo].[DifficultyClasses] DROP CONSTRAINT [FK_LegendaryActionDifficultyClass];
ALTER TABLE [dbo].[SpellDamageAtCharacterLevels] DROP CONSTRAINT [FK_SpellSpellDamageAtCharacterLevel];


-- Drop tables

DROP TABLE [dbo].[Abilities];
DROP TABLE [dbo].[ArmorClasses];
DROP TABLE [dbo].[ConditionImmunities];
DROP TABLE [dbo].[Proficiencies];
DROP TABLE [dbo].[Speeds];
DROP TABLE [dbo].[Actions];
DROP TABLE [dbo].[SpellCastingStats];
DROP TABLE [dbo].[SpecialAbilities];
DROP TABLE [dbo].[LegendaryActions];
DROP TABLE [dbo].[Damages];
DROP TABLE [dbo].[DifficultyClasses];
DROP TABLE [dbo].[Spells];
DROP TABLE [dbo].[SpellDamages];
DROP TABLE [dbo].[SpellMonsterTables];
DROP TABLE [dbo].[Scenarios];
DROP TABLE [dbo].[CharacterScenarioTables];
DROP TABLE [dbo].[PlayerCharacterBasics];
DROP TABLE [dbo].[MonsterScenarioTables];
DROP TABLE [dbo].[SpellHealings];
DROP TABLE [dbo].[SpellDamageAtCharacterLevels];
DROP TABLE [dbo].[Monsters];

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Monsters'
CREATE TABLE [dbo].[Monsters] (
    [Name] nvarchar(200)  NOT NULL,
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
    [MonsterName] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'ArmorClasses'
CREATE TABLE [dbo].[ArmorClasses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ac_Type] nvarchar(max)  NOT NULL,
    [AC] smallint  NOT NULL,
    [MonsterName] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'ConditionImmunities'
CREATE TABLE [dbo].[ConditionImmunities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [URL] nvarchar(max)  NOT NULL,
    [MonsterName] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'Proficiencies'
CREATE TABLE [dbo].[Proficiencies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Bonus] smallint  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [MonsterName] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'Speeds'
CREATE TABLE [dbo].[Speeds] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Distance] nvarchar(max)  NOT NULL,
    [MonsterName] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'Actions'
CREATE TABLE [dbo].[Actions] (
    [Name] nvarchar(200)  NOT NULL,
    [Desc] nvarchar(max)  NOT NULL,
    [Attack_Bonus] smallint  NULL,
    [Usage_Type] nvarchar(max)  NULL,
    [Usage_Times] smallint  NULL,
    [MonsterName] nvarchar(200)  NOT NULL
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
    [MonsterName] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'SpecialAbilities'
CREATE TABLE [dbo].[SpecialAbilities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Desc] nvarchar(max)  NOT NULL,
    [MonsterName] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'LegendaryActions'
CREATE TABLE [dbo].[LegendaryActions] (
    [Name] nvarchar(200)  NOT NULL,
    [Desc] nvarchar(max)  NOT NULL,
    [Attack_Bonus] smallint  NULL,
    [MonsterName] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'Damages'
CREATE TABLE [dbo].[Damages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Damage_Type] nvarchar(max)  NOT NULL,
    [Damage_Dice] nvarchar(max)  NOT NULL,
    [ActionMonsterName] nvarchar(200)  NULL,
    [ActionName] nvarchar(200)  NULL,
    [LegendaryActionMonsterName] nvarchar(200)  NULL,
    [LegendaryActionName] nvarchar(200)  NULL
);
GO

-- Creating table 'DifficultyClasses'
CREATE TABLE [dbo].[DifficultyClasses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DC_Type] nvarchar(max)  NOT NULL,
    [DC_Value] smallint  NULL,
    [SpellName] nvarchar(200)  NULL,
    [ActionMonsterName] nvarchar(200)  NULL,
    [ActionName] nvarchar(200)  NULL,
    [LegendaryActionMonsterName] nvarchar(200)  NULL,
    [LegendaryActionName] nvarchar(200)  NULL
);
GO

-- Creating table 'Spells'
CREATE TABLE [dbo].[Spells] (
    [Name] nvarchar(200)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Range] nvarchar(max)  NOT NULL,
    [Components] nvarchar(max)  NOT NULL,
    [IsRitual] bit  NOT NULL,
    [Duration] nvarchar(max)  NOT NULL,
    [IsConcentration] bit  NOT NULL,
    [Casting_Time] nvarchar(max)  NOT NULL,
    [Level] int  NOT NULL,
    [School] nvarchar(max)  NOT NULL,
    [Higher_Level] nvarchar(max)  NULL,
    [Material] nvarchar(max)  NULL,
    [Area_Of_Effect_Type] nvarchar(max)  NULL,
    [Area_Of_Effect_Size] int  NULL,
    [DC_Type] nvarchar(max)  NULL,
    [DC_Success] nvarchar(max)  NULL
);
GO

-- Creating table 'SpellDamages'
CREATE TABLE [dbo].[SpellDamages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Damage_Type] nvarchar(max)  NULL,
    [Damage_L1] nvarchar(max)  NULL,
    [Damage_L2] nvarchar(max)  NULL,
    [Damage_L3] nvarchar(max)  NULL,
    [Damage_L4] nvarchar(max)  NULL,
    [Damage_L5] nvarchar(max)  NULL,
    [Damage_L6] nvarchar(max)  NULL,
    [Damage_L7] nvarchar(max)  NULL,
    [Damage_L8] nvarchar(max)  NULL,
    [Damage_L9] nvarchar(max)  NULL,
    [SpellName] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'SpellMonsterTables'
CREATE TABLE [dbo].[SpellMonsterTables] (
    [SpellName] nvarchar(200)  NOT NULL,
    [MonsterName] nvarchar(200)  NOT NULL
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
    [ScenarioId] int  NOT NULL,
    [MonsterName] nvarchar(200)  NOT NULL
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
    [SpellName] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'SpellDamageAtCharacterLevels'
CREATE TABLE [dbo].[SpellDamageAtCharacterLevels] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Damage_Type] nvarchar(max)  NULL,
    [Damage_L1] nvarchar(max)  NULL,
    [Damage_L2] nvarchar(max)  NULL,
    [Damage_L3] nvarchar(max)  NULL,
    [Damage_L4] nvarchar(max)  NULL,
    [Damage_L5] nvarchar(max)  NULL,
    [Damage_L6] nvarchar(max)  NULL,
    [Damage_L7] nvarchar(max)  NULL,
    [Damage_L8] nvarchar(max)  NULL,
    [Damage_L9] nvarchar(max)  NULL,
    [Damage_L10] nvarchar(max)  NULL,
    [Damage_L11] nvarchar(max)  NULL,
    [Damage_L12] nvarchar(max)  NULL,
    [Damage_L13] nvarchar(max)  NULL,
    [Damage_L14] nvarchar(max)  NULL,
    [Damage_L15] nvarchar(max)  NULL,
    [Damage_L16] nvarchar(max)  NULL,
    [Damage_L17] nvarchar(max)  NULL,
    [Damage_L18] nvarchar(max)  NULL,
    [Damage_L19] nvarchar(max)  NULL,
    [Damage_L20] nvarchar(max)  NULL,
    [SpellName] nvarchar(200)  NOT NULL
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

-- Creating primary key on [SpellName], [MonsterName] in table 'SpellMonsterTables'
ALTER TABLE [dbo].[SpellMonsterTables]
ADD CONSTRAINT [PK_SpellMonsterTables]
    PRIMARY KEY CLUSTERED ([SpellName], [MonsterName] ASC);
GO

-- Creating primary key on [Id] in table 'Scenarios'
ALTER TABLE [dbo].[Scenarios]
ADD CONSTRAINT [PK_Scenarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ScenarioId], [PlayerCharacterBasicId] in table 'CharacterScenarioTables'
ALTER TABLE [dbo].[CharacterScenarioTables]
ADD CONSTRAINT [PK_CharacterScenarioTables]
    PRIMARY KEY CLUSTERED ([ScenarioId], [PlayerCharacterBasicId] ASC);
GO

-- Creating primary key on [Id] in table 'PlayerCharacterBasics'
ALTER TABLE [dbo].[PlayerCharacterBasics]
ADD CONSTRAINT [PK_PlayerCharacterBasics]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ScenarioId], [MonsterName] in table 'MonsterScenarioTables'
ALTER TABLE [dbo].[MonsterScenarioTables]
ADD CONSTRAINT [PK_MonsterScenarioTables]
    PRIMARY KEY CLUSTERED ([ScenarioId], [MonsterName] ASC);
GO

-- Creating primary key on [Id] in table 'SpellHealings'
ALTER TABLE [dbo].[SpellHealings]
ADD CONSTRAINT [PK_SpellHealings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SpellDamageAtCharacterLevels'
ALTER TABLE [dbo].[SpellDamageAtCharacterLevels]
ADD CONSTRAINT [PK_SpellDamageAtCharacterLevels]
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

-- Creating foreign key on [SpellName] in table 'SpellMonsterTables'
ALTER TABLE [dbo].[SpellMonsterTables]
ADD CONSTRAINT [FK_SpellSpellMonsterTable]
    FOREIGN KEY ([SpellName])
    REFERENCES [dbo].[Spells]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
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

-- Creating foreign key on [SpellName] in table 'SpellDamageAtCharacterLevels'
ALTER TABLE [dbo].[SpellDamageAtCharacterLevels]
ADD CONSTRAINT [FK_SpellSpellDamageAtCharacterLevel]
    FOREIGN KEY ([SpellName])
    REFERENCES [dbo].[Spells]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SpellSpellDamageAtCharacterLevel'
CREATE INDEX [IX_FK_SpellSpellDamageAtCharacterLevel]
ON [dbo].[SpellDamageAtCharacterLevels]
    ([SpellName]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------