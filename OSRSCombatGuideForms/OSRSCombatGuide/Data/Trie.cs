using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSCombatGuide.Data
{
    [Serializable]
    public class Trie<T>
    {
        private Node Root = new Node("", null);

        public void Add(string identifier, T item)
        {
            if (identifier == "")
            {
                return;
            }
            Node curNode = Root;
            for (int i = 0; i < identifier.Length; i++)
            {
                if (!curNode.Continuations.ContainsKey(identifier[i]))
                {
                    curNode.Continuations.Add(identifier[i], new Node(identifier.Substring(0, i + 1), curNode));
                }
                curNode = curNode.Continuations[identifier[i]];
            }
            curNode.Terminations.Add(item);
        }

        public List<T> MatchingItems(string identifier, int maxItems = 100)
        {
            List<T> ret = new List<T>();
            Node curNode = Root;
            for (int i = 0; i < identifier.Length; i++)
            {
                if (!curNode.Continuations.ContainsKey(identifier[i]))
                {
                    return ret;
                }
                curNode = curNode.Continuations[identifier[i]];
            }
            FindSubItems(curNode, ret, ref maxItems);
            return ret;
        }

        private void FindSubItems(Node curNode, List<T> items, ref int remainingItems)
        {
            if (remainingItems == 0)
            {
                return;
            }
            for (int i = 0; i < curNode.Terminations.Count; i++)
            {
                if (remainingItems == 0)
                {
                    return;
                }
                items.Add(curNode.Terminations[i]);
                remainingItems--;
            }
            foreach (char key in curNode.Continuations.Keys)
            {
                FindSubItems(curNode.Continuations[key], items, ref remainingItems);
            }
        }

        [Serializable]
        private class Node
        {
            public Dictionary<char, Node> Continuations = new Dictionary<char, Node>();

            public List<T> Terminations = new List<T>();

            public string WordToDate { get; private set; }

            public Node Parent { get; private set; }

            public Node(string wordToDate, Node parent)
            {
                WordToDate = wordToDate;
                Parent = parent;
            }
        }
    }
}
