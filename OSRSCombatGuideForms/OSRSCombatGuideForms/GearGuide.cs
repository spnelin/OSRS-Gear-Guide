using OSRSCombatGuide.Server.ApiConnection;
using OSRSCombatGuide.Server.Data;
using OSRSCombatGuide.Server.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSRSCombatGuideForms
{
    public partial class GearGuide : Form
    {
        private Player Player { get; set; }

        private const string PlayerFilePath = @"C:\temp\OSRSPlayer.sav";

        private List<Monster> SelectedMonsters { get; set; } = new List<Monster>();

        private int PreviousMonsterIndex { get; set; }

        private int PreviousEquipmentIndex { get; set; }

        public GearGuide()
        {
            Player = new Player();
            InitializeComponent();
        }

        private void GearGuide_Load(object sender, EventArgs e)
        {
            Text = "Gear Guide";
            ItemLoader.LoadEquipment();
            ItemLoader.LoadMonsters();
            FillMonsterLookup();
            FillEquipmentLookup();
            MonsterLookup.TextChanged += FillMonsterLookup;
            EquipmentLookup.TextChanged += FillEquipmentLookup;
            AttackEntry.LostFocus += UpdateLevel;
            DefenseEntry.LostFocus += UpdateLevel;
            StrengthEntry.LostFocus += UpdateLevel;
            PrayerEntry.LostFocus += UpdateLevel;
            MagicEntry.LostFocus += UpdateLevel;
            RangedEntry.LostFocus += UpdateLevel;
            HitpointsEntry.LostFocus += UpdateLevel;
            DpsValue.Text = "";
            GoldCostValue.Text = "";
            GoldPerDpsValue.Text = "";
            StatsDataFill();
        }

        private void StatsDataFill()
        {
            AttackEntry.Text = Player.Skills.GetLevel(Skill.Attack).ToString();
            DefenseEntry.Text = Player.Skills.GetLevel(Skill.Defense).ToString();
            StrengthEntry.Text = Player.Skills.GetLevel(Skill.Strength).ToString();
            MagicEntry.Text = Player.Skills.GetLevel(Skill.Magic).ToString();
            PrayerEntry.Text = Player.Skills.GetLevel(Skill.Prayer).ToString();
            RangedEntry.Text = Player.Skills.GetLevel(Skill.Ranged).ToString();
            HitpointsEntry.Text = Player.Skills.GetLevel(Skill.Hitpoints).ToString();
        }

        private void FillMonsterLookup(object sender = null, EventArgs e = null)
        {
            if (MonsterLookup.SelectedIndex > -1)
            {
                if (MonsterLookup.SelectedIndex != PreviousMonsterIndex)
                {
                    return;
                }
            }
            List<Monster> monsterList = Monster.MonsterLookup.MatchingItems(MonsterLookup.Text);
            int cursorPos = MonsterLookup.SelectionStart; //Cursor position gets strangely reset when we repopulate items below - saving it off to restore
            MonsterLookup.BeginUpdate();
            MonsterLookup.Items.Clear();
            monsterList.ForEach(a => MonsterLookup.Items.Add(a));
            MonsterLookup.EndUpdate();
            MonsterLookup.SelectionStart = cursorPos;
        }

        private void FillEquipmentLookup(object sender = null, EventArgs e = null)
        {
            if (EquipmentLookup.SelectedIndex > -1)
            {
                if (EquipmentLookup.SelectedIndex != PreviousEquipmentIndex)
                {
                    return;
                }
            }
            List<Equipment> equipmentList = EquipmentCollection.AllEquipment.EquipmentLookup.MatchingItems(EquipmentLookup.Text);
            int cursorPos = EquipmentLookup.SelectionStart; //Cursor position gets strangely reset when we repopulate items below - saving it off to restore
            EquipmentLookup.BeginUpdate();
            EquipmentLookup.Items.Clear();
            equipmentList.ForEach(a => EquipmentLookup.Items.Add(a));
            EquipmentLookup.EndUpdate();
            EquipmentLookup.SelectionStart = cursorPos;
        }

        private void UpdateLevel(object sender, EventArgs e)
        {
            int newLevel;
            Skill skill;
            if (sender == AttackEntry)
            {
                skill = Skill.Attack;
            }
            else if (sender == StrengthEntry)
            {
                skill = Skill.Strength;
            }
            else if (sender == DefenseEntry)
            {
                skill = Skill.Defense;
            }
            else if (sender == HitpointsEntry)
            {
                skill = Skill.Hitpoints;
            }
            else if (sender == PrayerEntry)
            {
                skill = Skill.Prayer;
            }
            else if (sender == RangedEntry)
            {
                skill = Skill.Ranged;
            }
            else if (sender == MagicEntry)
            {
                skill = Skill.Magic;
            }
            else
            {
                return;
            }
            TextBox entry = (TextBox)sender;
            if (!int.TryParse(entry.Text, out newLevel))
            {
                entry.Text = Player.Skills.GetLevel(skill).ToString();
                return;
            }
            if (newLevel > 99)
            {
                newLevel = 99;
            }
            if (newLevel < 1)
            {
                newLevel = 1;
            }
            Player.Skills.SetLevel(skill, newLevel);
            entry.Text = newLevel.ToString();
            return;
        }

        private void PlayerEquipmentCollection_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MonsterLookup_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreviousMonsterIndex = ((ComboBox)sender).SelectedIndex;
        }

        private void EquipmentLookup_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreviousEquipmentIndex = ((ComboBox)sender).SelectedIndex;
        }

        private void UpgradeTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EquipmentWebLoad_Click(object sender, EventArgs e)
        {

        }

        private void MonsterWebLoad_Click(object sender, EventArgs e)
        {

        }

        private void MonsterFileLoad_Click(object sender, EventArgs e)
        {

        }

        private void AddMonster_Click(object sender, EventArgs e)
        {
            if (MonsterLookup.SelectedIndex < 0 || MonsterLookup.SelectedIndex >= MonsterLookup.Items.Count)
            {
                return;
            }
            if (!SelectedMonsters.Contains((Monster)MonsterLookup.Items[MonsterLookup.SelectedIndex]))
            {
                SelectedMonsters.Add((Monster)MonsterLookup.Items[MonsterLookup.SelectedIndex]);
                MonsterList.BeginUpdate();
                MonsterList.Items.Clear();
                SelectedMonsters.ForEach(a => MonsterList.Items.Add(a));
                MonsterList.EndUpdate();
                MonsterList.SelectedIndex = SelectedMonsters.Count - 1;
            }
        }

        private void AddEquipment_Click(object sender, EventArgs e)
        {
            if (EquipmentLookup.SelectedIndex < 0 || EquipmentLookup.SelectedIndex >= EquipmentLookup.Items.Count)
            {
                return;
            }
            if (!Player.AvailableEquipment.Equipment.Contains((Equipment)EquipmentLookup.Items[EquipmentLookup.SelectedIndex]))
            {
                Player.AvailableEquipment.AddEquipment((Equipment)EquipmentLookup.Items[EquipmentLookup.SelectedIndex]);
                PlayerEquipmentCollection.BeginUpdate();
                PlayerEquipmentCollection.Items.Clear();
                Player.AvailableEquipment.Equipment.ForEach(a => PlayerEquipmentCollection.Items.Add(a));
                PlayerEquipmentCollection.EndUpdate();
                PlayerEquipmentCollection.SelectedIndex = Player.AvailableEquipment.Equipment.Count - 1;
                Equipment current;
                switch (((Equipment)EquipmentLookup.Items[EquipmentLookup.SelectedIndex]).Slot)
                {
                    case EquipmentSlot.Ammo:
                        AmmoSelection.BeginUpdate();
                        current = AmmoSelection.SelectedIndex > -1 ? (Equipment)AmmoSelection.Items[AmmoSelection.SelectedIndex] : null;
                        AmmoSelection.Items.Clear();
                        Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Ammo).ForEach(a => AmmoSelection.Items.Add(a));
                        AmmoSelection.EndUpdate();
                        AmmoSelection.SelectedIndex = current == null ? 0 : Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Ammo).IndexOf(current);
                        break;
                    case EquipmentSlot.Body:
                        BodySelection.BeginUpdate();
                        current = BodySelection.SelectedIndex > -1 ? (Equipment)BodySelection.Items[BodySelection.SelectedIndex] : null;
                        BodySelection.Items.Clear();
                        Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Body).ForEach(a => BodySelection.Items.Add(a));
                        BodySelection.EndUpdate();
                        BodySelection.SelectedIndex = current == null ? 0 : Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Body).IndexOf(current);
                        break;
                    case EquipmentSlot.Cape:
                        CapeSelection.BeginUpdate();
                        current = CapeSelection.SelectedIndex > -1 ? (Equipment)CapeSelection.Items[CapeSelection.SelectedIndex] : null;
                        CapeSelection.Items.Clear();
                        Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Cape).ForEach(a => CapeSelection.Items.Add(a));
                        CapeSelection.EndUpdate();
                        CapeSelection.SelectedIndex = current == null ? 0 : Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Cape).IndexOf(current);
                        break;
                    case EquipmentSlot.Feet:
                        BootsSelection.BeginUpdate();
                        current = BootsSelection.SelectedIndex > -1 ? (Equipment)BootsSelection.Items[BootsSelection.SelectedIndex] : null;
                        BootsSelection.Items.Clear();
                        Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Feet).ForEach(a => BootsSelection.Items.Add(a));
                        BootsSelection.EndUpdate();
                        BootsSelection.SelectedIndex = current == null ? 0 : Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Feet).IndexOf(current);
                        break;
                    case EquipmentSlot.Hands:
                        GlovesSelection.BeginUpdate();
                        current = GlovesSelection.SelectedIndex > -1 ? (Equipment)GlovesSelection.Items[GlovesSelection.SelectedIndex] : null;
                        GlovesSelection.Items.Clear();
                        Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Hands).ForEach(a => GlovesSelection.Items.Add(a));
                        GlovesSelection.EndUpdate();
                        GlovesSelection.SelectedIndex = current == null ? 0 : Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Hands).IndexOf(current);
                        break;
                    case EquipmentSlot.Head:
                        HeadSelection.BeginUpdate();
                        current = HeadSelection.SelectedIndex > -1 ? (Equipment)HeadSelection.Items[HeadSelection.SelectedIndex] : null;
                        HeadSelection.Items.Clear();
                        Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Head).ForEach(a => HeadSelection.Items.Add(a));
                        HeadSelection.EndUpdate();
                        HeadSelection.SelectedIndex = current == null ? 0 : Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Head).IndexOf(current);
                        break;
                    case EquipmentSlot.Legs:
                        LegsSelection.BeginUpdate();
                        current = LegsSelection.SelectedIndex > -1 ? (Equipment)LegsSelection.Items[LegsSelection.SelectedIndex] : null;
                        LegsSelection.Items.Clear();
                        Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Legs).ForEach(a => LegsSelection.Items.Add(a));
                        LegsSelection.EndUpdate();
                        LegsSelection.SelectedIndex = current == null ? 0 : Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Legs).IndexOf(current);
                        break;
                    case EquipmentSlot.Neck:
                        NeckSelection.BeginUpdate();
                        current = NeckSelection.SelectedIndex > -1 ? (Equipment)NeckSelection.Items[NeckSelection.SelectedIndex] : null;
                        NeckSelection.Items.Clear();
                        Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Neck).ForEach(a => NeckSelection.Items.Add(a));
                        NeckSelection.EndUpdate();
                        NeckSelection.SelectedIndex = current == null ? 0 : Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Neck).IndexOf(current);
                        break;
                    case EquipmentSlot.Ring:
                        RingSelection.BeginUpdate();
                        current = RingSelection.SelectedIndex > -1 ? (Equipment)RingSelection.Items[RingSelection.SelectedIndex] : null;
                        RingSelection.Items.Clear();
                        Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Ring).ForEach(a => RingSelection.Items.Add(a));
                        RingSelection.EndUpdate();
                        RingSelection.SelectedIndex = current == null ? 0 : Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Ring).IndexOf(current);
                        break;
                    case EquipmentSlot.Shield:
                        ShieldSelection.BeginUpdate();
                        current = ShieldSelection.SelectedIndex > -1 ? (Equipment)ShieldSelection.Items[ShieldSelection.SelectedIndex] : null;
                        ShieldSelection.Items.Clear();
                        Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Shield).ForEach(a => ShieldSelection.Items.Add(a));
                        ShieldSelection.EndUpdate();
                        ShieldSelection.SelectedIndex = current == null ? 0 : Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Shield).IndexOf(current);
                        break;
                    case EquipmentSlot.Weapon:
                    case EquipmentSlot.TwoHanded:
                        WeaponSelection.BeginUpdate();
                        current = ShieldSelection.SelectedIndex > -1 ? (Equipment)WeaponSelection.Items[WeaponSelection.SelectedIndex] : null;
                        WeaponSelection.Items.Clear();
                        Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Weapon).ForEach(a => WeaponSelection.Items.Add(a));
                        Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.TwoHanded).ForEach(a => WeaponSelection.Items.Add(a));
                        WeaponSelection.EndUpdate();
                        if (current == null)
                        {
                            WeaponSelection.SelectedIndex = 0;
                        }
                        else if (((Weapon)current).TwoHanded)
                        {
                            WeaponSelection.SelectedIndex = Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.TwoHanded).IndexOf(current) + Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Weapon).Count;
                        }
                        else
                        {
                            WeaponSelection.SelectedIndex = Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Weapon).IndexOf(current);
                        }
                        break;
                }
            }
        }

        private void CapeSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null)
            {
                return;
            }
            Player.Equipment.Equip((Equipment)((ComboBox)sender).SelectedItem);
        }

        private void WeaponSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null)
            {
                return;
            }
            Player.Equipment.Equip((Equipment)((ComboBox)sender).SelectedItem);
            if (((Equipment)((ComboBox)sender).SelectedItem).Slot == EquipmentSlot.TwoHanded)
            {
                ShieldSelection.SelectedIndex = -1;
            }
        }

        private void GlovesSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null)
            {
                return;
            }
            Player.Equipment.Equip((Equipment)((ComboBox)sender).SelectedItem);
        }

        private void RingSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null)
            {
                return;
            }
            Player.Equipment.Equip((Equipment)((ComboBox)sender).SelectedItem);
        }

        private void HeadSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null)
            {
                return;
            }
            Player.Equipment.Equip((Equipment)((ComboBox)sender).SelectedItem);
        }

        private void BodySelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null)
            {
                return;
            }
            Player.Equipment.Equip((Equipment)((ComboBox)sender).SelectedItem);
        }

        private void LegsSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null)
            {
                return;
            }
            Player.Equipment.Equip((Equipment)((ComboBox)sender).SelectedItem);
        }

        private void BootsSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null)
            {
                return;
            }
            Player.Equipment.Equip((Equipment)((ComboBox)sender).SelectedItem);
        }

        private void AmmoSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null)
            {
                return;
            }
            Player.Equipment.Equip((Equipment)((ComboBox)sender).SelectedItem);
        }

        private void ShieldSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null)
            {
                return;
            }
            Player.Equipment.Equip((Equipment)((ComboBox)sender).SelectedItem);
            if ((Equipment)WeaponSelection.SelectedItem != null && ((Equipment)WeaponSelection.SelectedItem).Slot == EquipmentSlot.TwoHanded)
            {
                WeaponSelection.SelectedIndex = -1;
            }
        }

        private void NeckSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null)
            {
                return;
            }
            Player.Equipment.Equip((Equipment)((ComboBox)sender).SelectedItem);
        }

        private void FindOptimalGear_Click(object sender, EventArgs e)
        {
            if (MonsterList.SelectedItem == null)
            {
                return;
            }
            EquipmentSet set = GearSelection.OptimalMeleeDamageEquipment(Player, (Monster)MonsterList.SelectedItem, Player.AvailableEquipment, out double dps);
            Player.EquipSet(set);
            AmmoSelection.SelectedIndex = Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Ammo).IndexOf(Player.Equipment.Get(EquipmentSlot.Ammo));
            BodySelection.SelectedIndex = Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Body).IndexOf(Player.Equipment.Get(EquipmentSlot.Body));
            CapeSelection.SelectedIndex = Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Cape).IndexOf(Player.Equipment.Get(EquipmentSlot.Cape));
            BootsSelection.SelectedIndex = Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Feet).IndexOf(Player.Equipment.Get(EquipmentSlot.Feet));
            GlovesSelection.SelectedIndex = Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Hands).IndexOf(Player.Equipment.Get(EquipmentSlot.Hands));
            HeadSelection.SelectedIndex = Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Head).IndexOf(Player.Equipment.Get(EquipmentSlot.Head));
            LegsSelection.SelectedIndex = Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Legs).IndexOf(Player.Equipment.Get(EquipmentSlot.Legs));
            NeckSelection.SelectedIndex = Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Neck).IndexOf(Player.Equipment.Get(EquipmentSlot.Neck));
            RingSelection.SelectedIndex = Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Ring).IndexOf(Player.Equipment.Get(EquipmentSlot.Ring));
            ShieldSelection.SelectedIndex = Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Shield).IndexOf(Player.Equipment.Get(EquipmentSlot.Shield));
            WeaponSelection.SelectedIndex = Player.AvailableEquipment.EquipmentBySlot(Player.Equipment.Get(EquipmentSlot.Weapon).Slot).IndexOf(Player.Equipment.Get(EquipmentSlot.Weapon)) +
                Player.Equipment.Get(EquipmentSlot.Weapon).Slot == EquipmentSlot.TwoHanded ? Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Weapon).Count : 0;
            DpsValue.Text = dps.ToString();
            GoldCostValue.Text = set.FullCost().ToString();
            GoldPerDpsValue.Text = (dps / set.FullCost()).ToString();
        }

        private void SaveEquipment_Click(object sender, EventArgs e)
        {
            FileStream stream = new FileStream(PlayerFilePath, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, Player);
            stream.Close();
        }

        private void EquipmentFileLoad_Click(object sender, EventArgs e)
        {
            FileStream stream = new FileStream(PlayerFilePath, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            Player = (Player)formatter.Deserialize(stream);
            stream.Close();
            StatsDataFill();
            PlayerEquipmentCollection.BeginUpdate();
            PlayerEquipmentCollection.Items.Clear();
            Player.AvailableEquipment.Equipment.ForEach(a => PlayerEquipmentCollection.Items.Add(a));
            PlayerEquipmentCollection.EndUpdate();
            PlayerEquipmentCollection.SelectedIndex = 0;
            AmmoSelection.BeginUpdate();
            AmmoSelection.Items.Clear();
            Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Ammo).ForEach(a => AmmoSelection.Items.Add(a));
            AmmoSelection.EndUpdate();
            BodySelection.BeginUpdate();
            BodySelection.Items.Clear();
            Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Body).ForEach(a => BodySelection.Items.Add(a));
            BodySelection.EndUpdate();
            CapeSelection.BeginUpdate();
            CapeSelection.Items.Clear();
            Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Cape).ForEach(a => CapeSelection.Items.Add(a));
            CapeSelection.EndUpdate();
            BootsSelection.BeginUpdate();
            BootsSelection.Items.Clear();
            Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Feet).ForEach(a => BootsSelection.Items.Add(a));
            BootsSelection.EndUpdate();
            GlovesSelection.BeginUpdate();
            GlovesSelection.Items.Clear();
            Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Hands).ForEach(a => GlovesSelection.Items.Add(a));
            GlovesSelection.EndUpdate();
            HeadSelection.BeginUpdate();
            HeadSelection.Items.Clear();
            Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Head).ForEach(a => HeadSelection.Items.Add(a));
            HeadSelection.EndUpdate();
            LegsSelection.BeginUpdate();
            LegsSelection.Items.Clear();
            Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Legs).ForEach(a => LegsSelection.Items.Add(a));
            LegsSelection.EndUpdate();
            NeckSelection.BeginUpdate();
            NeckSelection.Items.Clear();
            Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Neck).ForEach(a => NeckSelection.Items.Add(a));
            NeckSelection.EndUpdate();
            RingSelection.BeginUpdate();
            RingSelection.Items.Clear();
            Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Ring).ForEach(a => RingSelection.Items.Add(a));
            RingSelection.EndUpdate();
            ShieldSelection.BeginUpdate();
            ShieldSelection.Items.Clear();
            Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Shield).ForEach(a => ShieldSelection.Items.Add(a));
            ShieldSelection.EndUpdate();
            WeaponSelection.BeginUpdate();
            WeaponSelection.Items.Clear();
            Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.Weapon).ForEach(a => WeaponSelection.Items.Add(a));
            Player.AvailableEquipment.EquipmentBySlot(EquipmentSlot.TwoHanded).ForEach(a => WeaponSelection.Items.Add(a));
            WeaponSelection.EndUpdate();
        }

        private void FindGearUpgrades_Click(object sender, EventArgs e)
        {
            List<EquipmentDpsAdvantage> upgrades = EquipmentCollection.AllEquipment.GetMeleeUpgrades(Player, Player.Equipment, Player.AvailableEquipment, (Monster)MonsterList.SelectedItem);
            UpgradeTable.DataSource = upgrades;
            
        }

        private void DownloadEquipment_Click(object sender, EventArgs e)
        {
            ItemLoader.LoadEquipment(false);
        }

        private void DownloadMonsters_Click(object sender, EventArgs e)
        {
            ItemLoader.LoadMonsters(false);
        }
    }
}
