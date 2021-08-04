namespace OSRSCombatGuideForms
{
    partial class GearGuide
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label UpgradesLabel;
            this.PlayerEquipmentCollection = new System.Windows.Forms.ListBox();
            this.EquipmentLookup = new System.Windows.Forms.ComboBox();
            this.HeadSelection = new System.Windows.Forms.ComboBox();
            this.CapeSelection = new System.Windows.Forms.ComboBox();
            this.AmmoSelection = new System.Windows.Forms.ComboBox();
            this.BodySelection = new System.Windows.Forms.ComboBox();
            this.LegsSelection = new System.Windows.Forms.ComboBox();
            this.BootsSelection = new System.Windows.Forms.ComboBox();
            this.WeaponSelection = new System.Windows.Forms.ComboBox();
            this.GlovesSelection = new System.Windows.Forms.ComboBox();
            this.ShieldSelection = new System.Windows.Forms.ComboBox();
            this.NeckSelection = new System.Windows.Forms.ComboBox();
            this.RingSelection = new System.Windows.Forms.ComboBox();
            this.MonsterLookup = new System.Windows.Forms.ComboBox();
            this.MonsterList = new System.Windows.Forms.ListBox();
            this.EquipmentFileLoad = new System.Windows.Forms.Button();
            this.FindOptimalGear = new System.Windows.Forms.Button();
            this.FindGearUpgrades = new System.Windows.Forms.Button();
            this.Dps = new System.Windows.Forms.Label();
            this.DpsValue = new System.Windows.Forms.Label();
            this.GoldCost = new System.Windows.Forms.Label();
            this.GoldCostValue = new System.Windows.Forms.Label();
            this.GoldPerDps = new System.Windows.Forms.Label();
            this.GoldPerDpsValue = new System.Windows.Forms.Label();
            this.UpgradeTable = new System.Windows.Forms.DataGridView();
            this.StrengthEntry = new System.Windows.Forms.TextBox();
            this.DefenseEntry = new System.Windows.Forms.TextBox();
            this.RangedEntry = new System.Windows.Forms.TextBox();
            this.MagicEntry = new System.Windows.Forms.TextBox();
            this.PrayerEntry = new System.Windows.Forms.TextBox();
            this.AttackEntry = new System.Windows.Forms.TextBox();
            this.HitpointsEntry = new System.Windows.Forms.TextBox();
            this.HitpointsLabel = new System.Windows.Forms.Label();
            this.AttackLabel = new System.Windows.Forms.Label();
            this.StrengthLabel = new System.Windows.Forms.Label();
            this.DefenseLabel = new System.Windows.Forms.Label();
            this.RangedLabel = new System.Windows.Forms.Label();
            this.MagicLabel = new System.Windows.Forms.Label();
            this.PrayerLabel = new System.Windows.Forms.Label();
            this.SaveEquipment = new System.Windows.Forms.Button();
            this.DownloadMonsters = new System.Windows.Forms.Button();
            this.DownloadEquipment = new System.Windows.Forms.Button();
            this.AddEquipment = new System.Windows.Forms.Button();
            this.AddMonster = new System.Windows.Forms.Button();
            this.YourEquipmentLabel = new System.Windows.Forms.Label();
            this.MonstersLabel = new System.Windows.Forms.Label();
            this.HeadLabel = new System.Windows.Forms.Label();
            this.AmmoLabel = new System.Windows.Forms.Label();
            this.CapeLabel = new System.Windows.Forms.Label();
            this.BodyLabel = new System.Windows.Forms.Label();
            this.WeaponLabel = new System.Windows.Forms.Label();
            this.ShieldLabel = new System.Windows.Forms.Label();
            this.LegsLabel = new System.Windows.Forms.Label();
            this.GlovesLabel = new System.Windows.Forms.Label();
            this.NeckLabel = new System.Windows.Forms.Label();
            this.RingLabel = new System.Windows.Forms.Label();
            this.BootsLabel = new System.Windows.Forms.Label();
            UpgradesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UpgradeTable)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayerEquipmentCollection
            // 
            this.PlayerEquipmentCollection.FormattingEnabled = true;
            this.PlayerEquipmentCollection.Location = new System.Drawing.Point(3, 44);
            this.PlayerEquipmentCollection.Name = "PlayerEquipmentCollection";
            this.PlayerEquipmentCollection.Size = new System.Drawing.Size(188, 186);
            this.PlayerEquipmentCollection.TabIndex = 0;
            this.PlayerEquipmentCollection.SelectedIndexChanged += new System.EventHandler(this.PlayerEquipmentCollection_SelectedIndexChanged);
            // 
            // EquipmentLookup
            // 
            this.EquipmentLookup.FormattingEnabled = true;
            this.EquipmentLookup.Location = new System.Drawing.Point(3, 17);
            this.EquipmentLookup.Name = "EquipmentLookup";
            this.EquipmentLookup.Size = new System.Drawing.Size(121, 21);
            this.EquipmentLookup.TabIndex = 1;
            this.EquipmentLookup.SelectedIndexChanged += new System.EventHandler(this.EquipmentLookup_SelectedIndexChanged);
            // 
            // HeadSelection
            // 
            this.HeadSelection.FormattingEnabled = true;
            this.HeadSelection.Location = new System.Drawing.Point(514, 54);
            this.HeadSelection.Name = "HeadSelection";
            this.HeadSelection.Size = new System.Drawing.Size(121, 21);
            this.HeadSelection.TabIndex = 2;
            this.HeadSelection.SelectedIndexChanged += new System.EventHandler(this.HeadSelection_SelectedIndexChanged);
            // 
            // CapeSelection
            // 
            this.CapeSelection.FormattingEnabled = true;
            this.CapeSelection.Location = new System.Drawing.Point(296, 80);
            this.CapeSelection.Name = "CapeSelection";
            this.CapeSelection.Size = new System.Drawing.Size(121, 21);
            this.CapeSelection.TabIndex = 3;
            this.CapeSelection.SelectedIndexChanged += new System.EventHandler(this.CapeSelection_SelectedIndexChanged);
            // 
            // AmmoSelection
            // 
            this.AmmoSelection.FormattingEnabled = true;
            this.AmmoSelection.Location = new System.Drawing.Point(722, 80);
            this.AmmoSelection.Name = "AmmoSelection";
            this.AmmoSelection.Size = new System.Drawing.Size(121, 21);
            this.AmmoSelection.TabIndex = 4;
            this.AmmoSelection.SelectedIndexChanged += new System.EventHandler(this.AmmoSelection_SelectedIndexChanged);
            // 
            // BodySelection
            // 
            this.BodySelection.FormattingEnabled = true;
            this.BodySelection.Location = new System.Drawing.Point(514, 165);
            this.BodySelection.Name = "BodySelection";
            this.BodySelection.Size = new System.Drawing.Size(121, 21);
            this.BodySelection.TabIndex = 5;
            this.BodySelection.SelectedIndexChanged += new System.EventHandler(this.BodySelection_SelectedIndexChanged);
            // 
            // LegsSelection
            // 
            this.LegsSelection.FormattingEnabled = true;
            this.LegsSelection.Location = new System.Drawing.Point(514, 280);
            this.LegsSelection.Name = "LegsSelection";
            this.LegsSelection.Size = new System.Drawing.Size(121, 21);
            this.LegsSelection.TabIndex = 6;
            this.LegsSelection.SelectedIndexChanged += new System.EventHandler(this.LegsSelection_SelectedIndexChanged);
            // 
            // BootsSelection
            // 
            this.BootsSelection.FormattingEnabled = true;
            this.BootsSelection.Location = new System.Drawing.Point(514, 389);
            this.BootsSelection.Name = "BootsSelection";
            this.BootsSelection.Size = new System.Drawing.Size(121, 21);
            this.BootsSelection.TabIndex = 7;
            this.BootsSelection.SelectedIndexChanged += new System.EventHandler(this.BootsSelection_SelectedIndexChanged);
            // 
            // WeaponSelection
            // 
            this.WeaponSelection.FormattingEnabled = true;
            this.WeaponSelection.Location = new System.Drawing.Point(296, 191);
            this.WeaponSelection.Name = "WeaponSelection";
            this.WeaponSelection.Size = new System.Drawing.Size(121, 21);
            this.WeaponSelection.TabIndex = 8;
            this.WeaponSelection.SelectedIndexChanged += new System.EventHandler(this.WeaponSelection_SelectedIndexChanged);
            // 
            // GlovesSelection
            // 
            this.GlovesSelection.FormattingEnabled = true;
            this.GlovesSelection.Location = new System.Drawing.Point(296, 306);
            this.GlovesSelection.Name = "GlovesSelection";
            this.GlovesSelection.Size = new System.Drawing.Size(121, 21);
            this.GlovesSelection.TabIndex = 9;
            this.GlovesSelection.SelectedIndexChanged += new System.EventHandler(this.GlovesSelection_SelectedIndexChanged);
            // 
            // ShieldSelection
            // 
            this.ShieldSelection.FormattingEnabled = true;
            this.ShieldSelection.Location = new System.Drawing.Point(722, 191);
            this.ShieldSelection.Name = "ShieldSelection";
            this.ShieldSelection.Size = new System.Drawing.Size(121, 21);
            this.ShieldSelection.TabIndex = 10;
            this.ShieldSelection.SelectedIndexChanged += new System.EventHandler(this.ShieldSelection_SelectedIndexChanged);
            // 
            // NeckSelection
            // 
            this.NeckSelection.FormattingEnabled = true;
            this.NeckSelection.Location = new System.Drawing.Point(722, 306);
            this.NeckSelection.Name = "NeckSelection";
            this.NeckSelection.Size = new System.Drawing.Size(121, 21);
            this.NeckSelection.TabIndex = 11;
            this.NeckSelection.SelectedIndexChanged += new System.EventHandler(this.NeckSelection_SelectedIndexChanged);
            // 
            // RingSelection
            // 
            this.RingSelection.FormattingEnabled = true;
            this.RingSelection.Location = new System.Drawing.Point(296, 416);
            this.RingSelection.Name = "RingSelection";
            this.RingSelection.Size = new System.Drawing.Size(121, 21);
            this.RingSelection.TabIndex = 12;
            this.RingSelection.SelectedIndexChanged += new System.EventHandler(this.RingSelection_SelectedIndexChanged);
            // 
            // MonsterLookup
            // 
            this.MonsterLookup.FormattingEnabled = true;
            this.MonsterLookup.Location = new System.Drawing.Point(3, 295);
            this.MonsterLookup.Name = "MonsterLookup";
            this.MonsterLookup.Size = new System.Drawing.Size(121, 21);
            this.MonsterLookup.TabIndex = 15;
            this.MonsterLookup.SelectedIndexChanged += new System.EventHandler(this.MonsterLookup_SelectedIndexChanged);
            // 
            // MonsterList
            // 
            this.MonsterList.FormattingEnabled = true;
            this.MonsterList.Location = new System.Drawing.Point(3, 322);
            this.MonsterList.Name = "MonsterList";
            this.MonsterList.Size = new System.Drawing.Size(188, 186);
            this.MonsterList.TabIndex = 14;
            // 
            // EquipmentFileLoad
            // 
            this.EquipmentFileLoad.Location = new System.Drawing.Point(116, 236);
            this.EquipmentFileLoad.Name = "EquipmentFileLoad";
            this.EquipmentFileLoad.Size = new System.Drawing.Size(75, 23);
            this.EquipmentFileLoad.TabIndex = 16;
            this.EquipmentFileLoad.Text = "Load";
            this.EquipmentFileLoad.UseVisualStyleBackColor = true;
            this.EquipmentFileLoad.Click += new System.EventHandler(this.EquipmentFileLoad_Click);
            // 
            // FindOptimalGear
            // 
            this.FindOptimalGear.Location = new System.Drawing.Point(921, 54);
            this.FindOptimalGear.Name = "FindOptimalGear";
            this.FindOptimalGear.Size = new System.Drawing.Size(240, 23);
            this.FindOptimalGear.TabIndex = 19;
            this.FindOptimalGear.Text = "Find Optimal Gear";
            this.FindOptimalGear.UseVisualStyleBackColor = true;
            this.FindOptimalGear.Click += new System.EventHandler(this.FindOptimalGear_Click);
            // 
            // FindGearUpgrades
            // 
            this.FindGearUpgrades.Location = new System.Drawing.Point(921, 80);
            this.FindGearUpgrades.Name = "FindGearUpgrades";
            this.FindGearUpgrades.Size = new System.Drawing.Size(240, 23);
            this.FindGearUpgrades.TabIndex = 20;
            this.FindGearUpgrades.Text = "Find Gear Upgrades";
            this.FindGearUpgrades.UseVisualStyleBackColor = true;
            this.FindGearUpgrades.Click += new System.EventHandler(this.FindGearUpgrades_Click);
            // 
            // Dps
            // 
            this.Dps.AutoSize = true;
            this.Dps.Location = new System.Drawing.Point(918, 115);
            this.Dps.Name = "Dps";
            this.Dps.Size = new System.Drawing.Size(106, 13);
            this.Dps.TabIndex = 21;
            this.Dps.Text = "Damage Per Second";
            // 
            // DpsValue
            // 
            this.DpsValue.AutoSize = true;
            this.DpsValue.Location = new System.Drawing.Point(1050, 115);
            this.DpsValue.Name = "DpsValue";
            this.DpsValue.Size = new System.Drawing.Size(53, 13);
            this.DpsValue.TabIndex = 22;
            this.DpsValue.Text = "DpsValue";
            // 
            // GoldCost
            // 
            this.GoldCost.AutoSize = true;
            this.GoldCost.Location = new System.Drawing.Point(918, 140);
            this.GoldCost.Name = "GoldCost";
            this.GoldCost.Size = new System.Drawing.Size(108, 13);
            this.GoldCost.TabIndex = 23;
            this.GoldCost.Text = "Equipment Price (GP)";
            // 
            // GoldCostValue
            // 
            this.GoldCostValue.AutoSize = true;
            this.GoldCostValue.Location = new System.Drawing.Point(1050, 140);
            this.GoldCostValue.Name = "GoldCostValue";
            this.GoldCostValue.Size = new System.Drawing.Size(77, 13);
            this.GoldCostValue.TabIndex = 24;
            this.GoldCostValue.Text = "GoldCostValue";
            // 
            // GoldPerDps
            // 
            this.GoldPerDps.AutoSize = true;
            this.GoldPerDps.Location = new System.Drawing.Point(918, 165);
            this.GoldPerDps.Name = "GoldPerDps";
            this.GoldPerDps.Size = new System.Drawing.Size(75, 13);
            this.GoldPerDps.TabIndex = 25;
            this.GoldPerDps.Text = "Price Per DPS";
            // 
            // GoldPerDpsValue
            // 
            this.GoldPerDpsValue.AutoSize = true;
            this.GoldPerDpsValue.Location = new System.Drawing.Point(1050, 165);
            this.GoldPerDpsValue.Name = "GoldPerDpsValue";
            this.GoldPerDpsValue.Size = new System.Drawing.Size(91, 13);
            this.GoldPerDpsValue.TabIndex = 26;
            this.GoldPerDpsValue.Text = "GoldPerDpsValue";
            // 
            // UpgradeTable
            // 
            this.UpgradeTable.AllowUserToAddRows = false;
            this.UpgradeTable.AllowUserToDeleteRows = false;
            this.UpgradeTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UpgradeTable.Location = new System.Drawing.Point(921, 205);
            this.UpgradeTable.Name = "UpgradeTable";
            this.UpgradeTable.ReadOnly = true;
            this.UpgradeTable.Size = new System.Drawing.Size(316, 421);
            this.UpgradeTable.TabIndex = 29;
            this.UpgradeTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UpgradeTable_CellContentClick);
            // 
            // StrengthEntry
            // 
            this.StrengthEntry.Location = new System.Drawing.Point(807, 488);
            this.StrengthEntry.Name = "StrengthEntry";
            this.StrengthEntry.Size = new System.Drawing.Size(100, 20);
            this.StrengthEntry.TabIndex = 30;
            // 
            // DefenseEntry
            // 
            this.DefenseEntry.Location = new System.Drawing.Point(807, 514);
            this.DefenseEntry.Name = "DefenseEntry";
            this.DefenseEntry.Size = new System.Drawing.Size(100, 20);
            this.DefenseEntry.TabIndex = 31;
            // 
            // RangedEntry
            // 
            this.RangedEntry.Location = new System.Drawing.Point(807, 540);
            this.RangedEntry.Name = "RangedEntry";
            this.RangedEntry.Size = new System.Drawing.Size(100, 20);
            this.RangedEntry.TabIndex = 32;
            // 
            // MagicEntry
            // 
            this.MagicEntry.Location = new System.Drawing.Point(807, 566);
            this.MagicEntry.Name = "MagicEntry";
            this.MagicEntry.Size = new System.Drawing.Size(100, 20);
            this.MagicEntry.TabIndex = 33;
            // 
            // PrayerEntry
            // 
            this.PrayerEntry.Location = new System.Drawing.Point(807, 592);
            this.PrayerEntry.Name = "PrayerEntry";
            this.PrayerEntry.Size = new System.Drawing.Size(100, 20);
            this.PrayerEntry.TabIndex = 34;
            // 
            // AttackEntry
            // 
            this.AttackEntry.Location = new System.Drawing.Point(807, 462);
            this.AttackEntry.Name = "AttackEntry";
            this.AttackEntry.Size = new System.Drawing.Size(100, 20);
            this.AttackEntry.TabIndex = 35;
            // 
            // HitpointsEntry
            // 
            this.HitpointsEntry.Location = new System.Drawing.Point(807, 436);
            this.HitpointsEntry.Name = "HitpointsEntry";
            this.HitpointsEntry.Size = new System.Drawing.Size(100, 20);
            this.HitpointsEntry.TabIndex = 36;
            // 
            // HitpointsLabel
            // 
            this.HitpointsLabel.AutoSize = true;
            this.HitpointsLabel.Location = new System.Drawing.Point(719, 439);
            this.HitpointsLabel.Name = "HitpointsLabel";
            this.HitpointsLabel.Size = new System.Drawing.Size(48, 13);
            this.HitpointsLabel.TabIndex = 37;
            this.HitpointsLabel.Text = "Hitpoints";
            // 
            // AttackLabel
            // 
            this.AttackLabel.AutoSize = true;
            this.AttackLabel.Location = new System.Drawing.Point(719, 465);
            this.AttackLabel.Name = "AttackLabel";
            this.AttackLabel.Size = new System.Drawing.Size(38, 13);
            this.AttackLabel.TabIndex = 38;
            this.AttackLabel.Text = "Attack";
            // 
            // StrengthLabel
            // 
            this.StrengthLabel.AutoSize = true;
            this.StrengthLabel.Location = new System.Drawing.Point(719, 491);
            this.StrengthLabel.Name = "StrengthLabel";
            this.StrengthLabel.Size = new System.Drawing.Size(47, 13);
            this.StrengthLabel.TabIndex = 39;
            this.StrengthLabel.Text = "Strength";
            // 
            // DefenseLabel
            // 
            this.DefenseLabel.AutoSize = true;
            this.DefenseLabel.Location = new System.Drawing.Point(719, 517);
            this.DefenseLabel.Name = "DefenseLabel";
            this.DefenseLabel.Size = new System.Drawing.Size(47, 13);
            this.DefenseLabel.TabIndex = 40;
            this.DefenseLabel.Text = "Defense";
            // 
            // RangedLabel
            // 
            this.RangedLabel.AutoSize = true;
            this.RangedLabel.Location = new System.Drawing.Point(719, 543);
            this.RangedLabel.Name = "RangedLabel";
            this.RangedLabel.Size = new System.Drawing.Size(45, 13);
            this.RangedLabel.TabIndex = 41;
            this.RangedLabel.Text = "Ranged";
            // 
            // MagicLabel
            // 
            this.MagicLabel.AutoSize = true;
            this.MagicLabel.Location = new System.Drawing.Point(719, 569);
            this.MagicLabel.Name = "MagicLabel";
            this.MagicLabel.Size = new System.Drawing.Size(36, 13);
            this.MagicLabel.TabIndex = 42;
            this.MagicLabel.Text = "Magic";
            // 
            // PrayerLabel
            // 
            this.PrayerLabel.AutoSize = true;
            this.PrayerLabel.Location = new System.Drawing.Point(719, 595);
            this.PrayerLabel.Name = "PrayerLabel";
            this.PrayerLabel.Size = new System.Drawing.Size(37, 13);
            this.PrayerLabel.TabIndex = 43;
            this.PrayerLabel.Text = "Prayer";
            // 
            // SaveEquipment
            // 
            this.SaveEquipment.Location = new System.Drawing.Point(3, 236);
            this.SaveEquipment.Name = "SaveEquipment";
            this.SaveEquipment.Size = new System.Drawing.Size(75, 23);
            this.SaveEquipment.TabIndex = 44;
            this.SaveEquipment.Text = "Save";
            this.SaveEquipment.UseVisualStyleBackColor = true;
            this.SaveEquipment.Click += new System.EventHandler(this.SaveEquipment_Click);
            // 
            // DownloadMonsters
            // 
            this.DownloadMonsters.Location = new System.Drawing.Point(12, 603);
            this.DownloadMonsters.Name = "DownloadMonsters";
            this.DownloadMonsters.Size = new System.Drawing.Size(179, 23);
            this.DownloadMonsters.TabIndex = 45;
            this.DownloadMonsters.Text = "Re-Download Monsters";
            this.DownloadMonsters.UseVisualStyleBackColor = true;
            this.DownloadMonsters.Click += new System.EventHandler(this.DownloadMonsters_Click);
            // 
            // DownloadEquipment
            // 
            this.DownloadEquipment.Location = new System.Drawing.Point(12, 574);
            this.DownloadEquipment.Name = "DownloadEquipment";
            this.DownloadEquipment.Size = new System.Drawing.Size(179, 23);
            this.DownloadEquipment.TabIndex = 46;
            this.DownloadEquipment.Text = "Re-Download Equipment";
            this.DownloadEquipment.UseVisualStyleBackColor = true;
            this.DownloadEquipment.Click += new System.EventHandler(this.DownloadEquipment_Click);
            // 
            // AddEquipment
            // 
            this.AddEquipment.Location = new System.Drawing.Point(130, 17);
            this.AddEquipment.Name = "AddEquipment";
            this.AddEquipment.Size = new System.Drawing.Size(61, 23);
            this.AddEquipment.TabIndex = 47;
            this.AddEquipment.Text = "Add";
            this.AddEquipment.UseVisualStyleBackColor = true;
            this.AddEquipment.Click += new System.EventHandler(this.AddEquipment_Click);
            // 
            // AddMonster
            // 
            this.AddMonster.Location = new System.Drawing.Point(130, 295);
            this.AddMonster.Name = "AddMonster";
            this.AddMonster.Size = new System.Drawing.Size(61, 23);
            this.AddMonster.TabIndex = 48;
            this.AddMonster.Text = "Add";
            this.AddMonster.UseVisualStyleBackColor = true;
            this.AddMonster.Click += new System.EventHandler(this.AddMonster_Click);
            // 
            // YourEquipmentLabel
            // 
            this.YourEquipmentLabel.AutoSize = true;
            this.YourEquipmentLabel.Location = new System.Drawing.Point(0, 0);
            this.YourEquipmentLabel.Name = "YourEquipmentLabel";
            this.YourEquipmentLabel.Size = new System.Drawing.Size(82, 13);
            this.YourEquipmentLabel.TabIndex = 49;
            this.YourEquipmentLabel.Text = "Your Equipment";
            // 
            // MonstersLabel
            // 
            this.MonstersLabel.AutoSize = true;
            this.MonstersLabel.Location = new System.Drawing.Point(0, 279);
            this.MonstersLabel.Name = "MonstersLabel";
            this.MonstersLabel.Size = new System.Drawing.Size(50, 13);
            this.MonstersLabel.TabIndex = 50;
            this.MonstersLabel.Text = "Monsters";
            // 
            // HeadLabel
            // 
            this.HeadLabel.AutoSize = true;
            this.HeadLabel.Location = new System.Drawing.Point(511, 38);
            this.HeadLabel.Name = "HeadLabel";
            this.HeadLabel.Size = new System.Drawing.Size(54, 13);
            this.HeadLabel.TabIndex = 51;
            this.HeadLabel.Text = "Headgear";
            // 
            // AmmoLabel
            // 
            this.AmmoLabel.AutoSize = true;
            this.AmmoLabel.Location = new System.Drawing.Point(719, 64);
            this.AmmoLabel.Name = "AmmoLabel";
            this.AmmoLabel.Size = new System.Drawing.Size(36, 13);
            this.AmmoLabel.TabIndex = 52;
            this.AmmoLabel.Text = "Ammo";
            // 
            // CapeLabel
            // 
            this.CapeLabel.AutoSize = true;
            this.CapeLabel.Location = new System.Drawing.Point(293, 64);
            this.CapeLabel.Name = "CapeLabel";
            this.CapeLabel.Size = new System.Drawing.Size(32, 13);
            this.CapeLabel.TabIndex = 53;
            this.CapeLabel.Text = "Cape";
            // 
            // BodyLabel
            // 
            this.BodyLabel.AutoSize = true;
            this.BodyLabel.Location = new System.Drawing.Point(511, 149);
            this.BodyLabel.Name = "BodyLabel";
            this.BodyLabel.Size = new System.Drawing.Size(31, 13);
            this.BodyLabel.TabIndex = 54;
            this.BodyLabel.Text = "Body";
            // 
            // WeaponLabel
            // 
            this.WeaponLabel.AutoSize = true;
            this.WeaponLabel.Location = new System.Drawing.Point(293, 175);
            this.WeaponLabel.Name = "WeaponLabel";
            this.WeaponLabel.Size = new System.Drawing.Size(48, 13);
            this.WeaponLabel.TabIndex = 55;
            this.WeaponLabel.Text = "Weapon";
            // 
            // ShieldLabel
            // 
            this.ShieldLabel.AutoSize = true;
            this.ShieldLabel.Location = new System.Drawing.Point(719, 175);
            this.ShieldLabel.Name = "ShieldLabel";
            this.ShieldLabel.Size = new System.Drawing.Size(45, 13);
            this.ShieldLabel.TabIndex = 56;
            this.ShieldLabel.Text = "Offhand";
            // 
            // LegsLabel
            // 
            this.LegsLabel.AutoSize = true;
            this.LegsLabel.Location = new System.Drawing.Point(511, 264);
            this.LegsLabel.Name = "LegsLabel";
            this.LegsLabel.Size = new System.Drawing.Size(30, 13);
            this.LegsLabel.TabIndex = 57;
            this.LegsLabel.Text = "Legs";
            // 
            // GlovesLabel
            // 
            this.GlovesLabel.AutoSize = true;
            this.GlovesLabel.Location = new System.Drawing.Point(293, 290);
            this.GlovesLabel.Name = "GlovesLabel";
            this.GlovesLabel.Size = new System.Drawing.Size(38, 13);
            this.GlovesLabel.TabIndex = 58;
            this.GlovesLabel.Text = "Hands";
            // 
            // NeckLabel
            // 
            this.NeckLabel.AutoSize = true;
            this.NeckLabel.Location = new System.Drawing.Point(719, 290);
            this.NeckLabel.Name = "NeckLabel";
            this.NeckLabel.Size = new System.Drawing.Size(33, 13);
            this.NeckLabel.TabIndex = 59;
            this.NeckLabel.Text = "Neck";
            // 
            // RingLabel
            // 
            this.RingLabel.AutoSize = true;
            this.RingLabel.Location = new System.Drawing.Point(293, 400);
            this.RingLabel.Name = "RingLabel";
            this.RingLabel.Size = new System.Drawing.Size(29, 13);
            this.RingLabel.TabIndex = 60;
            this.RingLabel.Text = "Ring";
            // 
            // BootsLabel
            // 
            this.BootsLabel.AutoSize = true;
            this.BootsLabel.Location = new System.Drawing.Point(511, 373);
            this.BootsLabel.Name = "BootsLabel";
            this.BootsLabel.Size = new System.Drawing.Size(28, 13);
            this.BootsLabel.TabIndex = 61;
            this.BootsLabel.Text = "Feet";
            // 
            // UpgradesLabel
            // 
            UpgradesLabel.AutoSize = true;
            UpgradesLabel.Location = new System.Drawing.Point(918, 189);
            UpgradesLabel.Name = "UpgradesLabel";
            UpgradesLabel.Size = new System.Drawing.Size(149, 13);
            UpgradesLabel.TabIndex = 62;
            UpgradesLabel.Text = "Equipment Upgrades (by cost)";
            // 
            // GearGuide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 638);
            this.Controls.Add(UpgradesLabel);
            this.Controls.Add(this.BootsLabel);
            this.Controls.Add(this.RingLabel);
            this.Controls.Add(this.NeckLabel);
            this.Controls.Add(this.GlovesLabel);
            this.Controls.Add(this.LegsLabel);
            this.Controls.Add(this.ShieldLabel);
            this.Controls.Add(this.WeaponLabel);
            this.Controls.Add(this.BodyLabel);
            this.Controls.Add(this.CapeLabel);
            this.Controls.Add(this.AmmoLabel);
            this.Controls.Add(this.HeadLabel);
            this.Controls.Add(this.MonstersLabel);
            this.Controls.Add(this.YourEquipmentLabel);
            this.Controls.Add(this.AddMonster);
            this.Controls.Add(this.AddEquipment);
            this.Controls.Add(this.DownloadEquipment);
            this.Controls.Add(this.DownloadMonsters);
            this.Controls.Add(this.SaveEquipment);
            this.Controls.Add(this.PrayerLabel);
            this.Controls.Add(this.MagicLabel);
            this.Controls.Add(this.RangedLabel);
            this.Controls.Add(this.DefenseLabel);
            this.Controls.Add(this.StrengthLabel);
            this.Controls.Add(this.AttackLabel);
            this.Controls.Add(this.HitpointsLabel);
            this.Controls.Add(this.HitpointsEntry);
            this.Controls.Add(this.AttackEntry);
            this.Controls.Add(this.PrayerEntry);
            this.Controls.Add(this.MagicEntry);
            this.Controls.Add(this.RangedEntry);
            this.Controls.Add(this.DefenseEntry);
            this.Controls.Add(this.StrengthEntry);
            this.Controls.Add(this.UpgradeTable);
            this.Controls.Add(this.GoldPerDpsValue);
            this.Controls.Add(this.GoldPerDps);
            this.Controls.Add(this.GoldCostValue);
            this.Controls.Add(this.GoldCost);
            this.Controls.Add(this.DpsValue);
            this.Controls.Add(this.Dps);
            this.Controls.Add(this.FindGearUpgrades);
            this.Controls.Add(this.FindOptimalGear);
            this.Controls.Add(this.EquipmentFileLoad);
            this.Controls.Add(this.MonsterLookup);
            this.Controls.Add(this.MonsterList);
            this.Controls.Add(this.RingSelection);
            this.Controls.Add(this.NeckSelection);
            this.Controls.Add(this.ShieldSelection);
            this.Controls.Add(this.GlovesSelection);
            this.Controls.Add(this.WeaponSelection);
            this.Controls.Add(this.BootsSelection);
            this.Controls.Add(this.LegsSelection);
            this.Controls.Add(this.BodySelection);
            this.Controls.Add(this.AmmoSelection);
            this.Controls.Add(this.CapeSelection);
            this.Controls.Add(this.HeadSelection);
            this.Controls.Add(this.EquipmentLookup);
            this.Controls.Add(this.PlayerEquipmentCollection);
            this.Name = "GearGuide";
            this.Text = "GearGuide";
            this.Load += new System.EventHandler(this.GearGuide_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UpgradeTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox PlayerEquipmentCollection;
        private System.Windows.Forms.ComboBox EquipmentLookup;
        private System.Windows.Forms.ComboBox HeadSelection;
        private System.Windows.Forms.ComboBox CapeSelection;
        private System.Windows.Forms.ComboBox AmmoSelection;
        private System.Windows.Forms.ComboBox BodySelection;
        private System.Windows.Forms.ComboBox LegsSelection;
        private System.Windows.Forms.ComboBox BootsSelection;
        private System.Windows.Forms.ComboBox WeaponSelection;
        private System.Windows.Forms.ComboBox GlovesSelection;
        private System.Windows.Forms.ComboBox ShieldSelection;
        private System.Windows.Forms.ComboBox NeckSelection;
        private System.Windows.Forms.ComboBox RingSelection;
        private System.Windows.Forms.ComboBox MonsterLookup;
        private System.Windows.Forms.ListBox MonsterList;
        private System.Windows.Forms.Button EquipmentFileLoad;
        private System.Windows.Forms.Button FindOptimalGear;
        private System.Windows.Forms.Button FindGearUpgrades;
        private System.Windows.Forms.Label Dps;
        private System.Windows.Forms.Label DpsValue;
        private System.Windows.Forms.Label GoldCost;
        private System.Windows.Forms.Label GoldCostValue;
        private System.Windows.Forms.Label GoldPerDps;
        private System.Windows.Forms.Label GoldPerDpsValue;
        private System.Windows.Forms.DataGridView UpgradeTable;
        private System.Windows.Forms.TextBox StrengthEntry;
        private System.Windows.Forms.TextBox DefenseEntry;
        private System.Windows.Forms.TextBox RangedEntry;
        private System.Windows.Forms.TextBox MagicEntry;
        private System.Windows.Forms.TextBox PrayerEntry;
        private System.Windows.Forms.TextBox AttackEntry;
        private System.Windows.Forms.TextBox HitpointsEntry;
        private System.Windows.Forms.Label HitpointsLabel;
        private System.Windows.Forms.Label AttackLabel;
        private System.Windows.Forms.Label StrengthLabel;
        private System.Windows.Forms.Label DefenseLabel;
        private System.Windows.Forms.Label RangedLabel;
        private System.Windows.Forms.Label MagicLabel;
        private System.Windows.Forms.Label PrayerLabel;
        private System.Windows.Forms.Button SaveEquipment;
        private System.Windows.Forms.Button DownloadMonsters;
        private System.Windows.Forms.Button DownloadEquipment;
        private System.Windows.Forms.Button AddEquipment;
        private System.Windows.Forms.Button AddMonster;
        private System.Windows.Forms.Label YourEquipmentLabel;
        private System.Windows.Forms.Label MonstersLabel;
        private System.Windows.Forms.Label HeadLabel;
        private System.Windows.Forms.Label AmmoLabel;
        private System.Windows.Forms.Label CapeLabel;
        private System.Windows.Forms.Label BodyLabel;
        private System.Windows.Forms.Label WeaponLabel;
        private System.Windows.Forms.Label ShieldLabel;
        private System.Windows.Forms.Label LegsLabel;
        private System.Windows.Forms.Label GlovesLabel;
        private System.Windows.Forms.Label NeckLabel;
        private System.Windows.Forms.Label RingLabel;
        private System.Windows.Forms.Label BootsLabel;
    }
}