using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRSCombatGuide.Server.Data
{
    [Serializable]
    public class Player
    {
        public SkillSet Skills { get; private set; }
        public EquipmentSet Equipment { get; private set; }
        public EquipmentCollection AvailableEquipment { get; private set; }

        public void EquipSet(EquipmentSet set)
        {
            Equipment = set;
        }

        public Player()
        {
            Skills = new SkillSet();
            Equipment = new EquipmentSet();
            AvailableEquipment = new EquipmentCollection();
        }

        public Player(SkillSet skills, EquipmentSet equipment, EquipmentCollection availableEquipment)
        {
            Skills = skills;
            Equipment = equipment;
            AvailableEquipment = availableEquipment;
        }
    }

    [Serializable]
    public class SkillSet
    {
        private int[] _Skills { get; set; }
        public void SetLevel(Skill skill, int level)
        {
            _Skills[(int)skill] = level;
        }
        public int GetLevel(Skill skill)
        {
            return _Skills[(int)skill];
        }
        public SkillSet()
        {
            _Skills = new int[7];
            for (int i = 0; i < _Skills.Length; i++)
            {
                _Skills[i] = 1;
            }
        }
        public SkillSet(int attack, int strength, int defense, int ranged, int magic, int prayer, int hitpoints) : this()
        {
            _Skills[(int)Skill.Attack] = attack;
            _Skills[(int)Skill.Strength] = strength;
            _Skills[(int)Skill.Defense] = defense;
            _Skills[(int)Skill.Ranged] = ranged;
            _Skills[(int)Skill.Magic] = magic;
            _Skills[(int)Skill.Prayer] = prayer;
            _Skills[(int)Skill.Hitpoints] = hitpoints;
        }
    }

    public enum Skill
    {
        Attack,
        Strength,
        Defense,
        Ranged,
        Magic,
        Prayer,
        Hitpoints
    }
}
