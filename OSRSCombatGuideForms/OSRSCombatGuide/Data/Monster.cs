using OSRSCombatGuide.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRSCombatGuide.Server.Data
{
    [Serializable]
    public class Monster
    {
        public static List<Monster> AllMonsters = new List<Monster>();

        public static Trie<Monster> MonsterLookup = new Trie<Monster>();

        public string Name { get; private set; }
        public int Id { get; private set; }
        public int AttackSpeed { get; private set; }
        public SkillSet Skills { get; private set; }
        public StatSet Stats { get; private set; }
        //public List<MonsterAttackType> AttackTypes { get; private set; }
        //todo: add drops and slayer info

        public override string ToString()
        {
            return Name;
        }

        public Monster(string name, int id, int attackSpeed, SkillSet skills, StatSet stats)
        {
            Name = name;
            Id = id;
            AttackSpeed = attackSpeed;
            Skills = skills;
            Stats = stats;
            AllMonsters.Add(this);
            MonsterLookup.Add(name, this);
        }
    }

    public enum MonsterAttackType
    {
        Melee,
        Magic,
        Ranged,
        MagicalMelee,
        MagicalRanged,
        RangedMelee,
        Dragonfire
    }
}
