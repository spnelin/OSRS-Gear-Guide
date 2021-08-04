using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRSCombatGuide.Server.Data
{
    [Serializable]
    public class Equipment : Item
    {
        protected static Dictionary<string, Equipment> _nameLookup { get; set; } = new Dictionary<string, Equipment>();

        public StatSet Stats { get; private set; }
        public EquipmentSlot Slot { get; private set; }
        public List<SkillRequirement> Requirements { get; private set; }

        public static void CreateEquipment(string name, int id, string examine, CostInfo costInfo, StatSet stats, EquipmentSlot slot, List<SkillRequirement> requirements)
        {
            if (_nameLookup.ContainsKey(name))
            {
                //no dupes
            }
            else if (!stats.StatsAboveZero())
            {
                //no statless items
            }
            else if (EquipmentOffList.IsOffListed(name))
            {
                //no offlisted stuff
            }
            else
            {
                _nameLookup.Add(name, new Equipment(name, id, examine, costInfo, stats, slot, requirements));
            }
        }

        protected Equipment(string name, int id, string examine, CostInfo costInfo, StatSet stats, EquipmentSlot slot, List<SkillRequirement> requirements) : base(name, id, examine, costInfo)
        {
            Stats = stats;
            Slot = slot;
            Requirements = requirements;
            EquipmentCollection.AllEquipment.AddEquipment(this);
        }
    }

    [Serializable]
    public class StatSet
    {
        private int[] Stats { get; set; } = new int[14];

        public void SetStat(EquipmentStat stat, int value)
        {
            Stats[(int)stat] = value;
        }

        public int GetStat(EquipmentStat stat)
        {
            return Stats[(int)stat];
        }

        public bool StatsAboveZero()
        {
            return Stats.Any(a => a > 0);
        }

        public StatSet()
        {

        }

        public StatSet (int attackStab, int attackSlash, int attackCrush, int attackMagic, int attackRanged, int defenseStab, int defenseSlash, int defenseCrush, int defenseMagic, int defenseRanged, int strengthMelee, int strengthRanged, int strengthMagic, int prayer)
        {
            Stats[0] = attackStab;
            Stats[1] = attackSlash;
            Stats[2] = attackCrush;
            Stats[3] = attackMagic;
            Stats[4] = attackRanged;
            Stats[5] = defenseStab;
            Stats[6] = defenseSlash;
            Stats[7] = defenseCrush;
            Stats[8] = defenseMagic;
            Stats[9] = defenseRanged;
            Stats[10] = strengthMelee;
            Stats[11] = strengthRanged;
            Stats[12] = strengthMagic;
            Stats[13] = prayer;
        }

        public StatSet (List<StatSet> contributingSets)
        {
            foreach (StatSet set in contributingSets)
            {
                for (int i = 0; i < 14; i++)
                {
                    Stats[i] += set.GetStat((EquipmentStat)i);
                }
            }
        }
    }

    [Serializable]
    public class SkillRequirement
    {
        public Skill Skill { get; private set; }
        public int Requirement { get; private set; }
        public bool MatchesSet(SkillSet skillSet)
        {
            return skillSet.GetLevel(Skill) >= Requirement;
        }
        public SkillRequirement(Skill skill, int requirement)
        {
            Skill = skill;
            Requirement = requirement;
        }
    }

    public enum EquipmentStat
    {
        AttackStab,
        AttackSlash,
        AttackCrush,
        AttackMagic,
        AttackRanged,
        DefenseStab,
        DefenseSlash,
        DefenseCrush,
        DefenseMagic,
        DefenseRanged,
        StrengthMelee,
        StrengthRanged,
        StrengthMagic,
        Prayer
    }

    public enum EquipmentSlot
    {
        Head,
        Cape,
        Neck,
        Ammo,
        Weapon,
        Shield,
        Body,
        Legs,
        Hands,
        Feet,
        Ring,
        TwoHanded
    }
}
