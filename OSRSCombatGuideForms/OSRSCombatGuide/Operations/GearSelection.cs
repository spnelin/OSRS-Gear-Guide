using OSRSCombatGuide.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRSCombatGuide.Server.Operations
{
    public class GearSelection
    {
        public static EquipmentSet OptimalMeleeDamageEquipment(Player player, Monster target, EquipmentCollection collection)
        {
            return OptimalMeleeDamageEquipment(player, target, collection, out double throwaway);
        }

        public static EquipmentSet OptimalMeleeDamageEquipment(Player player, Monster target, EquipmentCollection collection, out double setDps)
        {
            List<EquipmentSet> equipmentSets = new List<EquipmentSet>();
            //First, decide which attack types will be most effective against the target's defense
            EquipmentStat[] statPriority = new EquipmentStat[4];
            statPriority[0] = EquipmentStat.StrengthMelee;
            int defCrush = target.Stats.GetStat(EquipmentStat.DefenseCrush);
            int defSlash = target.Stats.GetStat(EquipmentStat.DefenseSlash);
            int defStab = target.Stats.GetStat(EquipmentStat.DefenseStab);
            if (defCrush < defSlash)
            {
                if (defCrush < defStab)
                {
                    statPriority[1] = EquipmentStat.DefenseCrush;
                    if (defSlash < defStab)
                    {
                        statPriority[2] = EquipmentStat.DefenseSlash;
                        statPriority[3] = EquipmentStat.DefenseStab;
                    }
                    else
                    {
                        statPriority[2] = EquipmentStat.DefenseStab;
                        statPriority[3] = EquipmentStat.DefenseSlash;
                    }
                }
                else
                {
                    statPriority[1] = EquipmentStat.DefenseStab;
                    statPriority[2] = EquipmentStat.DefenseCrush;
                    statPriority[3] = EquipmentStat.DefenseSlash;
                }
            }
            else
            {
                if (defCrush < defStab)
                {
                    statPriority[1] = EquipmentStat.DefenseSlash;
                    statPriority[2] = EquipmentStat.DefenseCrush;
                    statPriority[3] = EquipmentStat.DefenseStab;
                }
                else
                {
                    statPriority[3] = EquipmentStat.DefenseCrush;
                    if (defSlash < defStab)
                    {
                        statPriority[1] = EquipmentStat.DefenseSlash;
                        statPriority[2] = EquipmentStat.DefenseStab;
                    }
                    else
                    {
                        statPriority[1] = EquipmentStat.DefenseStab;
                        statPriority[2] = EquipmentStat.DefenseSlash;
                    }
                }
            }
            //Now get some weapons (and offhands, for one-handed weapons) and run comparisons
            List<EquipmentSet> potentialSets = new List<EquipmentSet>();
            Equipment bestOneHanded = collection.GetStrictBIS(EquipmentSlot.Weapon, statPriority);
            Equipment bestOffHand = collection.GetStrictBIS(EquipmentSlot.Shield, statPriority);
            Equipment bestTwoHanded = collection.GetStrictBIS(EquipmentSlot.TwoHanded, statPriority);
            List<Equipment> viableOneHanded = collection.GetAlternatives(bestOneHanded, statPriority);
            viableOneHanded.Add(bestOneHanded);
            List<Equipment> viableOffHand = collection.GetAlternatives(bestOffHand, statPriority);
            viableOffHand.Add(bestOffHand);
            List<Equipment> viableTwoHanded = collection.GetAlternatives(bestTwoHanded, statPriority);
            viableTwoHanded.Add(bestTwoHanded);
            //Put the weapons into "sets" to compare
            if (viableOneHanded.Count > 0)
            {
                foreach (Equipment equipment in viableOneHanded)
                {
                    if (viableOffHand.Count > 0)
                    {
                        foreach (Equipment offhand in viableOffHand)
                        {
                            Weapon weapon = (Weapon)equipment;
                            for (int i = 0; i < weapon.Type.Stances.Count; i++)
                            {
                                EquipmentSet set = new EquipmentSet();
                                set.CombatStyleIndex = i;
                                set.Equip(equipment);
                                set.Equip(offhand);
                                potentialSets.Add(set);
                            }
                        }
                    }
                }
            }
            if (viableTwoHanded.Count > 0)
            {
                foreach (Equipment equipment in viableTwoHanded)
                {
                    Weapon weapon = (Weapon)equipment;
                    for (int i = 0; i < weapon.Type.Stances.Count; i++)
                    {
                        EquipmentSet set = new EquipmentSet();
                        set.CombatStyleIndex = i;
                        set.Equip(equipment);
                        potentialSets.Add(set);
                    }
                }
            }
            if (potentialSets.Count == 0)
            {
                potentialSets.Add(new EquipmentSet());
            }
            double maxDPS = 0;
            EquipmentSet bestSet = null;
            foreach (EquipmentSet set in potentialSets)
            {
                Weapon weapon = (Weapon)set.Get(EquipmentSlot.Weapon);
                CombatStyle style = set.CombatStyle;
                CombatCalculator.MeleeDamagePerSecondArgs dpsArgs = new CombatCalculator.MeleeDamagePerSecondArgs(style.AttackStyle, style.AttackType, weapon.AttackSpeed);
                double dps = CombatCalculator.MeleeDamagePerSecond(player.Skills, set.FullEquipmentStats(), target.Skills, target.Stats, dpsArgs);
                if (dps > maxDPS)
                {
                    maxDPS = dps;
                    bestSet = set;
                }
            }
            //clear out unusable weapons from our potential sets
            potentialSets.Clear();
            potentialSets.Add(bestSet);
            //we have selected our combat style - now search for all equipment that maximizes that style
            statPriority = new EquipmentStat[] { EquipmentStat.StrengthMelee, Utility.AttackTypeToAttackStat(bestSet.CombatStyle.AttackType) };
            foreach (EquipmentSlot slot in new EquipmentSlot[] { EquipmentSlot.Body, EquipmentSlot.Cape, EquipmentSlot.Feet, EquipmentSlot.Hands, EquipmentSlot.Head, EquipmentSlot.Legs, EquipmentSlot.Neck, EquipmentSlot.Ring })
            {
                List<EquipmentSet> newPotentialSets = new List<EquipmentSet>();
                Equipment bis = collection.GetStrictBIS(slot, statPriority);
                if (bis == null)
                {
                    continue;
                }
                List<Equipment> alternatives = collection.GetAlternatives(bis, statPriority);
                alternatives.Add(bis);
                foreach (EquipmentSet set in potentialSets)
                {
                    foreach (Equipment alternative in alternatives)
                    {
                        EquipmentSet newSet = set.Clone();
                        newSet.Equip(alternative);
                        newPotentialSets.Add(newSet);
                    }
                }
                potentialSets = newPotentialSets;
            }
            //and now finally we identify the winner
            maxDPS = 0;
            bestSet = null;
            foreach (EquipmentSet set in potentialSets)
            {
                Weapon weapon = (Weapon)set.Get(EquipmentSlot.Weapon);
                CombatStyle style = set.CombatStyle;
                CombatCalculator.MeleeDamagePerSecondArgs dpsArgs = new CombatCalculator.MeleeDamagePerSecondArgs(style.AttackStyle, style.AttackType, weapon.AttackSpeed);
                double dps = CombatCalculator.MeleeDamagePerSecond(player.Skills, set.FullEquipmentStats(), target.Skills, target.Stats, dpsArgs);
                if (dps > maxDPS)
                {
                    maxDPS = dps;
                    bestSet = set;
                }
            }
            setDps = maxDPS;
            return bestSet;
        }
    }
}
