using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using OSRSCombatGuide.Server.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace OSRSCombatGuide.Server.ApiConnection
{
    public static class ItemLoader
    {
        private const string AllEquipmentPath = @"C:\temp\AllEquipment.sav";

        public static bool LoadEquipmentFile()
        {
            if (File.Exists(AllEquipmentPath))
            {
                EquipmentCollection.LoadAllEquipment(AllEquipmentPath);
                return true;
            }
            return false;
        }

        public static void LoadEquipment(bool allowFileLoad = true)
        {
            if (allowFileLoad && LoadEquipmentFile())
            {
                return;
            }
            List<JsonEquipment> jsonEquipment = new List<JsonEquipment>();
            string url = "https://api.osrsbox.com/equipment";
            string parameterStub = "?page=";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Load equipment until pages run out
            int page = 1;
            while (true)
            {
                HttpResponseMessage response = client.GetAsync(parameterStub + page).Result;
                if (response.IsSuccessStatusCode)
                {
                    JsonEquipmentResponse data = response.Content.ReadAsAsync<JsonEquipmentResponse>().Result;
                    if (data._items.Count == 0)
                    {
                        break;
                    }
                    else
                    {
                        jsonEquipment.AddRange(data._items);
                        page++;
                    }
                }
                else
                {
                    break;
                }
            }
            //Parse equipment and fill out objects
            string geUrl = "https://services.runescape.com/m=itemdb_oldschool/api/catalogue/detail.json";
            HttpClient geClient = new HttpClient();
            geClient.BaseAddress = new Uri(geUrl);
            geClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            foreach (JsonEquipment json in jsonEquipment)
            {
                int gePrice = 0;
                if (json.tradeable_on_ge)
                {
                    string geParam = "?item=" + json.id;
                    HttpResponseMessage response = geClient.GetAsync(geParam).Result;
                    response.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    if (response.IsSuccessStatusCode)
                    {
                        JsonGEData data = response.Content.ReadAsAsync<JsonGEData>().Result;
                        if (data != null && data.current != null)
                        {
                            gePrice = data.current.price;
                        }
                    }
                }
                CostInfo costInfo = new CostInfo(json.tradeable_on_ge, json.highalch == null ? 0 : (int)json.highalch, gePrice);
                StatSet stats = new StatSet(
                    json.equipment.attack_stab, json.equipment.attack_slash, json.equipment.attack_crush, json.equipment.attack_magic, json.equipment.attack_ranged,
                    json.equipment.defence_stab, json.equipment.defence_slash, json.equipment.defence_crush, json.equipment.defence_magic, json.equipment.defence_ranged,
                    json.equipment.melee_strength, json.equipment.ranged_strength, json.equipment.magic_damage, json.equipment.prayer);
                if (json.weapon != null)
                {
                    try
                    {
                        List<CombatStyle> stances = json.weapon.stances.Select(a => CombatStyleFromJson(a)).ToList();
                        WeaponType type = WeaponType.Create(json.weapon.weapon_type, stances);
                        Weapon.CreateWeapon(json.name, json.id, json.examine, costInfo, stats, SlotFromJson(json.equipment.slot), null, json.weapon.attack_speed, type);
                    }
                    catch
                    {
                        continue;
                    }
                }
                else
                {
                    Equipment.CreateEquipment(json.name, json.id, json.examine, costInfo, stats, SlotFromJson(json.equipment.slot), null);
                }
            }
            EquipmentCollection.AllEquipment.Save(AllEquipmentPath);
        }

        public static void LoadMonsters(bool allowFileLoad = true)
        {
            if (allowFileLoad && LoadMonstersFile())
            {
                return;
            }
            List<JsonMonster> jsonMonsters = new List<JsonMonster>();
            string url = "https://api.osrsbox.com/monsters";
            string parameterStub = "?page=";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Load equipment until pages run out
            int page = 1;
            while (true)
            {
                HttpResponseMessage response = client.GetAsync(parameterStub + page).Result;
                if (response.IsSuccessStatusCode)
                {
                    JsonMonsterResponse data = response.Content.ReadAsAsync<JsonMonsterResponse>().Result;
                    if (data._items.Count == 0)
                    {
                        break;
                    }
                    else
                    {
                        jsonMonsters.AddRange(data._items);
                        page++;
                    }
                }
                else
                {
                    break;
                }
            }
            foreach (JsonMonster json in jsonMonsters)
            {
                if (json.hitpoints == null)
                {
                    int a = 5;
                }
                SkillSet skills = new SkillSet(json.attack_level.GetValueOrDefault(), json.strength_level.GetValueOrDefault(), json.defence_level.GetValueOrDefault(), json.ranged_level.GetValueOrDefault(), json.magic_level.GetValueOrDefault(), 0, json.hitpoints.GetValueOrDefault());
                StatSet stats = new StatSet(json.attack_bonus.GetValueOrDefault(), json.attack_bonus.GetValueOrDefault(), json.attack_bonus.GetValueOrDefault(), json.attack_magic.GetValueOrDefault(), json.attack_ranged.GetValueOrDefault(), 
                    json.defence_stab.GetValueOrDefault(), json.defence_slash.GetValueOrDefault(), json.defence_crush.GetValueOrDefault(), json.defence_magic.GetValueOrDefault(), json.defence_ranged.GetValueOrDefault(), 
                    json.strength_bonus.GetValueOrDefault(), json.ranged_bonus.GetValueOrDefault(), json.magic_bonus.GetValueOrDefault(), 0);
                Monster monster = new Monster(json.name, json.id, json.attack_speed.GetValueOrDefault(), skills, stats);
            }
            SaveMonsters();
        }

        private static bool LoadMonstersFile()
        {
            string monstersFile = @"C:\Temp\OSRSMonsters.sav";
            if (!File.Exists(monstersFile))
            {
                return false;
            }
            FileStream stream = new FileStream(monstersFile, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            List<Monster> monsterList = (List<Monster>)formatter.Deserialize(stream);
            stream.Close();
            Monster.AllMonsters = monsterList;
            foreach (Monster monster in monsterList)
            {
                Monster.MonsterLookup.Add(monster.Name, monster);
            }
            return true;
        }

        public static void SaveMonsters()
        {
            string monstersFile = @"C:\Temp\OSRSMonsters.sav";
            FileStream stream = new FileStream(monstersFile, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, Monster.AllMonsters);
            stream.Close();
        }

        private static EquipmentSlot SlotFromJson(string slot)
        {
            switch (slot)
            {
                case "ammo":
                    return EquipmentSlot.Ammo;
                case "body":
                    return EquipmentSlot.Body;
                case "cape":
                    return EquipmentSlot.Cape;
                case "feet":
                    return EquipmentSlot.Feet;
                case "hands":
                    return EquipmentSlot.Hands;
                case "head":
                    return EquipmentSlot.Head;
                case "legs":
                    return EquipmentSlot.Legs;
                case "neck":
                    return EquipmentSlot.Neck;
                case "ring":
                    return EquipmentSlot.Ring;
                case "shield":
                    return EquipmentSlot.Shield;
                case "2h":
                    return EquipmentSlot.TwoHanded;
                case "weapon":
                    return EquipmentSlot.Weapon;
                default:
                    throw new ArgumentException("Unexpected slot name.");
            }
        }

        private static CombatStyle CombatStyleFromJson(JsonWeaponStance stance)
        {
            AttackType attackType;
            switch (stance.attack_type)
            {
                case "stab":
                    attackType = AttackType.Stab;
                    break;
                case "slash":
                    attackType = AttackType.Slash;
                    break;
                case "crush":
                    attackType = AttackType.Crush;
                    break;
                default:
                    if (stance.experience == "ranged" || stance.experience == "ranged and defence")
                    {
                        attackType = AttackType.Ranged;
                    }
                    else if (stance.experience == "magic" || stance.experience == "magic and defence")
                    {
                        attackType = AttackType.Magic;
                    }
                    else
                    {
                        throw new ArgumentException("No valid attack type in stance.");
                    }
                    break;
            }
            AttackStyle attackStyle;
            switch (stance.attack_style)
            {
                case "accurate":
                    attackStyle = AttackStyle.Accurate;
                    break;
                case "aggressive":
                    attackStyle = AttackStyle.Aggressive;
                    break;
                case "controlled":
                    attackStyle = AttackStyle.Controlled;
                    break;
                case "defensive":
                    attackStyle = AttackStyle.Defensive;
                    break;
                case "magic":
                    attackStyle = AttackStyle.Magic;
                    break;
                default:
                    if (stance.combat_style == "accurate")
                    {
                        attackStyle = AttackStyle.Accurate;
                    }
                    else if (stance.combat_style == "rapid")
                    {
                        attackStyle = AttackStyle.Rapid;
                    }
                    else if (stance.combat_style == "longrange")
                    {
                        attackStyle = AttackStyle.Longrange;
                    }
                    else
                    {
                        throw new ArgumentException("No valid attack style in stance.");
                    }
                    break;
            }

            return new CombatStyle(stance.combat_style.Substring(0, 1).ToUpper() + stance.combat_style.Substring(1), attackType, attackStyle);
        }

        public class JsonEquipmentResponse
        {
            public List<JsonEquipment> _items { get; set; }
        }

        public class JsonEquipment
        {
            public int id { get; set; }
            public string name { get; set; }
            public string examine { get; set; }
            public bool tradeable_on_ge { get; set; }
            public int? highalch { get; set; }
            public JsonEquipmentStats equipment { get; set; }
            public JsonWeaponStats weapon { get; set; }
        }

        public class JsonEquipmentStats
        {
            public int attack_stab { get; set; }
            public int attack_slash {get; set;}
            public int attack_crush {get; set;}
            public int attack_magic {get; set;}
            public int attack_ranged {get; set;}
            public int defence_stab {get; set;}
            public int defence_slash {get; set;}
            public int defence_crush {get; set;}
            public int defence_magic {get; set;}
            public int defence_ranged {get; set;}
            public int melee_strength {get; set;}
            public int ranged_strength {get; set;}
            public int magic_damage {get; set;}
            public int prayer {get; set;}
            public string slot { get; set; }
        }

        public class JsonWeaponStats
        {
            public int attack_speed { get; set; }
            public string weapon_type { get; set; }
            public List<JsonWeaponStance> stances { get; set; }
        }

        public class JsonWeaponStance
        {
            public string combat_style { get; set; }
            public string attack_type { get; set; }
            public string attack_style { get; set; }
            public string experience { get; set; }
        }

        public class JsonGEData
        {
            public JsonGECurrentPrice current { get; set; }
        }

        public class JsonGECurrentPrice
        {
            public int price { get; set; }
        }

        public class JsonMonsterResponse
        {
            public List<JsonMonster> _items { get; set; }
        }

        public class JsonMonster
        {
            public int id { get; set; }
            public string name { get; set; }
            public int? attack_speed { get; set; }
            public int? hitpoints { get; set; }
            public int? attack_level { get; set; }
            public int? strength_level { get; set; }
            public int? defence_level { get; set; }
            public int? magic_level { get; set; }
            public int? ranged_level { get; set; }
            public int? attack_bonus { get; set; }
            public int? strength_bonus { get; set; }
            public int? attack_magic { get; set; }
            public int? magic_bonus { get; set; }
            public int? attack_ranged { get; set; }
            public int? ranged_bonus { get; set; }
            public int? defence_stab { get; set; }
            public int? defence_slash { get; set; }
            public int? defence_crush { get; set; }
            public int? defence_magic { get; set; }
            public int? defence_ranged { get; set; }
        }
    }
}
