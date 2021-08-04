using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRSCombatGuide.Server.Data
{
    public static class EquipmentOffList
    {
        private static HashSet<string> _OffList { get; set; }

        public static bool IsOffListed(string name) => _OffList.Contains(name);

        static EquipmentOffList()
        {
            _OffList = new HashSet<string>();
            _OffList.Add("Statius's full helm");
            _OffList.Add("Statius's platebody");
            _OffList.Add("Statius's platelegs");
            _OffList.Add("Statius's warhammer");
            _OffList.Add("Vesta's chainbody");
            _OffList.Add("Vesta's plateskirt");
            _OffList.Add("Vesta's longsword");
            _OffList.Add("Vesta's blighted longsword");
            _OffList.Add("Vesta's longsword (inactive)");
            _OffList.Add("Vesta's spear");
            _OffList.Add("Zuriel's hood");
            _OffList.Add("Zuriel's robe bottom");
            _OffList.Add("Zuriel's robe top");
            _OffList.Add("Zuriel's staff");
            _OffList.Add("Morrigan's coif");
            _OffList.Add("Morrigan's leather body");
            _OffList.Add("Morrigan's leather chaps");
            _OffList.Add("Morrigan's javelin");
            _OffList.Add("Morrigan's throwing axe");
            _OffList.Add("Zuriel's hood");_OffList.Add("Zuriel's hood");
            _OffList.Add("Crystal helm (perfected)");
            _OffList.Add("Crystal helm (attuned)");
            _OffList.Add("Crystal helm (basic)");
            _OffList.Add("Crystal body (perfected)");
            _OffList.Add("Crystal body (attuned)");
            _OffList.Add("Crystal body (basic)");
            _OffList.Add("Crystal legs (perfected)");
            _OffList.Add("Crystal legs (attuned)");
            _OffList.Add("Crystal legs (basic)");
            _OffList.Add("Crystal halberd (perfected)");
            _OffList.Add("Crystal halberd (attuned)");
            _OffList.Add("Crystal halberd (basic)");
            _OffList.Add("Crystal staff (perfected)");
            _OffList.Add("Crystal staff (attuned)");
            _OffList.Add("Crystal staff (basic)");
            _OffList.Add("Crystal bow (perfected)");
            _OffList.Add("Crystal bow (attuned)");
            _OffList.Add("Crystal bow (basic)");
            _OffList.Add("Corrupted helm (perfected)");
            _OffList.Add("Corrupted helm (attuned)");
            _OffList.Add("Corrupted helm (basic)");
            _OffList.Add("Corrupted body (perfected)");
            _OffList.Add("Corrupted body (attuned)");
            _OffList.Add("Corrupted body (basic)");
            _OffList.Add("Corrupted legs (perfected)");
            _OffList.Add("Corrupted legs (attuned)");
            _OffList.Add("Corrupted legs (basic)");
            _OffList.Add("Corrupted halberd (perfected)");
            _OffList.Add("Corrupted halberd (attuned)");
            _OffList.Add("Corrupted halberd (basic)");
            _OffList.Add("Corrupted staff (perfected)");
            _OffList.Add("Corrupted staff (attuned)");
            _OffList.Add("Corrupted staff (basic)");
            _OffList.Add("Corrupted bow (perfected)");
            _OffList.Add("Corrupted bow (attuned)");
            _OffList.Add("Corrupted bow (basic)");
        }
    }
}
