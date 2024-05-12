using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DatabaseClassLibrary.Databases
{
    public partial class InitiativeTrackerDB : DbContext
    {
        public InitiativeTrackerDB(string databaseName)
            : base(databaseName)
        {
        }

        public virtual DbSet<Ability> Abilities { get; set; }
        public virtual DbSet<CombatAction> CombatActions { get; set; }
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
        public virtual DbSet<MonsterSpellTable> MonsterSpells { get; set; }
        public virtual DbSet<MonsterScenarioTable> MonsterScenarios {  get; set; }
        public virtual DbSet<PlayerScenarioTable> PlayerScenarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Scenario>()
                .HasMany(e => e.PlayerScenarios)
                .WithRequired(e => e.Scenario)
                .HasForeignKey(e => e.ScenarioID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Scenario>()
                .HasMany(e => e.MonsterScenarios)
                .WithRequired(e => e.Scenario)
                .HasForeignKey(e => e.ScenarioID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Monster>()
                .HasMany(e => e.Abilities)
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
                .HasMany(e => e.SpellMonsters)
                .WithRequired(e => e.Monster)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Monster>()
                .HasMany(e => e.MonsterScenarios)
                .WithRequired(e => e.Monster)
                .HasForeignKey(e => e.MonsterName)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Monster>()
                .HasMany(e => e.Senses)
                .WithRequired(e => e.Monster)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<Spell>()
                .HasMany(e => e.SpellMonsters)
                .WithRequired(e => e.Spell)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Monster>()
                .HasMany(m => m.CombatActions)
                .WithRequired(ca => ca.Monster)
                .HasForeignKey(ca => ca.MonsterName)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayerCharacterBasic>()
                .HasMany(e => e.PlayerScenarios)
                .WithRequired(e => e.Player)
                .HasForeignKey(e => e.PlayerID)
                .WillCascadeOnDelete(false);
        }


    }
}
