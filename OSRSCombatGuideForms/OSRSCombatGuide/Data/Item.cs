using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRSCombatGuide.Server.Data
{
    [Serializable]
    public class Item
    {
        public static Dictionary<int, Item> IDTable { get; private set; } = new Dictionary<int, Item>();

        public string Name { get; private set; }
        public int Id { get; private set; }
        public string Examine { get; private set; }
        public CostInfo CostInfo { get; private set; }

        public override string ToString()
        {
            return Name;
        }

        public Item(string name, int id, string examine, CostInfo costInfo)
        {
            Name = name;
            Id = id;
            Examine = examine;
            CostInfo = costInfo;
            IDTable.Add(id, this);
        }
    }
    
    [Serializable]
    public class CostInfo
    {
        public bool Tradeable { get; private set; }
        public int HighAlch { get; private set; }
        public int GEPrice { get; private set; }
        public int HighestPrice => Tradeable && GEPrice > HighAlch ? GEPrice : HighAlch;

        public CostInfo(bool tradeable, int highAlch, int geprice)
        {
            Tradeable = tradeable;
            HighAlch = highAlch;
            GEPrice = geprice;
        }
    }
}
