using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DatabaseModel.Databases
{
    public partial class InitiativeTrackerDB : DbContext
    {
        public InitiativeTrackerDB(string databaseName)
            : base(databaseName)
        {
        }

        public virtual DbSet<Ability> Abilities { get; set; }
        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<ArmorClass> ArmorClasses { get; set; }
        public virtual DbSet<ConditionImmunity> ConditionImmunities { get; set; }
        public virtual DbSet<Damage> Damages { get; set; }
        public virtual DbSet<DifficultyClass> DifficultyClasses { get; set; }
        public virtual DbSet<LegendaryAction> LegendaryActions { get; set; }
        public virtual DbSet<Monster> Monsters { get; set; }
        public virtual DbSet<PlayerCharacterBasic> PlayerCharacterBasics { get; set; }
        public virtual DbSet<Proficiency> Proficiencies { get; set; }
        public virtual DbSet<Scenario> Scenarios { get; set; }
        public virtual DbSet<Sense> Senses { get; set; }
        public virtual DbSet<SpecialAbility> SpecialAbilities { get; set; }
        public virtual DbSet<Speed> Speeds { get; set; }
        public virtual DbSet<SpellCastingStat> SpellCastingStats { get; set; }
        public virtual DbSet<SpellDamageAtCharacterLevel> SpellDamageAtCharacterLevels { get; set; }
        public virtual DbSet<SpellDamage> SpellDamages { get; set; }
        public virtual DbSet<SpellHealing> SpellHealings { get; set; }
        public virtual DbSet<Spell> Spells { get; set; }
        public virtual DbSet<Usage> Usages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Action>()
                .HasMany(e => e.Damages)
                .WithOptional(e => e.Action)
                .HasForeignKey(e => new { e.ActionName, e.ActionMonsterName });

            modelBuilder.Entity<Action>()
                .HasMany(e => e.DifficultyClasses)
                .WithOptional(e => e.Action)
                .HasForeignKey(e => new { e.ActionName, e.ActionMonsterName });

            modelBuilder.Entity<LegendaryAction>()
                .HasMany(e => e.Damages)
                .WithOptional(e => e.LegendaryAction)
                .HasForeignKey(e => new { e.LegendaryActionName, e.LegendaryActionMonsterName });

            modelBuilder.Entity<LegendaryAction>()
                .HasMany(e => e.DifficultyClasses)
                .WithOptional(e => e.LegendaryAction)
                .HasForeignKey(e => new { e.LegendaryActionName, e.LegendaryActionMonsterName });

            modelBuilder.Entity<Monster>()
                .HasMany(e => e.Abilities)
                .WithRequired(e => e.Monster)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Monster>()
                .HasMany(e => e.Actions)
                .WithRequired(e => e.Monster)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Monster>()
                .HasMany(e => e.ArmorClasses)
                .WithRequired(e => e.Monster)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Monster>()
                .HasMany(e => e.ConditionImmunities)
                .WithRequired(e => e.Monster)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Monster>()
                .HasMany(e => e.LegendaryActions)
                .WithRequired(e => e.Monster)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Monster>()
                .HasMany(e => e.Proficiencies)
                .WithRequired(e => e.Monster)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Monster>()
                .HasMany(e => e.SpecialAbilities)
                .WithRequired(e => e.Monster)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Monster>()
                .HasMany(e => e.Speeds)
                .WithRequired(e => e.Monster)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Monster>()
                .HasMany(e => e.SpellCastingStats)
                .WithRequired(e => e.Monster)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Monster>()
                .HasMany(e => e.Scenarios)
                .WithMany(e => e.Monsters)
                .Map(m => m.ToTable("MonsterScenarioTables").MapLeftKey("MonsterName").MapRightKey("ScenarioId"));

            modelBuilder.Entity<Monster>()
                .HasMany(e => e.Spells)
                .WithMany(e => e.Monsters)
                .Map(m => m.ToTable("SpellMonsterTables").MapLeftKey("MonsterName").MapRightKey("SpellName"));

            modelBuilder.Entity<PlayerCharacterBasic>()
                .HasMany(e => e.Scenarios)
                .WithMany(e => e.PlayerCharacterBasics)
                .Map(m => m.ToTable("CharacterScenarioTables").MapLeftKey("PlayerCharacterBasicId").MapRightKey("ScenarioId"));

            modelBuilder.Entity<Sense>()
                .Property(e => e.Darkvision)
                .IsUnicode(false);

            modelBuilder.Entity<Sense>()
                .Property(e => e.Truesight)
                .IsUnicode(false);

            modelBuilder.Entity<Sense>()
                .Property(e => e.Blindsight)
                .IsUnicode(false);

            modelBuilder.Entity<Sense>()
                .Property(e => e.Tremorsense)
                .IsUnicode(false);

            modelBuilder.Entity<Spell>()
                .HasMany(e => e.SpellDamageAtCharacterLevels)
                .WithRequired(e => e.Spell)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Spell>()
                .HasMany(e => e.SpellDamages)
                .WithRequired(e => e.Spell)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Spell>()
                .HasMany(e => e.SpellHealings)
                .WithRequired(e => e.Spell)
                .WillCascadeOnDelete(false);
        }
    }
}
