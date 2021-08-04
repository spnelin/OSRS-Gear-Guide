using OSRSCombatGuide.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRSCombatGuide.Server.Operations
{
    public static class Utility
    {
        public static EquipmentStat AttackTypeToAttackStat(AttackType type)
        {
            switch (type)
            {
                case AttackType.Crush:
                    return EquipmentStat.AttackCrush;
                case AttackType.Magic:
                    return EquipmentStat.AttackMagic;
                case AttackType.Ranged:
                    return EquipmentStat.AttackRanged;
                case AttackType.Slash:
                    return EquipmentStat.AttackSlash;
                case AttackType.Stab:
                    return EquipmentStat.AttackStab;
                default:
                    throw new ArgumentException();
            }
        }

        public static EquipmentStat AttackTypeToDefenseStat(AttackType type)
        {
            switch (type)
            {
                case AttackType.Crush:
                    return EquipmentStat.DefenseCrush;
                case AttackType.Magic:
                    return EquipmentStat.DefenseMagic;
                case AttackType.Ranged:
                    return EquipmentStat.DefenseRanged;
                case AttackType.Slash:
                    return EquipmentStat.DefenseSlash;
                case AttackType.Stab:
                    return EquipmentStat.DefenseStab;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
