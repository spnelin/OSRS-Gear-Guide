using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRSCombatGuide.Server.Data
{
    [Serializable]
    public class EquipmentSet
    {
        private Equipment[] _Equipment = new Equipment[11];

        public int CombatStyleIndex { get; set; }

        public CombatStyle CombatStyle => ((Weapon)_Equipment[(int)EquipmentSlot.Weapon]).Type.Stances[CombatStyleIndex];

        public void Equip(Equipment equipment)
        {
            if (equipment == null)
            {
                return;
            }
            if (equipment.Slot == EquipmentSlot.TwoHanded)
            {
                _Equipment[(int)EquipmentSlot.Shield] = null;
                _Equipment[(int)EquipmentSlot.Weapon] = equipment;
            }
            else if (equipment.Slot == EquipmentSlot.Shield && _Equipment[(int)EquipmentSlot.Weapon].Slot == EquipmentSlot.TwoHanded)
            {
                _Equipment[(int)EquipmentSlot.Shield] = equipment;
                _Equipment[(int)EquipmentSlot.Weapon] = null;
            }
            else
            {
                _Equipment[(int)equipment.Slot] = equipment;
            }
        }
        public Equipment Get(EquipmentSlot slot)
        {
            if (slot == EquipmentSlot.TwoHanded)
            {
                return _Equipment[(int)EquipmentSlot.Weapon];
            }
            else
            {
                return _Equipment[(int)slot];
            }
        }
        public StatSet FullEquipmentStats()
        {
            List<StatSet> equipmentStats = new List<StatSet>();
            for (int i = 0; i < _Equipment.Length; i++)
            {
                if (_Equipment[i] != null)
                {
                    equipmentStats.Add(_Equipment[i].Stats);
                }
            }
            return new StatSet(equipmentStats);
        }

        public int FullCost()
        {
            int cost = 0;
            for (int i = 0; i < _Equipment.Length; i++)
            {
                if (_Equipment[i] != null)
                {
                    cost += _Equipment[i].CostInfo.HighestPrice;
                }
            }
            return cost;
        }

        public EquipmentSet Clone()
        {
            EquipmentSet clone = new EquipmentSet();
            clone.CombatStyleIndex = CombatStyleIndex;
            for (int i = 0; i < _Equipment.Length; i++)
            {
                if (_Equipment[i] != null)
                {
                    clone.Equip(_Equipment[i]);
                }
            }
            return clone;
        }
    }
}
