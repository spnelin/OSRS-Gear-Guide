using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRSCombatGuide.Server.Data
{
    [Serializable]
    public class Weapon : Equipment
    {
        public bool TwoHanded { get; private set; }
        public int AttackSpeed { get; private set; }
        public WeaponType Type { get; private set; }

        public static void CreateWeapon(string name, int id, string examine, CostInfo costInfo, StatSet stats, EquipmentSlot slot, List<SkillRequirement> requirements, int attackSpeed, WeaponType type)
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
                _nameLookup.Add(name, new Weapon(name, id, examine, costInfo, stats, slot, requirements, attackSpeed, type));
            }
        }

        protected Weapon(string name, int id, string examine, CostInfo costInfo, StatSet stats, EquipmentSlot slot, List<SkillRequirement> requirements, int attackSpeed, WeaponType type) : base(name, id, examine, costInfo, stats, slot, requirements)
        {
            TwoHanded = slot == EquipmentSlot.TwoHanded;
            AttackSpeed = attackSpeed;
            Type = type;
        }
    }

    [Serializable]
    public class WeaponType
    {
        private static Dictionary<string, WeaponType> _WeaponTypes = new Dictionary<string, WeaponType>();

        public static WeaponType Create(string name, List<CombatStyle> stances)
        {
            if (!_WeaponTypes.ContainsKey(name))
            {
                _WeaponTypes.Add(name, new WeaponType(name, stances));
            }
            return _WeaponTypes[name];
        }

        public string Name { get; private set; }
        public List<CombatStyle> Stances { get; private set; }

        private WeaponType(string name, List<CombatStyle> stances)
        {
            Name = name;
            Stances = stances;
        }
    }

    [Serializable]
    public class CombatStyle
    {
        public string Name { get; private set; }
        public AttackType AttackType { get; private set; }
        public AttackStyle AttackStyle { get; private set; }

        public CombatStyle(string name, AttackType attackType, AttackStyle attackStyle)
        {
            Name = name;
            AttackType = attackType;
            AttackStyle = attackStyle;
        }
    }

    public enum AttackType
    {
        Stab,
        Slash,
        Crush,
        Magic,
        Ranged
    }

    public enum AttackStyle
    {
        Accurate,
        Aggressive,
        Defensive,
        Controlled,
        Rapid,
        Longrange,
        Magic,
        MonsterNeutral
    }
}
