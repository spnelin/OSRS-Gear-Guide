using OSRSCombatGuide.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRSCombatGuide.Server.Operations
{
    public static class CombatCalculator
    {
        private static int _maxHit = 0;

        //Todo: abstract away Player and Monster. We only need the suitable bonuses to calculate this.
        public static double MeleeDamagePerSecond(SkillSet attackerSkills, StatSet attackerStats, SkillSet defenderSkills, StatSet defenderStats, MeleeDamagePerSecondArgs args)
        {
            AttackStyle style = args.AttackStyle;
            AttackType type = args.AttackType;
            //note: this does not reflect Controlled properly
            double chanceToHit = GetMeleeChanceToHit(
                attackerSkills.GetLevel(Skill.Attack), 
                attackerStats.GetStat(Utility.AttackTypeToAttackStat(type)), 
                defenderSkills.GetLevel(Skill.Defense), 
                defenderStats.GetStat(Utility.AttackTypeToDefenseStat(type)), 
                style == AttackStyle.Accurate);
            int maxHit = GetMeleeMaxHit(
                attackerSkills.GetLevel(Skill.Strength), 
                attackerStats.GetStat(EquipmentStat.StrengthMelee), 
                style == AttackStyle.Aggressive);
            if (maxHit > _maxHit)
            {
                _maxHit = maxHit;
            }
            double damagePerHit = (maxHit * chanceToHit) / 2;
            double damagePerTick = damagePerHit / args.AttackSpeed;
            return damagePerTick * (5 / 3);
        }

        public class MeleeDamagePerSecondArgs
        {
            public AttackStyle AttackStyle { get; private set; }
            public AttackType AttackType { get; private set; }
            public int AttackSpeed { get; private set; }

            public MeleeDamagePerSecondArgs(AttackStyle attackStyle, AttackType attackType, int attackSpeed)
            {
                AttackStyle = attackStyle;
                AttackType = attackType;
                AttackSpeed = attackSpeed;
            }
        }

        private static double GetMeleeChanceToHit(int attack, int attackBonus, int defense, int defenseBonus, bool trainingAttack)
        {
            int effectiveAttack = attack + 8 + (trainingAttack ? 3 : 0);
            double attackRoll = effectiveAttack * (attackBonus + 64);
            double defenseRoll = (defense + 9) * (defenseBonus + 64);
            return attackRoll > defenseRoll ? 1 - ((defenseRoll + 2) / (2 * attackRoll + 1)) : attackRoll / (2 * (defenseRoll + 1));
        }

        private static int GetMeleeMaxHit(int strength, int strengthBonus, bool trainingStrength)
        {
            int effectiveStrength = strength + 8 + (trainingStrength ? 3 : 0);
            return ((effectiveStrength * (strengthBonus + 64)) + 320) / 640;
        }
    }
}
