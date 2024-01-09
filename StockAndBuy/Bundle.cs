using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockAndBuy
{
    public class Bundle
    {
        public string Name { get; set; }
        public int RequiredUnits { get; set; }
        public int TotalUnits { get; set; }
        public List<Bundle> Children = new List<Bundle>();
        internal bool IsLeaf()
        {
            return this.Children == null || this.Children.Count == 0;
        }
        public int DepthOfBundle(Bundle bundle, int depth)
        {
            // Base case 
            if (bundle == null)
                return 0;

            // Check for all children and find the maximum depth  
            foreach (Bundle node in bundle.Children)
            {
                depth++;
                if (!node.IsLeaf())
                    depth=Math.Max(depth, DepthOfBundle(node, depth));
            }

            return depth;
        }
    }
}
