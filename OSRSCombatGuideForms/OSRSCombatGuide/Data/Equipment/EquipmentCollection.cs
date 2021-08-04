using OSRSCombatGuide.Data;
using OSRSCombatGuide.Server.Operations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Xml;

namespace OSRSCombatGuide.Server.Data
{
    [Serializable]
    public class EquipmentCollection
    {
        public static EquipmentCollection AllEquipment { get; private set; } = new EquipmentCollection();

        private List<Equipment>[,] EquipmentByStats { get; set; }

        public List<Equipment> Equipment { get; private set; }

        public Trie<Equipment> EquipmentLookup { get; private set; } 

        public static void LoadAllEquipment(string filepath)
        {
            AllEquipment = Load(filepath);
        }

        public void Save(string filepath)
        {
            FileStream stream = new FileStream(filepath, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Close();
        }

        public static EquipmentCollection Load(string filepath)
        {
            FileStream stream = new FileStream(filepath, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            EquipmentCollection collection = (EquipmentCollection)formatter.Deserialize(stream);
            stream.Close();
            return collection;
        }

        public void AddEquipment(Equipment equipment)
        {
            Equipment.Add(equipment);
            int slot = (int)equipment.Slot;
            for (int stat = 0; stat < EquipmentByStats.GetLength(1); stat++)
            {
                int newStat = equipment.Stats.GetStat((EquipmentStat)stat);
                bool placed = false;
                for (int j = 0; j < EquipmentByStats[slot, stat].Count; j++)
                {
                    if (EquipmentByStats[slot, stat][j].Stats.GetStat((EquipmentStat)stat) < newStat)
                    {
                        EquipmentByStats[slot, stat].Insert(j, equipment);
                        placed = true;
                        break;
                    }
                }
                if (!placed)
                {
                    EquipmentByStats[slot, stat].Add(equipment);
                }
            }
            EquipmentLookup.Add(equipment.Name, equipment);
        }

        public bool RemoveEquipment(Equipment equipment)
        {
            int slot = (int)equipment.Slot;
            if (Equipment.Remove(equipment))
            {
                for (int stat = 0; stat < EquipmentByStats.GetLength(1); stat++)
                {
                    EquipmentByStats[slot, stat].Remove(equipment);
                }
                return true;
            }
            return false;
        }

        public List<Equipment> EquipmentBySlot(EquipmentSlot slot)
        {
            return EquipmentByStats[(int)slot, 0];
        }

        public Equipment GetStrictBIS(EquipmentSlot slot, EquipmentStat[] statPriority)
        {
            List<Equipment> validChoices = new List<Equipment>();
            int statIndex = 0;
            while (statIndex < statPriority.Length && EquipmentByStats[(int)slot, (int)statPriority[statIndex]].Count == 0)
            {
                statIndex++;
            }
            if (statIndex == statPriority.Length)
            {
                return null;
            }
            int maxStat = EquipmentByStats[(int)slot, (int)statPriority[statIndex]][0].Stats.GetStat(statPriority[statIndex]);
            for (int i = 0; i < EquipmentByStats[(int)slot, (int)statPriority[statIndex]].Count; i++)
            {
                if (EquipmentByStats[(int)slot, (int)statPriority[statIndex]][i].Stats.GetStat(statPriority[statIndex]) == maxStat)
                {
                    validChoices.Add(EquipmentByStats[(int)slot, (int)statPriority[statIndex]][i]);
                }
                else
                {
                    break;
                }
            }
            if (validChoices.Count == 1)
            {
                return validChoices[0];
            }
            for (int i = 0; i < statPriority.Length; i++)
            {
                if (i == statIndex)
                {
                    continue;
                }
                validChoices.Sort((a, b) => b.Stats.GetStat(statPriority[i]).CompareTo(a.Stats.GetStat(statPriority[i])));
                maxStat = validChoices[0].Stats.GetStat(statPriority[i]);
                validChoices.RemoveAll(a => a.Stats.GetStat(statPriority[i]) != maxStat);
                if (validChoices.Count == 1)
                {
                    return validChoices[0];
                }
            }
            return validChoices[0];
        }

        public List<Equipment> GetAlternatives(Equipment bis, EquipmentStat[] statPriority)
        {
            List<Equipment> validChoices = new List<Equipment>();
            if (bis == null)
            {
                return validChoices;
            }
            int slot = (int)bis.Slot;
            for (int statIndex = 1; statIndex < statPriority.Length; statIndex++)
            {
                List<Equipment> statEquipment = EquipmentByStats[slot, (int)statPriority[statIndex]];
                Equipment bestStatEquipment = statEquipment[0];
                for (int i = 1; i < statEquipment.Count; i++)
                {
                    if (statEquipment[i] == bis)
                    {
                        break;
                    }
                    else
                    {
                        for (int j = 0; j < statPriority.Length; j++)
                        {
                            if (j == statIndex)
                            {
                                continue;
                            }
                            if (statEquipment[i].Stats.GetStat(statPriority[j]) > bestStatEquipment.Stats.GetStat(statPriority[j]))
                            {
                                validChoices.Add(statEquipment[i]);
                                break;
                            }
                        }
                    }
                }
            }
            return validChoices;
        }

        public List<EquipmentDpsAdvantage> GetMeleeUpgrades(Player player, EquipmentSet startingSet, EquipmentCollection previousCollection, Monster target)
        {
            List<EquipmentDpsAdvantage> ret = new List<EquipmentDpsAdvantage>();
            EquipmentStat[] statPriority = new EquipmentStat[] { EquipmentStat.StrengthMelee, Utility.AttackTypeToAttackStat(startingSet.CombatStyle.AttackType) };
            double baseDps = CombatCalculator.MeleeDamagePerSecond(player.Skills, startingSet.FullEquipmentStats(), target.Skills, target.Stats, 
                new CombatCalculator.MeleeDamagePerSecondArgs(startingSet.CombatStyle.AttackStyle, startingSet.CombatStyle.AttackType, ((Weapon)startingSet.Get(EquipmentSlot.Weapon)).AttackSpeed));
            bool weaponTwoHanded = ((Weapon)startingSet.Get(EquipmentSlot.Weapon)).Slot == EquipmentSlot.TwoHanded;
            for (int slotNum = 0; slotNum < 11; slotNum++)
            {
                EquipmentSlot slot = (EquipmentSlot)slotNum;
                if (weaponTwoHanded)
                {
                    if (slot == EquipmentSlot.Weapon)
                    {
                        slot = EquipmentSlot.TwoHanded;
                    }
                    if (slot == EquipmentSlot.Shield)
                    {
                        continue;
                    }
                }
                for (int statIndex = 0; statIndex < statPriority.Length; statIndex++)
                {
                    int equipmentIndex = 0;
                    while (equipmentIndex < EquipmentByStats[slotNum, (int)statPriority[statIndex]].Count && EquipmentByStats[slotNum, (int)statPriority[statIndex]][equipmentIndex].Stats.GetStat(statPriority[statIndex]) > (startingSet.Get(slot) == null ? 0 : startingSet.Get(slot).Stats.GetStat(statPriority[statIndex])))
                    {
                        EquipmentSet set = startingSet.Clone();
                        set.Equip(EquipmentByStats[slotNum, (int)statPriority[statIndex]][equipmentIndex]);
                        double newDps = CombatCalculator.MeleeDamagePerSecond(player.Skills, set.FullEquipmentStats(), target.Skills, target.Stats,
                            new CombatCalculator.MeleeDamagePerSecondArgs(set.CombatStyle.AttackStyle, set.CombatStyle.AttackType, ((Weapon)set.Get(EquipmentSlot.Weapon)).AttackSpeed));
                        if (newDps > baseDps)
                        {
                            ret.Add(new EquipmentDpsAdvantage(EquipmentByStats[slotNum, (int)statPriority[statIndex]][equipmentIndex], newDps - baseDps));
                        }
                        equipmentIndex++;
                    }
                }
            }
            if (weaponTwoHanded)
            {
                Equipment bisWeapon = previousCollection.GetStrictBIS(EquipmentSlot.Weapon, statPriority);
                Equipment bisOffHand = previousCollection.GetStrictBIS(EquipmentSlot.Shield, statPriority);
                EquipmentSlot slot = EquipmentSlot.Weapon;
                for (int statIndex = 0; statIndex < statPriority.Length; statIndex++)
                {
                    int equipmentIndex = 0;
                    while (equipmentIndex < EquipmentByStats[(int)slot, (int)statPriority[statIndex]].Count && EquipmentByStats[(int)slot, (int)statPriority[statIndex]][equipmentIndex].Stats.GetStat(statPriority[statIndex]) > (startingSet.Get(slot) == null ? 0 : startingSet.Get(slot).Stats.GetStat(statPriority[statIndex])))
                    {
                        EquipmentSet set = startingSet.Clone();
                        set.Equip(bisOffHand);
                        set.Equip(EquipmentByStats[(int)slot, (int)statPriority[statIndex]][equipmentIndex]);
                        double newDps = CombatCalculator.MeleeDamagePerSecond(player.Skills, set.FullEquipmentStats(), target.Skills, target.Stats,
                            new CombatCalculator.MeleeDamagePerSecondArgs(set.CombatStyle.AttackStyle, set.CombatStyle.AttackType, ((Weapon)set.Get(EquipmentSlot.Weapon)).AttackSpeed));
                        if (newDps > baseDps)
                        {
                            ret.Add(new EquipmentDpsAdvantage(EquipmentByStats[(int)slot, (int)statPriority[statIndex]][equipmentIndex], newDps - baseDps));
                        }
                        equipmentIndex++;
                    }
                }
                slot = EquipmentSlot.Shield;
                for (int statIndex = 0; statIndex < statPriority.Length; statIndex++)
                {
                    int equipmentIndex = 0;
                    while (equipmentIndex < EquipmentByStats[(int)slot, (int)statPriority[statIndex]].Count && EquipmentByStats[(int)slot, (int)statPriority[statIndex]][equipmentIndex].Stats.GetStat(statPriority[statIndex]) > (startingSet.Get(slot) == null ? 0 : startingSet.Get(slot).Stats.GetStat(statPriority[statIndex])))
                    {
                        EquipmentSet set = startingSet.Clone();
                        set.Equip(bisWeapon);
                        set.Equip(EquipmentByStats[(int)slot, (int)statPriority[statIndex]][equipmentIndex]);
                        double newDps = CombatCalculator.MeleeDamagePerSecond(player.Skills, set.FullEquipmentStats(), target.Skills, target.Stats,
                            new CombatCalculator.MeleeDamagePerSecondArgs(set.CombatStyle.AttackStyle, set.CombatStyle.AttackType, ((Weapon)set.Get(EquipmentSlot.Weapon)).AttackSpeed));
                        if (newDps > baseDps)
                        {
                            ret.Add(new EquipmentDpsAdvantage(EquipmentByStats[(int)slot, (int)statPriority[statIndex]][equipmentIndex], newDps - baseDps));
                        }
                        equipmentIndex++;
                    }
                }
            }
            else
            {
                EquipmentSlot slot = EquipmentSlot.TwoHanded;
                for (int statIndex = 0; statIndex < statPriority.Length; statIndex++)
                {
                    int equipmentIndex = 0;
                    while (equipmentIndex < EquipmentByStats[(int)slot, (int)statPriority[statIndex]].Count && EquipmentByStats[(int)slot, (int)statPriority[statIndex]][equipmentIndex].Stats.GetStat(statPriority[statIndex]) > (startingSet.Get(slot) == null ? 0 : startingSet.Get(slot).Stats.GetStat(statPriority[statIndex])))
                    {
                        EquipmentSet set = startingSet.Clone();
                        set.Equip(EquipmentByStats[(int)slot, (int)statPriority[statIndex]][equipmentIndex]);
                        double newDps = CombatCalculator.MeleeDamagePerSecond(player.Skills, set.FullEquipmentStats(), target.Skills, target.Stats,
                            new CombatCalculator.MeleeDamagePerSecondArgs(set.CombatStyle.AttackStyle, set.CombatStyle.AttackType, ((Weapon)set.Get(EquipmentSlot.Weapon)).AttackSpeed));
                        if (newDps > baseDps)
                        {
                            ret.Add(new EquipmentDpsAdvantage(EquipmentByStats[(int)slot, (int)statPriority[statIndex]][equipmentIndex], newDps - baseDps));
                        }
                        equipmentIndex++;
                    }
                }
            }
            ret.Sort((a, b) => a.GoldPerDps.CompareTo(b.GoldPerDps));
            return ret;
        }

        public EquipmentCollection()
        {
            EquipmentByStats = new List<Equipment>[12,14];
            for (int slot = 0; slot < 12; slot++)
            {
                for (int stat = 0; stat < 14; stat++)
                {
                    EquipmentByStats[slot, stat] = new List<Equipment>();
                }
            }
            Equipment = new List<Equipment>();
            EquipmentLookup = new Trie<Equipment>();
        }

        public EquipmentCollection(List<Equipment> equipment) : this()
        {
            Equipment.AddRange(equipment);
            foreach (Equipment e in equipment)
            {
                int slot = (int)e.Slot;
                for (int stat = 0; stat < EquipmentByStats.GetLength(1); stat++)
                {
                    EquipmentByStats[slot, stat].Add(e);
                }
            }
            for (int slot = 0; slot < 11; slot++)
            {
                for (int stat = 0; stat < 14; stat++)
                {
                    EquipmentByStats[slot, stat].Sort((a, b) => b.Stats.GetStat((EquipmentStat)stat).CompareTo(a.Stats.GetStat((EquipmentStat)stat)));
                }
            }
        }
    }

    public class EquipmentDpsAdvantage
    {
        public Equipment Equipment { get; private set; }

        public double DpsAdvantage { get; private set; }

        public double GoldPerDps => Equipment.CostInfo.HighestPrice / DpsAdvantage;

        public EquipmentDpsAdvantage(Equipment equipment, double dpsAdvantage)
        {
            Equipment = equipment;
            DpsAdvantage = dpsAdvantage;
        }
    }
}
